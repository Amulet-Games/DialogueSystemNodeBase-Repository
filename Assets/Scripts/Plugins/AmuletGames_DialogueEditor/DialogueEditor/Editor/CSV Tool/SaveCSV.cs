using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace AG
{
    public class SaveCSV
    {
        //private string directoryName = "Resources/Dialogue/CSV_Files";
        //private string fileName = "DialogueCSV_Save.csv";
        //private string seperator = ",";
        //private string guidName = "Guid ID";

        //G_LanguageTypeEnum[] languageTypes;

        public void Save()
        {
            //void Create_CSV_Headers()
            //{
            //    List<string> header = new List<string>();

            //    AddGuidIDTextToList_Header();

            //    AddSupportLanguageToList_Header();

            //    MakeCSVText_Header();

            //    void AddGuidIDTextToList_Header()
            //    {
            //        header.Add(guidName);
            //    }

            //    void AddSupportLanguageToList_Header()
            //    {
            //        G_LanguageTypeEnum[] languageTypes = (G_LanguageTypeEnum[])Enum.GetValues(typeof(G_LanguageTypeEnum));
            //        for (int i = 0; i < languageTypes.Length; i++)
            //        {
            //            header.Add(languageTypes[i].ToString());
            //        }
            //    }

            //    void MakeCSVText_Header()
            //    {
            //        using (StreamWriter sw = File.CreateText(GetFilePath()))
            //        {
            //            string finalString = "";

            //            int headerCount = header.Count;
            //            for (int i = 0; i < headerCount; i++)
            //            {
            //                if (finalString != "")
            //                {
            //                    finalString += seperator;
            //                }

            //                finalString += header[i];
            //            }

            //            sw.WriteLine(finalString);
            //        }
            //    }
            //}

            //void Create_CSV_Body()
            //{
            //    List<string> texts;

            //    List<DialogueContainerSO> dialContainers = CSVHelper.FindAllObjectsFromResources<DialogueContainerSO>();
            //    foreach (DialogueContainerSO containerSO in dialContainers)
            //    {
            //        foreach (DialogueNodeData nodeData in containerSO.dialogueNodeDataSavables)
            //        {
            //            texts = new List<string>();
            //            texts.Add(nodeData.nodeGuid);

            //            for (int i = 0; i < languageTypes.Length; i++)
            //            {
            //                string _dialogueNode_string_lg = nodeData.String_LGs.Find(String_LG => String_LG.languageType == languageTypes[i]).genericContent.Replace("\"", "\"\"");
            //                texts.Add($"\"{_dialogueNode_string_lg}\"");
            //            }

            //            AppendToFile();

            //            foreach (ChoiceData choiceData in nodeData.choiceDataList)
            //            {
            //                texts = new List<string>();
            //                texts.Add(choiceData.dataGuid);

            //                for (int i = 0; i < languageTypes.Length; i++)
            //                {
            //                    string _choiceData_string_lg = choiceData.String_LGs.Find(String_LG => String_LG.languageType == languageTypes[i]).genericContent.Replace("\"", "\"\"");
            //                    texts.Add($"\"{_choiceData_string_lg}\"");
            //                }

            //                AppendToFile();
            //            }
            //        }
            //    }

            //    void AppendToFile()
            //    {
            //        using (StreamWriter sw = File.AppendText(GetFilePath()))
            //        {
            //            string finalString = "";

            //            int stringCount = texts.Count;
            //            for (int i = 0; i < stringCount; i++)
            //            {
            //                if (finalString != "")
            //                {
            //                    finalString += seperator;
            //                }

            //                finalString += texts[i];
            //            }

            //            sw.WriteLine(finalString);
            //        }
            //    }
            //}

            //void CreateDirectory()
            //{
            //    string directory = GetDirectoryPath();

            //    if (!Directory.Exists(directory))
            //    {
            //        Directory.CreateDirectory(directory);
            //    }
            //}

            //string GetFilePath()
            //{
            //    return $"{GetDirectoryPath()}/{fileName}";
            //}

            //string GetDirectoryPath()
            //{
            //    return $"{Application.dataPath}/{directoryName}";
            //}
        }
    }
}