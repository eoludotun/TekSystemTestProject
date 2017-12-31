using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TekSystemTestProject.TestHelperFolder
{
    public class RestCall
    {


        public string requestURL(string url)
        {
            var feedClient = new RestClient(url);
            var requestClient = new RestRequest("USA/all",Method.GET);
            IRestResponse response = feedClient.Execute(requestClient) as RestResponse;

            return response.Content;

        }


        public ResponseStatus statusCode(string url)
        {
            var feedClient = new RestClient(url);
            var requestClient = new RestRequest(Method.GET);
            //var jsonResponse = feedClient.Execute(requestClient);
            IRestResponse response = feedClient.Execute(requestClient) as RestResponse;
            if ((response.StatusCode == HttpStatusCode.OK))
            {
                Console.Write(response.StatusCode.ToString());
                return ResponseStatus.Completed;
            }
            return response.ResponseStatus;
        }

        public void AskStatusCode(int code)
        {
            switch (code)
            {
                case 404:
                    // Do an action
                    break;

                case 405:
                    // Do an action
                    break;
            }
        }

        public string ReadTextFile(string filePath)
        {
            string result = string.Empty;
            try
            {
                using (StreamReader sr = new StreamReader(System.IO.File.Open(filePath, FileMode.Open)))
                {
                    result = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                Console.Write("Cannot open file {0}. \nError:{1}", filePath, ex.Message);
            }
            Console.Write("File content:\n{0}", result);
            return result;
        }

        public static Dictionary<string, object> CreateDictionary(JObject input)
        {

            IDictionary<string, JToken> temp = input as IDictionary<string, JToken>;
            Dictionary<string, object> result = new Dictionary<string, object>();
            foreach (var item in temp)
            {
                result.Add(item.Key, item.Value);
            }
            return result;
        }
    }
}
        


