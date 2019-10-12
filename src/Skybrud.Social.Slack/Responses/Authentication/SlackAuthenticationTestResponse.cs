using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Slack.Models.Authentication;

namespace Skybrud.Social.Slack.Responses.Authentication {

    public class SlackAuthenticationTestResponse : SlackResponse<SlackAuthenticationTest> {

        #region Constructors

        private SlackAuthenticationTestResponse(IHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>SlackAuthenticationTestResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>WindowsLiveUserResponse</code>.</returns>
        public static SlackAuthenticationTestResponse ParseResponse(IHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException(nameof(response));

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new SlackAuthenticationTestResponse(response) {
                Body = ParseJsonObject(response.Body, SlackAuthenticationTest.Parse)
            };

        }

        #endregion

    }

}