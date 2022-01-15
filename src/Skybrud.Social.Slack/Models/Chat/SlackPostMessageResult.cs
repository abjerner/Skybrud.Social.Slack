using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Slack.Models.Messages;

namespace Skybrud.Social.Slack.Models.Chat {

    /// <summary>
    /// Class representing the body of a response received when posting a new message to the Slack API.
    /// </summary>
    public class SlackPostMessageResult : SlackResult {

        #region Properties

        /// <summary>
        /// Gets a reference to the posted message team.
        /// </summary>
        public SlackMessage Message { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackPostMessageResult(JObject json) : base(json) {
            Message = json.GetObject("message", SlackMessage.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SlackPostMessageResult"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackPostMessageResult"/>.</returns>
        public static SlackPostMessageResult Parse(JObject json) {
            return json == null ? null : new SlackPostMessageResult(json);
        }

        #endregion

    }

}