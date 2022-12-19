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
            Action<EventModifier> addToSegmentAction,
            Action<EventModifier> removeFromSegmentAction
        )
        {
            ObjectField eventSOField;

            Button modifierRemoveButton;

            SetupModifierBox();

            SetupEventSOField();

            SetupModifierRemoveButton();

            CheckSourceValues();

            AddFieldsToBox();

            InvokeModifierCreatedAction();

            void SetupModifierBox()
            {
                MainBox = new Box();
                MainBox.AddToClassList(StylesConfig.Modifier_Event_MainBox);
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
                modifierRemoveButton = ModifierFactory.GetNewModifierRemoveButton
                (
                    action: () => removeFromSegmentAction.Invoke(this),
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
                addToSegmentAction.Invoke(this);
            }
        }
    }
}