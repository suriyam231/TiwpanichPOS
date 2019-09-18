using Dashboard.API.Models;
using Dashboard.DTOs;
using Dashboard.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Dashboard.Service
{
    public class RunningNoService : IRunningNo
    {
        private readonly SRM_DEVContext Context;
        public RunningNoService(SRM_DEVContext context)
        {
            Context = context;
        }
        public async Task<RunningNoDTO> GenerateRunningNo()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(string.Format("", "04", "RP"));
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<RunningNoDTO>(responseBody);
                }
                catch (HttpRequestException ex)
                {
                    throw ex;
                }
            }
        }
    }
}
