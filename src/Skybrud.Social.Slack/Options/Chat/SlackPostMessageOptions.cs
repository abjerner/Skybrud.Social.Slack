using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Slack.Options.Chat {

    public class SlackPostMessageOptions : IHttpPostOptions {

        #region Properties

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
        
        [JsonProperty("username", NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }

        [JsonProperty("icon_emoji", NullValueHandling = NullValueHandling.Ignore)]
        public string IconEmoji { get; set; }


        [JsonProperty("link_names", NullValueHandling = NullValueHandling.Ignore)]
        public bool LinkNames { get; set; }

        [JsonProperty("attachments", NullValueHandling = NullValueHandling.Ignore)]
        public List<SlackMessageAttachment> Attachments { get; set; }

        #endregion

        public SlackPostMessageOptions() {
            Attachments = new List<SlackMessageAttachment>();
        }

        public IHttpQueryString GetQueryString() {
            return new HttpQueryString();
        }

        public IHttpPostData GetPostData() {
            
            IHttpPostData data = new HttpPostData();

            if (String.IsNullOrWhiteSpace(Channel)) throw new PropertyNotSetException(nameof(Channel));
            if (String.IsNullOrWhiteSpace(Text)) throw new PropertyNotSetException(nameof(Text));

            data.Add("channel", Channel);
            data.Add("text", Channel);

            if (Attachments != null && Attachments.Count > 0) {
                data.Add("attachments", JsonConvert.SerializeObject(Attachments));
            }

            return data;

        }

    }

}