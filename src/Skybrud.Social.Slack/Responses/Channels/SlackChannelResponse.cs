using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Social.Slack.Models.Channels;

namespace Skybrud.Social.Slack.Responses.Channels {

    /// <summary>
    /// Class representing a response with information about a Slack channel.
    /// </summary>
    public class SlackChannelResponse : SlackResponse<SlackChannelResponseBody> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response from the Slack API.</param>
        public SlackChannelResponse(IHttpResponse response) : base(response, out JObject body) {
            Body = SlackChannelResponseBody.Parse(body);
        }

    }

}