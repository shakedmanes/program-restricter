using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;

namespace program_restricter
{
    class ApplicationCommandLine
    {

        private const string HELP_TEXT_PATH_FILE = "Path for the file to block/unblock";
        private const string HELP_TEXT_OPERATION = "Operation to perform (0 = Block, 1 = Unblock)";
        private const string HELP_TEXT_USERNAME = "Username to perform operation on";
        public enum OperationType { Block = 0, Unblock };

        // Required Options
        [Option('f', "file", Required = true, HelpText = HELP_TEXT_PATH_FILE)]
        public string PathFile { get; set; }

        [Option('o', "operation", Required = true, HelpText = HELP_TEXT_OPERATION)]
        public OperationType Operation { get; set; }

        [Option('u', "user", Required = true, HelpText = HELP_TEXT_USERNAME)]
        public string Username { get; set; }                
    }
}
