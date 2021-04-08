using System;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Social.Slack.Scopes {

    /// <summary>
    /// Class representing a scope of the Slack API.
    /// </summary>
    public class SlackScope {

        #region Private fields

        private static Dictionary<string, SlackScope> _lookup;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the alias of the scope.
        /// </summary>
        public string Alias { get; }

        /// <summary>
        /// Gets the name of the scope.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the description of the scope.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets an array of registered scopes.
        /// </summary>
        public static SlackScope[] Scopes => Lookup.Values.ToArray();


        private static Dictionary<string, SlackScope> Lookup {
            get {
                if (_lookup == null) {
                    _lookup = new Dictionary<string, SlackScope>();
                    foreach (SlackScopeGroup group in SlackScopes.Groups) {
                        foreach (SlackScope scope in group.Scopes) {
                            Lookup.Add(scope.Alias, scope);
                        }
                    }
                }
                return _lookup;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new scope based on the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="alias">The name of the scope.</param>
        internal SlackScope(string alias) : this(alias, null, null) { }

        /// <summary>
        /// Initializes a new scope based on the specified <paramref name="alias"/> and <paramref name="name"/>.
        /// </summary>
        /// <param name="alias">The name of the scope.</param>
        /// <param name="name">The name of the scope.</param>
        internal SlackScope(string alias, string name) : this(alias, name, null) { }

        /// <summary>
        /// Initializes a new scope based on the specified <paramref name="alias"/>, <paramref name="name"/> and <paramref name="description"/>.
        /// </summary>
        /// <param name="alias">The name of the scope.</param>
        /// <param name="name">The name of the scope.</param>
        /// <param name="description">The description of the scope.</param>
        internal SlackScope(string alias, string name, string description) {
            Alias = alias;
            Name = name ?? alias;
            Description = description;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public override string ToString() {
            return Alias;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Registers a scope in the internal dictionary.
        /// </summary>
        /// <param name="scope">The scope to be registered.</param>
        public static SlackScope RegisterScope(SlackScope scope) {
            if (scope == null) throw new ArgumentNullException(nameof(scope));
            if (Lookup.ContainsKey(scope.Alias)) throw new ArgumentException("A scope with the specified alias has already been registered.", nameof(scope));
            Lookup.Add(scope.Alias, scope);
            return scope;
        }

        /// <summary>
        /// Registers a scope in the internal dictionary.
        /// </summary>
        /// <param name="alias">The alias of the scope.</param>
        public static SlackScope RegisterScope(string alias) {
            return RegisterScope(alias, null, null);
        }

        /// <summary>
        /// Registers a scope in the internal dictionary.
        /// </summary>
        /// <param name="alias">The alias of the scope.</param>
        /// <param name="name">The name of the scope.</param>
        public static SlackScope RegisterScope(string alias, string name) {
            return RegisterScope(alias, name, null);
        }

        /// <summary>
        /// Registers a scope in the internal dictionary.
        /// </summary>
        /// <param name="alias">The alias of the scope.</param>
        /// <param name="name">The name of the scope.</param>
        /// <param name="description">The description of the scope.</param>
        public static SlackScope RegisterScope(string alias, string name, string description) {
            if (Lookup.ContainsKey(alias)) throw new ArgumentException("A scope with the specified alias \"" + alias + "\" has already been registered.", nameof(alias));
            SlackScope scope = new SlackScope(alias, name ?? alias, description);
            Lookup.Add(scope.Name, scope);
            return scope;
        }

        /// <summary>
        /// Attempts to get a scope with the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="alias">The alias of the scope.</param>
        /// <returns>A scope matching the specified <paramref name="alias"/>, or <c>null</c> if not found.</returns>
        public static SlackScope GetScope(string alias) {
            return Lookup.TryGetValue(alias, out SlackScope scope) ? scope : null;
        }

        /// <summary>
        /// Returns whether the scope is a known scope.
        /// </summary>
        /// <param name="alias">The alias of the scope.</param>
        /// <returns><c>true</c> if the specified <paramref name="alias"/> matches a known scope, otherwise <c>false</c>.</returns>
        public static bool ScopeExists(string alias) {
            return Lookup.ContainsKey(alias);
        }

        #endregion

        #region Operators

        /// <summary>
        /// Adding two instances of <see cref="SlackScope"/> will result in a <see cref="SlackScopeList"/> containing both scopes.
        /// </summary>
        /// <param name="left">The left scope.</param>
        /// <param name="right">The right scope.</param>
        public static SlackScopeList operator +(SlackScope left, SlackScope right) {
            return new SlackScopeList(left, right);
        }

        #endregion

    }

}