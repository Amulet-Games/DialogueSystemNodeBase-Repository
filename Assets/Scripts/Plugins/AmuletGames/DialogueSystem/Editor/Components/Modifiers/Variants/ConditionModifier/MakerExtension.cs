using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG.DS
{
    public partial class ConditionModifier
        : ModifierFrameBase<ConditionModifier, ConditionModifierData>
    {
        /// <inheritdoc />
        public override void CreateInstanceElements
        (
            ConditionModifierData data,
            Action<ConditionModifier> addToSegmentAction,
            Action<ConditionModifier> removeFromSegmentAction
        )
        {
            // Boxes
            Box buttonSideBox;

            // First term
            ObjectField firstTermObjectField;

            // Operator
            EnumField conditionComparisonTypeEnumField;

            // Second term
            TextField secondTermTextField;
            FloatField secondTermFloatField;
            ObjectField secondTermObjectField;

            Button modifierRemoveButton;

            SetupModifierBox();

            SetupFirstTermObjectField();

            SetupConditionComparisonTypeEnumField();

            SetupSecondTermTextField();

            SetupSecondTermFloatField();

            SetupSecondTermObjectField();

            SetupChangeFieldTypeButton();

            SetupModifierRemoveButton();

            CheckSourceValues();

            AddFieldsToBox();

            InvokeModifierCreatedAction();

            void SetupModifierBox()
            {
                MainBox = new Box();
                MainBox.AddToClassList(StylesConfig.Modifier_Condition_MainBox);

                buttonSideBox = new Box();
                buttonSideBox.AddToClassList(StylesConfig.Modifier_Condition_ButtonSideBox);
            }

            void SetupFirstTermObjectField()
            {
                firstTermObjectField = VariableFieldFactory.GetNewObjectField
                (
                    variableContainer: FirstTermVariableContainer,
                    fieldIcon: AssetsConfig.ScriptableObjectFieldIconSprite,
                    fieldUSS01: StylesConfig.Modifier_Condition_FirstTerm_ObjectField
                );
            }

            void SetupConditionComparisonTypeEnumField()
            {
                conditionComparisonTypeEnumField = EnumFieldFactory.GetNewIconicEnumField
                (
                    iconicEnumContainer: ConditionComparisonTypeEnumContainer,
                    containerValueChangedAction: EnumContainerValueChangedAction,
                    fieldUSS01: StylesConfig.Modifier_Condition_Operator_EnumField,
                    iconImageUSS01: StylesConfig.Modifier_Condition_Operator_EnumField_Icon
                );
            }

            void SetupSecondTermTextField()
            {
                secondTermTextField = TextFieldFactory.GetNewTextField
                (
                    textContainer: SecondTermTextContainer,
                    fieldIcon: AssetsConfig.KeyboardInputFieldIconSprite,
                    isMultiLine: false,
                    placeholderText: StringsConfig.ConditionModifierCompareToStringPlaceholderText,
                    fieldUSS01: StylesConfig.Modifier_Condition_SecondTerm_TextField
                );
            }

            void SetupSecondTermFloatField()
            {
                secondTermFloatField = FloatFieldFactory.GetNewFloatField
                (
                    floatContainer: SecondTermFloatContainer,
                    fieldIcon: AssetsConfig.KeyboardInputFieldIconSprite,
                    fieldUSS01: StylesConfig.Modifier_Condition_SecondTerm_FloatField
                );
            }

            void SetupSecondTermObjectField()
            {
                secondTermObjectField = VariableFieldFactory.GetNewObjectField
                (
                    variableContainer: SecondTermVariableContainer,
                    fieldIcon: AssetsConfig.ScriptableObjectFieldIconSprite,
                    fieldUSS01: StylesConfig.Modifier_Condition_SecondTerm_ObjectField
                );
            }

            void SetupChangeFieldTypeButton()
            {
                changeFieldTypeButton = ButtonFactory.GetNewButton
                (
                    isAlert: true,
                    btnSprite: AssetsConfig.ChangeFieldTypeButtonIconSprite,
                    btnPressedAction: ButtonPressedAction,
                    buttonUSS01: StylesConfig.Modifier_Condition_ChangeFieldType_Button
                );
            }

            void SetupModifierRemoveButton()
            {
                modifierRemoveButton = ModifierFactory.GetNewModifierRemoveButton
                (
                    action: () => removeFromSegmentAction.Invoke(this),
                    buttonUSS01: StylesConfig.Modifier_Condition_RemoveModifier_Button
                );
            }

            void CheckSourceValues()
            {
                if (data != null)
                    LoadModifierValue(data);
            }

            void AddFieldsToBox()
            {
                // Button side box
                buttonSideBox.Add(changeFieldTypeButton);
                buttonSideBox.Add(modifierRemoveButton);

                // Main box
                MainBox.Add(firstTermObjectField);
                MainBox.Add(conditionComparisonTypeEnumField);
                MainBox.Add(secondTermFloatField);
                MainBox.Add(secondTermTextField);
                MainBox.Add(secondTermObjectField);
                MainBox.Add(buttonSideBox);
            }

            void InvokeModifierCreatedAction()
            {
                ModifierCreatedAction();
                addToSegmentAction.Invoke(this);
            }
        }
    }
}