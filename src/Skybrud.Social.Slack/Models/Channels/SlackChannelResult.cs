using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Slack.Models.Channels {
    
    /// <summary>
    /// Class representing a the response body of a single Slack channel.
    /// </summary>
    public class SlackChannelResult : SlackResult {

        #region Properties

        /// <summary>
        /// Gets a reference to the channel from the response body.
        /// </summary>
        public SlackChannel Channel { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackChannelResult(JObject obj) : base(obj) {
            Channel = obj.GetObject("channel", SlackChannel.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SlackChannelResult"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackChannelResult"/>.</returns>
        public static SlackChannelResult Parse(JObject obj) {
            return obj == null ? null : new SlackChannelResult(obj);
        }

        #endregion

    }

}