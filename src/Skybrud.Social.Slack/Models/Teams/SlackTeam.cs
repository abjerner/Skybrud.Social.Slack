using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Slack.Models.Teams {
    
    /// <summary>
    /// Class representing a Slack team.
    /// </summary>
    public class SlackTeam : SlackObject {

        #region Properties

        public string Id { get; }

        public string Name { get; }

        public string Domain { get; }

        public string EmailDomain { get; }

        public SlackTeamIcon Icon { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackTeam(JObject obj) : base(obj) {
            Id = obj.GetString("id");
            Name = obj.GetString("name");
            Domain = obj.GetString("domain");
            EmailDomain = obj.GetString("email_domain");
            Icon = obj.GetObject("icon", SlackTeamIcon.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SlackTeam"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackTeam"/>.</returns>
        public static SlackTeam Parse(JObject obj) {
            return obj == null ? null : new SlackTeam(obj);
        }

        #endregion

    }

}