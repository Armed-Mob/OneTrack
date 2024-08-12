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
                    case "Series":
                        details.Series = result.Value; break;
                    case "Drive Type":
                        details.DriveType = result.Value; break;
                    case "Engine Model":
                        details.EngineModel = result.Value; break;
                    case "Cab Type":
                        details.CabType = result.Value; break;
                    case "Turbo":
                        details.Turbo = result.Value; break;
                    case "Fuel Type - Primary":
                        details.FuelTypePrimary = result.Value; break;
                    case "Displacement (L)":
                        details.DisplacementL = result.Value; break;
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
        public string Doors { get; set; } = string.Empty;
        public string Gvwr { get; set; } = string.Empty;
        public int? ColorId { get; set; }
        public string Series { get; set; } = string.Empty;
        public string DriveType { get; set; } = string.Empty;
        public string EngineModel { get; set; } = string.Empty;
        public string Turbo { get; set; } = string.Empty;
        public string CabType { get; set; } = string.Empty;
        public string FuelTypePrimary { get; set; } = string.Empty;
        public string DisplacementL { get; set; } = string.Empty;
    }
}
