using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG
{
    public class DSModifiersMaker
    {
        /// <summary>
        /// Create all the UIElements that are needed in this modifier as instance.
        /// </summary>
        /// <param name="source">The another modifier that has the values to this new modifier to load from if it's provided.</param>
        /// <param name="conditionModifierAddedAction">Action that will invoked at the end of this setup process.</param>
        /// <param name="conditionModifierRemovedAction">Action that will invoked when this modifier is deleted from the node.</param>
        public static void GetNewConditionModifier
            (ConditionModifier source, Action<ConditionModifier> conditionModifierAddedAction, Action<ConditionModifier> conditionModifierRemovedAction)
        {
            ConditionModifier newConditionModifier;

            Box mainBox;

            TextField conditionNameField;
            FloatField conditionNumberField;
            EnumField conditionEnumField;

            Button modifierRemoveButton;

            CreateNewModifier();

            SetupModifierBox();

            SetupTextField();

            SetupFloatField();

            SetupEnumField();

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
                mainBox.AddToClassList(DSStylesConfig.modifier_Condition_MainBox);
            }

            void SetupTextField()
            {
                conditionNameField = DSTextFieldsMaker.GetNewTextField(newConditionModifier.ConditionName_TextContainer, "Condition Name", DSStylesConfig.modifier_Condition_TextField);
            }

            void SetupFloatField()
            {
                conditionNumberField = DSFloatFieldsMaker.GetNewFloatField(newConditionModifier.ComparisonNumber_FloatContainer, DSStylesConfig.modifier_Condition_FloatField);
            }

            void SetupEnumField()
            {
                conditionEnumField = DSEnumFieldsMaker.GetNewEnumField(newConditionModifier.ComparisonType_EnumContainer, ConditionCompareTypeChangedAction, DSStylesConfig.modifier_Condition_EnumField);
            }

            void SetupModifierRemoveButton()
            {
                modifierRemoveButton = AddModifierRemoveButton(ConditionModifierRemovedAction);
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
                mainBox.Add(conditionNameField);
                mainBox.Add(conditionEnumField);
                mainBox.Add(conditionNumberField);
                mainBox.Add(modifierRemoveButton);
            }

            void AssignReferencesToModifier()
            {
                newConditionModifier.MainBox = mainBox;
            }

            void ConditionModifierAddedAction()
            {
                conditionModifierAddedAction.Invoke(newConditionModifier);
                ConditionCompareTypeChangedAction();
            }

            void ConditionModifierRemovedAction()
            {
                conditionModifierRemovedAction.Invoke(newConditionModifier);
            }

            void ConditionCompareTypeChangedAction()
            {
                newConditionModifier.ToggleFloatFieldVisibleAction();
            }
        }


        /// <summary>
        /// Create all the UIElements that are needed in this modifier as instance.
        /// </summary>
        /// <param name="source">The another modifier that has the values to this new modifier to load from if it's provided.</param>
        /// <param name="eventModifierAddedAction">Action that will invoked at the end of this setup process.</param>
        /// <param name="eventModifierRemovedAction">Action that will invoked when this modifier is deleted from the node.</param>
        public static void GetNewEventModifier
            (EventModifier source, Action<EventModifier> eventModifierAddedAction, Action<EventModifier> eventModifierRemovedAction)
        {
            EventModifier newEventModifier;

            Box mainBox;

            ObjectField eventObjectField;

            Button modifierRemoveButton;

            CreateNewModifier();

            SetupModifierBox();

            SetupEventObjectField();

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
                mainBox.AddToClassList(DSStylesConfig.modifier_Event_MainBox);
            }

            void SetupEventObjectField()
            {
                eventObjectField = DSObjectFieldsMaker.GetNewObjectField(newEventModifier.DialogueEventSO_ObjectContainer, DSStylesConfig.modifier_Event_ObjectField);
            }

            void SetupModifierRemvoeButton()
            {
                modifierRemoveButton = AddModifierRemoveButton(EventModifierRemovedAction);
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
                mainBox.Add(eventObjectField);
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
        /// <param name="ModifierRemovedAction">The action to invoke when remove button is pressed.</param>
        /// <returns>A new button to remove the modifier that it's connecting to.</returns>
        static Button AddModifierRemoveButton(Action ModifierRemovedAction)
        {
            return DSButtonsMaker.GetNewButton(DSAssetsConfig.removeModifierButtonIconImage, ModifierRemovedAction, DSStylesConfig.modifier_RemoveModifier_Button);
        }
    }
}