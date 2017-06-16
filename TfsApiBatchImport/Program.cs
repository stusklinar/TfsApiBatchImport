using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using WorkItemMigration;
using WorkItemMigration.Extensions;

namespace TfsApiBatchImport
{


    class Program
    {
        static void Main(string[] args)
        {
            var runner = new Runner();

            runner.Run();
        }
    }

    public class Runner
    {
        private BatchRequest CreateWorkItemBatchRequest(WorkItem wi, Dictionary<string, string> headers)
        {
            return new BatchRequest
            {
                method = "PATCH",
                uri = '/' + wi.GetTeamProject() + $"/_apis/wit/workitems/${wi.GetWorkItemType()}?api-version=2.2",
                headers = headers,
                body = wi.Fields.Select(x => new { op = "add", path = x.Key, value = x.Value }).ToArray()
            };
        }

        public void Run()
        {
            string connectionUrl = "URL";
            string projectName = "Development";
            string personalAccessToken = "KEY";
            string basicAuthHeaderValue = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "pat", personalAccessToken)));

            List<BatchRequest> batchRequests = new List<BatchRequest>();
            Dictionary<string, string> headers = new Dictionary<string, string>() {
                { "Content-Type", "application/json-patch+json" }
            };

            for (int i = -1; i > -200; i--)
            {
                batchRequests.Add(CreateWorkItemBatchRequest(new WorkItem()
                {
                    Fields = new Dictionary<string, object>()
                    {
                        {Constants.Paths.Title,"New Title from batcher" },
                        {Constants.Paths.WorkItemType,"Bug" },
                        {Constants.Paths.TeamProject,"Development" },
                        {"/id",i.ToString() }
                    },
                    Id = i * -1

                }, headers));
            }

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", basicAuthHeaderValue);

                var batchRequest = new StringContent(JsonConvert.SerializeObject(batchRequests), Encoding.UTF8, "application/json");
                var method = new HttpMethod("POST");

                // send the request
                var request = new HttpRequestMessage(method, connectionUrl + "/_apis/wit/$batch?api-version=2.2") { Content = batchRequest };
                var response = client.SendAsync(request).Result;

                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = response.Content.ReadAsStringAsync();
                    WorkItemBatchPostResponse batchResponse = response.Content.ReadAsAsync<WorkItemBatchPostResponse>().Result;

                }
                else
                {
                    // not successful
                }
            }
        }
    }
}
