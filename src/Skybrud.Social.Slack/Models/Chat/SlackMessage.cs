using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Slack.Models.Chat {
    
    /// <summary>
    /// Class representing a Slack message.
    /// </summary>
    public class SlackMessage : SlackObject {

        #region Properties

        /// <summary>
        /// Gets the main text of the message.
        /// </summary>
        public string Text { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackMessage(JObject obj) : base(obj) {
            Text = obj.GetString("text");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SlackMessage"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackMessage"/>.</returns>
        public static SlackMessage Parse(JObject obj) {
            return obj == null ? null : new SlackMessage(obj);
        }

        #endregion

    }

}