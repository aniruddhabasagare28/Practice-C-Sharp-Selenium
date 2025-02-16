using RestSharp;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using ApiAutomationFramework.Models;

public class UserTests
{
    private readonly ApiClient _apiClient;

    public UserTests()
    {
        _apiClient = new ApiClient("https://reqres.in/api");  // Dummy API
    }

    [Test]
    public async Task Test_GetUser()
    {
        var request = new RequestBuilder("/users/2", Method.Get).Build();
        var response = await _apiClient.ExecuteRequest(request);

        NUnit.Framework.Assert.AreEqual(200, (int)response.StatusCode);
        Console.WriteLine(response.Content);
    }

    [Test]
    public async Task Test_CreateUser()
    {
        var user = new User { Name = "John Doe", Job = "Developer" };

        var request = new RequestBuilder("/users", Method.Post)
                        .AddJsonBody(user)
                        .Build();

        var response = await _apiClient.ExecuteRequest(request);

        NUnit.Framework.Assert.AreEqual(201, (int)response.StatusCode);
        Console.WriteLine(response.Content);
    }

    [Test]
    public async Task Test_UpdateUser()
    {
        var user = new User { Name = "John Updated", Job = "Manager" };

        var request = new RequestBuilder("/users/2", Method.Put)
                        .AddJsonBody(user)
                        .Build();

        var response = await _apiClient.ExecuteRequest(request);

        NUnit.Framework.Assert.AreEqual(200, (int)response.StatusCode);
        Console.WriteLine(response.Content);
    }

    [Test]
    public async Task Test_DeleteUser()
    {
        var request = new RequestBuilder("/users/2", Method.Delete).Build();
        var response = await _apiClient.ExecuteRequest(request);

        NUnit.Framework.Assert.AreEqual(204, (int)response.StatusCode);
    }
}
