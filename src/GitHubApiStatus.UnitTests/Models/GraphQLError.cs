using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GitHubApiStatus.UnitTests;

class GraphQLError
{
	public GraphQLError(string message, GraphQLLocation[] locations)
	{
		Message = message;
		Locations = locations;
	}

	[JsonProperty("message")]
	public string Message { get; }

	[JsonProperty("locations")]
	public GraphQLLocation[] Locations { get; }

	[JsonExtensionData]
	public IDictionary<string, JToken>? AdditonalEntries { get; set; }
}

class GraphQLLocation
{
	[JsonProperty("line")]
	public long Line { get; }

	[JsonProperty("column")]
	public long Column { get; }
}