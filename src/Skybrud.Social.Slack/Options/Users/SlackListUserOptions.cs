using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Slack.Options.Users {
    
    /// <summary>
    /// Options for getting a list of users.
    /// </summary>
    public class SlackListUserOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the cursor. Paginate through collections of data by setting the cursor property to a
        /// <c>next_cursor</c> attribute returned by a previous request's <c>response_metadata</c>. Default value
        /// fetches the first "page" of the collection. See pagination for more detail.
        /// </summary>
        public string Cursor { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of items to return. Fewer than the requested number of items may be
        /// returned, even if the end of the users list hasn't been reached. Providing no limit value will result
        /// in Slack attempting to deliver you the entire result set. If the collection is too large you may
        /// experience <c>limit_required</c> or HTTP 500 errors.
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Gets or sets the encoded team id to list users in, required if <c>org</c> token is used.
        /// </summary>
        public string TeamId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public SlackListUserOptions() { }
        
        /// <summary>
        /// Initializes a new instance with based on the specified <paramref name="cursor"/>. and <paramref name="limit"/>.
        /// </summary>
        /// <param name="cursor">The cursor.</param>
        /// <param name="limit">The maximum amount of items to be returned.</param>
        public SlackListUserOptions(string cursor, int limit) {
            Cursor = cursor;
            Limit = limit;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            IHttpQueryString query = new HttpQueryString();

            if (!string.IsNullOrWhiteSpace(Cursor)) query.Add("cursor", Cursor);
            if (Limit != null) query.Add("limit", Limit);
            if (!string.IsNullOrWhiteSpace(TeamId)) query.Add("team_id", TeamId);

            return HttpRequest.Get("/api/users.list", query);

        }

        #endregion

    }

}