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
    /// <see>
    ///     <cref>https://api.slack.com/types/conversation</cref>
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

        /// <summary>
        /// Gets whether the channel is a channel.
        /// </summary>
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

        /// <summary>
        /// Gets the name of the channel, but with with any non-Latin characters filtered out.
        /// </summary>
        public string NameNormalized { get; }

        /// <summary>
        /// Gets whether the channel is shared between two teams.
        /// </summary>
        public bool IsShared { get; }

        /// <summary>
        /// Gets whether the channel is shared between <a href="https://api.slack.com/enterprise-grid">Enterprise Grid</a>
        /// workspaces within the same organization. It's a little different from (externally)
        /// <a href="https://api.slack.com/shared-channels">Shared Channels</a>.
        /// </summary>
        public bool IsOrgShared { get; }

        /// <summary>
        /// Returns whether the calling member is part of the channel.
        /// </summary>
        public bool IsMember { get; }

        /// <summary>
        /// Gets whether the channel is private.
        /// </summary>
        public bool IsPrivate { get; }

        /// <summary>
        /// Gets whether the channel represents an unnamed private conversation between multiple users.
        /// </summary>
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

        /// <summary>
        /// Gets an array with names the channel have had in the past.
        /// </summary>
        public string[] PreviousNames { get; }

        /// <summary>
        /// Gets the total amount of members in the channel.
        /// </summary>
        public long NumMembers { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackChannel(JObject json) : base(json) {
            Id = json.GetString("id");
            Name = json.GetString("name");
            IsChannel = json.GetBoolean("is_channel");
            Created = json.GetInt64("created", EssentialsTime.FromUnixTimestamp);
            IsArchived = json.GetBoolean("is_archived");
            IsGeneral = json.GetBoolean("is_general");
            // TODO: Add support for the "unlinked" property
            Creator = json.GetString("creator");
            NameNormalized = json.GetString("name_normalized");
            IsShared = json.GetBoolean("is_shared");
            IsOrgShared = json.GetBoolean("is_org_shared");
            IsMember = json.GetBoolean("is_member");
            IsPrivate = json.GetBoolean("is_private");
            IsMpim = json.GetBoolean("is_mpim");
            Members = json.GetStringArray("members");
            Topic = json.GetObject("topic", SlackChannelTopic.Parse);
            Purpose = json.GetObject("purpose", SlackChannelPurpose.Parse);
            PreviousNames = json.GetStringArray("previous_names");
            NumMembers = json.GetInt64("num_members");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SlackChannel"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackChannel"/>.</returns>
        public static SlackChannel Parse(JObject json) {
            return json == null ? null : new SlackChannel(json);
        }

        #endregion

    }

}