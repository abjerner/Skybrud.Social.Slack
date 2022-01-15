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
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackChannelResult(JObject json) : base(json) {
            Channel = json.GetObject("channel", SlackChannel.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SlackChannelResult"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackChannelResult"/>.</returns>
        public static SlackChannelResult Parse(JObject json) {
            return json == null ? null : new SlackChannelResult(json);
        }

        #endregion

    }

}