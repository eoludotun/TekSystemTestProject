using NUnit.Framework;
using RestSharp;
using System;
using System.Configuration;
using TechTalk.SpecFlow;
using TekSystemTestProject.TestHelperFolder;

namespace TekSystemTestProject
{
    [Binding]
    public class PositiveAndNegativeTestSteps : BaseClass_Utility
    {
        private static RestClient feedClient = new RestClient(ConfigurationManager.AppSettings.Get("API"));
        private static IRestResponse response { get; set; }
        private static IRestResponse invalidEndpoint { get; set; }
        private static RestClient feedInvalidClient { get; set; }

        [When(@"User make a Valid GET request to API Endpoint")]
        public void WhenUserMakeAValidGETRequestToAPIEndpoint()
        {
            var requestClient = new RestRequest("USA/all", Method.GET);
            response = feedClient.Execute(requestClient) as RestResponse;

        }
        
        [Then(@"Validate the response\(s\) code are (.*)")]
        public void ThenValidateTheResponseSCodeAre(int responseCode)
        {
            Boolean validateResponseCode = false;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Expected responseCode: " + responseCode + " Actual responseCode : " + response.StatusDescription);
                System.Console.WriteLine(response.StatusCode);
                Logger().Info(response);
                validateResponseCode = true;
                Assert.IsTrue(validateResponseCode);
            }
            else
            {
                // GET raw content as string
                Console.WriteLine(response.StatusDescription + " " + response.ResponseUri + " " + response.StatusCode);
                validateResponseCode = false;
                Assert.IsTrue(validateResponseCode);
            }
        }

        [Given(@"An API containing invalid endpoint")]
        public void GivenAnAPIContainingInvalidEndpoint()
        {

            feedInvalidClient = new RestClient(ConfigurationManager.AppSettings.Get("API"));
           
        }

        [When(@"User make an invalid GET request to API Endpoint")]
        public void WhenUserMakeAnInvalidGETRequestToAPIEndpoint()
        {
            var requestinvalidClient = new RestRequest("USA/badResquest", Method.GET);
            response = feedInvalidClient.Execute(requestinvalidClient) as RestResponse;

        }
    }
}
