using LagoVista.PoolController.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace LagoVista.PoolController.Services
{
    public class PoolService
    {
        private async Task<ParticleResponse> RequestVariableAsync(String variable)
        {

            var client = new HttpClient();
            var url = String.Format($"https://api.particle.io/v1/devices/{Settings.DeviceId}/{variable}");//?access_token={Settings.AuthString}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AuthString);

            var json = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<ParticleResponse>(json);

        }

        public async Task<string> GetTemperatureAsync()
        {
            var result = await RequestVariableAsync("tempIn");
            return result.Result;
        }

        public async Task<string> GetModeAsync()
        {
            var result = await RequestVariableAsync("mode");
            return result.Result;
        }

        public async Task<string> GetSourceAsync()
        {
            var result = await RequestVariableAsync("source");
            return result.Result;
        }

        public async Task<string> GetOutputAsync()
        {
            var result = await RequestVariableAsync("output");
            return result.Result;
        }

        public async Task<string> GetSpaModeAsync()
        {
            var result = await RequestVariableAsync("spamode");
            return result.Result;
        }

        public async Task<string> GetLowerPressureAsync()
        {
            var result = await RequestVariableAsync("lp");
            return result.Result;
        }

        public async Task<string> GetFlowAsync()
        {
            var result = await RequestVariableAsync("flow");
            return result.Result;
        }

        public async Task<string> GetHighPressureAsync()
        {
            var result = await RequestVariableAsync("hp");
            return result.Result;
        }

        public async Task<string> GetSpaSetpointAsync()
        {
            var result = await RequestVariableAsync("spasetpoint");
            return result.Result;
        }

        public async Task<string> GetPoolSetpointAsync()
        {
            var result = await RequestVariableAsync("poolsetpoint");
            return result.Result;
        }

    }
}
