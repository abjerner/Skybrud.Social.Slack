using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Slack.Models.Users {
    
    /// <summary>
    /// Class representing a Slack user.
    /// </summary>
    public class SlackUser : SlackObject {

        #region Properties

        public string Id { get; }

        public string Name { get; }

        public bool IsDeleted { get; }

        public string Color { get; }

        public string RealName { get; }

        public string TimeZone { get; }

        public string TimeZoneLabel { get; }

        public TimeSpan TimeZoneOffset { get; }

        public SlackUserProfile Profile { get; }

        public bool IsAdmin { get; }
        
        public bool IsOwner { get; }
        
        public bool IsPrimaryOwner { get; }
        
        public bool IsRestricted { get; }
        
        public bool IsUltraRestricted { get; }
        
        public bool IsBot { get; }
        
        public bool HasFiles { get; }
        
        /// <summary>
        /// Gets whether the user has enabled 2 factor authentication.
        /// </summary>
        public bool Has2Fa { get; }

        /// <summary>
        /// Gets the presence of the user.
        /// </summary>
        public SlackPresence Presence { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackUser(JObject obj) : base(obj) {
            Id = obj.GetString("id");
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
            HasFiles = obj.GetBoolean("has_files");
            Has2Fa = obj.GetBoolean("has_2fa");
            Presence = obj.GetEnum("presence", SlackPresence.Unspecified);
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