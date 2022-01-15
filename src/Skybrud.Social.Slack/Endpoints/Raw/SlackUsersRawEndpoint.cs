using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Slack.OAuth;
using Skybrud.Social.Slack.Options.Users;

namespace Skybrud.Social.Slack.Endpoints.Raw {
    
    /// <summary>
    /// Raw implementation of the users endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://api.slack.com/methods?filter=users</cref>
    /// </see>
    public class SlackUsersRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public SlackOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal SlackUsersRawEndpoint(SlackOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about a team member.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://api.slack.com/methods/users.info</cref>
        /// </see>
        public IHttpResponse GetInfo(string userId) {
            if (string.IsNullOrWhiteSpace(userId)) throw new ArgumentNullException(nameof(userId));
            return Client.Get($"/api/users.info?user={userId}");
        }

        /// <summary>
        /// Gets a list of all users in the team. This includes deleted/deactivated users.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://api.slack.com/methods/users.list</cref>
        /// </see>
        public IHttpResponse GetList() {
            return GetList(new SlackListUserOptions());
        }

        /// <summary>
        /// Gets a list of all users matching the specified <paramref name="options"/>.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://api.slack.com/methods/users.list</cref>
        /// </see>
        public IHttpResponse GetList(SlackListUserOptions options) {
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Gets the presence of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetPresence() {
            return GetPresence(new SlackGetUserPresenceOptions());
        }

        /// <summary>
        /// Gets the presence of the specified <paramref name="user"/>.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetPresence(string user)  {
            if (string.IsNullOrWhiteSpace(user)) throw new ArgumentNullException(nameof(user));
            return GetPresence(new SlackGetUserPresenceOptions(user));
        }

        /// <summary>
        /// Gets the presence of the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetPresence(SlackGetUserPresenceOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options)); 
            return Client.GetResponse(options);
        }

        #endregion

    }

}