using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Social.Slack.Models.Teams;

namespace Skybrud.Social.Slack.Responses.Teams {

    /// <summary>
    /// Class representing a response with information about a Slack team.
    /// </summary>
    public class SlackTeamResponse : SlackResponse<SlackTeamResult> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response from the Slack API.</param>
        public SlackTeamResponse(IHttpResponse response) : base(response, out JObject body) {
            Body = SlackTeamResult.Parse(body);
        }

    }

}