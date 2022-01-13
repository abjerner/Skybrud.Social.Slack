using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Slack.Models.Emojis {

    /// <summary>
    /// Class representing the response body for a list of custom emojis.
    /// </summary>
    /// <see>
    ///     <cref>https://api.slack.com/methods/emoji.list</cref>
    /// </see>
    public class SlackEmojiListResult : SlackResult {

        #region Properties

        /// <summary>
        /// Gets a reference to the emoji list from the response body.
        /// </summary>
        public SlackEmojiList Emoji { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the response body.</param>
        protected SlackEmojiListResult(JObject json) : base(json) {
            Emoji = json.GetObject("emoji", SlackEmojiList.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SlackEmojiListResult"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackEmojiListResult"/>.</returns>
        public static SlackEmojiListResult Parse(JObject json) {
            return json == null ? null : new SlackEmojiListResult(json);
        }

        #endregion

    }

}