using System.Security.Principal;

namespace program_restricter
{
    class UserUtils
    {
        /// <summary>
        /// Retrieves user's account SID by user name
        /// </summary>
        /// <param name="Username">User name of the account</param>
        /// <returns>Account SID of the user</returns>
        public static string GetUserSIDByName(string Username)
        {
            NTAccount account = new NTAccount(Username);
            SecurityIdentifier identifier = (SecurityIdentifier)account.Translate(typeof(SecurityIdentifier));
            return identifier.Value;
        }
    }
}
