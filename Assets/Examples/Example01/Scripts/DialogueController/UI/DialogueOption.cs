using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace AG
{
    using DS;

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