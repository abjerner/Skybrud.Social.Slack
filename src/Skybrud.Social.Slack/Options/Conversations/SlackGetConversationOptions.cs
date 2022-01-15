using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Slack.Options.Conversations {

    /// <summary>
    /// Class representing the options for getting information about a Slack conversations.
    /// </summary>
    /// <see>
    ///     <cref>https://api.slack.com/methods/conversations.info</cref>
    /// </see>
    public class SlackGetConversationOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the conversation/channel.
        /// </summary>
        public string ConversationId { get; set; }

        /// <summary>
        /// Gets or sets whether to receive the locale for this conversation. Default is <c>false</c>.
        /// </summary>
        public bool IncludeLocale { get; set; }

        /// <summary>
        /// Gets or sets whether to include the member count for the specified conversation. Default is <c>false</c>.
        /// </summary>
        public bool IncludeNumbMembers { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public SlackGetConversationOptions() { }

        /// <summary>
        /// Initializes a new instance with based on the specified <paramref name="conversationId"/>.
        /// </summary>
        /// <param name="conversationId">The ID of the conversation/channel.</param>
        public SlackGetConversationOptions(string conversationId) {
            ConversationId = conversationId;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            if (string.IsNullOrWhiteSpace(ConversationId)) throw new PropertyNotSetException(nameof(ConversationId));

            IHttpQueryString query = new HttpQueryString {
                { "channel", ConversationId }
            };

            if (IncludeLocale) query.Add("include_locale", "true");
            if (IncludeNumbMembers) query.Add("include_num_members", "true");

            return HttpRequest.Get("/api/conversations.info", query);

        }

        #endregion

    }

}