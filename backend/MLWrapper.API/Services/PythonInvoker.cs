using System.Text;
using System.Text.Json;
using MLWrapper.API.Models;

public class PythonInvoker
{
    private readonly HttpClient _httpClient;

    public PythonInvoker(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> InvokePredictionAsync(InputModel input)
    {
        var json = JsonSerializer.Serialize(input);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("http://localhost:8000/predict", content);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}