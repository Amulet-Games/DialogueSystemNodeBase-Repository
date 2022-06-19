using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace AG
{
    public class DialogueOption : MonoBehaviour
    {
        [Header("UI (Drops.)")]
        public TMP_Text optionText;
        public Button optionBtn;

        [Header("Canvas (Drops.)")]
        public Canvas optionCanvas;

        public void ShowOption()
        {
            optionCanvas.enabled = true;
        }

        public void HideOption()
        {
            optionCanvas.enabled = false;
        }
    }
}