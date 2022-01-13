using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Slack.Options.Pins {
    
    /// <summary>
    /// Options for getting a list of pins in a Slack channel.
    /// </summary>
    /// <see>
    ///     <cref>https://api.slack.com/methods/pins.list</cref>
    /// </see>
    public class SlackGetPinListOptions : IHttpRequestOptions {
        
        #region Properties

        /// <summary>
        /// Gets or sets the channel to get pinned items for.
        /// </summary>
        public string Channel { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public SlackGetPinListOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="channel"/>.
        /// </summary>
        /// <param name="channel">The channel to get pinned items for.</param>
        public SlackGetPinListOptions(string channel) {
            Channel = channel;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {
            if (string.IsNullOrWhiteSpace(Channel)) throw new PropertyNotSetException(nameof(Channel));
            return HttpRequest.Get("/api/pins.list", new HttpQueryString {{"channel", Channel}});
        }

        #endregion

    }

}