using Newtonsoft.Json.Linq;

namespace Skybrud.Social.Slack.Models.Pins {
    
    /// <summary>
    /// Class representing a pinned item.
    /// </summary>
    /// <see>
    ///     <cref>https://api.slack.com/methods/pins.list</cref>
    /// </see>
    public class SlackPinnedMessage : SlackObject {

        #region Properties
        
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the message.</param>
        protected SlackPinnedMessage(JObject json) : base(json) {

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SlackPinnedMessage"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackPinnedMessage"/>.</returns>
        public static SlackPinnedMessage Parse(JObject json) {
            return json == null ? null : new SlackPinnedMessage(json);
        }

        #endregion

    }

}