using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AG.DS
{
    public class CSVToolbar
    {
        [MenuItem("Custom Tools/Dialogue/Save to CSV")]
        public static void SaveToCSV()
        {
            SaveCSV saveCSV = new SaveCSV();
            saveCSV.Save();

            EditorApplication.Beep();
            Debug.Log("<color=green> Save CSV File successfully! </color>");
        }

        [MenuItem("Custom Tools/Dialogue/Load from CSV")]
        public static void LoadFromCSV()
        {
            LoadCSV loadCSV = new LoadCSV();
            loadCSV.Load();

            EditorApplication.Beep();
            Debug.Log("<color=green> Loading CSV File successfully! </color>");
        }

        [MenuItem("Custom Tools/Dialogue/Update Dialogue Languages")]
        public static void UpdataDialogueLanguage()
        {
            CSVExistingLanguageRefresher refresher = new CSVExistingLanguageRefresher();
            refresher.UpdateLanguage();

            EditorApplication.Beep();
            Debug.Log("<color=green> Update languages successfully! </color>");
        }
    }
}