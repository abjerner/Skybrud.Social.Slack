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
        public SlackScopeList Scope { get; }

        /// <summary>
        /// Gets the name of the team selected by the user.
        /// </summary>
        public string TeamName { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackTokenInfo(JObject json) : base(json) {

            // Convert the "scope" string to a collection of scopes
            SlackScopeList scopes = new SlackScopeList();
            foreach (string name in json.GetString("scope").Split(',')) {
                SlackScope scope = SlackScope.GetScope(name) ?? SlackScope.RegisterScope(name);
                scopes.Add(scope);
            }

            AccessToken = json.GetString("access_token");
            Scope = scopes;
            TeamName = json.GetString("team_name");

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SlackTokenInfo"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="Newtonsoft.Json.Linq.JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackTokenInfo"/>.</returns>
        public static SlackTokenInfo Parse(JObject json) {
            return json == null ? null : new SlackTokenInfo(json);
        }

        #endregion

    }

}