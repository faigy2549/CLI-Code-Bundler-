using System;
using System.Collections.Generic;
using System.CommandLine.Invocation;
using System.CommandLine;
using codeBundler.Services;


namespace codeBundler.Commands
{
    public static class BundleCommand
    {
        public static Command CreateCommand()
        {
            var command = new Command("bundle", "Bundle code files into a single file.");

            var languageOption = new Option<string>(
                new[] { "--language", "-l" },
                "Programming language to include (e.g., cs, js, all)");
            languageOption.IsRequired = true;
            command.AddOption(languageOption);

            var outputOption = new Option<string?>(
                new[] { "--output", "-o" },
                "Output path for the bundled file (default: 'bundle.txt').");
            command.AddOption(outputOption);

            var noteOption = new Option<bool>(
                new[] { "--note", "-n" },
                "Include file names and paths as comments.");
            command.AddOption(noteOption);

            var sortOption = new Option<string>(
                new[] { "--sort", "-s" },
                () => "filename",
                "Sorting order (filename or type).");
            command.AddOption(sortOption);

            var removeEmptyLinesOption = new Option<bool>(
                new[] { "--remove-empty-lines", "-r" },
                "Remove empty lines from code files.");
            command.AddOption(removeEmptyLinesOption);

            var authorOption = new Option<string?>(
                new[] { "--author", "-a" },
                "Include the author's name as a comment at the top.");
            command.AddOption(authorOption);

            // Bind the handler
            command.SetHandler(
             (string language, string? output, bool note, string sort, bool removeEmptyLines, string? author) =>
             {
                 BundlerService.BundleFiles(language, output, note, sort, removeEmptyLines, author);
             },
             languageOption, outputOption, noteOption, sortOption, removeEmptyLinesOption, authorOption);

            return command;
        }
    }
}

