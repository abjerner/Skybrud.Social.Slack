using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.Slack.Models.Common;

namespace Skybrud.Social.Slack.Models.Users {
   
    /// <summary>
    /// Class representing the presence of a user.
    /// </summary>
    public class SlackPresence : SlackResult {

        #region Properties

        /// <summary>
        /// Gets the presence of the user.
        /// </summary>
        public SlackPresenceState Presence { get; }

        /// <summary>
        /// Gets whether the user is online.
        /// </summary>
        public SlackBoolean IsOnline { get; }

        /// <summary>
        /// Gets whether the user is auto away.
        /// </summary>
        public SlackBoolean IsAutoAway { get; }

        /// <summary>
        /// Gets whether the user is manual away.
        /// </summary>
        public SlackBoolean IsManualAway { get; }

        /// <summary>
        /// Gets the connection count.
        /// </summary>
        public int ConnectionCount { get; }

        /// <summary>
        /// Gets a timestamp with the last activity of the user.
        /// </summary>
        public EssentialsTime LastActivity { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackPresence(JObject json) : base(json)  {
            Presence = json.GetEnum("presence", SlackPresenceState.Unspecified);
            IsOnline = json.GetString("online", ParseBoolean);
            IsAutoAway = json.GetString("auto_away", ParseBoolean);
            IsManualAway = json.GetString("manual_away", ParseBoolean);
            ConnectionCount = json.GetInt32("connection_count");
            LastActivity = json.GetInt32("last_activity", x => x > 0 ? EssentialsTime.FromUnixTimestamp(x) : null);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SlackPresence"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackPresence"/>.</returns>
        public static SlackPresence Parse(JObject json) {
            return json == null ? null : new SlackPresence(json);
        }

        #endregion

    }

}