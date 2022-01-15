using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Strings;
using Skybrud.Social.Slack.Options.Chat;
using Skybrud.Social.Slack.Scopes;

namespace Skybrud.Social.Slack {

    /// <summary>
    /// Class with various utility and helper methods for working with the Slack API.
    /// </summary>
    public static class SlackUtils {

        /// <summary>
        /// Posts a message to the specified <paramref name="webhookUrl"/>.
        /// </summary>
        /// <param name="webhookUrl">The webhook URL.</param>
        /// <param name="options">The options describing the message.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response from the API.</returns>
        /// <see>
        ///     <cref>https://api.slack.com/messaging/webhooks</cref>
        /// </see>
        public static IHttpResponse PostMessage(string webhookUrl, SlackPostMessageOptions options) {

            if (string.IsNullOrWhiteSpace(webhookUrl)) throw new ArgumentNullException(nameof(webhookUrl));
            if (options == null) throw new ArgumentNullException(nameof(options));

            // Initialize the request
            HttpRequest request = new HttpRequest {
                Url = webhookUrl,
                Method = HttpMethod.Post,
                ContentType = "application/x-www-form-urlencoded"
            };

            // Append the message to the POST body
            request.PostData.Add("payload", JsonConvert.SerializeObject(options));

            // Make the request to the webhook
            return request.GetResponse();

        }

        internal static IEnumerable<SlackScope> GetScopesFromType(Type type) {
            return from field in type.GetRuntimeFields() where field.FieldType == typeof(SlackScope) select (SlackScope) field.GetValue(null);
        }

        /// <summary>
        /// Converts the specified enum values to a lower case string with words separated by underscores. If values
        /// contains more than one enum value, the names will be separated by commas.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="values">The enum values to be converted.</param>
        /// <returns>The converted string.</returns>
        public static string ToString<T>(IEnumerable<T> values) where T : Enum {
            return StringUtils.ToUnderscore(values);
        }

    }

}