using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG.DS
{
    public partial class ConditionModifier
    {
        /// <summary>
        /// Variable container for storing the first term value that'll be used to compare from.
        /// </summary>
        public VariableFieldModel FirstTermVariableContainer;


        /// <summary>
        /// Enum container for how the users want to compare the value in this condition.
        /// </summary>
        public ConditionComparisonTypeIconicEnumFieldModel ConditionComparisonTypeEnumContainer;


        /// <summary>
        /// Text field model for storing the second term value that'll be used to compare to.
        /// </summary>
        public CommonTextFieldModel SecondTermTextFieldModel;


        /// <summary>
        /// Float field container for storing the second term value that'll be used to compare to.
        /// </summary>
        public CommonFloatFieldModel SecondTermFloatFieldModel;


        /// <summary>
        /// Variable container for storing the second term value that'll be used to compare to.
        /// </summary>
        public VariableFieldModel SecondTermVariableContainer;


        /// <summary>
        /// Is the in display second term field appearing as the keyboard input field?
        /// </summary>
        bool isShowKeyboardInputField;


        /// <summary>
        /// Button that change the second term field type when clicked.
        /// </summary>
        Button changeFieldTypeButton;


        /// <summary>
        /// Reference of the current in display second term visual element.
        /// </summary>
        VisualElement tempInDisplaySecondTermElement;


        /// <summary>
        /// Reference of the current condition comparison type.
        /// </summary>
        M_Condition_ComparisonType conditionComparisonType;


        /// <summary>
        /// The box UIElement that stores all the visual elements of its content.
        /// </summary>
        public Box MainBox;


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
            SecondTermTextFieldModel = new(placeholderText: StringConfig.Instance.ConditionModifierCompareToStringPlaceholderText);
            SecondTermFloatFieldModel = new();
            SecondTermVariableContainer = new();

            // Showing keyboard input field is by default.
            isShowKeyboardInputField = true;
        }


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create all the UIElements that are needed in the root modifier.
        /// </summary>
        /// <param name="node">Node of which this modifier is created for.</param>
        public void CreateRootElements(NodeBase node)
        {
            // First term
            ObjectField firstTermObjectField;

            // Operator
            EnumField conditionComparisonTypeEnumField;

            // Second term
            ObjectField secondTermObjectField;

            // Side buttons
            Box buttonBox;

            SetupModifierBox();

            SetupFirstTermObjectField();

            SetupConditionComparisonTypeEnumField();

            SetupSecondTermTextField();

            SetupSecondTermFloatField();

            SetupSecondTermFloatFieldIcon();

            SetupSecondTermObjectField();

            SetupChangeFieldTypeButton();

            AddFieldsToBox();

            AddBoxToNode();

            ModifierCreatedAction();

            void SetupModifierBox()
            {
                MainBox = new();
                MainBox.AddToClassList(StyleConfig.Instance.Modifier_Condition_Rooted_Main_Box);

                buttonBox = new();
                buttonBox.AddToClassList(StyleConfig.Instance.Modifier_Condition_Rooted_Button_Box);
            }

            void SetupFirstTermObjectField()
            {
                firstTermObjectField = VariableFieldFactory.GetNewObjectField
                (
                    variableContainer: FirstTermVariableContainer,
                    fieldIcon: ConfigResourcesManager.Instance.SpriteConfig.ScriptableObjectFieldIconSprite,
                    fieldUSS01: StyleConfig.Instance.Modifier_Condition_Rooted_FirstTerm_ObjectField
                );
            }

            void SetupConditionComparisonTypeEnumField()
            {
                conditionComparisonTypeEnumField = EnumFieldFactory.GetNewIconicEnumField
                (
                    iconicEnumContainer: ConditionComparisonTypeEnumContainer,
                    containerValueChangedAction: EnumContainerValueChangedAction,
                    fieldUSS01: StyleConfig.Instance.Modifier_Condition_Rooted_Operator_EnumField,
                    iconImageUSS01: StyleConfig.Instance.Modifier_Condition_Rooted_Operator_Icon
                );
            }

            void SetupSecondTermTextField()
            {
                SecondTermTextFieldModel.TextField = CommonTextFieldPresenter.CreateElements
                (
                    isMultiLine: false,
                    placeholderText: SecondTermTextFieldModel.PlaceholderText,
                    fieldUSS01: StyleConfig.Instance.Modifier_Condition_Rooted_SecondTerm_TextField
                );

                new CommonTextFieldCallback(model: SecondTermTextFieldModel).RegisterEvents();
            }

            void SetupSecondTermFloatField()
            {
                SecondTermFloatFieldModel.FloatField = CommonFloatFieldPresenter.CreateElements
                (
                    fieldUSS01: StyleConfig.Instance.Modifier_Condition_Rooted_SecondTerm_FloatField
                );

                new CommonFloatFieldCallback(model: SecondTermFloatFieldModel).RegisterEvents();
            }

            void SetupSecondTermFloatFieldIcon()
            {
                SecondTermFloatFieldModel.FloatField.AddFieldIcon
                (
                    iconSprite: ConfigResourcesManager.Instance.SpriteConfig.KeyboardInputFieldIconSprite
                );
            }

            void SetupSecondTermObjectField()
            {
                secondTermObjectField = VariableFieldFactory.GetNewObjectField
                (
                    variableContainer: SecondTermVariableContainer,
                    fieldIcon: ConfigResourcesManager.Instance.SpriteConfig.ScriptableObjectFieldIconSprite,
                    fieldUSS01: StyleConfig.Instance.Modifier_Condition_Rooted_SecondTerm_ObjectField
                );
            }

            void SetupChangeFieldTypeButton()
            {
                changeFieldTypeButton = CommonButtonPresenter.CreateElements
                (
                    buttonSprite: ConfigResourcesManager.Instance.SpriteConfig.ChangeFieldTypeButtonIconSprite,
                    buttonUSS01: StyleConfig.Instance.Modifier_Condition_Rooted_ChangeFieldType_Button
                );

                new CommonButtonCallback(
                    isAlert: true,
                    button: changeFieldTypeButton,
                    clickEvent: ChangeFieldTypeButtonClickEvent).RegisterEvents();
            }

            void AddFieldsToBox()
            {
                // Button side box
                buttonBox.Add(changeFieldTypeButton);

                // Main box
                MainBox.Add(firstTermObjectField);
                MainBox.Add(conditionComparisonTypeEnumField);
                MainBox.Add(SecondTermFloatFieldModel.FloatField);
                MainBox.Add(SecondTermTextFieldModel.TextField);
                MainBox.Add(secondTermObjectField);
                MainBox.Add(buttonBox);
            }

            void AddBoxToNode()
            {
                node.ContentContainer.Add(MainBox);
            }
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// The action to invoke when the modifier is created.
        /// </summary>
        public void ModifierCreatedAction()
        {
            // Update the internal in display second term type.
            UpdateInDisplaySecondTermType();

            // Hide all the second term elements.
            SecondTermTextFieldModel.TextField.HideElement();
            SecondTermFloatFieldModel.FloatField.HideElement();
            SecondTermVariableContainer.ObjectField.HideElement();

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
        /// The event to invoked when the change field type button is clicked.
        /// </summary>
        void ChangeFieldTypeButtonClickEvent(ClickEvent evt)
        {
            // Switch the status.
            isShowKeyboardInputField = !isShowKeyboardInputField;

            // Hide the current in display second term element.
            HideInDisplaySecondTermElement();

            // Show the new in display second term element.
            ShowSecondTermElementByComparisonType();
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the modifier values to the given data.
        /// </summary>
        /// <param name="data">The given data to save to.</param>
        public void SaveModifierValue(ConditionModifierData data)
        {
            // Save containers.
            FirstTermVariableContainer.Save(data.FirstTermVariableGroupData);
            data.ConditionComparisonTypeEnumIndex = ConditionComparisonTypeEnumContainer.Value;
            data.SecondTermText = SecondTermTextFieldModel.TextField.value;
            data.SecondTermFloat = SecondTermFloatFieldModel.Value;
            SecondTermVariableContainer.Save(data.SecondTermVariableGoupData);

            // Save isShowKeyboardInputField
            data.IsShowKeyboardInputField = isShowKeyboardInputField;
        }


        /// <summary>
        /// Load the modifier values from the given data.
        /// </summary>
        /// <param name="data">The given data to load from.</param>
        public void LoadModifierValue(ConditionModifierData data)
        {
            // Load containers.
            FirstTermVariableContainer.Load(data.FirstTermVariableGroupData);
            ConditionComparisonTypeEnumContainer.Load(data.ConditionComparisonTypeEnumIndex);
            SecondTermTextFieldModel.Load(data.SecondTermText);
            SecondTermFloatFieldModel.Load(data.SecondTermFloat);
            SecondTermVariableContainer.Load(data.SecondTermVariableGoupData);

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
            if (tempInDisplaySecondTermElement != null)
                tempInDisplaySecondTermElement.HideElement();
        }


        /// <summary>
        /// Show the correct second term field element according to the current
        /// <br>condition comparison type.</br>
        /// </summary>
        void ShowSecondTermElementByComparisonType()
        {
            // Cache reference of the new in display second term element.
            VisualElement secondTermElement = null;

            switch (conditionComparisonType)
            {
                // "True" / "False" doesn't show any second term field.
                case M_Condition_ComparisonType.True:
                case M_Condition_ComparisonType.False:
                    break;

                // "Matches" shows text field.
                case M_Condition_ComparisonType.Matches:

                    secondTermElement = isShowKeyboardInputField
                        ? SecondTermTextFieldModel.TextField
                        : SecondTermVariableContainer.ObjectField;

                    secondTermElement.ShowElement();
                    break;

                // "Equals" / "Bigger" / "Smaller" shows float field.
                case M_Condition_ComparisonType.Equals:
                case M_Condition_ComparisonType.EqualsOrBigger:
                case M_Condition_ComparisonType.EqualsOrSmaller:
                case M_Condition_ComparisonType.Bigger:
                case M_Condition_ComparisonType.Smaller:

                    secondTermElement = isShowKeyboardInputField
                        ? SecondTermFloatFieldModel.FloatField
                        : SecondTermVariableContainer.ObjectField;

                    secondTermElement.ShowElement();
                    break;
            }

            // Overwrite the internal reference.
            tempInDisplaySecondTermElement = secondTermElement;
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
            var spriteConfig = ConfigResourcesManager.Instance.SpriteConfig;

            if (ConditionComparisonTypeEnumContainer.IsTrueOrFalseComparisonType())
            {
                // Disable button.
                changeFieldTypeButton.pickingMode = PickingMode.Ignore;
                changeFieldTypeButton.style.backgroundImage = spriteConfig.ChangeFieldTypeButtonBlockedIconSprite.texture;
            }
            else
            {
                // Enable button.
                changeFieldTypeButton.pickingMode = PickingMode.Position;
                changeFieldTypeButton.style.backgroundImage = spriteConfig.ChangeFieldTypeButtonIconSprite.texture;
            }
        }
    }
}