using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Slack.Models.Teams {
    
    /// <summary>
    /// Class representing icon details of a Slack team.
    /// </summary>
    public class SlackTeamIcon : SlackObject {

        #region Properties

        public string Image34 { get; }

        public string Image44 { get; }

        public string Image68 { get; }

        public string Image88 { get; }

        public string Image102 { get; }

        public string Image132 { get; }

        public string Image230 { get; }

        public string ImageOriginal { get; }

        public bool ImageDefault { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackTeamIcon(JObject obj) : base(obj) {
            Image34 = obj.GetString("image_34");
            Image44 = obj.GetString("image_44");
            Image68 = obj.GetString("image_68");
            Image88 = obj.GetString("image_88");
            Image102 = obj.GetString("image_102");
            Image132 = obj.GetString("image_132");
            Image230 = obj.GetString("image_230");
            ImageOriginal = obj.GetString("image_original");
            ImageDefault = obj.GetBoolean("image_default");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SlackTeamIcon"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackTeamIcon"/>.</returns>
        public static SlackTeamIcon Parse(JObject obj) {
            return obj == null ? null : new SlackTeamIcon(obj);
        }

        #endregion

    }

}