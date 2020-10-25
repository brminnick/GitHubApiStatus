using System;
using Newtonsoft.Json;

namespace GitStatus.Mobile
{
    class GitHubViewerResponse
    {
        public GitHubViewerResponse(User viewer) => Viewer = viewer;

        [JsonProperty("viewer")]
        public User Viewer { get; }
    }
}
