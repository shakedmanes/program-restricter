using System;
using CommandLine;

namespace program_restricter
{
    static class ProgramRestricter
    {

        static void Main(string[] args)
        {
            // Performming operation according to arguments given
            Console.WriteLine(
                Parser.Default.ParseArguments<ApplicationCommandLine>(args).MapResult(
                options => ParsingOptions(options),
                errors => ErrorHandler(errors)
                )
            );

            Console.Read();
        }

        
        /// <summary>
        /// Parsing arguments options given for performing operations.
        /// </summary>
        /// <param name="options">Parsed result options given by Parser </param>
        /// <returns>String indicating the result of the operation</returns>
        static string ParsingOptions(ApplicationCommandLine options)
        {
            if (options.Operation == ApplicationCommandLine.OperationType.Block)
            {
                return Restricter.RestrictProgram(options.PathFile, options.Username);
            }
            else if (options.Operation == ApplicationCommandLine.OperationType.Unblock)
            {
                return Restricter.UnrestrictProgram(options.PathFile, options.Username);
            }
            else
            {
                return "Unexpected input given.";
            }
        }

        static string ErrorHandler(System.Collections.Generic.IEnumerable<Error> erros)
        {
            return "error happend";
        }
    }
}
