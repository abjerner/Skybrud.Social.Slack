using System;

namespace Skybrud.Social.Slack.Exceptions {

    /// <summary>
    /// Class representing a Slack exception.
    /// </summary>
    public class SlackException : Exception {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SlackException"/> class with a specified error <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public SlackException(string message) : base(message) { }

        #endregion

    }

}