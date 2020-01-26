// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass

using System;

namespace Skybrud.Social.Slack.Scopes {

    /// <see>
    ///     <cref>https://api.slack.com/docs/oauth-scopes</cref>
    /// </see>
    public class SlackScopes {

        /// <summary>
        /// Legacy scopes now deprecated in the Slack API.
        /// </summary>
        public static class Legacy {

            #region Constants

            /// <summary>
            /// Allows applications to confirm your identity.
            /// </summary>
            [Obsolete("Deprecated in the Slack API.")]
            public static readonly SlackScope Identify = new SlackScope("identify", "Identify", "Allows applications to confirm your identity.");

            /// <summary>
            /// Allows applications to read any messages and state that the user can see.
            /// </summary>
            [Obsolete("Deprecated in the Slack API.")]
            public static readonly SlackScope Read = new SlackScope("read", "Read", "Allows applications to read any messages and state that the user can see.");

            /// <summary>
            /// Allows applications to write messages and create content on behalf of the user.
            /// </summary>
            [Obsolete("Deprecated in the Slack API.")]
            public static readonly SlackScope Post = new SlackScope("post", "Post", "Allows applications to write messages and create content on behalf of the user.");

            /// <summary>
            /// Allows applications to connect to slack as a client, and post messages on behalf of the user.
            /// </summary>
            [Obsolete("Deprecated in the Slack API.")]
            public static readonly SlackScope Client = new SlackScope("client", "Client", "Allows applications to connect to slack as a client, and post messages on behalf of the user.");

            /// <summary>
            /// Allows applications to perform administrative actions, requires the authed user is an admin.
            /// </summary>
            [Obsolete("Deprecated in the Slack API.")]
            public static readonly SlackScope Admin = new SlackScope("admin", "Admin", "Allows applications to perform administrative actions, requires the authed user is an admin.");

            #endregion

        }

        /// <summary>
        /// Scopes related to administrative actions.
        /// </summary>
        public static class Admin {

            /// <summary>
            /// This scope lets an app "View apps and app requests in a workspace".
            /// </summary>
            /// <see>
            ///     <cref>https://api.slack.com/scopes/admin.apps:read</cref>
            /// </see>
            public static readonly SlackScope AppsRead = new SlackScope("admin.apps:read", "Apps (read)", "This scope lets an app \"View apps and app requests in a workspace\".");


            /// <summary>
            /// This scope lets an app "Manage apps in a workspace".
            /// </summary>
            /// <see>
            ///     <cref>https://api.slack.com/scopes/admin.apps:write</cref>
            /// </see>
            public static readonly SlackScope AppsWrite = new SlackScope("admin.apps:write", "Apps (write)", "This scope lets an app \"Manage apps in a workspace\".");


            /// <summary>
            /// This scope lets an app "Gain information about invite requests in a Grid organization".
            /// </summary>
            /// <see>
            ///     <cref>https://api.slack.com/scopes/admin.invites:read</cref>
            /// </see>
            public static readonly SlackScope InvitesRead = new SlackScope("admin.invites:read", "Invites (read)", "This scope lets an app \"Gain information about invite requests in a Grid organization\".");


            /// <summary>
            /// This scope lets an app "Approve or deny invite requests in a Grid organization".
            /// </summary>
            /// <see>
            ///     <cref>https://api.slack.com/scopes/admin.invites:write</cref>
            /// </see>
            public static readonly SlackScope InvitesWrite = new SlackScope("admin.invites:write", "Invites (write)", "This scope lets an app \"Approve or deny invite requests in a Grid organization\".");


            /// <summary>
            /// This scope lets an app "Access information about the workspace".
            /// </summary>
            /// <see>
            ///     <cref>https://api.slack.com/scopes/admin.teams:read</cref>
            /// </see>
            public static readonly SlackScope TeamsRead = new SlackScope("admin.teams:read", "Teams (read)", "This scope lets an app \"Access information about the workspace\".");


