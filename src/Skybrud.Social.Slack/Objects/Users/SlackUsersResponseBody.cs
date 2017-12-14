using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Slack.Objects.Users {
    
    public class SlackUsersResponseBody : SlackObject {

        #region Properties

        /// <summary>
        /// Gets a reference to the members of the team.
        /// </summary>
        public SlackUser[] Members { get; private set; }
        
        #endregion

        #region Constructors

        private SlackUsersResponseBody(JObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>SlackUsersResponseBody</code> from the specified <code>JObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static SlackUsersResponseBody Parse(JObject obj) {
            if (obj == null) return null;
            return new SlackUsersResponseBody(obj) {
                Members = obj.GetArrayItems("members", SlackUser.Parse)
            };
        }

        #endregion

    }

}