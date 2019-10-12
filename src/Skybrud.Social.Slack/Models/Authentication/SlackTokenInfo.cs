using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Slack.Scopes;

namespace Skybrud.Social.Slack.Models.Authentication {
    
    /// <summary>
    /// Class representing the response body of a call to get an access token.
    /// </summary>
    public class SlackTokenInfo : SlackObject {

        #region Properties
        
        /// <summary>
        /// Gets the access token.
        /// </summary>
        public string AccessToken { get; }

        /// <summary>
        /// Gets a collection of the scopes the user has granted.
        /// </summary>
        public SlackScopeCollection Scope { get; }

        /// <summary>
        /// Gets the name of the team selected by the user.
        /// </summary>
        public string TeamName { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackTokenInfo(JObject obj) : base(obj) {

            // Convert the "scope" string to a collection of scopes
            SlackScopeCollection scopes = new SlackScopeCollection();
            foreach (string name in obj.GetString("scope").Split(',')) {
                SlackScope scope = SlackScope.GetScope(name) ?? SlackScope.RegisterScope(name);
                scopes.Add(scope);
            }

            AccessToken = obj.GetString("access_token");
            Scope = scopes;
            TeamName = obj.GetString("team_name");

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SlackTokenInfo"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="Newtonsoft.Json.Linq.JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackTokenInfo"/>.</returns>
        public static SlackTokenInfo Parse(JObject obj) {
            return obj == null ? null : new SlackTokenInfo(obj);
        }

        #endregion

    }

}