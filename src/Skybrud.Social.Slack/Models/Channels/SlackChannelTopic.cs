using Newtonsoft.Json.Linq;
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
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackChannelTopic(JObject obj) : base(obj) {
            Value = obj.GetString("value");
            Creator = obj.GetString("creator");
            LastSet = obj.GetDouble("last_set", x => x < 1 ? null : EssentialsTime.FromUnixTimestamp(x));
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SlackChannelTopic"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackChannelTopic"/>.</returns>
        public static SlackChannelTopic Parse(JObject obj) {
            return obj == null ? null : new SlackChannelTopic(obj);
        }

        #endregion

    }

}