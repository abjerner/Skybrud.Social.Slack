using System;
using Skybrud.Essentials.Http;

namespace Skybrud.Social.Slack.Exceptions {

    /// <summary>
    /// Class representing an exception based on an error from the Slack API.
    /// </summary>
    public class SlackHttpException : Exception {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <see cref="IHttpResponse"/>.
        /// </summary>
        public IHttpResponse Response { get; }

        /// <summary>
        /// Gets the error returned by the Slack API.
        /// </summary>
        public string Error { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new exception based on the specified parameters.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="error">The error.</param>
        public SlackHttpException(IHttpResponse response, string error) : base("Invalid response received from the Slack API: " + error) {
            Response = response;
            Error = error;
        }

        #endregion

    }

}