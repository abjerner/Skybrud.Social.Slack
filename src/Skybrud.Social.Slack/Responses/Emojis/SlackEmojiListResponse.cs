using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Social.Slack.Models.Emojis;

namespace Skybrud.Social.Slack.Responses.Emojis {

    /// <summary>
    /// Class representing a response with a list of Slack emojis.
    /// </summary>
    public class SlackEmojiListResponse : SlackResponse<SlackEmojiListResponseBody> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response from the Slack API.</param>
        public SlackEmojiListResponse(IHttpResponse response) : base(response, out JObject body) {
            Body = SlackEmojiListResponseBody.Parse(body);
        }

    }

}