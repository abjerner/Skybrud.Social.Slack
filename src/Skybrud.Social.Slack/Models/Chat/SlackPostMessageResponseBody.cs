using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Slack.Models.Chat {

    /// <summary>
    /// Class representing the body of a response received when posting a new message to the Slack API.
    /// </summary>
    public class SlackPostMessageResponseBody : SlackResponseBody {

        #region Properties

        /// <summary>
        /// Gets a reference to the posted message team.
        /// </summary>
        public SlackMessage Message { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackPostMessageResponseBody(JObject obj) : base(obj) {
            Message = obj.GetObject("message", SlackMessage.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SlackPostMessageResponseBody"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackPostMessageResponseBody"/>.</returns>
        public static SlackPostMessageResponseBody Parse(JObject obj) {
            return obj == null ? null : new SlackPostMessageResponseBody(obj);
        }

        #endregion

    }

}