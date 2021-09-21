using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Innovator.Client;
using Microsoft.AspNetCore.Components;

namespace TelerikBlazorApp1.Services
{
  public class ArasConnectionService
  {
    private readonly HttpClient httpClient;

    /// <summary>
    /// The connection to the Aras server.
    /// </summary>
    public IRemoteConnection ArasConnection { get; set; }

    /// <summary>
    /// Id of the user that is logged in.
    /// </summary>
    public string UserId { get; private set; }

    public ArasConnectionService() : this(new HttpClient()) { }

    public ArasConnectionService(HttpClient client)
    {
      httpClient = client;
    }

    /// <summary>
    /// Login to Aras.
    /// </summary>
    /// <param name="username">UserName</param>
    /// <param name="password">Password</param>
    /// <returns></returns>
    public async Task<bool> Login(string username, string password)
    {
      bool loginSuccess = false;

      // First get the AuthToken (arasUserName and arasPassword) from Lumen //

      string authInfo = username + ":" + password;
      authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));

      //Url for the request is directly to the lumen endpoint that returns aras login information. This is needed to get around the MD5 hash problems.
      HttpRequestMessage authRequest = new HttpRequestMessage(HttpMethod.Get, "https://lumentest.gentex.com/GetAuthToken?db={DEV}");
      //Headers to help bypass CORS policy, as well as follow the redirects lumen does
      authRequest.Headers.Add("X-MS-Proxy", "AzureAD-Application-Proxy");
      //authRequest.SetBrowserRequestOption("Set-Cookie", "SameSite=None; Secure");
      //authRequest.SetBrowserRequestOption("redirect", "follow");
      //authRequest.SetBrowserRequestMode(BrowserRequestMode.Cors);
      //authRequest.SetBrowserRequestCache(BrowserRequestCache.NoCache);
      authRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authInfo);

      HttpResponseMessage response = await httpClient.SendAsync(authRequest, HttpCompletionOption.ResponseContentRead);
      if (response.IsSuccessStatusCode)
      {
        string xmlAuthToken = await response.Content.ReadAsStringAsync();
        var xml = new XmlDocument();
        xml.LoadXml(xmlAuthToken);

        string arasUser = xml.SelectSingleNode("Result/user")?.InnerText;
        string arasPass = xml.SelectSingleNode("Result/password")?.InnerText;

        // Log into Aras
        if (!string.IsNullOrEmpty(arasUser) && !string.IsNullOrEmpty(arasPass))
        {
          httpClient.CancelPendingRequests();
          ConnectionPreferences connPrefs = new ConnectionPreferences();
          connPrefs.Url = "http://zvm-devplm.gentex.com/innovator11sp12";
          var connection = await Factory.GetConnection(connPrefs, true);

          var userLogin = await connection.Login(new ExplicitHashCredentials("DEV", arasUser, arasPass), true);
          UserId = userLogin;
          ArasConnection = connection;
          loginSuccess = true;
        }
      }

      return loginSuccess;
    }
  }
}
