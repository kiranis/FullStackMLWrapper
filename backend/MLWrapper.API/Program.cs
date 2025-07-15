
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
var app = builder.Build();

app.MapGet("/", () => "ML Wrapper API is running");

app.MapPost("/predict", async (HttpClient http, SampleInput input) =>
{
    var response = await http.PostAsJsonAsync("http://ml-service:8000/predict", input);
    return await response.Content.ReadFromJsonAsync<PredictionResult>();
});

app.Run();

record SampleInput(string Feature1, float Feature2);
record PredictionResult(string Label, float Confidence);