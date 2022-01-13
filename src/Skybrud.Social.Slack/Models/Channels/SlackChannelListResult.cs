using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Slack.Models.Channels {
    
    /// <summary>
    /// Class representing a the response body with a list of Slack channels.
    /// </summary>
    public class SlackChannelListResult : SlackResult {

        #region Properties

        /// <summary>
        /// Gets an array with the channels of the response.
        /// </summary>
        public SlackChannel[] Channels { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackChannelListResult(JObject obj) : base(obj) {
            Channels = obj.GetArrayItems("channels", SlackChannel.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SlackChannelListResult"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackChannelListResult"/>.</returns>
        public static SlackChannelListResult Parse(JObject obj) {
            return obj == null ? null : new SlackChannelListResult(obj);
        }

        #endregion

    }

}