using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Slack.Models.Conversations {

    /// <summary>
    /// Class representing a Slack conversation.
    /// </summary>
    /// <see>
    ///     <cref>https://api.slack.com/types/conversation</cref>
    /// </see>
    public class SlackConversation : SlackObject {

        #region Properties

        /// <summary>
        /// Gets the unique ID of the conversation.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets the name of the conversation.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets whether the conversation is a channel.
        /// </summary>
        public bool IsChannel { get; }

        /// <summary>
        /// Gets whether the conversation is a group.
        /// </summary>
        public bool IsGroup { get; }

        /// <summary>
        /// Gets whether the conversation is a an IM.
        /// </summary>
        public bool IsIm { get; }

        /// <summary>
        /// Gets a timestamp for when the channel was created.
        /// </summary>
        public EssentialsTime Created { get; }

        /// <summary>
        /// gets the ID of the user who created the conversation.
        /// </summary>
        public string Creator { get; }

        /// <summary>
        /// Gets whether the conversation has been archived.
        /// </summary>
        public bool IsArchived { get; }

        /// <summary>
        /// Gets whether the conversation is the workspace's "general" discussion channel (even if it's not named
        /// <c>#general</c> but it might be anyway). That might be important to your app because almost every user is a
        /// member.
        /// </summary>
        public bool IsGeneral { get; }

        /// <summary>
        /// if <c>true</c>, indicates the user or bot user or Slack app associated with the token making the API call
        /// is itself a member of the conversation.
        /// </summary>
        public bool IsMember { get; }

        /// <summary>
        /// If <c>true</c>, means the conversation is privileged between two or more members. Meet their privacy
        /// expectations.
        /// </summary>
        public bool IsPrivate { get; }

        /// <summary>
        /// If <c>true</c>, the conversation represents an unnamed private conversation between multiple users. It's an
        /// <see cref="IsPrivate"/> kind of thing.
        /// </summary>
        public bool IsMpim { get; }

        /// <summary>
        /// Gets information about the topic of the conversation.
        /// </summary>
        public SlackConversationTopic Topic { get; }

        /// <summary>
        /// Gets whether the conversation has a topic.
        /// </summary>
        public bool HasTopic => Topic != null && string.IsNullOrWhiteSpace(Topic.Value) == false;

        /// <summary>
        /// Gets information about the purpose of the conversation.
        /// </summary>
        public SlackConversationPurpose Purpose { get; }

        /// <summary>
        /// Gets whether the conversation has a purpose.
        /// </summary>
        public bool HasPurpose => Purpose != null && string.IsNullOrWhiteSpace(Purpose.Value) == false;

        /// <summary>
        /// Gets an array with names the conversation have had in the past.
        /// </summary>
        public string[] PreviousNames { get; }

        /// <summary>
        /// Gets the total amount of members in the conversation.
        /// </summary>
        public long NumMembers { get; }

        /// <summary>
        /// Gets the user associated with the conversation. This property is only returned for IM conversations.
        /// </summary>
        public string User { get; }

        /// <summary>
        /// Gets or sets whether the user behind the conversations has been deleted. This property is only returned for IM conversations.
        /// </summary>
        public bool IsUserDeleted { get; }

        /// <summary>
        /// Gets or sets the priority of the conversations. This property is only returned for IM conversations.
        /// </summary>
        public double Priority { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackConversation(JObject json) : base(json) {
            Id = json.GetString("id");
            Name = json.GetString("name");
            IsChannel = json.GetBoolean("is_channel");
            IsGroup = json.GetBoolean("is_group");
            IsIm = json.GetBoolean("is_im");
            Created = json.GetDouble("created", EssentialsTime.FromUnixTimestamp);
            Creator = json.GetString("creator");
            IsArchived = json.GetBoolean("is_archived");
            IsGeneral = json.GetBoolean("is_general");
            IsMember = json.GetBoolean("is_member");
            IsPrivate = json.GetBoolean("is_private");
            IsMpim = json.GetBoolean("is_mpim");
            Topic = json.GetObject("topic", SlackConversationTopic.Parse);
            Purpose = json.GetObject("purpose", SlackConversationPurpose.Parse);
            PreviousNames = json.GetStringArray("previous_names");
            NumMembers = json.GetInt64("num_members");
            User = json.GetString("user");
            IsUserDeleted = json.GetBoolean("is_user_deleted");
            Priority = json.GetDouble("priority");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SlackConversation"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackConversation"/>.</returns>
        public static SlackConversation Parse(JObject json) {
            return json == null ? null : new SlackConversation(json);
        }

        #endregion

    }

}