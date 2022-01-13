using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Slack.Models.Emojis;

namespace Skybrud.Social.Slack.Models.Pins {
    
    /// <summary>
    /// Class representing a list of pinned items.
    /// </summary>
    public class SlackPinnedItemList : SlackResponseBody {

        #region Properties

        /// <summary>
        /// Gets an array with the pinned items.
        /// </summary>
        public SlackPinnedItem[] Items { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the pinned item list.</param>
        protected SlackPinnedItemList(JObject json) : base(json) {
            Items = json.GetArrayItems("items", SlackPinnedItem.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SlackPinnedItemList"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackPinnedItemList"/>.</returns>
        public static SlackPinnedItemList Parse(JObject json) {
            return json == null ? null : new SlackPinnedItemList(json);
        }

        #endregion

    }

}