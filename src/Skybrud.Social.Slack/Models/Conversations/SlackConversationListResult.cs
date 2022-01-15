using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Slack.Models.Conversations {
    
    /// <summary>
    /// Class representing a list of Slack conversations.
    /// </summary>
    public class SlackConversationListResult : SlackListResult {

        #region Properties
        
        /// <summary>
        /// Gets an array with the channels/conversations of the team.
        /// </summary>
        public SlackConversation[] Channels { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackConversationListResult(JObject json) : base(json) {
            Channels = json.GetArrayItems("channels", SlackConversation.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SlackConversationListResult"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackConversationListResult"/>.</returns>
        public static SlackConversationListResult Parse(JObject json) {
            return json == null ? null : new SlackConversationListResult(json);
        }

        #endregion

    }

}