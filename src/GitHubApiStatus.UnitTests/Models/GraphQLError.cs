using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


/* Unmerged change from project 'GitHubApiStatus.UnitTests(netcoreapp2.1)'
Before:
namespace GitHubApiStatus.UnitTests
{
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
}
After:
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
*/

/* Unmerged change from project 'GitHubApiStatus.UnitTests(netcoreapp3.1)'
Before:
namespace GitHubApiStatus.UnitTests
{
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
}
After:
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
*/

/* Unmerged change from project 'GitHubApiStatus.UnitTests(net5.0)'
Before:
namespace GitHubApiStatus.UnitTests
{
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
}
After:
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
*/
namespace GitHubApiStatus.UnitTests
{
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
}