            /// <summary>
            /// This scope lets an app "Make changes to the workspace".
            /// </summary>
            /// <see>
            ///     <cref>https://api.slack.com/scopes/admin.teams:write</cref>
            /// </see>
            public static readonly SlackScope TeamsWrite = new SlackScope("admin.teams:write", "Teams (write)", "This scope lets an app \"Make changes to the workspace\".");


            /// <summary>
            /// This scope lets an app "Access the workspace’s profile information".
            /// </summary>
            /// <see>
            ///     <cref>https://api.slack.com/scopes/admin.users:read</cref>
            /// </see>
            public static readonly SlackScope UsersRead = new SlackScope("admin.users:read", "Users (read)", "This scope lets an app \"Access the workspace’s profile information\".");


            /// <summary>
            /// This scope lets an app "Modify account information".
            /// </summary>
            /// <see>
            ///     <cref>https://api.slack.com/scopes/admin.users:write</cref>
            /// </see>
            public static readonly SlackScope UsersWrite = new SlackScope("admin.users:write", "Users (write)", "This scope lets an app \"Modify account information\".");

        }

        /// <summary>
        /// Scopes related to the <strong>Channels</strong> endpoint.
        /// </summary>
        public static class Channels {
            
            /// <summary>
            /// This scope lets an app "View messages and other content in public channels that your slack app has been added to".
            /// </summary>
            /// <see>
            ///     <cref>https://api.slack.com/scopes/channels:history</cref>
            /// </see>
            public static readonly SlackScope History = new SlackScope("channels:history", "Manage", "This scope lets an app \"View messages and other content in public channels that your slack app has been added to\".");

            /// <summary>
            /// This scope lets an app "Join public channels in the workspace".
            /// </summary>
            /// <see>
            ///     <cref>https://api.slack.com/scopes/channels:join</cref>
            /// </see>
            public static readonly SlackScope Join = new SlackScope("channels:join", "Join", "This scope lets an app \"Join public channels in the workspace\".");

            /// <summary>
            /// This scope lets an app "Manage public channels that your slack app has been added to and create new ones".
            /// </summary>
            /// <see>
            ///     <cref>https://api.slack.com/scopes/channels:manage</cref>
            /// </see>
            public static readonly SlackScope Manage = new SlackScope("channels:manage", "Manage", "This scope lets an app \"Manage public channels that your slack app has been added to and create new ones\".");

            /// <summary>
            /// This scope lets an app "View basic information about public channels in the workspace".
            /// </summary>
            /// <see>
            ///     <cref>https://api.slack.com/scopes/channels:read</cref>
            /// </see>
            public static readonly SlackScope Read = new SlackScope("channels:read", "Read", "This scope lets an app \"View basic information about public channels in the workspace\".");

            /// <summary>
            /// This scope lets an app "Manage the user’s public channels and create new ones on the user’s behalf".
            /// </summary>
            /// <see>
            ///     <cref>https://api.slack.com/scopes/channels:write</cref>
            /// </see>
            public static readonly SlackScope Write = new SlackScope("channels:write", "Write", "This scope lets an app \"Manage the user’s public channels and create new ones on the user’s behalf\".");

        }
        
        /// <summary>
        /// Scopes related to the <strong>Chat</strong> endpoint.
        /// </summary>
        public static class Chat {

            /// <summary>
            /// This scope lets an app "Send messages as your slack app".
            /// </summary>
            /// <see>
            ///     <cref>https://api.slack.com/scopes/chat:write:bot</cref>
            /// </see>
            public static readonly SlackScope WriteBot = new SlackScope("chat:write:bot", "Write as bot", "This scope lets an app \"Send messages as your slack app\".");

            /// <summary>
            /// This scope lets an app "Send messages on the user’s behalf".
            /// </summary>
            /// <see>
            ///     <cref>https://api.slack.com/scopes/chat:write:user</cref>
            /// </see>
            public static readonly SlackScope WriteUser = new SlackScope("chat:write:user", "Write as user", "This scope lets an app \"Send messages on the user’s behalf\".");

        }

