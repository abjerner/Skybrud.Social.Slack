﻿using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Slack.Models.Channels {

    /// <summary>
    /// Class representing the topic a Slack channel.
    /// </summary>
    public class SlackChannelTopic : SlackObject {

        #region Properties

        /// <summary>
        /// Gets the value representing the topic.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Gets the user who set the topic.
        /// </summary>
        public string Creator { get; }

        /// <summary>
        /// Gets a timestamp for when the topic was last updated.
        /// </summary>
        public EssentialsTime LastSet { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackChannelTopic(JObject json) : base(json) {
            Value = json.GetString("value");
            Creator = json.GetString("creator");
            LastSet = json.GetDouble("last_set", x => x < 1 ? null : EssentialsTime.FromUnixTimestamp(x));
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SlackChannelTopic"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackChannelTopic"/>.</returns>
        public static SlackChannelTopic Parse(JObject json) {
            return json == null ? null : new SlackChannelTopic(json);
        }

        #endregion

    }

}