using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Social.Slack.Models.Chat;

namespace Skybrud.Social.Slack.Responses.Chat {

    /// <summary>
    /// Class representing the response received when posting a new message to the Slack API.
    /// </summary>
    public class SlackPostMessageResponse : SlackResponse<SlackPostMessageResponseBody> {

        #region Constructors

        private SlackPostMessageResponse(IHttpResponse response) : base(response) {
            ValidateResponse(response, out JObject body);
            Body = SlackPostMessageResponseBody.Parse(body);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="SlackPostMessageResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="SlackPostMessageResponse"/> representing the response.</returns>
        public static SlackPostMessageResponse Parse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new SlackPostMessageResponse(response);
        }

        #endregion

    }

}