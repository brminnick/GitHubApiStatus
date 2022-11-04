using Newtonsoft.Json;


/* Unmerged change from project 'GitHubApiStatus.UnitTests(netcoreapp2.1)'
Before:
namespace GitHubApiStatus.UnitTests
{
    class GraphQLResponse<T>
    {
        public GraphQLResponse(T data, GraphQLError[] errors)
        {
            Data = data;
            Errors = errors;
        }

        [JsonProperty("data")]
        public T Data { get; }

        [JsonProperty("errors")]
        public GraphQLError[] Errors { get; }
    }
}
After:
namespace GitHubApiStatus.UnitTests;

    class GraphQLResponse<T>
    {
        public GraphQLResponse(T data, GraphQLError[] errors)
        {
            Data = data;
            Errors = errors;
        }

        [JsonProperty("data")]
        public T Data { get; }

        [JsonProperty("errors")]
        public GraphQLError[] Errors { get; }
    }
*/

/* Unmerged change from project 'GitHubApiStatus.UnitTests(netcoreapp3.1)'
Before:
namespace GitHubApiStatus.UnitTests
{
    class GraphQLResponse<T>
    {
        public GraphQLResponse(T data, GraphQLError[] errors)
        {
            Data = data;
            Errors = errors;
        }

        [JsonProperty("data")]
        public T Data { get; }

        [JsonProperty("errors")]
        public GraphQLError[] Errors { get; }
    }
}
After:
namespace GitHubApiStatus.UnitTests;

    class GraphQLResponse<T>
    {
        public GraphQLResponse(T data, GraphQLError[] errors)
        {
            Data = data;
            Errors = errors;
        }

        [JsonProperty("data")]
        public T Data { get; }

        [JsonProperty("errors")]
        public GraphQLError[] Errors { get; }
    }
*/

/* Unmerged change from project 'GitHubApiStatus.UnitTests(net5.0)'
Before:
namespace GitHubApiStatus.UnitTests
{
    class GraphQLResponse<T>
    {
        public GraphQLResponse(T data, GraphQLError[] errors)
        {
            Data = data;
            Errors = errors;
        }

        [JsonProperty("data")]
        public T Data { get; }

        [JsonProperty("errors")]
        public GraphQLError[] Errors { get; }
    }
}
After:
namespace GitHubApiStatus.UnitTests;

    class GraphQLResponse<T>
    {
        public GraphQLResponse(T data, GraphQLError[] errors)
        {
            Data = data;
            Errors = errors;
        }

        [JsonProperty("data")]
        public T Data { get; }

        [JsonProperty("errors")]
        public GraphQLError[] Errors { get; }
    }
*/
namespace GitHubApiStatus.UnitTests
{
	class GraphQLResponse<T>
	{
		public GraphQLResponse(T data, GraphQLError[] errors)
		{
			Data = data;
			Errors = errors;
		}

		[JsonProperty("data")]
		public T Data { get; }

		[JsonProperty("errors")]
		public GraphQLError[] Errors { get; }
	}
}