using Skybrud.Social.Slack.Endpoints.Raw;
using Skybrud.Social.Slack.Options.Users;
using Skybrud.Social.Slack.Responses.Users;

namespace Skybrud.Social.Slack.Endpoints {

    /// <summary>
    /// Implementation of the users endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://api.slack.com/methods?filter=users</cref>
    /// </see>
    public class SlackUsersEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Slack service.
        /// </summary>
        public SlackHttpService Service { get; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public SlackUsersRawEndpoint Raw => Service.Client.Users;

        #endregion

        #region Constructors

        internal SlackUsersEndpoint(SlackHttpService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about a team member.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <see>
        ///     <cref>https://api.slack.com/methods/users.info</cref>
        /// </see>
        /// <returns>An instance of <see cref="SlackUserResponse"/> representing the response.</returns>
        public SlackUserResponse GetInfo(string userId) {
            return new SlackUserResponse(Raw.GetInfo(userId));
        }

        /// <summary>
        /// Gets a list of all users in the team. This includes deleted/deactivated users.
        /// </summary>
        /// <see>
        ///     <cref>https://api.slack.com/methods/users.list</cref>
        /// </see>
        /// <returns>An instance of <see cref="SlackUserListResponse"/> representing the response.</returns>
        public SlackUserListResponse GetList() {
            return new SlackUserListResponse(Raw.GetList());
        }

        /// <summary>
        /// Gets a list of all users matching the specified <paramref name="options"/>.
        /// </summary>
        /// <returns>An instance of <see cref="SlackUserListResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://api.slack.com/methods/users.list</cref>
        /// </see>
        public SlackUserListResponse GetList(SlackListUserOptions options) {
            return new SlackUserListResponse(Raw.GetList(options));
        }

        /// <summary>
        /// Gets the presence of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="SlackUserPresenceResponse"/> representing the response.</returns>
        public SlackUserPresenceResponse GetPresence() {
            return new SlackUserPresenceResponse(Raw.GetPresence());
        }

        /// <summary>
        /// Gets the presence of the specified <paramref name="user"/>.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>An instance of <see cref="SlackUserPresenceResponse"/> representing the response.</returns>
        public SlackUserPresenceResponse GetPresence(string user)  {
            return new SlackUserPresenceResponse(Raw.GetPresence(user));
        }

        /// <summary>
        /// Gets the presence of the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="SlackUserPresenceResponse"/> representing the response.</returns>
        public SlackUserPresenceResponse GetPresence(SlackGetUserPresenceOptions options) {
            return new SlackUserPresenceResponse(Raw.GetPresence(options));
        }

        #endregion

    }

}