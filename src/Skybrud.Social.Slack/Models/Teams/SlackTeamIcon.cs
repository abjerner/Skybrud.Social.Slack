using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Slack.Models.Teams {
    
    /// <summary>
    /// Class representing icon details of a Slack team.
    /// </summary>
    public class SlackTeamIcon : SlackObject {

        #region Properties

        /// <summary>
        /// Gets the URL to a version the team's icon measuring 34x34 pixels.
        /// </summary>
        public string Image34 { get; }

        /// <summary>
        /// Gets the URL to a version the team's icon measuring 44x34 pixels.
        /// </summary>
        public string Image44 { get; }

        /// <summary>
        /// Gets the URL to a version the team's icon measuring 68x68 pixels.
        /// </summary>
        public string Image68 { get; }

        /// <summary>
        /// Gets the URL to a version the team's icon measuring 88x88 pixels.
        /// </summary>
        public string Image88 { get; }

        /// <summary>
        /// Gets the URL to a version the team's icon measuring 102x102 pixels.
        /// </summary>
        public string Image102 { get; }

        /// <summary>
        /// Gets the URL to a version the team's icon measuring 132x1324 pixels.
        /// </summary>
        public string Image132 { get; }

        /// <summary>
        /// Gets the URL to a version the team's icon measuring 230x230 pixels.
        /// </summary>
        public string Image230 { get; }

        /// <summary>
        /// Gets the URL to the original image used for the team's icon.
        /// </summary>
        public string ImageOriginal { get; }

        /// <summary>
        /// Gets whether the team is using the default Slack icon.
        /// </summary>
        public bool IsImageDefault { get; }

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
            IsImageDefault = obj.GetBoolean("image_default");
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