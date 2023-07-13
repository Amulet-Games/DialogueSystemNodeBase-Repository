using System.IO;

namespace AG.DS
{
    public static class FilePathExtensions
    {
        /// <summary>
        /// Returns true if the file has no content.
        /// </summary>
        /// <param name="filePath">Extension file path</param>
        /// <returns>True if the file has no content.</returns>
        public static bool IsFileEmpty(this string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            return fileInfo.Length == 0
                || fileInfo.Length < 10 && File.ReadAllText(filePath).Length == 0;
        }
    }
}