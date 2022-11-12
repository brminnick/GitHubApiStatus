using Newtonsoft.Json;

namespace GitHubApiStatus.UnitTests;

class GraphQLRequest
{
	public GraphQLRequest(string query, string variables = "")
	{
		Query = query;
		Variables = variables;
	}

	[JsonProperty("query")]
	public string Query { get; }

	[JsonProperty("variables")]
	public string Variables { get; }
}