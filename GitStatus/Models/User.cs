using System;
using System.Text;
using Newtonsoft.Json;

namespace GitStatus
{
    public class User
    {
        public User(string name, string company, DateTimeOffset createdAt, string login, Uri avatarUrl)
        {
            Name = name;
            Company = company;
            AccountCreationDate = createdAt;
            Alias = login;
            AvatarUri = avatarUrl;
        }

        [JsonProperty("name")]
        public string Name { get; }

        [JsonProperty("company")]
        public string Company { get; }

        [JsonProperty("createdAt")]
        public DateTimeOffset AccountCreationDate { get; }

        [JsonProperty("login")]
        public string Alias { get; }

        [JsonProperty("avatarUrl")]
        public Uri AvatarUri { get; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{nameof(Name)}: {Name}");
            stringBuilder.AppendLine($"{nameof(Company)}: {Company}");
            stringBuilder.AppendLine($"{nameof(AccountCreationDate)}: {AccountCreationDate}");

            return stringBuilder.ToString();
        }
    }
}
