using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Slack.Models.Users {
    
    /// <summary>
    /// Class representing a Slack user.
    /// </summary>
    /// <see>
    ///     <cref>https://api.slack.com/types/user</cref>
    /// </see>
    public class SlackUser : SlackObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the user.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets the ID of the team.
        /// </summary>
        public string TeamId { get; }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets whether the user has been delted.
        /// </summary>
        public bool IsDeleted { get; }

        /// <summary>
        /// Gets the color of the user. Used in some clients to display a special username color.
        /// </summary>
        public string Color { get; }

        /// <summary>
        /// Gets the real name of the user.
        /// </summary>
        public string RealName { get; }

        /// <summary>
        /// Gets a human-readable string for the geographic timezone-related region this user has specified in their account - eg. <c>Europe/Amsterdam</c>.
        /// </summary>
        public string TimeZone { get; }

        /// <summary>
        /// Gets the commonly used name of the timezone - eg. <c>Central European Time</c>.
        /// </summary>
        public string TimeZoneLabel { get; }

        /// <summary>
        /// Gets the UTC offset of the user's time zone.
        /// </summary>
        public TimeSpan TimeZoneOffset { get; }

        /// <summary>
        /// Gets a reference to the profile of the user.
        /// </summary>
        public SlackUserProfile Profile { get; }

        /// <summary>
        /// Gets whether the user is an admin of the current team.
        /// </summary>
        public bool IsAdmin { get; }
        
        /// <summary>
        /// Gets whether the user is an owner of the current team.
        /// </summary>
        public bool IsOwner { get; }
        
        /// <summary>
        /// Gets whether the user is the primary user of the current team.
        /// </summary>
        public bool IsPrimaryOwner { get; }

        /// <summary>
        /// Gets whether the user is restricted to a number of channels within the current team.
        /// </summary>
        public bool IsRestricted { get; }

        /// <summary>
        /// Gets whether the user is restricted to a single channel within the current team.
        /// </summary>
        public bool IsUltraRestricted { get; }
        
        /// <summary>
        /// Gets whether the user is a bot.
        /// </summary>
        public bool IsBot { get; }

        /// <summary>
        /// Gets whether the user is an app user.
        /// </summary>
        public bool IsAppUser { get; }

        /// <summary>
        /// Gets whether the user has enabled 2 factor authentication.
        /// </summary>
        public bool Has2Fa { get; }

        /// <summary>
        /// Gets the presence of the user.
        /// </summary>
        public SlackPresence Presence { get; }

        /// <summary>
        /// Gets a timestamp for when the user was last updated.
        /// </summary>
        public EssentialsTime Updated { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackUser(JObject obj) : base(obj) {
            Id = obj.GetString("id");
            TeamId = obj.GetString("team_id");
            Name = obj.GetString("name");
            IsDeleted = obj.GetBoolean("deleted");
            Color = obj.GetString("color");
            RealName = obj.GetString("real_name");
            TimeZone = obj.GetString("tz");
            TimeZoneLabel = obj.GetString("tz_label");
            TimeZoneOffset = obj.GetDouble("tz_offset", TimeSpan.FromSeconds);
            Profile = obj.GetObject("profile", SlackUserProfile.Parse);
            IsAdmin = obj.GetBoolean("is_admin");
            IsOwner = obj.GetBoolean("is_owner");
            IsPrimaryOwner = obj.GetBoolean("is_primary_owner");
            IsRestricted = obj.GetBoolean("is_restricted");
            IsUltraRestricted = obj.GetBoolean("is_ultra_restricted");
            IsBot = obj.GetBoolean("is_bot");
            IsAppUser = obj.GetBoolean("is_app_user");
            Has2Fa = obj.GetBoolean("has_2fa");
            Presence = obj.GetEnum("presence", SlackPresence.Unspecified);
            Updated = obj.GetDouble("updated", EssentialsTime.FromUnixTimestamp);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SlackUser"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackUser"/>.</returns>
        public static SlackUser Parse(JObject obj) {
            return obj == null ? null : new SlackUser(obj);
        }

        #endregion

    }

}