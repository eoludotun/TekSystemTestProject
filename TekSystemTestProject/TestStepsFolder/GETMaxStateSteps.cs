

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TechTalk.SpecFlow;
using TekSystemTestProject.TestHelperFolder;


namespace TekSystemTestProject.TestStepsFolder
{
    [Binding]
    public class GETMaxStateSteps : BaseClass_Utility
    {
        RestCall restOBJ = new RestCall();
        private static int backToDigit { get; set; }
        private static string stateName { get; set; }
        private static string endpoint { get; set; }

        System.Collections.ArrayList maxStates = new System.Collections.ArrayList();
        List<string> nameState = new List<string>();

        [Given(@"An Endpoint containing USA states")]
        public void GivenAnEndpointContainingUSAStates()
        {
            endpoint = System.Configuration.ConfigurationManager.AppSettings.Get("API");
        }
        
        [When(@"User make a GET API to USA states Endpoint")]
        public void WhenUserMakeAGETAPIToUSAStatesEndpoint()
        {

            //Make API call        
            var response = restOBJ.requestURL(endpoint);

            //Parse JSON results 
            JObject items = JObject.Parse(response);
            IList<JToken> results = items["RestResponse"]["result"].ToList();

            foreach (JToken result in results)
            {
                var resu = result["area"];
                var states = result["name"];

                //Extract only digits from response
                Regex digitsOnly = new Regex(@"[^\d]");
                var statesValue = digitsOnly.Replace(resu.ToString(), "");
                stateName = Convert.ToString(states);
                backToDigit = Convert.ToInt32(statesValue);
                nameState.Add(stateName);
                maxStates.Add(backToDigit);

            }
        }

        [Then(@"Validate the max state in the result")]

        public void ThenValidateTheMaxStateInTheResult()
        {
            GetMaxStates(maxStates.OfType<Int32>().ToArray());
        }
    }
}
