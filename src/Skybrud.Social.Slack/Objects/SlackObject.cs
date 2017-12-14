using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;

namespace Skybrud.Social.Slack.Objects {
    
    public class SlackObject : JsonObjectBase {

        #region Constructors

        protected SlackObject(JObject obj) : base(obj) { }

        #endregion

    }

}