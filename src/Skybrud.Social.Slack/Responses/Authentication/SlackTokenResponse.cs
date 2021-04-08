using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Social.Slack.Models.Authentication;

namespace Skybrud.Social.Slack.Responses.Authentication {

    /// <summary>
    /// Class representing the response of a call to get an access token.
    /// </summary>
    public class SlackTokenResponse : SlackResponse<SlackTokenInfo> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response from the Slack API.</param>
        public SlackTokenResponse(IHttpResponse response) : base(response, out JObject body) {
            Body = SlackTokenInfo.Parse(body);
        }

    }

}