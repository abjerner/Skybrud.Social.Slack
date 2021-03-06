﻿using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Social.Slack.Models.Users;

namespace Skybrud.Social.Slack.Responses.Users {

    /// <summary>
    /// Class representing a response with a list of Slack users.
    /// </summary>
    public class SlackGetUserListResponse : SlackResponse<SlackUserListResponseBody> {

        #region Constructors

        private SlackGetUserListResponse(IHttpResponse response) : base(response) {
            ValidateResponse(response, out JObject body);
            Body = SlackUserListResponseBody.Parse(body);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="SlackGetUserListResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="SlackGetUserListResponse"/> representing the response.</returns>
        public static SlackGetUserListResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new SlackGetUserListResponse(response);
        }

        #endregion

    }

}