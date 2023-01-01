using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class LanguageAudioClipFieldCallbacks
    {
        /// <summary>
        /// Register new value changed actions to the given container's field element.
        /// </summary>
        /// <param name="languageAudioClipContainer">The container that connects with the field that the value changed actions are assigning to.</param>
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
                WindowChangedEvent.Invoke();
            });
        }


        /// <summary>
        /// Register new focus in actions to the given field element.
        /// </summary>
        /// <param name="objectField">The field to assign the focus in actions to.</param>
        public static void RegisterFocusInEvent(ObjectField objectField)
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
        /// Register new focus out actions to the given field element.
        /// </summary>
        /// <param name="objectField">The field to assign the focus out actions to.</param>
        public static void RegisterFocusOutEvent(ObjectField objectField)
        {
            objectField.RegisterCallback<FocusOutEvent>(callback =>
            {
                InputHint.Instance.HideHint();
            });
        }
    }
}