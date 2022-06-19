using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG
{
    public class DSLanguageAudioClipFieldUtilityEditor : DSFieldUtilityEditor
    {
        /// <summary>
        /// Each time the object field is assigned to a new value,
        /// the correct language Content(audio clip) in the Language Generics will changed at the sametime.
        /// field's style will also change based on the field is empty or not.
        /// </summary>
        /// <param name="LG_AudioClipContainer">LG object container of which the object field is connecting to.</param>
        public static void RegisterValueChangedEvent(LanguageAudioClipContainer LG_AudioClipContainer)
        {
            LG_AudioClipContainer.ObjectField.RegisterValueChangedCallback(value =>
            {
                LG_AudioClipContainer.Value.Find(AudioClip_LG => AudioClip_LG.languageType == SupportLanguage.selectedLanguage).genericsContent = value.newValue as AudioClip;

                DSObjectFieldUtility.ToggleEmptyStyle(LG_AudioClipContainer.ObjectField);

                InvokeDSWindowChangedEvent();
            });
        }

        /// <summary>
        /// Each time when the object field is selected,
        /// show field is language dependent hint.
        /// </summary>
        /// <param name="LG_AudioClipField">The LG object field this event is registered upon on.</param>
        public static void RegisterFieldFocusInEvent(ObjectField LG_AudioClipField)
        {
            LG_AudioClipField.RegisterCallback<FocusInEvent>(_ =>
            {
                DialogueEditorWindow.dsWindow.graphView.inputHint.ShowHint(DSStringsConfig.LG_InputHintText, LG_AudioClipField.worldBound);
            });
        }

        /// <summary>
        /// Each time when the object field is deselected,
        /// if it's currently empty then hide field is language dependent hint.
        /// </summary>
        /// <param name="LG_AudioClipField">The LG object field this event is registered upon on.</param>
        public static void RegisterFieldFocusOutEvent(ObjectField LG_AudioClipField)
        {
            LG_AudioClipField.RegisterCallback<FocusOutEvent>(_ =>
            {
                DialogueEditorWindow.dsWindow.graphView.inputHint.HideHint();
            });
        }
    }
}