        /// <summary>
        /// Scopes related to the <strong>Teams</strong> endpoint.
        /// </summary>
        public static class Teams {

            /// <summary>
            /// This scope lets an app "View the name, email domain, and icon for workspaces your slack app is connected to".
            /// </summary>
            /// <see>
            ///     <cref>https://api.slack.com/scopes/team:read</cref>
            /// </see>
            public static readonly SlackScope Read = new SlackScope("team:read", "Read", "This scope lets an app \"View the name, email domain, and icon for workspaces your slack app is connected to\".");

        }

        /// <summary>
        /// Scopes related to the <strong>Users</strong> endpoint.
        /// </summary>
        public static class Users {


            /// <summary>
            /// This scope lets an app "View profile details about people in the workspace".
            /// </summary>
            /// <see>
            ///     <cref>https://api.slack.com/scopes/users.profile:read</cref>
            /// </see>
            public static readonly SlackScope ProfileRead = new SlackScope("users.profile:read", "Profile read", "This scope lets an app \"View profile details about people in the workspace\".");


            /// <summary>
            /// This scope lets an app "Edit the user’s profile information and status".
            /// </summary>
            /// <see>
            ///     <cref>https://api.slack.com/scopes/users.profile:write</cref>
            /// </see>
            public static readonly SlackScope ProfileWrite = new SlackScope("users.profile:write", "Profile write", "This scope lets an app \"Edit the user’s profile information and status\".");


            /// <summary>
            /// This scope lets an app "Change the user's profile fields".
            /// </summary>
            /// <see>
            ///     <cref>https://api.slack.com/scopes/users.profile:write:user</cref>
            /// </see>
            public static readonly SlackScope ProfileWriteUser = new SlackScope("users.profile:write:user", "Profile write (fields)", "This scope lets an app \"Change the user's profile fields\".");


            /// <summary>
            /// This scope lets an app "View people in the workspace".
            /// </summary>
            /// <see>
            ///     <cref>https://api.slack.com/scopes/users:read</cref>
            /// </see>
            public static readonly SlackScope Read = new SlackScope("users:read", "Read", "This scope lets an app \"View people in the workspace\".");

            /// <summary>
            /// This scope lets an app "View email addresses of people in the workspace".
            /// </summary>
            /// <see>
            ///     <cref>https://api.slack.com/scopes/users:read.email</cref>
            /// </see>
            public static readonly SlackScope ReadEmail = new SlackScope("users:read.email", "Read email", "This scope lets an app \"View email addresses of people in the workspace\".");


            /// <summary>
            /// This scope lets an app "Set presence for your slack app".
            /// </summary>
            /// <see>
            ///     <cref>https://api.slack.com/scopes/users:write</cref>
            /// </see>
            public static readonly SlackScope Write = new SlackScope("users:write", "Write", "This scope lets an app \"Set presence for your slack app\".");

        }

        /// <summary>
        /// Gets an array of scope groups.
        /// </summary>
        public static SlackScopeGroup[] Groups = {
            new SlackScopeGroup(nameof(Admin), SlackUtils.GetScopesFromType(typeof(Admin))),
            new SlackScopeGroup(nameof(Channels), SlackUtils.GetScopesFromType(typeof(Channels))),
            new SlackScopeGroup(nameof(Chat), SlackUtils.GetScopesFromType(typeof(Chat))),
            new SlackScopeGroup(nameof(Teams), SlackUtils.GetScopesFromType(typeof(Teams))),
            new SlackScopeGroup(nameof(Users), SlackUtils.GetScopesFromType(typeof(Users))),
            new SlackScopeGroup(nameof(Legacy), SlackUtils.GetScopesFromType(typeof(Legacy)))
        };

    }

}