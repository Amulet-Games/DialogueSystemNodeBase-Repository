using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AG.DS
{
    public class CSVExistingLanguageRefresher
    {
        public void UpdateLanguage()
        {
            //List<DialogueContainerSO> dialogueContainers = Helper.FindAllDialogueContainerSO(); 

            //foreach (DialogueContainerSO DialogueContainer in dialogueContainers)
            //{
            //    foreach (DialogueNodeData nodeData in DialogueContainer.DialogueNodeDatas)
            //    {
            //        nodeData.TextLanguages = UpdateLanguageGeneric(nodeData.TextLanguages);
            //        nodeData.AudioClips = UpdateLanguageGeneric(nodeData.AudioClips);

            //        foreach (DialogueNodePort nodePort in nodeData.DialogueNodePorts)
            //        {
            //            nodePort.TextLanguages = UpdateLanguageGeneric(nodePort.TextLanguages);
            //        }
            //    }
            //}
        }

        //private List<LanguageGeneric<T>> UpdateLanguageGeneric<T>(List<LanguageGeneric<T>> languageGeneric)
        //{
        //    List<LanguageGeneric<T>> tmp = new();

        //    foreach (LanguageType languageType in (LanguageType[])Enum.GetValues(typeof(LanguageType)))
        //    {
        //        tmp.Add(new LanguageGeneric<T>
        //        {
        //            LanguageType = languageType
        //        });
        //    }

        //    foreach (LanguageGeneric<T> languageGeneric in languageGeneric)
        //    {
        //        if (tmp.Find(languag => languag.LanguageType == languageGeneric.LanguageType) != null)
        //        {
        //            tmp.Find(languag => languag.LanguageType == languageGeneric.LanguageType).LanguageGenericType = languageGeneric.LanguageGenericType;
        //        }
        //    }

        //    return tmp;
        //}
    }
}