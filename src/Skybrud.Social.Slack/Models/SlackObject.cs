using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Time;
using Skybrud.Social.Slack.Models.Common;

namespace Skybrud.Social.Slack.Models {

    /// <summary>
    /// Class representing a basic object from the Slack API, derived from an instance of <see cref="JObject"/>.
    /// </summary>
    public class SlackObject : JsonObjectBase {

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        protected SlackObject(JObject json) : base(json) { }

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

        /// <summary>
        /// Parses the specified UNIX timestamp <paramref name="value"/> into a corresponding <see cref="EssentialsTime"/> instance. If <paramref name="value"/> is lower than or equal to <c>0</c>, <c>null</c> is returned instead.
        /// </summary>
        /// <param name="value">The UNIX timestamp value.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public EssentialsTime ParseUnixTimestamp(long value) {
            return value < 1 ? null : EssentialsTime.FromUnixTimestamp(value);
        } 

        #endregion

    }

}