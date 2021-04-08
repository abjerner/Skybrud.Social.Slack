using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Social.Slack.Models.Authentication;

namespace Skybrud.Social.Slack.Responses.Authentication {

    /// <summary>
    /// Class representing a response wrarring an instance of <see cref="SlackAuthenticationTest"/>.
    /// </summary>
    public class SlackAuthenticationTestResponse : SlackResponse<SlackAuthenticationTest> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response from the Slack API.</param>
        public SlackAuthenticationTestResponse(IHttpResponse response) : base(response, out JObject body) {
            Body = SlackAuthenticationTest.Parse(body);
        }

    }

}