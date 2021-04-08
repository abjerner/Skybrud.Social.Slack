using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Social.Slack.Scopes {
    
    /// <summary>
    /// Class representing a list of scopes of the Slack API.
    /// </summary>
    public class SlackScopeList {

        #region Private fields

        private readonly List<SlackScope> _list = new List<SlackScope>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets an array of all the scopes added to the list.
        /// </summary>
        public SlackScope[] Items => _list.ToArray();

        /// <summary>
        /// Gets the amounts of scopes added to the list.
        /// </summary>
        public int Count => _list.Count;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new collection based on the specified <paramref name="array"/> of scopes.
        /// </summary>
        /// <param name="array">Array of scopes.</param>
        public SlackScopeList(params SlackScope[] array) {
            _list.AddRange(array);
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Adds the specified <paramref name="scope"/> to the list.
        /// </summary>
        /// <param name="scope">The scope to be added.</param>
        public void Add(SlackScope scope) {
            _list.Add(scope);
        }

        /// <summary>
        /// Returns an array of scopes based on the list.
        /// </summary>
        /// <returns>Array of scopes contained in the location.</returns>
        public SlackScope[] ToArray() {
            return _list.ToArray();
        }

        /// <summary>
        /// Returns an array of strings representing each scope in the list.
        /// </summary>
        /// <returns>Array of strings representing each scope in the list.</returns>
        public string[] ToStringArray() {
            return (from scope in _list select scope.Alias).ToArray();
        }

        /// <summary>
        /// Returns a string representing the scopea added to the list using a comma as a separator.
        /// </summary>
        /// <returns>String of scopes separated by a comma.</returns>
        public override string ToString() {
            return string.Join(",", from scope in _list select scope.Alias);
        }

        #endregion

        #region Operator overloading

        /// <summary>
        /// Initializes a new list based on a single <paramref name="scope"/>.
        /// </summary>
        /// <param name="scope">The scope the list should be based on.</param>
        /// <returns>Returns a new list based on a single <paramref name="scope"/>.</returns>
        public static implicit operator SlackScopeList(SlackScope scope) {
            return new SlackScopeList(scope);
        }

        /// <summary>
        /// Initializes a new list based on an <paramref name="array"/> of scopes.
        /// </summary>
        /// <param name="array">The array of scopes the list should be based on.</param>
        /// <returns>Returns a new list based on an <paramref name="array"/> of scopes.</returns>
        public static implicit operator SlackScopeList(SlackScope[] array) {
            return new SlackScopeList(array ?? new SlackScope[0]);
        }

        /// <summary>
        /// Adds support for adding a <paramref name="scope"/> to the <paramref name="list"/> using the plus operator.
        /// </summary>
        /// <param name="list">The list to which <paramref name="scope"/> will be added.</param>
        /// <param name="scope">The scope to be added to the <paramref name="list"/>.</param>
        public static SlackScopeList operator +(SlackScopeList list, SlackScope scope) {
            list.Add(scope);
            return list;
        }

        #endregion

    }

}