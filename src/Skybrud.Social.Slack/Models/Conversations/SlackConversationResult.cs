using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Slack.Models.Conversations {
    
    /// <summary>
    /// Class with information about a Slack conversations.
    /// </summary>
    public class SlackConversationResult : SlackResult {

        #region Properties
        
        /// <summary>
        /// Gets a reference to the conversation/channel.
        /// </summary>
        public SlackConversation Channel { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackConversationResult(JObject json) : base(json) {
            Channel = json.GetObject("channel", SlackConversation.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SlackConversationResult"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackConversationResult"/>.</returns>
        public static SlackConversationResult Parse(JObject json) {
            return json == null ? null : new SlackConversationResult(json);
        }

        #endregion

    }

}