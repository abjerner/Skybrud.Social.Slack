using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Slack.Models.Authentication;

namespace Skybrud.Social.Slack.Responses.Authentication {

    /// <summary>
    /// Class representing the response of a call to get an access token.
    /// </summary>
    public class SlackTokenResponse : SlackResponse<SlackTokenInfo> {
        
        #region Constructors

        private SlackTokenResponse(IHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>SlackTokenResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>SlackTokenResponse</code>.</returns>
        public static SlackTokenResponse ParseResponse(IHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException(nameof(response));
            
            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new SlackTokenResponse(response) {
                Body = ParseJsonObject(response.Body, SlackTokenInfo.Parse)
            };

        }

        #endregion

    }

}