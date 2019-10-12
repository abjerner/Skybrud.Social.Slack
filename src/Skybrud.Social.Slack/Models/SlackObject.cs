using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;

namespace Skybrud.Social.Slack.Models {

    /// <summary>
    /// Class representing a basic object from the Slack API, derived from an instance of <see cref="JObject"/>.
    /// </summary>
    public class SlackObject : JsonObjectBase {

        #region Constructors

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SlackObject"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SlackObject"/>.</returns>
        protected SlackObject(JObject obj) : base(obj) { }

        #endregion

    }

}