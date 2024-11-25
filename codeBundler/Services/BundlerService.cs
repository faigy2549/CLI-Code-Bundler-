using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace codeBundler.Services
{

    public static class BundlerService
    {
        public static void BundleFiles(string language, string? output, bool note, string sort, bool removeEmptyLines, string? author)
        {
            var directory = Directory.GetCurrentDirectory();
            
            IEnumerable<string> filesInDirectory = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);

            IEnumerable<string> files;
            if (language.Trim().ToLower() == "all")
            {
                files = filesInDirectory
                            .Where(file => !file.Contains("bin", StringComparison.OrdinalIgnoreCase)
                                           && !file.Contains("obj", StringComparison.OrdinalIgnoreCase)
                                           && Path.GetFileName(file) != output
                                           && Path.GetFileName(file) != "bundle.rsp")
                            .ToList();
            }
            else
            {
                files = filesInDirectory
                            .Where(file => Path.GetExtension(file).Equals("." + language.Trim(), StringComparison.OrdinalIgnoreCase)
                                           && !file.Contains("bin", StringComparison.OrdinalIgnoreCase)
                                           && !file.Contains("obj", StringComparison.OrdinalIgnoreCase)
                                           )
                            .ToList();
            }

            if (!files.Any())
            {
                Console.WriteLine("No files found to bundle.");
                return;
            }

            output ??= "bundle.txt";

            using (var writer = new StreamWriter(output))
            {
                if (author != null)
                {
                    writer.WriteLine($"// Author: {author}");
                }

                foreach (var file in files.OrderBy(f => sort == "type" ? Path.GetExtension(f) : Path.GetFileName(f)))
                {
                    if (note)
                    {
                        writer.WriteLine($"// File: {file}");
                    }

                    var lines = File.ReadAllLines(file);

                    if (removeEmptyLines)
                    {
                        lines = lines.Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();
                    }

                    foreach (var line in lines)
                    {
                        writer.WriteLine(line);
                    }
                }
            }

            Console.WriteLine($"Files bundled into {output}");
        }
    }

}
