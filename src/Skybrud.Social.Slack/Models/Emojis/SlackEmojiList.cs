using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Slack.Models.Emojis {

    /// <summary>
    /// Class representing a list of custom emojis.
    /// </summary>
    /// <see>
    ///     <cref>https://api.slack.com/methods/emoji.list</cref>
    /// </see>
    public class SlackEmojiList : SlackObject, IEnumerable<KeyValuePair<string, string>> {

        private readonly Dictionary<string, string> _emojis;

        #region Properties

        /// <summary>
        /// Gets the number of custom emojis in the list.
        /// </summary>
        public int Count => _emojis.Count;

        /// <summary>
        /// Gets a collection containing the keys in the <see cref="SlackEmojiList"/>.
        /// </summary>
        public Dictionary<string, string>.KeyCollection Keys => _emojis.Keys;

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value associated with the specified key. If the specified key is not found, a get operation
        /// throws a <see cref="KeyNotFoundException"/>.</returns>
        /// <exception cref="KeyNotFoundException">The property is retrieved and <paramref name="key"/> does not exist in the collection.</exception>
        public string this[string key] => _emojis[key];

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the emoji list.</param>
        protected SlackEmojiList(JObject json) : base(json) {
            _emojis = json.Properties().ToDictionary(x => x.Name, x => json.GetString(x.Name));
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Determines whether the list contains the specified key.
        /// </summary>
        /// <param name="key">The key to locate in the <see cref="SlackEmojiList"/>.</param>
        /// <returns><c>true</c> if the <see cref="SlackEmojiList"/> contains an element with the specified key; otherwise, <c>false</c>.</returns>
        public bool ContainsKey(string key) {
            return _emojis.ContainsKey(key);
        }


        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="value">When this method returns, contains the value associated with the specified key, if the key is found; otherwise, the default value for the type of the value parameter. This parameter is passed uninitialized.</param>
        /// <returns><c>true</c> if the <see cref="SlackEmojiList"/> contains an element with the specified key; otherwise, <c>false</c>.</returns>
        public bool TryGetValue(string key, out string value) {
            return _emojis.TryGetValue(key, out value);
        }

        /// <inheritdoc />
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator() {
            return _emojis.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SlackEmojiList"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="SlackEmojiList"/>.</returns>
        public static SlackEmojiList Parse(JObject json) {
            return json == null ? null : new SlackEmojiList(json);
        }

        #endregion

    }

}