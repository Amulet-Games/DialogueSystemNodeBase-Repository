using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace AG
{
    public class LoadCSV
    {
        //private string directoryName = "Resources/Dialogue/CSV_Files";
        //private string fileName = "DialogueCSV_Save.csv";

        //List<List<string>> parsedCSVTexts;
        //List<string> headers;

        //G_LanguageTypeEnum[] languageTypes;

        //DialogueNodeData dialogueNodeData;
        //ChoiceData choiceData;

        public void Load()
        {
            //CSVReader csvReader = new CSVReader();

            //parsedCSVTexts = csvReader.ParseCSV(File.ReadAllText($"{Application.dataPath}/{directoryName}/{fileName}"));

            //headers = parsedCSVTexts[0];

            //languageTypes = (G_LanguageTypeEnum[])Enum.GetValues(typeof(G_LanguageTypeEnum));

            //List<DialogueContainerSO> dialContainers = CSVHelper.FindAllObjectsFromResources<DialogueContainerSO>();

            //foreach (DialogueContainerSO containerSO in dialContainers)
            //{
            //    foreach (DialogueNodeData _dialogueNodeData in containerSO.dialogueNodeDataSavables)
            //    {
            //        dialogueNodeData = _dialogueNodeData;
            //        LoadIntoDialogueNodeData();

            //        foreach (ChoiceData _choiceData in _dialogueNodeData.choiceDataList)
            //        {
            //            choiceData = _choiceData;
            //            LoadIntoChoiceData();
            //        }
            //    }

            //    EditorUtility.SetDirty(containerSO);
            //    AssetDatabase.SaveAssets();
            //}
        }

        //void LoadIntoDialogueNodeData()
        //{
        //    foreach (List<string> row in parsedCSVTexts)
        //    {
        //        if (row[0] == dialogueNodeData.nodeGuid)
        //        {
        //            int row_Elements_Count = row.Count;
        //            for (int i = 0; i < row_Elements_Count; i++)
        //            {
        //                foreach (G_LanguageTypeEnum languageType in languageTypes)
        //                {
        //                    if (headers[i] == languageType.ToString())
        //                    {
        //                        dialogueNodeData.String_LGs.Find(String_LG => String_LG.languageType == languageType).genericContent = row[i];
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        //void LoadIntoChoiceData()
        //{
        //    foreach (List<string> row in parsedCSVTexts)
        //    {
        //        if (row[0] == choiceData.dataGuid)
        //        {
        //            int row_Elements_Count = row.Count;
        //            for (int i = 0; i < row_Elements_Count; i++)
        //            {
        //                foreach (G_LanguageTypeEnum languageType in languageTypes)
        //                {
        //                    if (headers[i] == languageType.ToString())
        //                    {
        //                        choiceData.String_LGs.Find(String_LG => String_LG.languageType == languageType).genericContent = row[i];
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}
    }
}