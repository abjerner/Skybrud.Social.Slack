using Skybrud.Social.Slack.Endpoints.Raw;
using Skybrud.Social.Slack.Responses.Channels;

namespace Skybrud.Social.Slack.Endpoints {

    /// <summary>
    /// Implementation of the <strong>Channels</strong> endpoint.
    /// </summary>
    public class SlackChannelsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Slack service.
        /// </summary>
        public SlackHttpService Service { get; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public SlackChannelsRawEndpoint Raw => Service.Client.Channels;

        #endregion

        #region Constructors

        internal SlackChannelsEndpoint(SlackHttpService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about a channel.
        /// </summary>
        /// <param name="channel">The ID of the channel.</param>
        /// <see>
        ///     <cref>https://api.slack.com/methods/channels.info</cref>
        /// </see>
        /// <returns>An instance of <see cref="SlackChannelResponse"/> representing the response.</returns>
        public SlackChannelResponse GetInfo(string channel) {
            return new SlackChannelResponse(Raw.GetInfo(channel));
        }

        /// <summary>
        /// Gets a list of all channels in the team.
        /// </summary>
        /// <see>
        ///     <cref>https://api.slack.com/methods/channels.list</cref>
        /// </see>
        /// <returns>An instance of <see cref="SlackChannelListResponse"/> representing the response.</returns>
        public SlackChannelListResponse GetList() {
            return new SlackChannelListResponse(Raw.GetList());
        }

        #endregion

    }

}