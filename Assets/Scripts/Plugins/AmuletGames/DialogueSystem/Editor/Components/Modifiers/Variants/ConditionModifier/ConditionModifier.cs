using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public partial class ConditionModifier
        : ModifierFrameBase<ConditionModifier, ConditionModifierData>
    {
        /// <summary>
        /// Variable container for storing the first term value that'll be used to compare from.
        /// </summary>
        public VariableContainer FirstTermVariableContainer;


        /// <summary>
        /// Enum container for how the users want to compare the value in this condition.
        /// </summary>
        public ConditionComparisonTypeEnumContainer ConditionComparisonTypeEnumContainer;


        /// <summary>
        /// Text container for storing the second term value that'll be used to compare to.
        /// </summary>
        public TextContainer SecondTermTextContainer;


        /// <summary>
        /// Float container for storing the second term value that'll be used to compare to.
        /// </summary>
        public FloatContainer SecondTermFloatContainer;


        /// <summary>
        /// Variable container for storing the second term value that'll be used to compare to.
        /// </summary>
        public VariableContainer SecondTermVariableContainer;


        /// <summary>
        /// Is the in display second term field appearing as the keyboard input field?
        /// </summary>
        [SerializeField] bool isShowKeyboardInputField;


        /// <summary>
        /// Button for changing the second term field's type.
        /// </summary>
        Button changeFieldTypeButton;


        /// <summary>
        /// Reference of the current in display second term field.
        /// </summary>
        VisualElement inDisplaySecondTermElement;


        /// <summary>
        /// Reference of the current condition comparison type.
        /// </summary>
        M_Condition_ComparisonType conditionComparisonType;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the condition modifier component class.
        /// </summary>
        public ConditionModifier()
        {
            // First term
            FirstTermVariableContainer = new();

            // Operator
            ConditionComparisonTypeEnumContainer = new();

            // Second term
            SecondTermTextContainer = new();
            SecondTermFloatContainer = new();
            SecondTermVariableContainer = new();

            // Showing keyboard input field is by default.
            isShowKeyboardInputField = true;
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreateRootElements(NodeBase node)
        {
            // First term
            ObjectField firstTermObjectField;

            // Operator
            EnumField conditionComparisonTypeEnumField;

            // Second term
            TextField secondTermTextField;
            FloatField secondTermFloatField;
            ObjectField secondTermObjectField;

            // Side buttons
            Box buttonSideBox;

            SetupModifierBox();

            SetupFirstTermObjectField();

            SetupConditionComparisonTypeEnumField();

            SetupSecondTermTextField();

            SetupSecondTermFloatField();

            SetupSecondTermObjectField();

            SetupChangeFieldTypeButton();

            AddFieldsToBox();

            AddBoxToNode();

            ModifierCreatedAction();

            void SetupModifierBox()
            {
                MainBox = new Box();
                MainBox.AddToClassList(StylesConfig.Modifier_Condition_Rooted_MainBox);

                buttonSideBox = new Box();
                buttonSideBox.AddToClassList(StylesConfig.Modifier_Condition_Rooted_ButtonSideBox);
            }

            void SetupFirstTermObjectField()
            {
                firstTermObjectField = VariableFieldFactory.GetNewObjectField
                (
                    variableContainer: FirstTermVariableContainer,
                    fieldIcon: AssetsConfig.ScriptableObjectFieldIconSprite,
                    fieldUSS01: StylesConfig.Modifier_Condition_Rooted_FirstTerm_ObjectField
                );
            }

            void SetupConditionComparisonTypeEnumField()
            {
                conditionComparisonTypeEnumField = EnumFieldFactory.GetNewIconicEnumField
                (
                    iconicEnumContainer: ConditionComparisonTypeEnumContainer,
                    containerValueChangedAction: EnumContainerValueChangedAction,
                    fieldUSS01: StylesConfig.Modifier_Condition_Rooted_Operator_EnumField,
                    iconImageUSS01: StylesConfig.Modifier_Condition_Rooted_Operator_EnumField_Icon
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
                    fieldUSS01: StylesConfig.Modifier_Condition_Rooted_SecondTerm_TextField
                );
            }

            void SetupSecondTermFloatField()
            {
                secondTermFloatField = FloatFieldFactory.GetNewFloatField
                (
                    floatContainer: SecondTermFloatContainer,
                    fieldIcon: AssetsConfig.KeyboardInputFieldIconSprite,
                    fieldUSS01: StylesConfig.Modifier_Condition_Rooted_SecondTerm_FloatField
                );
            }

            void SetupSecondTermObjectField()
            {
                secondTermObjectField = VariableFieldFactory.GetNewObjectField
                (
                    variableContainer: SecondTermVariableContainer,
                    fieldIcon: AssetsConfig.ScriptableObjectFieldIconSprite,
                    fieldUSS01: StylesConfig.Modifier_Condition_Rooted_SecondTerm_ObjectField
                );
            }

            void SetupChangeFieldTypeButton()
            {
                changeFieldTypeButton = ButtonFactory.GetNewButton
                (
                    isAlert: true,
                    btnSprite: AssetsConfig.ChangeFieldTypeButtonIconSprite,
                    btnPressedAction: ButtonPressedAction,
                    buttonUSS01: StylesConfig.Modifier_Condition_Rooted_ChangeFieldType_Button
                );
            }

            void AddFieldsToBox()
            {
                // Button side box
                buttonSideBox.Add(changeFieldTypeButton);

                // Main box
                MainBox.Add(firstTermObjectField);
                MainBox.Add(conditionComparisonTypeEnumField);
                MainBox.Add(secondTermFloatField);
                MainBox.Add(secondTermTextField);
                MainBox.Add(secondTermObjectField);
                MainBox.Add(buttonSideBox);
            }

            void AddBoxToNode()
            {
                node.mainContainer.Add(MainBox);
            }
        }


        // ----------------------------- Callbacks -----------------------------
        /// <inheritdoc />
        public override void ModifierCreatedAction()
        {
            // Update the internal in display second term type.
            UpdateInDisplaySecondTermType();

            // Hide all the second term elements.
            VisualElementHelper.HideElement(SecondTermTextContainer.TextField);
            VisualElementHelper.HideElement(SecondTermFloatContainer.FloatField);
            VisualElementHelper.HideElement(SecondTermVariableContainer.ObjectField);

            // Show the new in display second term element.
            ShowSecondTermElementByComparisonType();

            // Update the variable containers' assigning type according to the
            // current condition comparison type enum container's value.
            UpdateVariableContainerAssigningType();

            // Lock the field type change button 
            LockFieldTypeChangeButton();
        }


        /// <summary>
        /// Action that invoked when the condition comparison type enum container value is changed.
        /// </summary>
        void EnumContainerValueChangedAction()
        {
            // Update the internal in display second term type.
            UpdateInDisplaySecondTermType();

            // Hide the current in display second term element.
            HideInDisplaySecondTermElement();

            // Show the new in display second term element.
            ShowSecondTermElementByComparisonType();

            // Update the variable containers' assigning type according to the
            // current condition comparison type enum container's value.
            UpdateVariableContainerAssigningType();

            // Lock the field type change button 
            LockFieldTypeChangeButton();
        }


        /// <summary>
        /// Action that invoked when the change field type button is pressed.
        /// </summary>
        void ButtonPressedAction()
        {
            // Switch the status.
            isShowKeyboardInputField = !isShowKeyboardInputField;

            // Hide the current in display second term element.
            HideInDisplaySecondTermElement();

            // Show the new in display second term element.
            ShowSecondTermElementByComparisonType();
        }


        // ----------------------------- Serialization -----------------------------
        /// <inheritdoc />
        public override void SaveModifierValue(ConditionModifierData data)
        {
            // Save containers.
            FirstTermVariableContainer.SaveContainerValue(data.FirstTermVariableGroupData);
            data.ConditionComparisonTypeEnumIndex = ConditionComparisonTypeEnumContainer.Value;
            data.SecondTermText = SecondTermTextContainer.Value;
            data.SecondTermFloat = SecondTermFloatContainer.Value;
            SecondTermVariableContainer.SaveContainerValue(data.SecondTermVariableGoupData);

            // Save isShowKeyboardInputField
            data.IsShowKeyboardInputField = isShowKeyboardInputField;
        }


        /// <inheritdoc />
        public override void LoadModifierValue(ConditionModifierData data)
        {
            // Load containers.
            FirstTermVariableContainer.LoadContainerValue(data.FirstTermVariableGroupData);
            ConditionComparisonTypeEnumContainer.LoadContainerValue(data.ConditionComparisonTypeEnumIndex);
            SecondTermTextContainer.LoadContainerValue(data.SecondTermText);
            SecondTermFloatContainer.LoadContainerValue(data.SecondTermFloat);
            SecondTermVariableContainer.LoadContainerValue(data.SecondTermVariableGoupData);

            // Load isShowKeyboardInputField.
            isShowKeyboardInputField = data.IsShowKeyboardInputField;

            // Manually invoke the enumContainerValueChanged action.
            EnumContainerValueChangedAction();
        }


        // ----------------------------- Second Term Field Related Utilities -----------------------------
        /// <summary>
        /// Update the internal condition comparison type value so that we can update
        /// <br>the other parts of the modifier accordingly.</br>
        /// </summary>
        void UpdateInDisplaySecondTermType()
        {
            // Cache the current condition comparison type enum container value internally.
            conditionComparisonType =
                (M_Condition_ComparisonType)ConditionComparisonTypeEnumContainer.Value;
        }


        /// <summary>
        /// Hide the current in display second term element.
        /// </summary>
        void HideInDisplaySecondTermElement()
        {
            if (inDisplaySecondTermElement != null)
                VisualElementHelper.HideElement(inDisplaySecondTermElement);
        }


        /// <summary>
        /// Show the correct second term field element according to the current
        /// <br>condition comparison type.</br>
        /// </summary>
        void ShowSecondTermElementByComparisonType()
        {
            // Cache reference of the new in display second term element.
            VisualElement _element = null;

            switch (conditionComparisonType)
            {
                // "True" / "False" doesn't show any second term field.
                case M_Condition_ComparisonType.True:
                case M_Condition_ComparisonType.False:
                    break;

                // "Matches" shows text field.
                case M_Condition_ComparisonType.Matches:

                    _element = isShowKeyboardInputField
                             ? SecondTermTextContainer.TextField
                             : SecondTermVariableContainer.ObjectField;

                    VisualElementHelper.ShowElement(_element);
                    break;

                // "Equals" / "Bigger" / "Smaller" shows float field.
                case M_Condition_ComparisonType.Equals:
                case M_Condition_ComparisonType.EqualsOrBigger:
                case M_Condition_ComparisonType.EqualsOrSmaller:
                case M_Condition_ComparisonType.Bigger:
                case M_Condition_ComparisonType.Smaller:

                    _element = isShowKeyboardInputField
                             ? SecondTermFloatContainer.FloatField
                             : SecondTermVariableContainer.ObjectField;

                    VisualElementHelper.ShowElement(_element);
                    break;
            }

            // Overwrite the internal reference.
            inDisplaySecondTermElement = _element;
        }


        /// <summary>
        /// Update the modifier's variable containers' assigning type according to the
        /// <br>current condition comparison type.</br>
        /// </summary>
        void UpdateVariableContainerAssigningType()
        {
            switch (conditionComparisonType)
            {
                // "True" and "False" compare type is "Boolean".
                case M_Condition_ComparisonType.True:
                case M_Condition_ComparisonType.False:
                    FirstTermVariableContainer.ChangeAssigningType(G_VariableType.Boolean);
                    break;


                // "Matches" compare type is "String".
                case M_Condition_ComparisonType.Matches:
                    FirstTermVariableContainer.ChangeAssigningType(G_VariableType.String);
                    SecondTermVariableContainer.ChangeAssigningType(G_VariableType.String);
                    break;

                // "Equals" / "Bigger" / "Smaller" compare type is "Float".
                case M_Condition_ComparisonType.Equals:
                case M_Condition_ComparisonType.EqualsOrBigger:
                case M_Condition_ComparisonType.EqualsOrSmaller:
                case M_Condition_ComparisonType.Bigger:
                case M_Condition_ComparisonType.Smaller:
                    FirstTermVariableContainer.ChangeAssigningType(G_VariableType.Float);
                    SecondTermVariableContainer.ChangeAssigningType(G_VariableType.Float);
                    break;
            }
        }


        /// <summary>
        /// Lock the modifier's change field type button if the current
        /// <br>condition comparison type is either "True" or "False".</br>
        /// </summary>
        void LockFieldTypeChangeButton()
        {
            if (ConditionComparisonTypeEnumContainer.IsTrueOrFalseComparisonType())
            {
                // Disable button.
                changeFieldTypeButton.pickingMode = PickingMode.Ignore;
                changeFieldTypeButton.style.backgroundImage = AssetsConfig.ChangeFieldTypeButtonBlockedIconSprite.texture;
            }
            else
            {
                // Enable button.
                changeFieldTypeButton.pickingMode = PickingMode.Position;
                changeFieldTypeButton.style.backgroundImage = AssetsConfig.ChangeFieldTypeButtonIconSprite.texture;
            }
        }
    }
}