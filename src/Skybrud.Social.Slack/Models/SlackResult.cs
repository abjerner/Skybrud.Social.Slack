using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Slack.Models {
    
    /// <summary>
    /// Class representing a generic response body received from the Slack API.
    /// </summary>
    public class SlackResult : SlackObject {

        #region Properties

        /// <summary>
        /// Gets whether the request/response was successful.
        /// </summary>
        public bool IsOk { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        protected SlackResult(JObject json) : base(json) {
            IsOk = json.GetBoolean("ok");
        }

        #endregion

    }

}