namespace Skybrud.Social.Slack.Models.Pins {

    /// <summary>
    /// Enum class indicating the type of a pinned item.
    /// </summary>
    public enum SlackPinnedType {

        /// <summary>
        /// Indicates that the pinned item is a message.
        /// </summary>
        Message,

        /// <summary>
        /// Indicates that the pinned item is a file.
        /// </summary>
        File,

        /// <summary>
        /// Indicates that the pinned item is a file comment.
        /// </summary>
        FileComment

    }

}