﻿using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Slack.Models.Users {
    
    /// <summary>
    /// Class representing a list of Slack users (members of a Slack team).
    /// </summary>
    public class SlackUserListResult : SlackResult {

        #region Properties

        /// <summary>
        /// Gets an array with the members of the team.
        /// </summary>
        public SlackUser[] Members { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackUserListResult(JObject obj) : base(obj) {
            Members = obj.GetArrayItems("members", SlackUser.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SlackUserListResult"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackUserListResult"/>.</returns>
        public static SlackUserListResult Parse(JObject obj) {
            return obj == null ? null : new SlackUserListResult(obj);
        }

        #endregion

    }

}