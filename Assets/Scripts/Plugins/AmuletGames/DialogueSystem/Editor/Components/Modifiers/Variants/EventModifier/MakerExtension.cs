using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG.DS
{
    public partial class EventModifier
        : ModifierFrameBase<EventModifier, EventModifierData>
    {
        /// <inheritdoc />
        public override void CreateInstanceElements
        (
            EventModifierData data,
            Action<EventModifier> modifierCreatedAction,
            Action<EventModifier> removeButtonClickAction
        )
        {
            ObjectField eventSOField;

            Button modifierRemoveButton = null;

            SetupModifierBox();

            SetupEventSOField();

            SetupModifierRemoveButton();

            CheckSourceValues();

            AddFieldsToBox();

            InvokeModifierCreatedAction();

            void SetupModifierBox()
            {
                MainBox = new();
                MainBox.AddToClassList(StylesConfig.Modifier_Event_Main_Box);
            }

            void SetupEventSOField()
            {
                eventSOField = ObjectFieldFactory.GetNewObjectField
                (
                    objectContainer: EventObjectContainer,
                    fieldIcon: AssetsConfig.LanguageFieldHintIconSprite,
                    fieldUSS01: StylesConfig.Modifier_Event_ObjectField
                );
            }

            void SetupModifierRemoveButton()
            {
                modifierRemoveButton = ButtonFactory.GetNewButton
                (
                    isAlert: true,
                    buttonSprite: AssetsConfig.RemoveButtonIcon2Sprite,
                    buttonClickAction: () => removeButtonClickAction.Invoke(this),
                    buttonUSS01: StylesConfig.Modifier_Event_RemoveModifier_Button
                );
            }

            void CheckSourceValues()
            {
                if (data != null)
                    LoadModifierValue(data);
            }

            void AddFieldsToBox()
            {
                // Main box
                MainBox.Add(eventSOField);
                MainBox.Add(modifierRemoveButton);
            }

            void InvokeModifierCreatedAction()
            {
                modifierCreatedAction.Invoke(this);
            }
        }
    }
}