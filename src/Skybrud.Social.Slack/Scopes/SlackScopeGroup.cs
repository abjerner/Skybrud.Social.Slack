using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Skybrud.Social.Slack.Scopes {

    /// <summary>
    /// Class representing a group of scopes.
    /// </summary>
    public class SlackScopeGroup {

        #region Properties

        /// <summary>
        /// Gets the name of the group.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Gets an array with the scopes of the group.
        /// </summary>
        [JsonProperty("scopes")]
        public SlackScope[] Scopes { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new group with the specified <paramref name="name"/> and <paramref name="scopes"/>.
        /// </summary>
        /// <param name="name">The name of the group.</param>
        /// <param name="scopes">An array with the scopes that should make up the group.</param>
        public SlackScopeGroup(string name, SlackScope[] scopes) {
            Name = name;
            Scopes = scopes;
        }

        /// <summary>
        /// Initializes a new group with the specified <paramref name="name"/> and <paramref name="scopes"/>.
        /// </summary>
        /// <param name="name">The name of the group.</param>
        /// <param name="scopes">An array with the scopes that should make up the group.</param>
        public SlackScopeGroup(string name, IEnumerable<SlackScope> scopes) {
            Name = name;
            Scopes = scopes.ToArray();
        }

        #endregion

    }

}