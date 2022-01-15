namespace Skybrud.Social.Slack.Models.Common {

    /// <summary>
    /// Enum class representing a boolean value that may be either <see cref="Unspecified"/>, <see cref="True"/> or <see cref="False"/>.
    /// </summary>
    public enum SlackBoolean {

        /// <summary>
        /// Indicates that a value wasn't specified.
        /// </summary>
        Unspecified,

        /// <summary>
        /// Indicates a <c>false</c> boolean value.
        /// </summary>
        False,

        /// <summary>
        /// Indicates a <c>true</c> boolean value.
        /// </summary>
        True

    }

}