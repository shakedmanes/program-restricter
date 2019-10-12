using CommandLine;
using System;

namespace program_restricter
{
    static class ProgramRestricter
    {

        static void Main(string[] args)
        {
            // Performing operation according to arguments given
            Parser.Default.ParseArguments<BlockOptions, UnblockOptions>(args)
                .WithParsed<BlockOptions>(opts => ParsingBlockOptions(opts))
                .WithParsed<UnblockOptions>(opts => ParsingUnblockOptions(opts));

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("NOTE: Changes takes effect only after restart");
            Console.ResetColor();

            // For debugging purposes
            //Console.Read();
        }

        /// <summary>
        /// Parser for Block options
        /// </summary>
        /// <param name="options">Command Line options for blocking programs</param>        
        static void ParsingBlockOptions(BlockOptions options)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            // If only got Username 
            if (options.ProgramName == null && options.PathFile == null && options.ProgramsList == null)
            {
                Console.WriteLine("Missing actual file/s to block, maybe forgot to add file names or path?");
            }

            // Block single program
            if (options.ProgramName != null)
            {
                Console.WriteLine($"Blocking program {options.ProgramName} for user {options.Username}");
                try
                {
                    Restricter.RestrictProgram(options.ProgramName, options.Username);
                } catch (System.Exception err)
                {
                    ErrorHandler(err);
                }
            }

            // Block multiple programs via file
            if (options.PathFile != null)
            {
                Console.WriteLine($"Blocking programs in file {options.PathFile} for user {options.Username}");
                try
                {
                    Restricter.RestrictProgramsByFile(options.PathFile, options.Username);
                } catch (System.Exception err)
                {
                    ErrorHandler(err);
                }
            }

            // Block programs list
            if (options.ProgramsList != null)
            {
                string[] parsedProgramsList = EnumeratorToArray(options.ProgramsList);
                Console.WriteLine($"Blocking programs {string.Join(',', parsedProgramsList)} for user {options.Username}");
                Restricter.RestrictProgramsByList(parsedProgramsList, options.Username);
            }

            Console.ResetColor();
        }

        /// <summary>
        /// Parser for Unblocking options
        /// </summary>
        /// <param name="options">Command Line options for unblocking programs</param>
        static void ParsingUnblockOptions(UnblockOptions options)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            // If only got Username 
            if (options.ProgramName == null && options.PathFile == null && options.ProgramsList == null && options.All == false)
            {
                Console.WriteLine("Missing actual file/s to unblock, maybe forgot to add file names or path?");
            }

            // Unblock single program 
            if (options.ProgramName != null)
            {
                Console.WriteLine($"Unblocking program {options.ProgramName} for user {options.Username}");
                try
                {
                    Restricter.UnrestrictProgram(options.ProgramName, options.Username);
                } catch (System.Exception err)
                {
                    ErrorHandler(err);
                }
            }

            // Unblock multiple programs via file
            if (options.PathFile != null)
            {
                Console.WriteLine($"Unblocking programs in file {options.PathFile} for user {options.Username}");
                try
                {
                    Restricter.UnrestrictProgramsByFile(options.PathFile, options.Username);
                } catch (SystemException err)
                {
                    ErrorHandler(err);
                }
            }
            
            // Unblock all programs listed as restricted for user
            if (options.All)
            {
                Console.WriteLine($"Unblocking all programs for user {options.Username}");
                Restricter.UnrestrictAll(options.Username);
            }

            // Unblock programs list
            if (options.ProgramsList != null)
            {
                string[] parsedProgramsList = EnumeratorToArray(options.ProgramsList);
                Console.WriteLine($"Unblocking programs {string.Join(',', parsedProgramsList)} for user {options.Username}");
                Restricter.UnrestrictProgramsByList(parsedProgramsList, options.Username);
            }

            Console.ResetColor();
        }

        /// <summary>
        /// Error handler for exceptions
        /// </summary>
        /// <param name="error">Exception error</param>
        static void ErrorHandler(System.Exception error)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;

            if (error is System.IO.FileNotFoundException)
            {
                Console.WriteLine($"ERROR: {error.Message}");
            }

            else
            {
                Console.WriteLine("ERROR: Unexpected input given, try 'help' to see how to use");                
            }

            Console.ResetColor();
        }

        /// <summary>
        /// Helper function for transforming Enumerable to an Array
        /// </summary>
        /// <param name="Enumerable">Enumerable object to transform into Array</param>
        /// <returns>Transformed Array from given Enumerable</returns>
        private static string[] EnumeratorToArray(System.Collections.Generic.IEnumerable<string> Enumerable)
        {
            System.Collections.Generic.List<string> TempList = new System.Collections.Generic.List<string>();
            System.Collections.Generic.IEnumerator<string> Enumerator = Enumerable.GetEnumerator();
            while (Enumerator.MoveNext())
            {
                TempList.Add(Enumerator.Current);
            }

            return TempList.ToArray();
        }
    }
}
