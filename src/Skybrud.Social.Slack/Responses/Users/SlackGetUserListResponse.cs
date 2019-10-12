using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Slack.Models.Users;

namespace Skybrud.Social.Slack.Responses.Users {

    public class SlackGetUserListResponse : SlackResponse<SlackUsersResponseBody> {

        #region Constructors

        private SlackGetUserListResponse(IHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>SlackGetUserListResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>WindowsLiveUserResponse</code>.</returns>
        public static SlackGetUserListResponse ParseResponse(IHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException(nameof(response));

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new SlackGetUserListResponse(response) {
                Body = ParseJsonObject(response.Body, SlackUsersResponseBody.Parse)
            };

        }

        #endregion

    }

}