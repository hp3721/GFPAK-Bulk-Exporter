using System;
using System.IO;
using pkNX.Containers;

namespace GFPAK_Bulk_Exporter
{
    internal class Program
    {
        static readonly ContainerHandler ProgressTracker = new();

        static void Main(string[] args)
        {
            const string defaultPath = @"D:\Dumps\01001F5010DFA000\romfs\bin\archive";
            var path = args.Length > 0 ? args[0] : defaultPath;
            string PathGFPAK = path.Replace("archive", "extracted_archive");
            FileMitm.SetRedirect(PathGFPAK, PathGFPAK);
            ExtractGFPAKToFolder(path, PathGFPAK);
        }

        public static void ExtractGFPAKToFolder(string path, string dest)
        {
            Console.WriteLine("Dumping GFPAK files...");
            var files = Directory.EnumerateFiles(path, "*.gfpak", SearchOption.AllDirectories);
            foreach (var f in files)
            {
                try
                {
                    var gfpak = new GFPack(f);
                    var rpath = f.Replace(path, dest);
                    var dir = Path.GetDirectoryName(rpath);
                    if (dir == null)
                        throw new Exception("Bad directory?");
                    Directory.CreateDirectory(dir);
                    Console.WriteLine($"New GFPAK with {gfpak.Count} files.");
                    gfpak.Dump(rpath, ProgressTracker);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return;
                }
            }
            Console.WriteLine("Done!");
        }
    }
}
