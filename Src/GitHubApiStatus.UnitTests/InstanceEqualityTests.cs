using Newtonsoft.Json;
using NUnit.Framework;

namespace GitHubApiStatus.UnitTests
{
    class InstanceEqualityTests : BaseTest
    {
        [Test]
        public void Instance_Equals_DefaultConstructor()
        {
            //Arrange
            var githubApiStatus = new GitHubApiStatusService();

            //Act
            var serializedStaticInstance = JsonConvert.SerializeObject(GitHubApiStatusService.Instance);
            var serializedInstance = JsonConvert.SerializeObject(githubApiStatus);

            //Assert
            Assert.AreEqual(serializedInstance, serializedStaticInstance);
        }
    }
}
