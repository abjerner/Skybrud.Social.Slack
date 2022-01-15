using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Slack.Models.Pins {

    /// <summary>
    /// Class representing a pinned item.
    /// </summary>
    /// <see>
    ///     <cref>https://api.slack.com/methods/pins.list</cref>
    /// </see>
    public class SlackPinnedItem : SlackObject {

        #region Properties

        /// <summary>
        /// Gets the channel.
        /// </summary>
        public string Channel { get; }

        /// <summary>
        /// Gets a timestamp for when the item was pinned.
        /// </summary>
        public EssentialsTime Created { get; }

        /// <summary>
        /// Gets the ID of the user who pinned the item.
        /// </summary>
        public string CreatedBy { get; }

        /// <summary>
        /// Gets information about the pinned message.
        /// </summary>
        public SlackPinnedMessage Message { get; }

        /// <summary>
        /// Gets the type of the item.
        /// </summary>
        public SlackPinnedType Type { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the pinned item.</param>
        protected SlackPinnedItem(JObject json) : base(json) {
            Channel = json.GetString("channel");
            Created = json.GetInt32("created", EssentialsTime.FromUnixTimestamp);
            CreatedBy = json.GetString("created_by");
            Message = json.GetObject("message", SlackPinnedMessage.Parse);
            Type = json.GetEnum<SlackPinnedType>("type");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SlackPinnedItem"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackPinnedItem"/>.</returns>
        public static SlackPinnedItem Parse(JObject json) {
            return json == null ? null : new SlackPinnedItem(json);
        }

        #endregion

    }

}