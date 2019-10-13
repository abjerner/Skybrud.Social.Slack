using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;

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

    }

}