using System;
using Newtonsoft.Json;

namespace GitStatus
{
    class GitHubViewerResponse
    {
        public GitHubViewerResponse(User viewer) => Viewer = viewer;

        [JsonProperty("viewer")]
        public User Viewer { get; }
    }
}
