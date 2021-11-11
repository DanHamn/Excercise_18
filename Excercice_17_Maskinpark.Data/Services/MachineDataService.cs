using Excercice_17_Maskinpark.Core.Entities;
using Excercice_17_Maskinpark.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Excercice_17_Maskinpark.Data.Services
{
    public class MachineDataService : IMachineDataService
    {
        private readonly HttpClient _httpClient;

        public MachineDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Machine> AddMachine(Machine machine)
        {
            var machineJson = new StringContent(JsonSerializer.Serialize(machine), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Machines", machineJson);
            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Machine>(await response.Content.ReadAsStreamAsync());
            }
            return null;
        }

        public async Task DeleteMachine(Guid id)
        {
            await _httpClient.DeleteAsync($"api/Machines/{id}");
        }

        public async Task<IEnumerable<Machine>> GetAllMachines()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Machine>>
                (await _httpClient.GetStreamAsync($"api/Machines"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Machine> GetMachine(Guid id)
        {
            return await JsonSerializer.DeserializeAsync<Machine>
                (await _httpClient.GetStreamAsync($"api/Machines/{id}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateMachine(string machineId, Machine machine)
        {
            var machineJson = new StringContent(JsonSerializer.Serialize(machine), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync($"api/Machines/{machineId}", machineJson);
        }
    }
}
