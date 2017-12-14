using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Slack.Objects {
    
    public class SlackRootObject : SlackObject {

        #region Properties

        /// <summary>
        /// Gets whether the request/response was successful.
        /// </summary>
        public bool IsOk { get; private set; }

        #endregion

        #region Constructors

        protected SlackRootObject(JObject obj) : base(obj) {
            IsOk = obj.GetBoolean("ok");
        }

        #endregion

    }

}