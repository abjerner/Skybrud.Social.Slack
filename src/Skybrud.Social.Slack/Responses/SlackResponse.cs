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

        protected SlackResponse(IHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Validates the specified <code>response</code>.
        /// </summary>
        /// <param name="response">The response to be validated.</param>
        public static void ValidateResponse(IHttpResponse response) {

            // The Slack API will always return a "200 OK" status even when an error is returned, so we need to check
            // the "ok" property in the boolean instead

            // Get root object
            JObject obj = JsonUtils.ParseJsonObject(response.Body);

            // Is the request/response successful?
            bool isOk = obj.GetBoolean("ok");
                
            // Now throw some exceptions
            if (!isOk) throw new SlackHttpException(response, obj.GetString("error"));

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

        protected SlackResponse(IHttpResponse response) : base(response) { }

        #endregion

    }

}