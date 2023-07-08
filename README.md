# ShrinkCoinService

The `ShrinkCoinService` class provides a convenient way to interact with the ShrinkCoin API to perform various operations related to URL shrinking and tracking.

## Constructor

### `ShrinkCoinService(string apiKey)`

- `apiKey` (string): The API key associated with your ShrinkCoin account.

Creates a new instance of the `ShrinkCoinService` class with the specified API key.

## Methods

### `Task<Dictionary<string, object>> ShrinkURL(string url, bool isInstant = true)`

- `url` (string): The URL to be shortened.
- `isInstant` (bool, optional): Specifies whether the URL should be instantly available or not. Default is `true`.

This method sends a request to the ShrinkCoin API to shrink the given URL. It returns the response from the API as a dictionary.

### `Task<Dictionary<string, object>> DeleteURL(string id)`

- `id` (string): The ID of the shortened URL to be deleted.

This method sends a request to the ShrinkCoin API to delete the specified shortened URL. It returns the response from the API as a dictionary.

### `Task<Dictionary<string, object>> CheckURLClicks(string id)`

- `id` (string): The ID of the shortened URL for which to retrieve click information.

This method sends a request to the ShrinkCoin API to get the click information for the specified shortened URL. It returns the response from the API as a dictionary.

### `Task<Dictionary<string, object>> CheckURLCampaignClicks(string id, string campaign)`

- `id` (string): The ID of the shortened URL for which to retrieve click information.
- `campaign` (string): The name of the campaign to filter the click information.

This method sends a request to the ShrinkCoin API to get the click information for the specified shortened URL, filtered by the specified campaign. It returns the response from the API as a dictionary.

## Example Usage

```csharp
string apiKey = "YOUR_API_KEY";
ShrinkCoinService shrinkCoinService = new ShrinkCoinService(apiKey);

// Shrink a URL
string url = "https://example.com";
Dictionary<string, object> result = await shrinkCoinService.ShrinkURL(url);
PrintResult(result);

// Delete a shrunk URL
string id = "YOUR_URL_ID";
result = await shrinkCoinService.DeleteURL(id);
PrintResult(result);

// Check clicks for a URL
id = "YOUR_URL_ID";
result = await shrinkCoinService.CheckURLClicks(id);
PrintResult(result);

// Check clicks for a URL campaign
id = "YOUR_URL_ID";
string campaign = "YOUR_CAMPAIGN";
result = await shrinkCoinService.CheckURLCampaignClicks(id, campaign);
PrintResult(result);

void PrintResult(Dictionary<string, object> result)
{
    foreach (var kvp in result)
    {
        Console.WriteLine($"{kvp.Key}: {kvp.Value}");
    }
    Console.WriteLine();
}
```
Note: Replace "YOUR_API_KEY", "YOUR_URL_ID", and "YOUR_CAMPAIGN" with your actual API key, URL ID, and campaign name respectively.

That's it! You can use the ShrinkCoinService class in your C# code to integrate the ShrinkCoin API functionalities into your application.
