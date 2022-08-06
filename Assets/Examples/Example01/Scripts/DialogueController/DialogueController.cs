using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AG
{
    public class DialogueController : MonoBehaviour
    {
        [Header("Refs")]
        [ReadOnlyInspector] public DialogueUIHandler dialogueUI;
        [ReadOnlyInspector] public DialogueUtility dialogueUtility;
        [ReadOnlyInspector] public AudioSource audioSource;

        //[Space(10)]
        //[ReadOnlyInspector] public DialogueNodeData cur_DialogueNodeData;
        //[ReadOnlyInspector] public DialogueNodeData prev_DialogueNodeData;

        #region Callbacks.
        private void Start()
        {
            SetupRefs();
        }
        #endregion

        //public void StartDialogue()
        //{
        //    dialogueUI.ShowDialogueUI();

        //    RunStartNode();
        //}

        #region Run.
        //void RunNodeByType(BaseNodeData _nodeData)
        //{
        //    switch (_nodeData)
        //    {
        //        case StartNodeData node:
        //            RunStartNode();
        //            break;
        //        case DialogueNodeData node:
        //            RunDialogueNode(node);
        //            break;
        //        case EventNodeData node:
        //            RunEventNode(node);
        //            break;
        //        case EndNodeData node:
        //            RunEndNode(node);
        //            break;
        //    }
        //}

        //void RunStartNode()
        //{
        //    RunNodeByType(dialogueUtility.GetFirstNodeDataAfterStart());
        //}

        //void RunDialogueNode(DialogueNodeData _dialogueNodeData)
        //{
        //    if (cur_DialogueNodeData != _dialogueNodeData)
        //    {
        //        prev_DialogueNodeData = cur_DialogueNodeData;
        //        cur_DialogueNodeData = _dialogueNodeData;
        //    }

        //    dialogueUI.SetSpeakerText(_dialogueNodeData.speakerName, _dialogueNodeData.String_LGs.Find(String_LG => String_LG.languageType == LanguageHandler.singleton.languageType).genericContent);
        //    dialogueUI.SetSpeakerAvatar(_dialogueNodeData.speakerSprite);

        //    // Set the option buttons
        //    MakeOptionButtons(_dialogueNodeData.choiceDataList);

        //    // Update the audio clip that will be played along the dialogue.
        //    audioSource.clip = _dialogueNodeData.AudioClip_LGs.Find(AudioClip_LG => AudioClip_LG.languageType == LanguageHandler.singleton.languageType).genericContent;
        //    audioSource.Play();
        //}

        //void RunEventNode(EventNodeData _eventNodeData)
        //{
        //    for (int i = 0; i < _eventNodeData.scriptableEventAddons.Count; i++)
        //    {
        //        _eventNodeData.scriptableEventAddons[i].dialEventSO.Execute();
        //    }

        //    RunNodeByType(dialogueUtility.GetNextNodeData(_eventNodeData));
        //}

        //void RunEndNode(EndNodeData _endNodeData)
        //{
        //    switch (_endNodeData.endNodeType)
        //    {
        //        case N_EndNodeTypeEnum.End:
        //            dialogueUI.HideDialogueUI();
        //            break;
        //        case N_EndNodeTypeEnum.Repeat:
        //            RunNodeByType(dialogueUtility.GetNodeDataByGuid(cur_DialogueNodeData.nodeGuid));
        //            break;
        //        case N_EndNodeTypeEnum.Goback:
        //            RunNodeByType(dialogueUtility.GetNodeDataByGuid(prev_DialogueNodeData.nodeGuid));
        //            break;
        //        case N_EndNodeTypeEnum.ReturnToStart:
        //            RunStartNode();
        //            break;
        //    }
        //}
        #endregion

        #region Choice Buttons.
        //void MakeOptionButtons(List<ChoiceData> _choiceDataList)
        //{
        //    List<string> choiceTexts = new List<string>();
        //    List<UnityAction> unityActions = new List<UnityAction>();

        //    foreach (ChoiceData choiceData in _choiceDataList)
        //    {
        //        // Set the option texts
        //        choiceTexts.Add(choiceData.String_LGs.Find(String_LG => String_LG.languageType == LanguageHandler.singleton.languageType).genericContent);

        //        // Set the option button function when player clicked it
        //        UnityAction action = null;
        //        action += () =>
        //        {
        //            // Run the next node that was found by choice data's input guid
        //            RunNodeByType(dialogueUtility.GetNodeDataByGuid(choiceData.inputGuid));

        //            // Stop the current audio immediately
        //            audioSource.Stop();
        //        };
        //        unityActions.Add(action);
        //    }

        //    dialogueUI.SetOptions(choiceTexts, unityActions);
        //}
        #endregion

        #region Init.
        void SetupRefs()
        {
            dialogueUI = DialogueUIHandler.singleton;

            dialogueUtility = GetComponent<DialogueUtility>();
            audioSource = GetComponent<AudioSource>();
        }
        #endregion

    }
}