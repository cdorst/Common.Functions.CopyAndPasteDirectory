using System.IO;
using static System.IO.Path;
using static Common.Functions.CreateDirectory.DirectoryCreator;

namespace Common.Functions.CopyAndPasteDirectory
{
    public static class DirectoryCopier
    {
        public static void Copy(string sourcePath, string destinationPath)
        {
            var directoryInfo = GetDirectoryInfo(sourcePath);
            CopyFiles(directoryInfo, destinationPath);
            CopyFolders(directoryInfo, destinationPath);
        }

        private static void CopyFiles(DirectoryInfo directory, string destinationPath)
        {
            foreach (var file in directory.GetFiles())
                file.CopyTo(Combine(destinationPath, file.Name), overwrite: true);
        }

        private static void CopyFolders(DirectoryInfo directory, string destinationPath)
        {
            foreach (var subdirectory in directory.GetDirectories())
            {
                var destinationSubdirectory = Combine(destinationPath, subdirectory.Name);
                Create(destinationSubdirectory);
                Copy(subdirectory.FullName, destinationSubdirectory);
            }
        }

        private static DirectoryInfo GetDirectoryInfo(string sourcePath)
            => new DirectoryInfo(sourcePath);
    }
}
