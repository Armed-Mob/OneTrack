using System.Net.Http.Json;

namespace OT.Blazor.Services
{
    public class VinLookupService
    {
        private readonly HttpClient _httpClient;

        public VinLookupService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<VehicleDetails> GetVehicleDetailsByVin(string vin, int? year = null)
        {
            var url = $"https://vpic.nhtsa.dot.gov/api/vehicles/decodevin/{vin}?format=json";
            if (year.HasValue)
            {
                url += $"&modelyear={year.Value}";
            }
            var response = await _httpClient.GetFromJsonAsync<VehicleApiResponse>(url);
            return response?.Results?.ToVehicleDetails();
        }
    }

    public class VehicleApiResponse
    {
        public List<VinResult> Results { get; set; }
    }

    public class VinResult
    {
        public string Variable { get; set; }
        public string Value { get; set; }
    }

    public static class Extensions
    {
        public static VehicleDetails ToVehicleDetails(this List<VinResult> results)
        {
            var details = new VehicleDetails();
            results.ForEach(result =>
            {
                switch (result.Variable)
                {
                    case "Make":
                        details.Make = result.Value; break;
                    case "Model":
                        details.Model = result.Value; break;
                    case "Model Year":
                        details.Year = result.Value; break;
                    case "Trim":
                        details.Trim = result.Value; break;
                    case "Doors":
                        details.Doors = result.Value; break;
                    case "Gross Vehicle Weight Rating From":
                        details.Gvwr = result.Value; break;
                }
            });

            return details;
        }
    }

    public class VehicleDetails
    {
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string Trim { get; set; } = string.Empty;
        public string Doors { get; set; }
        public string Gvwr { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
    }
}
