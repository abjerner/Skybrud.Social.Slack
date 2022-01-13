using Skybrud.Social.Slack.Endpoints.Raw;
using Skybrud.Social.Slack.Responses.Emojis;

namespace Skybrud.Social.Slack.Endpoints {

    /// <summary>
    /// Implementation of the <strong>Emojis</strong> endpoint.
    /// </summary>
    public class SlackEmojisEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Slack service.
        /// </summary>
        public SlackHttpService Service { get; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public SlackEmojisRawEndpoint Raw => Service.Client.Emojis;

        #endregion

        #region Constructors

        internal SlackEmojisEndpoint(SlackHttpService service) {
            Service = service;
        }

        #endregion

        #region Member methods


        /// <summary>
        /// Gets a list of custom emojis for a team.
        /// </summary>
        /// <returns>An instance of <see cref="SlackEmojiListResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://api.slack.com/methods/emoji.list</cref>
        /// </see>
        public SlackEmojiListResponse GetList() {
            return new SlackEmojiListResponse(Raw.GetList());
        }

        #endregion

    }

}