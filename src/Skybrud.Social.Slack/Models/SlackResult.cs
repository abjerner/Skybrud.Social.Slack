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
        /// Initializes a new instance from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        protected SlackResult(JObject obj) : base(obj) {
            IsOk = obj.GetBoolean("ok");
        }

        #endregion

    }

}