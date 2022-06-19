using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace AG
{
    public static class CSVHelper
    {
        public static List<T> FindAllObjectFromResources<T>()
        {
            List<T> _list = new List<T>();

            string resourcesPath = Application.dataPath + "/Resources";
            string[] directories = Directory.GetDirectories(resourcesPath, "*", SearchOption.AllDirectories);

            for (int i = 0; i < directories.Length; i++)
            {
                string directoryPath = directories[i].Substring(resourcesPath.Length + 1);              // 1 is the '/' located at the end.
                T[] result = Resources.LoadAll(directoryPath, typeof(T)).Cast<T>().ToArray();

                for (int j = 0; j < result.Length; j++)
                {
                    if (!_list.Contains(result[j]))
                    {
                        _list.Add(result[j]);
                    }
                }
            }

            return _list;
        }

        /// This method will search through the whole "Asset" directory to find Dialogue Container SO
        /// Since it could be heavy to use based on the project size, currently it is not used.
        public static List<DialogueContainerSO> FindAllDialogueContainerSO()
        {
            // Find all the Dialogue Container SO in Assets and get it GUID.
            string[] guids = AssetDatabase.FindAssets("t:DialogueContainerSO");

            int guidsLength = guids.Length;

            // Create an array with the exact amount of Dialogue Container SO that we've found.
            DialogueContainerSO[] containerSOs = new DialogueContainerSO[guidsLength];

            string path;
            for (int i = 0; i < guidsLength; i++)
            {
                // Use the GUID to find the asset path
                path = AssetDatabase.GUIDToAssetPath(guids[i]);

                // Use the path to find and load Dialogue Container SO.
                containerSOs[i] = AssetDatabase.LoadAssetAtPath<DialogueContainerSO>(path);
            }

            return containerSOs.ToList();
        }
    }
}