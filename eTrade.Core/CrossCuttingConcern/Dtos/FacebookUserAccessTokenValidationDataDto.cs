using System.Text.Json.Serialization;

namespace eTrade.Core.CrossCuttingConcern.Dtos
{
    public class FacebookUserAccessTokenValidationDataDto
    {
        [JsonPropertyName("data")]
        public FacebookUserAccessTokenValidationDto Data { get; set; }

    }
    public class FacebookUserAccessTokenValidationDto
    {
        [JsonPropertyName("is_valid")]
        public bool IsValid { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
    }
}
