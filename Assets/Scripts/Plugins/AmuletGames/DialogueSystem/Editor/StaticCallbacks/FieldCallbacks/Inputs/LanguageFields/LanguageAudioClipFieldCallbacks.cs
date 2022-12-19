using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEngine;
using UnityEditor;

namespace AG.DS
{
    public class LanguageAudioClipFieldCallbacks : FieldCallbacksBase
    {
        /// <summary>
        /// Each time the object field is assigned to a new value,
        /// <br>the correct language value(audio clip) will be changed at the sametime.<br>
        /// <br>field's style will also change based on the field is empty or not.<br>
        /// </summary>
        /// <param name="languageAudioClipContainer">The container of which the field is connecting to.</param>
        public static void RegisterValueChangedEvent
        (
            LanguageAudioClipContainer languageAudioClipContainer
        )
        {
            // Cache the container's object field.
            var objectField = languageAudioClipContainer.ObjectField;

            objectField.RegisterValueChangedCallback(callback =>
            {
                // Unbind the previous bound object from the field.
                objectField.Unbind();

                // Push the current container's value to the undo stack.
                ///TestingWindow.Instance.PushUndo(languageAudioClipContainer);

                if (callback.newValue)
                {
                    // Set the new value to the container.
                    languageAudioClipContainer.LanguageGeneric
                        .ValueByLanguageType[LanguagesConfig.SelectedLanguage] = callback.newValue as AudioClip;

                    // Bind the new value to the field.
                    objectField.Bind(obj: new SerializedObject(callback.newValue));

                    // Hide empty style.
                    ObjectFieldHelper.HideEmptyStyle(objectField);
                }
                else
                {
                    // Set the container's value to null.
                    languageAudioClipContainer.LanguageGeneric
                        .ValueByLanguageType[LanguagesConfig.SelectedLanguage] = null;

                    // Show empty style.
                    ObjectFieldHelper.ShowEmptyStyle(objectField);
                }

                // Set has unsaved changes to true.
                InvokeWindowChangedEvent();
            });
        }


        /// <summary>
        /// Each time when the object field is selected, shows the language dependent input hint next to the field.
        /// </summary>
        /// <param name="objectField">The field to register the event on.</param>
        public static void RegisterFieldFocusInEvent(ObjectField objectField)
        {
            objectField.RegisterCallback<FocusInEvent>(callback =>
            {
                InputHint.Instance.ShowHint
                (
                    hintText: StringsConfig.LanguageFieldInputHintText,
                    targetWorldBoundRect: objectField.worldBound
                );
            });
        }


        /// <summary>
        /// Each time when the object field is deselected, hides the language dependent input hint next to the field.
        /// </summary>
        /// <param name="objectField">The field to register the event on.</param>
        public static void RegisterFieldFocusOutEvent(ObjectField objectField)
        {
            objectField.RegisterCallback<FocusOutEvent>(callback =>
            {
                InputHint.Instance.HideHint();
            });
        }
    }
}