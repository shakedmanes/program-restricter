using System;
using System.Collections.Generic;
using System.Text;

namespace program_restricter
{
    class Restricter
    {
        /// <summary>
        /// Restricting program for certian user.
        /// </summary>
        /// <param name="PathFile">Path for the program executable to restrict</param>
        /// <param name="Username">Username of the user to apply restriction on</param>
        /// <returns>String indicating result of operation</returns>
        public static string RestrictProgram(string PathFile, string Username)
        {
            return "Mock... user restricted!";
        }

        /// <summary>
        /// Removing restriction of a program for certian user.
        /// </summary>
        /// <param name="PathFile">Path for the program executable to remove restriction</param>
        /// <param name="Username">Username of the user to remove restriction from</param>
        /// <returns></returns>
        public static string UnrestrictProgram(string PathFile, string Username)
        {
            return "Mock... user unrestricted";
        }
    }
}
