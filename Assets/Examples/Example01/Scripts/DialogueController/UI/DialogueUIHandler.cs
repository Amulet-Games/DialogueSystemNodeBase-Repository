using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

namespace AG
{
    using DS;

    public class DialogueUIHandler : MonoBehaviour
    {
        [Header("Canvas (Drops).")]
        public Canvas dialogueUICanvas;

        [Header("Text UI (Drops).")]
        public TMP_Text speakerNameText;
        public TMP_Text speakerDialText;

        [Header("Image UI (Drops).")]
        public Image avatarImage;
        public Canvas avatarCanvas;

        [Header("Button UI (Drops).")]
        public DialogueOption[] dialogueOptions;

        [Header("Static.")]
        public static DialogueUIHandler singleton;

        #region Callbacks.
        private void Awake()
        {
            if (singleton != null)
            {
                Destroy(gameObject);
            }
            else
            {
                singleton = this;
            }
        }

        private void Start()
        {
            HideDialogueUI();
        }
        #endregion

        #region Show / Hide UI.
        public void ShowDialogueUI()
        {
            dialogueUICanvas.enabled = true;
        }

        public void HideDialogueUI()
        {
            dialogueUICanvas.enabled = false;
        }
        #endregion

        #region Text UI.
        public void SetSpeakerText(string _name, string _dialText)
        {
            speakerNameText.text = _name;
            speakerDialText.text = _dialText;
        }
        #endregion

        #region Image UI.
        public void SetSpeakerAvatar(Sprite _sprite)
        {
            if (_sprite != null)
            {
                avatarCanvas.enabled = true;
                avatarImage.sprite = _sprite;
            }
            else
            {
                avatarCanvas.enabled = false;
            }
        }
        #endregion

        #region Options UI.
        public void SetOptions(List<string> _optionTexts, List<UnityAction> _optionActions)
        {
            for (int i = 0; i < dialogueOptions.Length; i++)
            {
                dialogueOptions[i].HideOption();
            }

            for (int i = 0; i < _optionTexts.Count; i++)
            {
                dialogueOptions[i].ShowOption();
                dialogueOptions[i].optionText.text = _optionTexts[i];

                dialogueOptions[i].optionBtn.onClick = new Button.ButtonClickedEvent();
                dialogueOptions[i].optionBtn.onClick.AddListener(_optionActions[i]);
            }
        }
        #endregion
    }
}