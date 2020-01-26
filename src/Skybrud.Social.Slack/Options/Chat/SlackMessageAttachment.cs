using System.Collections.Generic;
using Newtonsoft.Json;
using Skybrud.Essentials.Json.Converters.Time;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Slack.Options.Chat {

    /// <summary>
    /// Class representing an attachment of a message.
    /// </summary>
    public class SlackMessageAttachment {

        #region Properties

        /// <summary>
        /// A valid URL that displays a small 16px by 16px image to the left of the <see cref="AuthorName"/> text. Will
        /// only work if <see cref="AuthorName"/> is present.
        /// </summary>
        [JsonProperty("author_icon", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthorIcon { get; set; }

        /// <summary>
        /// A valid URL that will hyperlink the <see cref="AuthorName"/> text. Will only work if
        /// <see cref="AuthorName"/> is present.
        /// </summary>
        [JsonProperty("author_link", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthorLink { get; set; }

        /// <summary>
        /// Small text used to display the author's name.
        /// </summary>
        [JsonProperty("author_name", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthorName { get; set; }

        /// <summary>
        /// Changes the color of the border on the left side of this attachment from the default gray. Can either be
        /// one of <c>good</c> (green), <c>warning</c> (yellow), <c>danger</c> (red), or any hex color code (eg. <c>#439FE0</c>).
        /// </summary>
        [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
        public string Color { get; set; }

        /// <summary>
        /// A plain text summary of the attachment used in clients that don't show formatted text (eg. IRC, mobile notifications).
        /// </summary>
        [JsonProperty("fallback", NullValueHandling = NullValueHandling.Ignore)]
        public string Fallback { get; set; }

        /// <summary>
        /// An array of field objects that get displayed in a table-like way. For best results, include no more than 2-3 field objects.
        /// </summary>
        /// <see>
        ///     <cref>https://api.slack.com/reference/messaging/attachments#field_objects</cref>
        /// </see>
        [JsonProperty("fields", NullValueHandling = NullValueHandling.Ignore)]
        public List<SlackMessageAttachmentField> Fields { get; set; }

        /// <summary>
        /// Some brief text to help contextualize and identify an attachment. Limited to 300 characters, and may be
        /// truncated further when displayed to users in environments with limited screen real estate.
        /// </summary>
        [JsonProperty("footer", NullValueHandling = NullValueHandling.Ignore)]
        public string Footer { get; set; }

        /// <summary>
        /// A valid URL to an image file that will be displayed beside the <see cref="Footer"/> text. Will only work if
        /// <see cref="AuthorName"/> is present. We'll render what you provide at 16px by 16px. It's best to use an
        /// image that is similarly sized.
        /// </summary>
        [JsonProperty("footer_icon", NullValueHandling = NullValueHandling.Ignore)]
        public string FooterIcon { get; set; }

        /// <summary>
        /// A valid URL to an image file that will be displayed at the bottom of the attachment. We support GIF, JPEG,
        /// PNG, and BMP formats.
        ///
        /// Large images will be resized to a maximum width of 360px or a maximum height of 500px, while still
        /// maintaining the original aspect ratio. Cannot be used with <see cref="ThumbUrl"/>.
        /// </summary>
        [JsonProperty("image_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageUrl { get; set; }

        /// <summary>
        /// A list of field names that should be formatted by mrkdwn syntax.
        /// </summary>
        [JsonProperty("mrkdwn_in", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> MrkdwnIn { get; set; }

        /// <summary>
        /// Text that appears above the message attachment block. It can be formatted as plain text, or with mrkdwn by
        /// including it in the <see cref="MrkdwnIn"/> field.
        /// </summary>
        [JsonProperty("pretext", NullValueHandling = NullValueHandling.Ignore)]
        public string Pretext { get; set; }

        /// <summary>
        /// The main body text of the attachment. It can be formatted as plain text, or with mrkdwn by including it in
        /// the <see cref="MrkdwnIn"/> field. The content will automatically collapse if it contains 700+ characters or
        /// 5+ linebreaks, and will display a "Show more..." link to expand the content.
        /// </summary>
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        /// <summary>
        /// A valid URL to an image file that will be displayed as a thumbnail on the right side of a message
        /// attachment. We currently support the following formats: GIF, JPEG, PNG, and BMP.
        ///
        /// The thumbnail's longest dimension will be scaled down to 75px while maintaining the aspect ratio of
        /// the image. The filesize of the image must also be less than 500 KB.
        ///
        /// For best results, please use images that are already 75px by 75px.
        /// </summary>
        [JsonProperty("thumb_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ThumbUrl { get; set; }

        /// <summary>
        /// Large title text near the top of the attachment.
        /// </summary>
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        /// <summary>
        /// A valid URL that turns the <see cref="Title"/> text into a hyperlink.
        /// </summary>
        [JsonProperty("title_link", NullValueHandling = NullValueHandling.Ignore)]
        public string TitleLink { get; set; }

        /// <summary>
        /// A timestamp that is used to related your attachment to a specific time. The attachment will display the
        /// additional timestamp value as part of the attachment's footer.
        ///
        /// Your message's timestamp will be displayed in varying ways, depending on how far in the past or future it
        /// is, relative to the present. Form factors, like mobile versus desktop may also transform its rendered
        /// appearance.
        /// </summary>
        [JsonProperty("ts", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(UnixTimeConverter))]
        public EssentialsTime Timestamnp { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new attachement with default options.
        /// </summary>
        public SlackMessageAttachment() {
            Fields = new List<SlackMessageAttachmentField>();
        }

        #endregion

    }

}