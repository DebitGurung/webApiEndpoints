using System.Net.Http.Json;
using webApiEndpoints.Model;

public class ApiHandlerService
{
    private readonly HttpClient _http;

    public List<Subject> Subjects { get; private set; } = new();

    public ApiHandlerService(HttpClient http)
    {
        _http = http;
    }

    public async Task LoadDatabaseDetailsThroughAPICall()
    {
        Subjects = await _http.GetFromJsonAsync<List<Subject>>("api/subjects") ?? new();
    }

    public async Task AddSubject(Subject subject)
    {
        var subjectDetails = new
        {
            subject.Name
        };

        var response = await _http.PostAsJsonAsync("api/subjects/", subjectDetails);
    }
}