using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public class ShrinkCoinService
{
    private string apiKey;
    private HttpClient httpClient;

    public ShrinkCoinService(string apiKey)
    {
        this.apiKey = apiKey;
        this.httpClient = new HttpClient();
    }

    public async Task<Dictionary<string, object>> ShrinkURL(string url, bool isInstant = true)
    {
        string apiUrl = "https://shrinkco.in/api/shrink";
        var parameters = new Dictionary<string, string>()
        {
            { "API_KEY", apiKey },
            { "URL", url },
            { "IS_INSTANT", isInstant.ToString() }
        };

        return await CallAPI(apiUrl, parameters);
    }

    public async Task<Dictionary<string, object>> DeleteURL(string id)
    {
        string apiUrl = "https://shrinkco.in/api/delete";
        var parameters = new Dictionary<string, string>()
        {
            { "API_KEY", apiKey },
            { "ID", id }
        };

        return await CallAPI(apiUrl, parameters);
    }

    public async Task<Dictionary<string, object>> CheckURLClicks(string id)
    {
        string apiUrl = "https://shrinkco.in/api/clicks";
        var parameters = new Dictionary<string, string>()
        {
            { "API_KEY", apiKey },
            { "ID", id }
        };

        return await CallAPI(apiUrl, parameters);
    }

    public async Task<Dictionary<string, object>> CheckURLCampaignClicks(string id, string campaign)
    {
        string apiUrl = "https://shrinkco.in/api/campaign";
        var parameters = new Dictionary<string, string>()
        {
            { "API_KEY", apiKey },
            { "ID", id },
            { "CAMPAIGN", campaign }
        };

        return await CallAPI(apiUrl, parameters);
    }

    private async Task<Dictionary<string, object>> CallAPI(string url, Dictionary<string, string> parameters)
    {
        var queryString = new FormUrlEncodedContent(parameters);
        string requestUrl = $"{url}?{await queryString.ReadAsStringAsync()}";

        var response = await httpClient.GetAsync(requestUrl);
        string responseContent = await response.Content.ReadAsStringAsync();

        // You may need to use a JSON parsing library to parse the responseContent into a dictionary.
        // Here, we assume the response content is a JSON object represented as a dictionary.
        return ParseJsonResponse(responseContent);
    }

    private Dictionary<string, object> ParseJsonResponse(string json)
    {
        // Implement your JSON parsing logic here based on the JSON structure of the response.
        // Convert the JSON string into a dictionary or use a JSON parsing library like Newtonsoft.Json.
        throw new NotImplementedException();
    }
}
