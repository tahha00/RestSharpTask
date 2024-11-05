using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace RestSharpProject.StepDefinitions
{
    [Binding]
    public class Product_Steps
    {
        private readonly ScenarioContext _scenarioContext;
        RestClient _client;
        RestResponse _response;

        public Product_Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I get all the products")]
        public void WhenIGetAllTheProducts()
        {
            _client = new RestClient("http://localhost:2002/api/");
            RestRequest request = new RestRequest("products", Method.Get) { RequestFormat = DataFormat.Json };
            _response = _client.Execute(request);
        }

        [Then(@"I get a response code '(.*)'")]
        public void ThenIGetAResponseCode(int responseCode)
        {
            int status = (int)_response.StatusCode;
            Assert.That(status, Is.EqualTo(responseCode), "Status codes do not match");
        }
    }
}


