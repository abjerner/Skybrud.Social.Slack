using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;
using Skybrud.Essentials.Strings;
using Skybrud.Social.Slack.Models.Common;

namespace Skybrud.Social.Slack.Models {

    /// <summary>
    /// Class representing a basic object from the Slack API, derived from an instance of <see cref="JObject"/>.
    /// </summary>
    public class SlackObject : JsonObjectBase {

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        protected SlackObject(JObject obj) : base(obj) { }

        #endregion

        #region Member methods

        /// <summary>
        /// Converts the specified string <paramref name="value"/> into an instance of <see cref="SlackBoolean"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        /// <returns>An instance of <see cref="SlackBoolean"/>.</returns>
        protected SlackBoolean ParseBoolean(string value)  {

            if (StringUtils.TryParseBoolean(value, out bool result)) {
                return result ? SlackBoolean.True : SlackBoolean.False;
            }

            return SlackBoolean.Unspecified;

        }

        #endregion

    }

}