using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Social.Slack.Models.Conversations;

namespace Skybrud.Social.Slack.Responses.Conversations {

    /// <summary>
    /// Class representing a response with a list of Slack conversations.
    /// </summary>
    public class SlackConversationListResponse : SlackResponse<SlackConversationListResult> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response from the Slack API.</param>
        public SlackConversationListResponse(IHttpResponse response) : base(response, out JObject body) {
            Body = SlackConversationListResult.Parse(body);
        }

    }

}