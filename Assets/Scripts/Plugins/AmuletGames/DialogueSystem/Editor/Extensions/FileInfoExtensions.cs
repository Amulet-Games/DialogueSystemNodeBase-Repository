using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

namespace AG.DS
{
    public static class FileInfoExtensions
    {
        public static bool IsFileEmpty(this string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            return fileInfo.Length == 0
                || fileInfo.Length < 10 && File.ReadAllText(filePath).Length == 0;
        }


        public static bool IsFileExist(this string filePath)
        {
            return File.Exists(filePath);
        }
    }
}