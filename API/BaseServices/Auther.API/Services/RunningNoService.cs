using Auther.API.DTOs;
using Auther.API.Interfaces;
using Auther.API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auther.API.Services
{
    public class RunningNoService : IRunningNoService
    {
        private readonly ISRMContext Context;
        public RunningNoService(ISRMContext context)
        {
            Context = context;
        }
        public async Task<RunningNoDTO> GenerateRunningNo()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string Code = RunningNo.UserSystemCode;
                    string ParamUser = RunningNo.paramUser1;
                    HttpResponseMessage response = await client.GetAsync(string.Format("http://localhost:2002/api/RunningNo/SystemCode?runningCode={0}&parameter={1}",Code,ParamUser));
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
