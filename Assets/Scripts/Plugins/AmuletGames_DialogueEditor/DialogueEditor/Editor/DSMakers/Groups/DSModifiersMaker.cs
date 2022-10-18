using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG
{
    public class DSModifiersMaker
    {
        /// <summary>
        /// Create a new condition modifier within any nodes that are specified in the modifierAddedAction.
        /// </summary>
        /// <param name="source">The another modifier that has the values to this new modifier to load from if it's provided.</param>
        /// <param name="conditionModifierAddedAction">Action to invoke at the end of this setup process.</param>
        /// <param name="conditionModifierRemovedAction">Action to invoke when this modifier is deleted from the node.</param>
        public static void GetNewConditionModifier
        (
            ConditionModifier source,
            Action<ConditionModifier> conditionModifierAddedAction,
            Action<ConditionModifier> conditionModifierRemovedAction
        )
        {
            ConditionModifier newConditionModifier;

            Box mainBox;

            TextField conditionNameTextField;
            FloatField comparisonNumberFloatField;
            EnumField conditionComparisonTypeEnumField;

            Button modifierRemoveButton;

            CreateNewModifier();

            SetupModifierBox();

            SetupConditionNameTextField();

            SetupComparisonNumberFloatField();

            SetupConditionComparisonTypeEnumField();

            SetupModifierRemoveButton();

            CheckSourceValues();

            AddFieldsToBox();

            AssignReferencesToModifier();

            ConditionModifierAddedAction();

            void CreateNewModifier()
            {
                newConditionModifier = new ConditionModifier();
            }

            void SetupModifierBox()
            {
                mainBox = new Box();
                mainBox.AddToClassList(DSStylesConfig.Modifier_Condition_MainBox);
            }

            void SetupConditionNameTextField()
            {
                conditionNameTextField = DSTextFieldsMaker.GetNewTextField
                (
                    newConditionModifier.ConditionNameTextContainer,
                    false,
                    DSStringsConfig.ConditionModifierConditionNamePlaceHolderText,
                    DSStylesConfig.Modifier_Condition_TextField
                );
            }

            void SetupComparisonNumberFloatField()
            {
                comparisonNumberFloatField = DSFloatFieldsMaker.GetNewFloatField
                (
                    newConditionModifier.ComparisonNumberFloatContainer,
                    DSStylesConfig.Modifier_Condition_FloatField
                );
            }

            void SetupConditionComparisonTypeEnumField()
            {
                conditionComparisonTypeEnumField = DSEnumFieldsMaker.GetNewEnumField
                (
                    newConditionModifier.ConditionComparisonTypeEnumContainer,
                    EnumFieldValueChangedAction,
                    DSStylesConfig.Modifier_Condition_EnumField
                );
            }

            void SetupModifierRemoveButton()
            {
                modifierRemoveButton = GetNewModifierRemoveButton(ConditionModifierRemovedAction);
            }

            void CheckSourceValues()
            {
                if (source != null)
                {
                    newConditionModifier.LoadModifierValue(source);
                }
            }

            void AddFieldsToBox()
            {
                mainBox.Add(conditionNameTextField);
                mainBox.Add(conditionComparisonTypeEnumField);
                mainBox.Add(comparisonNumberFloatField);
                mainBox.Add(modifierRemoveButton);
            }

            void AssignReferencesToModifier()
            {
                newConditionModifier.MainBox = mainBox;
            }

            void ConditionModifierAddedAction()
            {
                conditionModifierAddedAction.Invoke(newConditionModifier);
                EnumFieldValueChangedAction();
            }

            void ConditionModifierRemovedAction()
            {
                conditionModifierRemovedAction.Invoke(newConditionModifier);
            }

            void EnumFieldValueChangedAction()
            {
                newConditionModifier.ToggleConditionNumberDisplay();
            }
        }


        /// <summary>
        /// Create a new event modifier within any nodes that are specified in the modifierAddedAction.
        /// </summary>
        /// <param name="source">The another modifier that has the values to this new modifier to load from if it's provided.</param>
        /// <param name="eventModifierAddedAction">Action to invoke at the end of this setup process.</param>
        /// <param name="eventModifierRemovedAction">Action to invoke when this modifier is deleted from the node.</param>
        public static void GetNewEventModifier
        (
            EventModifier source,
            Action<EventModifier> eventModifierAddedAction,
            Action<EventModifier> eventModifierRemovedAction
        )
        {
            EventModifier newEventModifier;

            Box mainBox;

            ObjectField eventSOField;

            Button modifierRemoveButton;

            CreateNewModifier();

            SetupModifierBox();

            SetupEventSOField();

            SetupModifierRemvoeButton();

            CheckSourceValues();

            AddFieldsToBox();

            AssignReferencesToModifier();

            EventModifierAddedAction();

            void CreateNewModifier()
            {
                newEventModifier = new EventModifier();
            }

            void SetupModifierBox()
            {
                mainBox = new Box();
                mainBox.AddToClassList(DSStylesConfig.Modifier_Event_MainBox);
            }

            void SetupEventSOField()
            {
                eventSOField = DSObjectFieldsMaker.GetNewObjectField
                (
                    newEventModifier.EventObjectContainer,
                    DSAssetsConfig.InputHintIconSprite,
                    DSStylesConfig.Modifier_Event_ObjectField
                );
            }

            void SetupModifierRemvoeButton()
            {
                modifierRemoveButton = GetNewModifierRemoveButton(EventModifierRemovedAction);
            }

            void CheckSourceValues()
            {
                if (source != null)
                {
                    newEventModifier.LoadModifierValue(source);
                }
            }

            void AddFieldsToBox()
            {
                mainBox.Add(eventSOField);
                mainBox.Add(modifierRemoveButton);
            }

            void AssignReferencesToModifier()
            {
                newEventModifier.MainBox = mainBox;
            }

            void EventModifierAddedAction()
            {
                eventModifierAddedAction.Invoke(newEventModifier);
            }

            void EventModifierRemovedAction()
            {
                eventModifierRemovedAction.Invoke(newEventModifier);
            }
        }


        /// <summary>
        /// Create a new modifier's remove button within each modifier.
        /// </summary>
        /// <param name="modifierRemovedAction">The action to invoke when remove button is pressed.</param>
        /// <returns>A new button to remove the modifier that it's connecting to.</returns>
        static Button GetNewModifierRemoveButton(Action modifierRemovedAction)
            =>
            DSButtonsMaker.GetNewButton
            (
                DSAssetsConfig.RemoveModifierButtonIconImage,
                modifierRemovedAction,
                DSStylesConfig.Modifier_RemoveModifier_Button
            );
    }
}