using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using TaskManagement.Models;
using TaskManagement.DTOs;
using TaskManagement.Interface;

namespace TaskManagement.Services
{
    public class TaskRunningNoService : ITaskRunningNo
    {
        private readonly SRM_DEVContext Context;
        public TaskRunningNoService(SRM_DEVContext context)
        {
            Context = context;
        }
        public async Task<RunningNoDTO> GenerateRunningNo()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(string.Format("http://localhost:2002/api/RunningNo/SystemCode?runningCode={0}&parameter={1}", "02", "TM"));
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<RunningNoDTO>(responseBody);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
