using Skybrud.Social.Slack.Endpoints.Raw;
using Skybrud.Social.Slack.Responses.Authentication;

namespace Skybrud.Social.Slack.Endpoints {

    /// <summary>
    /// Implementation of the authentication endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://api.slack.com/methods?filter=auth</cref>
    /// </see>
    public class SlackAuthenticationEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Slack service.
        /// </summary>
        public SlackHttpService Service { get; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public SlackAuthenticationRawEndpoint Raw => Service.Client.Authentication;

        #endregion

        #region Constructors

        internal SlackAuthenticationEndpoint(SlackHttpService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// This method checks authentication and tells "you" who you are, even if you might be a bot.
        ///
        /// You can also use this method to test whether Slack API authentication is functional.
        /// </summary>
        /// <returns>An instance of <see cref="SlackAuthenticationTestResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://api.slack.com/methods/auth.test</cref>
        /// </see>
        public SlackAuthenticationTestResponse GetTest() {
            return new SlackAuthenticationTestResponse(Raw.GetTest());
        }

        #endregion

    }

}