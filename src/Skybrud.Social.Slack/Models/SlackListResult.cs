using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Slack.Models {
    
    /// <summary>
    /// Class representing a generic response body received from the Slack API.
    /// </summary>
    public class SlackListResult : SlackResult {

        #region Properties

        /// <summary>
        /// Gets the meata data of the response.
        /// </summary>
        public SlackResponseMetaData MetaData { get; }

        /// <summary>
        /// Gets whether the response had any meta data.
        /// </summary>
        public bool HasMetaData => MetaData != null;

        /// <summary>
        /// Gets the cursor for the next page.
        /// </summary>
        public string NextCursor => MetaData?.NextCursor;

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
        protected SlackListResult(JObject json) : base(json) {
            MetaData = json.GetObject("response_metadata", SlackResponseMetaData.Parse);
        }

        #endregion

    }

}