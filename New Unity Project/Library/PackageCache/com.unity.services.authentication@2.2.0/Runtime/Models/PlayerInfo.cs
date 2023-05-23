using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Unity.Services.Authentication
{
    /// <summary>
    /// Contains Player Information
    /// </summary>
    public sealed class PlayerInfo
    {
        const string k_OpenIdConnectPrefix = "oidc-";
        const string k_IdProviderNameRegex = @"^oidc-[a-z0-9-_\.]{1,15}$";

        /// <summary>
        /// Player Id
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Player Creation DateTime in UTC
        /// </summary>
        public DateTime? CreatedAt { get; }

        /// <summary>
        /// Player Identities
        /// </summary>
        public List<Identity> Identities { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        internal PlayerInfo(string playerId)
        {
            Id = playerId;
            Identities = new List<Identity>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        internal PlayerInfo(PlayerInfoResponse response) : this(response.Id, response.CreatedAt, response.ExternalIds)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        internal PlayerInfo(User user) : this(user.Id, user.CreatedAt, user.ExternalIds)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        internal PlayerInfo(string playerId, string createdAt, List<ExternalIdentity> externalIdentities)
        {
            Id = playerId;
            Identities = new List<Identity>();

            if (double.TryParse(createdAt, out var createAtSeconds))
            {
                var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                CreatedAt = epoch.AddSeconds(createAtSeconds);
            }

            if (externalIdentities != null)
            {
                foreach (var externalId in externalIdentities)
                {
                    Identities.Add(new Identity(externalId));
                }
            }
        }

        /// <summary>
        /// Returns the player's facebook id if one has been linked.
        /// </summary>
        /// <returns>The player's facebook id</returns>
        public string GetFacebookId()
        {
            return GetIdentityId(IdProviderKeys.Facebook);
        }

        /// <summary>
        /// Returns the player's steam id if one has been linked.
        /// </summary>
        /// <returns></returns>
        public string GetSteamId()
        {
            return GetIdentityId(IdProviderKeys.Steam);
        }

        /// <summary>
        /// Returns the player's Google Play Games id if one has been linked.
        /// </summary>
        /// <returns>The player's Google Play Games id</returns>
        public string GetGoogleId()
        {
            return GetIdentityId(IdProviderKeys.Google);
        }

        /// <summary>
        /// Returns the player's Sign in with Apple id if one has been linked.
        /// </summary>
        /// <returns>The player's Sign in with Apple id</returns>
        public string GetAppleId()
        {
            return GetIdentityId(IdProviderKeys.Apple);
        }

        /// <summary>
        /// Returns the player's id if one has been linked with a given OpenID Connect id provider.
        /// </summary>
        /// <param name="idProviderName">the name of the id provider created. Note that it must start with <i><b>&quot;oidc-&quot;</b></i> and have between 1 and 20 characters</param>
        /// <returns>The player's id</returns>
        public string GetOpenIdConnectId(string idProviderName)
        {
            return ValidateOpenIdConnectIdProviderName(idProviderName) ? GetIdentityId(idProviderName) : null;
        }

        /// <summary>
        /// Get all OpenID Connect id providers linked to the player
        /// </summary>
        /// <returns>A list of all OpenID Connect id providers</returns>
        public List<Identity> GetOpenIdConnectIdProviders()
        {
            return Identities?.FindAll(id => id.TypeId.StartsWith(k_OpenIdConnectPrefix));
        }

        /// <summary>
        /// Returns the player's identity user id for a given identity type id
        /// </summary>
        internal string GetIdentityId(string typeId)
        {
            return Identities?.FirstOrDefault(x => x.TypeId == typeId)?.UserId;
        }

        /// <summary>
        /// Add External Id to the Player Info
        /// </summary>
        internal void AddExternalIdentity(ExternalIdentity externalId)
        {
            if (externalId != null)
            {
                Identities.Add(new Identity(externalId));
            }
        }

        /// <summary>
        /// Removes External Id
        /// </summary>
        internal void RemoveIdentity(string typeId)
        {
            Identities?.RemoveAll(x => x.TypeId == typeId);
        }

        bool ValidateOpenIdConnectIdProviderName(string idProviderName)
        {
            return !string.IsNullOrEmpty(idProviderName) && Regex.Match(idProviderName, k_IdProviderNameRegex).Success;
        }
    }
}
