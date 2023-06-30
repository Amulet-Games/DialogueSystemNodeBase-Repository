using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace AG.DS
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
                // 1 is the '/' located at the end.
                string directoryPath = directories[i].Substring(resourcesPath.Length + 1);
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
        public static List<DialogueSystemModel> GetDialogueSystemModel()
        {
            // Find all the dialogue system model scriptable assets and cache their GUID.
            string[] GUIDs = AssetDatabase.FindAssets("t:DialogueSystemModel");

            var dsModels = new DialogueSystemModel[GUIDs.Length];

            string path;
            for (int i = 0; i < GUIDs.Length; i++)
            {
                // Use the GUID to find the asset path
                path = AssetDatabase.GUIDToAssetPath(GUIDs[i]);

                // Use the path to find and load Dialogue Container SO.
                dsModels[i] = AssetDatabase.LoadAssetAtPath<DialogueSystemModel>(path);
            }

            return dsModels.ToList();
        }
    }
}