using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Slack.Models.Users {
    
    public class SlackUserResponseBody : SlackObject {

        #region Properties

        /// <summary>
        /// Gets a reference to the requested user.
        /// </summary>
        public SlackUser User { get; private set; }
        
        #endregion

        #region Constructors

        private SlackUserResponseBody(JObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>SlackUserResponseBody</code> from the specified <code>JObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JObject</code> to parse.</param>
        public static SlackUserResponseBody Parse(JObject obj) {
            if (obj == null) return null;
            return new SlackUserResponseBody(obj) {
                User = obj.GetObject("user", SlackUser.Parse)
            };
        }

        #endregion

    }

}