using Newtonsoft.Json;

namespace Skybrud.Social.Slack.Options.Chat {

    public class SlackMessageAttachmentField {

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }

        [JsonProperty("short")]
        public bool IsShort { get; set; }

    }

}