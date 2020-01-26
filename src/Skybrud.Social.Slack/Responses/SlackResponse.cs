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
        protected SlackResponse(IHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Validates the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The response to be validated.</param>
        /// <param name="obj">A JSON object parsed from the response body.</param>
        protected void ValidateResponse(IHttpResponse response, out JObject obj) {

            // The Slack API will always return a "200 OK" status even when an error is returned, so we need to check
            // the "ok" property in the boolean instead

            // Get root object
            obj = JsonUtils.ParseJsonObject(response.Body);

            // Is the request/response successful?
            bool isOk = obj.GetBoolean("ok");
                
            // Now throw some exceptions
            if (!isOk) throw new SlackHttpException(response, obj.GetString("error"));

        }

        /// <summary>
        /// Validates the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The response to be validated.</param>
        protected void ValidateResponse(IHttpResponse response) {
            ValidateResponse(response, out _);
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

        #endregion

    }

}