using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Slack.Models.Channels {
    
    /// <summary>
    /// Class representing a Slack channel.
    /// </summary>
    /// <see>
    ///     <cref>https://api.slack.com/types/channel</cref>
    /// </see>
    public class SlackChannel : SlackObject {

        #region Properties

        /// <summary>
        /// Gets the unique ID of the channel.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets the name of the channel.
        /// </summary>
        public string Name { get; }

        public bool IsChannel { get; }

        /// <summary>
        /// Gets a timestamp for when the channel was created.
        /// </summary>
        public EssentialsTime Created { get; }

        /// <summary>
        /// Gets whether the channel is archived.
        /// </summary>
        public bool IsArchived { get; }

        /// <summary>
        /// Gets whether this channel is the "general" channel that includes all regular members. In most workspaces this is called <c>#general</c> but some workspaces have renamed it.
        /// </summary>
        public bool IsGeneral { get; }

        // TODO: Add support for the "unlinked" property

        /// <summary>
        /// Gets the ID of the member that created this channel.
        /// </summary>
        public string Creator { get; }

        public string NameNormalized { get; }

        public bool IsShared { get; }

        public bool IsOrgShared { get; }

        /// <summary>
        /// Returns whether the calling member is part of the channel.
        /// </summary>
        public bool IsMember { get; }

        public bool IsPrivate { get; }

        public bool IsMpim { get; }

        /// <summary>
        /// Gets a list of user ids for all users in this channel. This includes any disabled accounts that were in this channel when they were disabled.
        /// </summary>
        public string[] Members { get; }

        /// <summary>
        /// Gets information about the topic of the channel.
        /// </summary>
        public SlackChannelTopic Topic { get; }

        /// <summary>
        /// Gets wether the channel has a topic.
        /// </summary>
        public bool HasTopic => Topic != null && string.IsNullOrWhiteSpace(Topic.Value) == false;

        /// <summary>
        /// Gets information about the purpose of the channel.
        /// </summary>
        public SlackChannelPurpose Purpose { get; }

        /// <summary>
        /// Gets wether the channel has a purpose.
        /// </summary>
        public bool HasPurpose => Purpose != null && string.IsNullOrWhiteSpace(Purpose.Value) == false;

        public string[] PreviousNames { get; }

        public long NumMembers { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackChannel(JObject obj) : base(obj) {
            Id = obj.GetString("id");
            Name = obj.GetString("name");
            IsChannel = obj.GetBoolean("is_channel");
            Created = obj.GetDouble("created", EssentialsTime.FromUnixTimestamp);
            IsArchived = obj.GetBoolean("is_archived");
            IsGeneral = obj.GetBoolean("is_general");
            // TODO: Add support for the "unlinked" property
            Creator = obj.GetString("creator");
            NameNormalized = obj.GetString("name_normalized");
            IsShared = obj.GetBoolean("is_shared");
            IsOrgShared = obj.GetBoolean("is_org_shared");
            IsMember = obj.GetBoolean("is_member");
            IsPrivate = obj.GetBoolean("is_private");
            IsMpim = obj.GetBoolean("is_mpim");
            Members = obj.GetStringArray("members");
            Topic = obj.GetObject("topic", SlackChannelTopic.Parse);
            Purpose = obj.GetObject("purpose", SlackChannelPurpose.Parse);
            PreviousNames = obj.GetStringArray("previous_names");
            NumMembers = obj.GetInt64("num_members");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SlackChannel"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackChannel"/>.</returns>
        public static SlackChannel Parse(JObject obj) {
            return obj == null ? null : new SlackChannel(obj);
        }

        #endregion

    }

}