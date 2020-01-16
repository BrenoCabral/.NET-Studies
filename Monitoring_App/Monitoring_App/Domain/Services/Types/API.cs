using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Monitoring_App.Domain.States;
using Newtonsoft.Json.Linq;

namespace Monitoring_App.Domain.Services.Types
{
    
    public class API : IServiceType
    {
        string _communcationEndPoit;
        string _versionEndpoint;
        static HttpClient client = new HttpClient();
        public IState GetState(string communicationEndpoint, string versionEndpoint)
        {
            _communcationEndPoit = communicationEndpoint;
            _versionEndpoint = versionEndpoint;

            return new State()
            {
                IsOnline = IsOnline(),
                Version = GetVersion()
            };
        }

        public bool IsOnline()
        {
            try
            {
                // Creates an HttpWebRequest for the specified URL. 
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(_communcationEndPoit);
                // Sends the HttpWebRequest and waits for a response.
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                if (myHttpWebResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine("\r\nResponse Status Code is OK and StatusDescription is: {0}",
                                            myHttpWebResponse.StatusDescription);
                    // Releases the resources of the response.
                    myHttpWebResponse.Close();
                    return false;
                }
                return true;
            }
            catch (WebException e)
            {
                Console.WriteLine("\r\nWebException Raised. The following error occurred : {0}", e.Status);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nThe following Exception was raised : {0}", e.Message);
                return false;
            }
        }

        public string GetVersion()
        {
            try
            {
                HttpResponseMessage response = client.GetAsync(_versionEndpoint).Result;
                string responseString=String.Empty;
                string version = "Version not found";
                // Sends the HttpWebRequest and waits for a response.
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    JObject json = JObject.Parse(responseString);
                    version = json.GetValue("data")[0].ToString();
                }

                return version;
            }
            catch (WebException e)
            {
                Console.WriteLine("\r\nWebException Raised. The following error occurred : {0}", e.Status);
                return "Version not found. There is a problem in the endpoint";
            }
            catch (Exception e)
            {
                Console.WriteLine("\nThe following Exception was raised : {0}", e.Message);
                return "Version not found. There is a problem in the endpoint";
            }
        }

    }
}
