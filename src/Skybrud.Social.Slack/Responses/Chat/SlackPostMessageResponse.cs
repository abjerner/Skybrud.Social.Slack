using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Social.Slack.Models.Chat;

namespace Skybrud.Social.Slack.Responses.Chat {

    /// <summary>
    /// Class representing the response received when posting a new message to the Slack API.
    /// </summary>
    public class SlackPostMessageResponse : SlackResponse<SlackPostMessageResponseBody> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response from the Slack API.</param>
        public SlackPostMessageResponse(IHttpResponse response) : base(response, out JObject body) {
            Body = SlackPostMessageResponseBody.Parse(body);
        }

    }

}