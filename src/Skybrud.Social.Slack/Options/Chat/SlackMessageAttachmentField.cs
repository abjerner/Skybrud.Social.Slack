using Newtonsoft.Json;

namespace Skybrud.Social.Slack.Options.Chat {

    /// <summary>
    /// Class representing a field of an attachment.
    /// </summary>
    /// <see>
    ///     <cref>https://api.slack.com/reference/messaging/attachments#field_objects</cref>
    /// </see>
    public class SlackMessageAttachmentField {

        /// <summary>
        /// 	Shown as a bold heading displayed in the field object. It cannot contain markup and will be escaped for you.
        /// </summary>
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        /// <summary>
        /// The text value displayed in the field object. It can be formatted as plain text, or with mrkdwn by using the
        /// <see cref="SlackMessageAttachment.MrkdwnIn"/> options of the attachment.
        /// </summary>
        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }

        /// <summary>
        /// Indicates whether the field object is short enough to be displayed side-by-side with other field objects.
        /// Defaults to <c>false</c>.
        /// </summary>
        [JsonProperty("short")]
        public bool IsShort { get; set; }

    }

}