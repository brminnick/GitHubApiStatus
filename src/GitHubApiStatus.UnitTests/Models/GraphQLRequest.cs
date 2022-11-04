using Newtonsoft.Json;


/* Unmerged change from project 'GitHubApiStatus.UnitTests(netcoreapp2.1)'
Before:
namespace GitHubApiStatus.UnitTests
{
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
}
After:
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
*/

/* Unmerged change from project 'GitHubApiStatus.UnitTests(netcoreapp3.1)'
Before:
namespace GitHubApiStatus.UnitTests
{
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
}
After:
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
*/

/* Unmerged change from project 'GitHubApiStatus.UnitTests(net5.0)'
Before:
namespace GitHubApiStatus.UnitTests
{
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
}
After:
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
*/
namespace GitHubApiStatus.UnitTests
{
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
}