using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Social.Slack.Models.Teams;

namespace Skybrud.Social.Slack.Responses.Teams {

    public class SlackGetTeamInfoResponse : SlackResponse<SlackTeamResponseBody> {

        #region Constructors

        private SlackGetTeamInfoResponse(IHttpResponse response) : base(response) {
            ValidateResponse(response, out JObject body);
            Body = SlackTeamResponseBody.Parse(body);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="SlackGetTeamInfoResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="SlackGetTeamInfoResponse"/> representing the response.</returns>
        public static SlackGetTeamInfoResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new SlackGetTeamInfoResponse(response);
        }

        #endregion

    }

}