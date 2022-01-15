using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Slack.Models {

    /// <summary>
    /// Class representing the meta data of a list response.
    /// </summary>
    public class SlackResponseMetaData : SlackObject {

        #region Properties

        /// <summary>
        /// Gets the cursor for the next page.
        /// </summary>
        public string NextCursor { get; }

        /// <summary>
        /// Gets whether the meta data has a cursor for the next page.
        /// </summary>
        public bool HasNextCursor => !string.IsNullOrWhiteSpace(NextCursor);

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        protected SlackResponseMetaData(JObject json) : base(json) {
            NextCursor = json.GetString("next_cursor");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SlackResponseMetaData"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackResponseMetaData"/>.</returns>
        public static SlackResponseMetaData Parse(JObject json) {
            return json == null ? null : new SlackResponseMetaData(json);
        }

        #endregion

    }

}