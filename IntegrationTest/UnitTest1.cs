using MAIN;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using DATA.Enums;
using MAIN.Dtos.Authentications;
using MAIN.Dtos.Results;
using System.Net.Http.Json;

public class HomeTest
{
    private readonly TestServer _server;
    private readonly HttpClient _client;
    private const string API_PATH = "api/Authentications/Register";

    public HomeTest()
    {
        _server = new TestServer(WebHost.CreateDefaultBuilder()
           .UseStartup<Startup>()
           .UseEnvironment("Test"));
        _client = _server.CreateClient();
    }

    internal void Dispose()
    {
        _client.Dispose();
        _server.Dispose();
    }

    [Fact]
    public async Task Index_Get_ReturnsIndexHtmlPage()
    {
        // Act
        var response = await _client.GetAsync("/WeatherForecast");
        // Assert
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task FilterByDateRange()
    {
        var registerBody = new UserRegisterRequest
        {
            Name = "test",
            Password = "password",
            Email = "thas@gmail.com"
        };

        var response = await _client.PostAsJsonAsync(API_PATH, registerBody);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadAsAsync<ActionResultDto<UserRegisterResponse>>();

        Assert.Equal(SUCCESS_MESSAGE.CREATE_USER_SUCCESS, responseData.Data.Message);
    }
}
