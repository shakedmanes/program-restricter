using System;


namespace program_restricter
{
    class Restricter
    {
        /// <summary>
        /// Restrict program executable for specific user
        /// </summary>
        /// <param name="ProgramName">Program executable name to restrict</param>
        /// <param name="Username">User name of the user to perform restriction on</param>
        public static void RestrictProgram(string ProgramName, string Username)
        {
            SetProgramsState(new string[] { ProgramName }, Username, true);
        }

        /// <summary>
        /// Remove restriction of program executable for specific user
        /// </summary>
        /// <param name="ProgramName">Program executable name to remove restriction</param>
        /// <param name="Username">User name of the user to remove restriction on</param>
        public static void UnrestrictProgram(string ProgramName, string Username)
        {
            SetProgramsState(new string[] { ProgramName }, Username, false);
        }

        /// <summary>
        /// Restrict list of programs executables for user
        /// </summary>
        /// <param name="ProgramsList">Array of programs executables to restrict</param>
        /// <param name="Username">User name to apply restriction on</param>
        public static void RestrictProgramsByList(string[] ProgramsList, string Username)
        {
            SetProgramsState(ProgramsList, Username, true);
        }

        /// <summary>
        /// Remove restriction for user by list of programs executables
        /// </summary>
        /// <param name="ProgramsList">Array of programs executables to remove restriction</param>
        /// <param name="Username">User name to remove restriction from</param>
        public static void UnrestrictProgramsByList(string[] ProgramsList, string Username)
        {
            SetProgramsState(ProgramsList, Username, false);
        }

        /// <summary>
        /// Restricting programs for certain user.
        /// </summary>
        /// <param name="FilePath">Path of file contains the executables names to restrict</param>
        /// <param name="Username">User name of the user to apply restriction on</param>
        /// <returns>String indicating result of operation</returns>
        public static void RestrictProgramsByFile(string FilePath, string Username)
        {
            SetProgramsState(FilePath, Username, true);
        }

        /// <summary>
        /// Removing restriction of programs for certain user.
        /// </summary>
        /// <param name="FilePath">Path of file contains executables names to remove from restriction</param>
        /// <param name="Username">User name of the user to remove restriction from</param>
        /// <returns></returns>
        public static void UnrestrictProgramsByFile(string FilePath, string Username)
        {
            SetProgramsState(FilePath, Username, false);
        }

        /// <summary>
        /// Removing all restriction of programs for certain user.
        /// </summary>
        /// <param name="Username">User name of the user to remove restriction from</param>
        public static void UnrestrictAll(string Username)
        {
            SetProgramsState(Username, false);
        }

        /// <summary>
        /// Overload for <see cref="Restricter.SetProgramsState(string[], string, bool)"/> just for
        /// setting all programs state for certain user
        /// </summary>        
        /// <param name="Username">User name to apply programs state on</param>
        /// /// <param name="Restrict">Boolean indicates operation to perform. True - Restrict, False - Remove restriction</param>
        private static void SetProgramsState(string Username, bool Restrict)
        {
            if (Restrict)
            {
                throw new NotImplementedException("Currently, this feature is not ready yet");
            }
            else
            {
                RegistryUtils.RemoveRestrictionKey(UserUtils.GetUserSIDByName(Username));
            }
        }

        /// <summary>
        /// Overload for <see cref="Restricter.SetProgramsState(string[], string, bool)"/> just for
        /// receiving file contains the list of the programs to set state on
        /// </summary>
        /// <param name="FilePath">File path of file contains programs to set state on</param>
        /// <param name="Username">User name to apply programs state on</param>
        /// <param name="Restrict">Boolean indicates operation to perform. True - Restrict, False - Remove restriction</param>
        private static void SetProgramsState(string FilePath, string Username, bool Restrict)
        {
            // If the file not exists, throw error
            if (!System.IO.File.Exists(FilePath))
            {
                throw new System.IO.FileNotFoundException($"File at {FilePath} does not exists");
            }

            // Reading all the programs from the file
            string[] ProgramsList = System.IO.File.ReadAllLines(FilePath);

            SetProgramsState(ProgramsList, Username, Restrict);
        }

        /// <summary>
        /// Setting programs state (Restrict/Removed from restriction)
        /// </summary>
        /// <param name="ProgramsList">Array contains programs executables names</param>
        /// <param name="Username">User name to apply programs states on</param>
        /// <param name="Restrict">Boolean indicates the operation to perform. True for restrict, False for removing restriction</param>
        private static void SetProgramsState(string[] ProgramsList, string Username, bool Restrict)
        {
            // Restrict or remove restriction by programs list
            if (Restrict)
            {
                RegistryUtils.AddDisallowRegistryKeys(UserUtils.GetUserSIDByName(Username), ProgramsList);
            }
            else
            {
                RegistryUtils.RemoveDisallowRegistryKeys(UserUtils.GetUserSIDByName(Username), ProgramsList);
            }               
        }
    }
}
