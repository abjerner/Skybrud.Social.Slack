using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Slack.Options.Users {

    /// <summary>
    /// Class representing the options to get the presence of a Slack user.
    /// </summary>
    public class SlackGetUserPresenceOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the user to get presence info on. Defaults to the authed user if not specified.
        /// </summary>
        public string User { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public SlackGetUserPresenceOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="user"/>.
        /// </summary>
        /// <param name="user">The user.</param>
        public SlackGetUserPresenceOptions(string user) {
            User = user;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            // Initialize the query string
            IHttpQueryString query = new HttpQueryString();

            // Append the user if specified
            if (string.IsNullOrWhiteSpace(User) == false) query.Add("user", User);

            // Make the request to the API
            HttpRequest request = HttpRequest.Get("/api/users.getPresence", query);

            return request;

        }

        #endregion

    }

}