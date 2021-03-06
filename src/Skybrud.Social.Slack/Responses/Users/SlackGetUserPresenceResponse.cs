﻿using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Social.Slack.Models.Users;

namespace Skybrud.Social.Slack.Responses.Users {

    /// <summary>
    /// Class representing a response presence of a Slack user.
    /// </summary>
    public class SlackGetUserPresenceResponse : SlackResponse<SlackPresence> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response from the Slack API.</param>
        public SlackGetUserPresenceResponse(IHttpResponse response) : base(response) {
            ValidateResponse(response, out JObject body);
            Body = SlackPresence.Parse(body);
        }

    }

}