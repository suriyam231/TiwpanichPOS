using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using ProjectManagementService.Models;
using ProjectManagementService.Interface;
using ProjectManagementService.DTOs;

namespace ProjectManagementService.Service
{
    public class ProjectRunningNoService : IRunningNoService
    {
        private readonly SRM_DEVContext Context;
        public ProjectRunningNoService(SRM_DEVContext context)
        {
            Context = context;
        }
        public async Task<RunningNoDTO> GenerateRunningNo(string param)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(string.Format("http://localhost:2002/api/RunningNo/SystemCode?runningCode={0}&parameter={1}", "03", param));
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