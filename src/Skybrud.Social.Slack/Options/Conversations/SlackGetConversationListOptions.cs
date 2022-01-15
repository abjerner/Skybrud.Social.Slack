using System.Collections.Generic;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Slack.Options.Conversations {

    /// <summary>
    /// Class representing the options for getting a list of conversations.
    /// </summary>
    /// <see>
    ///     <cref>https://api.slack.com/methods/conversations.list</cref>
    /// </see>
    public class SlackGetConversationListOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the cursor. Paginate through collections of data by setting the cursor parameter to a
        /// <c>next_cursor</c> attribute returned by a previous request's response_metadata. Default value fetches the
        /// first "page" of the collection.
        /// </summary>
        public string Cursor { get; set; }

        /// <summary>
        /// Gets whether to exclude archived channels from the list. Default is <c>false</c>.
        /// </summary>
        public bool ExcludeArchived { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of items to return. Fewer than the requested number of items may be
        /// returned, even if the end of the users list hasn't been reached. Providing no limit value will result
        /// in Slack attempting to deliver you the entire result set. If the collection is too large you may
        /// experience <c>limit_required</c> or HTTP 500 errors.
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Gets or sets the ncoded team id to list channels in, required if token belongs to org-wide app.
        /// </summary>
        public string TeamId { get; set; }

        /// <summary>
        /// Gets or sets the types of conversations to be returned. If not specified, the Slack API defaults to
        /// <see cref="SlackConversationType.PublicChannel"/>.
        /// </summary>
        public List<SlackConversationType> Types { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public SlackGetConversationListOptions() {
            Types = new List<SlackConversationType>();
        }

        /// <summary>
        /// Initializes a new instance with based on the specified <paramref name="cursor"/>. and <paramref name="limit"/>.
        /// </summary>
        /// <param name="cursor">The cursor.</param>
        /// <param name="limit">The maximum amount of items to be returned..</param>
        public SlackGetConversationListOptions(string cursor, int limit) {
            Cursor = cursor;
            Limit = limit;
            Types = new List<SlackConversationType>();
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            IHttpQueryString query = new HttpQueryString();

            if (!string.IsNullOrWhiteSpace(Cursor)) query.Add("cursor", Cursor);
            if (ExcludeArchived) query.Add("exclude_archived", "true");
            if (Limit != null) query.Add("limit", Limit);
            if (!string.IsNullOrWhiteSpace(TeamId)) query.Add("team_id", TeamId);
            if (Types != null && Types.Count > 0) query.Add("types", SlackUtils.ToString(Types));

            return HttpRequest.Get("/api/conversations.list", query);

        }

        #endregion

    }

}