using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Social.Slack.Models.Authentication;

namespace Skybrud.Social.Slack.Responses.Authentication {

    /// <summary>
    /// Class representing the response of a call to get an access token.
    /// </summary>
    public class SlackTokenResponse : SlackResponse<SlackTokenInfo> {
        
        #region Constructors

        private SlackTokenResponse(IHttpResponse response) : base(response) {
            ValidateResponse(response, out JObject body);
            Body = SlackTokenInfo.Parse(body);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="SlackTokenResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="SlackTokenResponse"/> representing the response.</returns>
        public static SlackTokenResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new SlackTokenResponse(response);
        }

        #endregion

    }

}