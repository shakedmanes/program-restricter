using Microsoft.Win32;

namespace program_restricter
{
    class RegistryUtils
    {
        private static readonly string POLICIES_REG_KEY = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies";
        private static readonly string EXPLORER_REG_KEY = "Explorer";
        private static readonly string DISALLOW_REG_KEY = "DisallowRun";

        /// <summary>
        /// Adds programs to disallow registry keys of specific user by account SID and program names executables
        /// </summary>
        /// <param name="AccountSID">Account SID for accessing registry</param>
        /// <param name="ProgramNames">Program names executables to include in restriction</param>
        public static void AddDisallowRegistryKeys(string AccountSID, string[] ProgramNames) 
        {
            // Get Restriction key for adding restrictions
            RegistryKey RestrictionKey = GetRestrictionKey(AccountSID);

            // Adding each program to the restriction key
            foreach(string ProgramName in ProgramNames)
            {
                RestrictionKey.SetValue(ProgramName.Split('.')[0], ProgramName, RegistryValueKind.String);
            }

            RestrictionKey.Close();
        }

        /// <summary>
        /// Removes programs from disallow registry keys of specific user by account SID and program names executables
        /// </summary>
        /// <param name="AccountSID">Account SID for accessing registry</param>
        /// <param name="ProgramNames">Program names executables to exclude in restriction</param>
        public static void RemoveDisallowRegistryKeys(string AccountSID, string[] ProgramNames)
        {
            // Get Restriction key for removing restrictions
            RegistryKey RestrictionKey = GetRestrictionKey(AccountSID);

            // Removing each program from the restriction key
            foreach (string ProgramName in ProgramNames)
            {
                RestrictionKey.DeleteValue(ProgramName.Split('.')[0], false);                
            }

            RestrictionKey.Close();
        }

        /// <summary>
        /// Removing restriction key for allowing all programs for certain user
        /// </summary>
        /// <param name="AccountSID">The account SID for the user</param>
        public static void RemoveRestrictionKey(string AccountSID)
        {
            Registry.Users.DeleteSubKey($@"{AccountSID}\{POLICIES_REG_KEY}\{EXPLORER_REG_KEY}\{DISALLOW_REG_KEY}", false);
        }

        /// <summary>
        /// Get restriction registry key for given user account SID
        /// </summary>
        /// <param name="AccountSID">The account SID for the user</param>
        /// <returns>Ready Restriction Registry key for the given user account SID</returns>
        public static RegistryKey GetRestrictionKey(string AccountSID)
        {
            
            // Getting the Policies key
            RegistryKey PoliciesKey = Registry.Users.OpenSubKey($@"{AccountSID}\{POLICIES_REG_KEY}", true);

            // Trying to get the explorer key
            RegistryKey ExplorerKey = PoliciesKey.OpenSubKey(EXPLORER_REG_KEY, true);

            // If the explorer key not exists, creates one
            if (ExplorerKey == null)
            {
                ExplorerKey = PoliciesKey.CreateSubKey(EXPLORER_REG_KEY, true);
            }

            // Making sure the explorer key have key 'DisallowRun' and its on (1)
            ExplorerKey.SetValue(DISALLOW_REG_KEY, 1, RegistryValueKind.DWord);

            // Trying to get the disallow key 
            RegistryKey DisallowKey = ExplorerKey.OpenSubKey(DISALLOW_REG_KEY, true);

            // if the disallow key not exists, creates one
            if (DisallowKey == null)
            {
                DisallowKey = ExplorerKey.CreateSubKey(DISALLOW_REG_KEY, true);
            }

            ExplorerKey.Close();
            PoliciesKey.Close();

            return DisallowKey;
        }
    }
}
