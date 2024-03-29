﻿using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Slack.Models.Teams {

    /// <summary>
    /// Class representing a Slack team.
    /// </summary>
    public class SlackTeam : SlackObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the team.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets the name of the team.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the domain of the team.
        /// </summary>
        public string Domain { get; }

        /// <summary>
        /// Gets the email domain of the team.
        /// </summary>
        public string EmailDomain { get; }

        /// <summary>
        /// Gets information about the team icon.
        /// </summary>
        public SlackTeamIcon Icon { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackTeam(JObject json) : base(json) {
            Id = json.GetString("id");
            Name = json.GetString("name");
            Domain = json.GetString("domain");
            EmailDomain = json.GetString("email_domain");
            Icon = json.GetObject("icon", SlackTeamIcon.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SlackTeam"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackTeam"/>.</returns>
        public static SlackTeam Parse(JObject json) {
            return json == null ? null : new SlackTeam(json);
        }

        #endregion

    }

}