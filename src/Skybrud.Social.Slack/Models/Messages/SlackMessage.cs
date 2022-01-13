using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Slack.Models.Messages {
    
    /// <summary>
    /// Class representing a Slack message.
    /// </summary>
    public class SlackMessage : SlackObject {

        #region Properties
        
        /// <summary>
        /// Gets the main text of the message.
        /// </summary>
        public string Text { get; }

        // files

        // upload

        /// <summary>
        /// Gets the ID of the user who posted the message.
        /// </summary>
        public string User { get; }

        // display_as_bot

        // x_files

        public EssentialsTime Timestamp { get; }

        // team

        // attachments

        // blocks

        // thread_ts

        // parent_user_id

        /// <summary>
        /// Gets the IDs of the channel to which this message has been pinned.
        /// </summary>
        public string[] PinnedTo { get; }

        // reactions

        /// <summary>
        /// Gets the permalink to the message.
        /// </summary>
        public string Permalink { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackMessage(JObject obj) : base(obj) {
            // TODO: Add support for the "type" property
            Text = obj.GetString("text");
            // TODO: Add support for the "files" property
            // TODO: Add support for the "upload" property
            User = obj.GetString("user");
            // TODO: Add support for the "display_as_bot" property
            // TODO: Add support for the "x_files" property
            Timestamp = obj.GetDouble("ts", EssentialsTime.FromUnixTimestamp);
            // TODO: Add support for the "attachments" property
            // TODO: Add support for the "blocks" property
            // TODO: Add support for the "thread_ts" property
            // TODO: Add support for the "parent_user_id" property
            PinnedTo = obj.GetStringArray("pinned_to");
            // TODO: Add support for the "reactions" property
            Permalink = obj.GetString("permalink");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SlackMessage"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackMessage"/>.</returns>
        public static SlackMessage Parse(JObject obj) {
            return obj == null ? null : new SlackMessage(obj);
        }

        #endregion

    }

}