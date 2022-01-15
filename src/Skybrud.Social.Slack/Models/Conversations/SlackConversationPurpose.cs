using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Slack.Models.Conversations {

    /// <summary>
    /// Class representing the purpose a Slack conversation.
    /// </summary>
    public class SlackConversationPurpose : SlackObject {

        #region Properties

        /// <summary>
        /// Gets the value representing the purpose.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Gets the user who set the purpose.
        /// </summary>
        public string Creator { get; }

        /// <summary>
        /// Gets a timestamp for when the purpose was last updated.
        /// </summary>
        public EssentialsTime LastSet { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackConversationPurpose(JObject json) : base(json) {
            Value = json.GetString("value");
            Creator = json.GetString("creator");
            LastSet = json.GetInt64("last_set", ParseUnixTimestamp);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SlackConversationPurpose"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackConversationPurpose"/>.</returns>
        public static SlackConversationPurpose Parse(JObject json) {
            return json == null ? null : new SlackConversationPurpose(json);
        }

        #endregion

    }

}