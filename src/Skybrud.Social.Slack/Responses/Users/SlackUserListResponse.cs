﻿using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Social.Slack.Models.Users;

namespace Skybrud.Social.Slack.Responses.Users {

    /// <summary>
    /// Class representing a response with a list of Slack users.
    /// </summary>
    public class SlackUserListResponse : SlackResponse<SlackUserListResult> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response from the Slack API.</param>
        public SlackUserListResponse(IHttpResponse response) : base(response, out JObject body) {
            Body = SlackUserListResult.Parse(body);
        }

    }

}