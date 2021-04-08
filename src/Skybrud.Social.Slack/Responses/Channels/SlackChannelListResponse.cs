using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Social.Slack.Models.Channels;

namespace Skybrud.Social.Slack.Responses.Channels {

    /// <summary>
    /// Class representing a response with a list of Slack users.
    /// </summary>
    public class SlackChannelListResponse : SlackResponse<SlackChannelListResponseBody> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response from the Slack API.</param>
        public SlackChannelListResponse(IHttpResponse response) : base(response, out JObject body) {
            Body = SlackChannelListResponseBody.Parse(body);
        }

    }

}