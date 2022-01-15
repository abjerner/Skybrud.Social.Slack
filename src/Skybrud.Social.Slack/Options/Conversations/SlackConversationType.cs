namespace Skybrud.Social.Slack.Options.Conversations {
    
    /// <summary>
    /// Enum class indicating the types of conversations to be returned.
    /// </summary>
    public enum SlackConversationType {

        /// <summary>
        /// Indicates that public channels should be returned.
        /// </summary>
        PublicChannel,
        
        /// <summary>
        /// Indicates that private channels should be returned.
        /// </summary>
        PrivateChannel,
        
        /// <summary>
        /// Indicates that direct conversations between two users should be returned.
        /// </summary>
        Mpim,
        
        /// <summary>
        /// Indicates that multiple person conversations should be returned.
        /// </summary>
        Im

    }

}