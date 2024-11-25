using System;
using System.CommandLine;
using System.IO;

namespace codeBundler.Commands
{
    public static class CreateRspCommand
    {
        public static Command CreateCommand()
        {
            var command = new Command("create-rsp", "Create a response file for the 'bundle' command.");

            command.SetHandler(() =>
            {
                Console.WriteLine("Enter values for the following options:");

                Console.Write("Language (e.g., cs, js, all): ");
                var language = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(language))
                {
                    language = "all"; 
                }

                string output = "bundle.txt"; 
                while (true)
                {
                    Console.Write("Output file path (must be a valid file, default 'bundle.txt'): ");
                    var userOutput = Console.ReadLine()?.Trim();

                    if (string.IsNullOrEmpty(userOutput)) 
                    {
                        break; 
                    }

                    if (!userOutput.Contains('.'))
                    {
                        Console.WriteLine("Invalid file path. A file extension is required (e.g., .txt, .rsp).");
                    }
                    else
                    {
                        output = userOutput; 
                        break;
                    }
                }

                bool note = false;
                while (true)
                {
                    Console.Write("Include notes (true/false, default false): ");
                    var noteInput = Console.ReadLine()?.Trim();
                    if (string.IsNullOrEmpty(noteInput))
                    {
                        break; 
                    }
                    if (bool.TryParse(noteInput, out note))
                    {
                        break;
                    }
                    Console.WriteLine("Invalid input. Please enter 'true' or 'false' for notes.");
                }

                string sort;
                while (true)
                {
                    Console.Write("Sort by (filename/type, default is filename): ");
                    sort = Console.ReadLine()?.Trim();

                    if (string.IsNullOrEmpty(sort))
                    {
                        sort = "filename";
                        break;
                    }

                    if (sort == "filename" || sort == "type")
                    {
                        break;
                    }

                    Console.WriteLine("Invalid input. Please enter 'filename' or 'type'.");
                }


                bool removeEmptyLines = true;
                while (true)
                {
                    Console.Write("Remove empty lines (true/false, default true): ");
                    var removeInput = Console.ReadLine()?.Trim();
                    if (string.IsNullOrEmpty(removeInput))
                    {
                        break; 
                    }
                    if (bool.TryParse(removeInput, out removeEmptyLines))
                    {
                        break;
                    }
                    Console.WriteLine("Invalid input. Please enter 'true' or 'false' for removing empty lines.");
                }

                Console.Write("Author's name (optional): ");
                var author = Console.ReadLine()?.Trim();
                author = string.IsNullOrEmpty(author) ? "unknown" : author;

                var rspContent = $"-l {language}\n" +
                                 $"-o {output}\n" +
                                 $"-n {note}\n" +
                                 $"-s {sort}\n" +
                                 $"-r {removeEmptyLines}\n" +
                                 $"-a {author}";


                File.WriteAllText(@"C:\CustomCommands\configs\bundle.rsp", rspContent);

                Console.WriteLine("Response file created: bundle.rsp");
            });
            return command;
        }
    }
}
