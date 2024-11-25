using System.CommandLine;
using System.CommandLine.Invocation;
using codeBundler.Commands;
using System;

var rootCommand = new RootCommand("CodeBundler CLI")
{
    BundleCommand.CreateCommand(),
    CreateRspCommand.CreateCommand()
};

return await rootCommand.InvokeAsync(args);