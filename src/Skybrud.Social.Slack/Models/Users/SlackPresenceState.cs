namespace Skybrud.Social.Slack.Models.Users {

    /// <summary>
    /// Enum class representing the presence status of a <see cref="SlackUser"/>.
    /// </summary>
    public enum SlackPresenceState {

        /// <summary>
        /// Indicates that the presence wasn't specified.
        /// </summary>
        Unspecified,

        /// <summary>
        /// Indicates that the user is currently active.
        /// </summary>
        Active,

        /// <summary>
        /// Indicates that the user is currently away.
        /// </summary>
        Away

    }

}