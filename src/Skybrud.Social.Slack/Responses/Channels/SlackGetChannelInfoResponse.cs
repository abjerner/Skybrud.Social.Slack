using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Social.Slack.Models.Channels;

namespace Skybrud.Social.Slack.Responses.Channels {

    public class SlackGetChannelInfoResponse : SlackResponse<SlackChannelResponseBody> {

        #region Constructors

        private SlackGetChannelInfoResponse(IHttpResponse response) : base(response) {
            ValidateResponse(response, out JObject body);
            Body = SlackChannelResponseBody.Parse(body);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="SlackGetChannelInfoResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="SlackGetChannelInfoResponse"/> representing the response.</returns>
        public static SlackGetChannelInfoResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new SlackGetChannelInfoResponse(response);
        }

        #endregion

    }

}