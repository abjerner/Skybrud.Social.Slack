using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Slack.Models.Users {
    
    /// <summary>
    /// Class representing a response body with information about a Slack user.
    /// </summary>
    public class SlackUserResult : SlackResult {

        #region Properties

        /// <summary>
        /// Gets a reference to the requested user.
        /// </summary>
        public SlackUser User { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackUserResult(JObject json) : base(json) {
            User = json.GetObject("user", SlackUser.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SlackUserResult"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackUserResult"/>.</returns>
        public static SlackUserResult Parse(JObject json) {
            return json == null ? null : new SlackUserResult(json);
        }

        #endregion

    }

}