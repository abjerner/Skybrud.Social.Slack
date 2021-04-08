using Skybrud.Social.Slack.Endpoints.Raw;
using Skybrud.Social.Slack.Options.Users;
using Skybrud.Social.Slack.Responses.Users;

namespace Skybrud.Social.Slack.Endpoints {

    /// <summary>
    /// Implementation of the users endpoint.
    /// </summary>
    public class SlackUsersEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Slack service.
        /// </summary>
        public SlackService Service { get; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public SlackUsersRawEndpoint Raw => Service.Client.Users;

        #endregion

        #region Constructors

        internal SlackUsersEndpoint(SlackService service) {
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
        /// <returns>An instance of <see cref="SlackGetUserInfoResponse"/> representing the response.</returns>
        public SlackGetUserInfoResponse GetInfo(string userId) {
            return new SlackGetUserInfoResponse(Raw.GetInfo(userId));
        }

        /// <summary>
        /// Gets a list of all users in the team. This includes deleted/deactivated users.
        /// </summary>
        /// <see>
        ///     <cref>https://api.slack.com/methods/users.list</cref>
        /// </see>
        /// <returns>An instance of <see cref="SlackGetUserListResponse"/> representing the response.</returns>
        public SlackGetUserListResponse GetList() {
            return new SlackGetUserListResponse(Raw.GetList());
        }

        /// <summary>
        /// Gets a list of all users in the team. This includes deleted/deactivated users.
        /// </summary>
        /// <param name="presence">Specifies whether presence data should be included in the output.</param>
        /// <see>
        ///     <cref>https://api.slack.com/methods/users.list</cref>
        /// </see>
        /// <returns>An instance of <see cref="SlackGetUserListResponse"/> representing the response.</returns>
        public SlackGetUserListResponse GetUsers(bool presence) {
            return new SlackGetUserListResponse(Raw.GetList(presence));
        }

        /// <summary>
        /// Gets the presence of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="SlackGetUserPresenceResponse"/> representing the response.</returns>
        public SlackGetUserPresenceResponse GetPresence() {
            return new SlackGetUserPresenceResponse(Raw.GetPresence());
        }

        /// <summary>
        /// Gets the presence of the specified <paramref name="user"/>.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>An instance of <see cref="SlackGetUserPresenceResponse"/> representing the response.</returns>
        public SlackGetUserPresenceResponse GetPresence(string user)  {
            return new SlackGetUserPresenceResponse(Raw.GetPresence(user));
        }

        /// <summary>
        /// Gets the presence of the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="SlackGetUserPresenceResponse"/> representing the response.</returns>
        public SlackGetUserPresenceResponse GetPresence(SlackGetUserPresenceOptions options) {
            return new SlackGetUserPresenceResponse(Raw.GetPresence(options));
        }

        #endregion

    }

}