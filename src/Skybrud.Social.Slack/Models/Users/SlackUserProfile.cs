using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Slack.Models.Users {
    
    /// <summary>
    /// Class representing the profile part of a <see cref="SlackUser"/>.
    /// </summary>
    /// <see>
    ///     <cref>https://api.slack.com/methods/users.profile.get</cref>
    /// </see>
    public class SlackUserProfile : SlackObject {

        #region Properties

        /// <summary>
        /// Gets the job title of the user, or an empty string if not specified.
        /// </summary>
        public string Title { get; }
        
        /// <summary>
        /// Gets whether the user has specified a job title.
        /// </summary>
        public bool HasTitle => !string.IsNullOrWhiteSpace(Title);

        /// <summary>
        /// Gets the phone number of the user, or <c>null</c> if not specified.
        /// </summary>
        public string Phone { get; }

        /// <summary>
        /// Gets whether the user has specified a phone number.
        /// </summary>
        public bool HasPhone => !string.IsNullOrWhiteSpace(Phone);

        /// <summary>
        /// Gets the Skype name of the user, or <c>null</c> if not specified.
        /// </summary>
        public string Skype { get; }

        /// <summary>
        /// Gets whether the user has specified a Skype name.
        /// </summary>
        public bool HasSkype => !string.IsNullOrWhiteSpace(Skype);

        /// <summary>
        /// Gets the real name of the user.
        /// </summary>
        public string RealName { get; }

        /// <summary>
        /// Gets the normalized real name of the user.
        /// </summary>
        public string RealNameNormalized { get; }

        /// <summary>
        /// Gets whether the user has a real name.
        /// </summary>
        public bool HasRealName => !string.IsNullOrWhiteSpace(RealName);

        /// <summary>
        /// Gets the display name of the user.
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        /// Gets the normalized display name of the user.
        /// </summary>
        public string DisplayNameNormalized { get; }

        /// <summary>
        /// Gets whether the user has entered as display name.
        /// </summary>
        public bool HasDisplayName => !string.IsNullOrWhiteSpace(DisplayName);

        /// <summary>
        /// Gets the status text of the user.
        /// </summary>
        public string StatusText { get; }
        
        /// <summary>
        /// Gets whether the user has specified a status text.
        /// </summary>
        public bool HasStatusText => !string.IsNullOrWhiteSpace(StatusText);

        /// <summary>
        /// Gets the status emoji of the user.
        /// </summary>
        public string StatusEmoji { get; }

        /// <summary>
        /// Gets whether the user has specified a status emoji.
        /// </summary>
        public bool HasStatusEmoji => !string.IsNullOrWhiteSpace(StatusEmoji);

        /// <summary>
        ///  If the user's status is set to automatically expire, this provides the specific time.
        /// </summary>
        public EssentialsTime StatusExpiration { get; }

        /// <summary>
        /// Gets the avatar hash of the user.
        /// </summary>
        public string AvatarHash { get; }

        /// <summary>
        /// Gets the original version of the user's profile image (not cropped or resized).
        /// </summary>
        public string ImageOriginal { get; }

        /// <summary>
        /// Gets whether the user upload a custom profile image.
        /// </summary>
        public bool IsCustomImage { get; }
        
        /// <summary>
        /// Gets the email address of the user.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Gets the first name of the user.
        /// </summary>
        /// <remarks>Slack requires the user to enter their full name, where the first word appears to be treated as
        /// the first name, while the remaining words are treated as the last name. This means that all users have a
        /// first name, but not necessarily a last name.</remarks>
        public string FirstName { get; }

        /// <summary>
        /// Gets the last name of the user.
        /// </summary>
        /// <remarks>Slack requires the user to enter their full name, where the first word appears to be treated as
        /// the first name, while the remaining words are treated as the last name. This means that all users have a
        /// first name, but not necessarily a last name.</remarks>
        public string LastName { get; }

        /// <summary>
        /// Gets whether the user has entered a last name.
        /// </summary>
        public bool HasLastName => !string.IsNullOrWhiteSpace(LastName);

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
        /// Gets the URL of the profile image in 512x512 pixels.
        /// </summary>
        public string Image512 { get; }

        /// <summary>
        /// Gets the URL of the profile image in 1024x1024 pixels.
        /// </summary>
        public string Image1024 { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the object.</param>
        protected SlackUserProfile(JObject json) : base(json) {
            
            Title = json.GetString("title");
            Phone = json.GetString("phone");
            Skype = json.GetString("skype");

            RealName = json.GetString("real_name");
            RealNameNormalized = json.GetString("real_name_normalized");

            DisplayName = json.GetString("display_name");
            DisplayNameNormalized = json.GetString("display_name_normalized");

            // TODO: Add support for the "fields" property

            StatusText = json.GetString("status_text");
            StatusEmoji = json.GetString("status_emoji");
            StatusExpiration = json.GetInt32("status_expiration", x => x == 0 ? null : EssentialsTime.FromUnixTimestamp(x));

            AvatarHash = json.GetString("avatar_hash");
            ImageOriginal = json.GetString("image_original");
            IsCustomImage = json.GetBoolean("is_custom_image");
            
            Email = json.GetString("email");
            FirstName = json.GetString("first_name");
            LastName = json.GetString("last_name");

            Image24 = json.GetString("image_24");
            Image32 = json.GetString("image_32");
            Image48 = json.GetString("image_48");
            Image72 = json.GetString("image_72");
            Image192 = json.GetString("image_192");
            Image512 = json.GetString("image_512");
            Image1024 = json.GetString("image_1024");

            // TODO: Add support for the "status_text_canonical" property

            // TODO: Add support for the "team" property

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SlackUserProfile"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackUserProfile"/>.</returns>
        public static SlackUserProfile Parse(JObject json) {
            return json == null ? null : new SlackUserProfile(json);
        }

        #endregion

    }

}