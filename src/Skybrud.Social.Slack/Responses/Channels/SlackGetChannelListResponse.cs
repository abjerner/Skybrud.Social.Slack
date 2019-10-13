using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Social.Slack.Models.Channels;

namespace Skybrud.Social.Slack.Responses.Channels {

    public class SlackGetChannelListResponse : SlackResponse<SlackChannelListResponseBody> {

        #region Constructors

        private SlackGetChannelListResponse(IHttpResponse response) : base(response) {
            ValidateResponse(response, out JObject body);
            Body = SlackChannelListResponseBody.Parse(body);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="SlackGetChannelListResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="SlackGetChannelListResponse"/> representing the response.</returns>
        public static SlackGetChannelListResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new SlackGetChannelListResponse(response);
        }

        #endregion

    }

}