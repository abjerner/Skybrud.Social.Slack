using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Slack.Models.Users {
    
    /// <summary>
    /// Class representing the profile part of a <see cref="SlackUser"/>.
    /// </summary>
    public class SlackUserProfile : SlackObject {

        #region Properties

        /// <summary>
        /// Gets the first name of the user.
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Gets the last name of the user.
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// Gets the job title of the user, or <c>null</c> if not specified.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Gets the real name of the user.
        /// </summary>
        public string RealName { get; }

        /// <summary>
        /// Gets the normalized real name of the user.
        /// </summary>
        public string RealNameNormalized { get; }

        /// <summary>
        /// Gets the email address of the user.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Gets the Skype name of the user, or <c>null</c> if not specified.
        /// </summary>
        public string Skype { get; }

        /// <summary>
        /// Gets the phone number of the user, or <c>null</c> if not specified.
        /// </summary>
        public string Phone { get; }

        /// <summary>
        /// Gets the URL of the profile image in 24x24 pixels.
        /// </summary>
        public string Image24 { get; }

        /// <summary>
        /// Gets the URL of the profile image in 32x32 pixels.
        /// </summary>
        public string Image32 { get; }

        /// <summary>
        /// Gets the URL of the profile image in 48x48 pixels.
        /// </summary>
        public string Image48 { get; }

        /// <summary>
        /// Gets the URL of the profile image in 72x72 pixels.
        /// </summary>
        public string Image72 { get; }

        /// <summary>
        /// Gets the URL of the profile image in 192x192 pixels.
        /// </summary>
        public string Image192 { get; }

        /// <summary>
        /// Gets whether the user has specified a job title.
        /// </summary>
        public bool HasTitle => !string.IsNullOrWhiteSpace(Title);

        /// <summary>
        /// Gets whether the user has specified a Skype name.
        /// </summary>
        public bool HasSkype => !string.IsNullOrWhiteSpace(Skype);

        /// <summary>
        /// Gets whether the user has specified a phone number.
        /// </summary>
        public bool HasPhone => !string.IsNullOrWhiteSpace(Phone);

        #endregion

        #region Constructors
        
        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackUserProfile(JObject obj) : base(obj) {
            FirstName = obj.GetString("first_name");
            LastName = obj.GetString("last_name");
            Title = obj.GetString("title");
            RealName = obj.GetString("real_name");
            RealNameNormalized = obj.GetString("real_name_normalized");
            Email = obj.GetString("email");
            Skype = obj.GetString("skype");
            Phone = obj.GetString("phone");
            Image24 = obj.GetString("image_24");
            Image32 = obj.GetString("image_32");
            Image48 = obj.GetString("image_48");
            Image72 = obj.GetString("image_72");
            Image192 = obj.GetString("image_192");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="SlackUserProfile"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackUserProfile"/>.</returns>
        public static SlackUserProfile Parse(JObject obj) {
            return obj == null ? null : new SlackUserProfile(obj);
        }

        #endregion

    }

}