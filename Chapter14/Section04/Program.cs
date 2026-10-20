// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using System.Text.Json.Nodes;

var httpClient = new HttpClient();
await GetHtmlExample(httpClient);

static async Task GetHtmlExample(HttpClient httpClient)
{
	var url = "https://www.yahoo.com";
	//var text = await httpClient.GetStringAsync(url);

	httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(
		"MyWikipediaApp/1.0 (https://example.com/; contact@example.com)"
		);

	var text = await GetFromWikipediaAsync(httpClient, "足利市");
	Console.WriteLine(text);
}

static async Task<string> GetFromWikipediaAsync(HttpClient httpClient, string keyword)
{
	var builder = new UriBuilder("https://ja.wikipedia.org/w/api.php");
	var content = new FormUrlEncodedContent(new Dictionary<string, string>
	{
		["action"] = "query",
		["format"] = "json",
		["prop"] = "extracts",
		["exintro"] = "true",
		["explaintext"] = "true",
		["titles"] = keyword
	});

	// JsonStringを取得する
	builder.Query = await content.ReadAsStringAsync();
	var jsonString = await httpClient.GetStringAsync(builder.Uri);

	// JsonStringをパースして、コンテンツ文字列を取得する
	return GetContentString(jsonString);
}

// JsonStringをパースして、コンテンツ文字列を取得する
static string GetContentString(string jsonString)
{
	var jsonNode = JsonNode.Parse(jsonString)!;
	var node = jsonNode["query"]!["pages"]!;
	var pagesElement = JsonSerializer.Deserialize<JsonElement>(node);
	var name = GetChildPropertyName(pagesElement);
	JsonElement contentElement = pagesElement.GetProperty(name);
	JsonElement extractElement = contentElement.GetProperty("extract");
	return extractElement.GetString() ?? "";
}

// element直下のキー名を取得する
static string GetChildPropertyName(JsonElement element)
{
	return element.EnumerateObject().First().Name;
}