using System.Collections.Generic;
using Newtonsoft.Json;
using Skybrud.Essentials.Json.Converters.Time;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Slack.Options.Chat {

    public class SlackMessageAttachment {

        [JsonProperty("fallback", NullValueHandling = NullValueHandling.Ignore)]
        public string Fallback { get; set; }

        [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
        public string Color { get; set; }

        [JsonProperty("pretext", NullValueHandling = NullValueHandling.Ignore)]
        public string Pretext { get; set; }

        [JsonProperty("author_name", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthorName { get; set; }

        [JsonProperty("author_link", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthorLink { get; set; }

        [JsonProperty("author_icon", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthorIcon { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("title_link", NullValueHandling = NullValueHandling.Ignore)]
        public string TitleLink { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("fields", NullValueHandling = NullValueHandling.Ignore)]
        public List<SlackMessageAttachmentField> Fields { get; set; }

        [JsonProperty("image_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageUrl { get; set; }

        [JsonProperty("thumb_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ThumbUrl { get; set; }

        [JsonProperty("footer", NullValueHandling = NullValueHandling.Ignore)]
        public string Footer { get; set; }

        [JsonProperty("footer_icon", NullValueHandling = NullValueHandling.Ignore)]
        public string FooterIcon { get; set; }

        [JsonProperty("ts", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(UnixTimeConverter))]
        public EssentialsDateTime Timestamnp { get; set; }

        public SlackMessageAttachment() {
            Fields = new List<SlackMessageAttachmentField>();
        }

    }

}