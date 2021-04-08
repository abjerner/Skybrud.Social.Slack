using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Json;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Slack.Exceptions;
using Skybrud.Social.Slack.Models;

namespace Skybrud.Social.Slack.Responses {

    /// <summary>
    /// Class representing a response from the Slack API.
    /// </summary>
    public abstract class SlackResponse : HttpResponseBase {

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The response.</param>
        protected SlackResponse(IHttpResponse response) : base(response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
        }

        #endregion

    }

    /// <summary>
    /// Class representing a response from the Slack API.
    /// </summary>
    public class SlackResponse<T> : SlackResponse where T : SlackObject {

        #region Properties

        /// <summary>
        /// Gets the body of the response.
        /// </summary>
        public T Body { get; protected set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The response.</param>
        protected SlackResponse(IHttpResponse response) : base(response) { }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response from the Slack API.</param>
        /// <param name="json">The JSON object parsed from the response body.</param>
        protected SlackResponse(IHttpResponse response, out JObject json) : base(response) {

            // The Slack API will always return a "200 OK" status even when an error is returned, so we need to check
            // the "ok" property in the boolean instead

            // Get root object
            json = JsonUtils.ParseJsonObject(response.Body);

            // Is the request/response successful?
            bool isOk = json.GetBoolean("ok");

            // Now throw some exceptions
            if (!isOk) throw new SlackHttpException(response, json.GetString("error"));

        }

        #endregion

    }

}