using System.Collections.Generic;
using CommandLine;

namespace program_restricter
{
    [Verb("block", HelpText = ApplicationCommandLine.HELP_TEXT_BLOCK)]
    public class BlockOptions
    {
        [Option('u', "user", Required = true, HelpText = ApplicationCommandLine.HELP_TEXT_USERNAME)]
        public string Username { get; set; }

        [Option('p', "program", HelpText = ApplicationCommandLine.HELP_TEXT_PROGRAM, SetName = "input")]
        public string ProgramName { get; set; }

        [Option('l', "list", Required = true, HelpText = ApplicationCommandLine.HELP_TEXT_LIST_PROGRAMS, Separator = ',')]
        public IEnumerable<string> ProgramsList { get; set; }

        [Option('f', "file", HelpText = ApplicationCommandLine.HELP_TEXT_PATH_FILE, SetName = "input")]
        public string PathFile { get; set; }
    }

    [Verb("unblock", HelpText = ApplicationCommandLine.HELP_TEXT_UNBLOCK)]
    public class UnblockOptions
    {
        [Option('u', "user", Required = true, HelpText = ApplicationCommandLine.HELP_TEXT_USERNAME)]
        public string Username { get; set; }

        [Option('p', "program", HelpText = ApplicationCommandLine.HELP_TEXT_PROGRAM, SetName = "input")]
        public string ProgramName { get; set; }

        [Option('l', "list", Required = true, HelpText = ApplicationCommandLine.HELP_TEXT_LIST_PROGRAMS, Separator = ',')]
        public IEnumerable<string> ProgramsList { get; set; }

        [Option('f', "file", HelpText = ApplicationCommandLine.HELP_TEXT_PATH_FILE, SetName = "input")]
        public string PathFile { get; set; }

        [Option('a', "all", HelpText = ApplicationCommandLine.HELP_TEXT_UNBLOCK_ALL, SetName = "input")]
        public bool All { get; set; }
    }

    class ApplicationCommandLine
    {
        public const string HELP_TEXT_BLOCK = "Block program/s for specific user";
        public const string HELP_TEXT_UNBLOCK = "Unblock program/s for specific user";
        public const string HELP_TEXT_PATH_FILE = "Path for file contains list of executables to block/unblock";
        public const string HELP_TEXT_USERNAME = "User name to perform operation on";
        public const string HELP_TEXT_PROGRAM = "Single program executable name to block or unblock";
        public const string HELP_TEXT_LIST_PROGRAMS = "List of programs executable names to block or unblock separated by space";
        public const string HELP_TEXT_UNBLOCK_ALL = "Unblock all programs currently restricted for specific user";        
    }
}
