using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Social.Slack.Models.Authentication;

namespace Skybrud.Social.Slack.Responses.Authentication {

    /// <summary>
    /// Class representing a response wrarring an instance of <see cref="SlackAuthenticationTest"/>.
    /// </summary>
    public class SlackAuthenticationTestResponse : SlackResponse<SlackAuthenticationTest> {

        #region Constructors

        private SlackAuthenticationTestResponse(IHttpResponse response) : base(response) {
            ValidateResponse(response, out JObject body);
            Body = SlackAuthenticationTest.Parse(body);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="SlackAuthenticationTestResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="SlackAuthenticationTestResponse"/> representing the response.</returns>
        public static SlackAuthenticationTestResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new SlackAuthenticationTestResponse(response);
        }

        #endregion

    }

}