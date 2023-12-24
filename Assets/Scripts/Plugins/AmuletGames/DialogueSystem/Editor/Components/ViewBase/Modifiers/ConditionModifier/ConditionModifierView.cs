using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class ConditionModifierView
    {
        /// <summary>
        /// Folder that contains the modifier's elements.
        /// </summary>
        public Folder Folder;


        /// <summary>
        /// Button that moves the modifier up one position when clicked.
        /// </summary>
        public CommonButton MoveUpButton;


        /// <summary>
        /// Button that moves the modifier down one position when clicked.
        /// </summary>
        public CommonButton MoveDownButton;


        /// <summary>
        /// Button that renames the modifier when clicked.
        /// </summary>
        public CommonButton RenameButton;


        /// <summary>
        /// Button that removes the modifier when clicked.
        /// </summary>
        public CommonButton RemoveButton;


        /// <summary>
        /// Element that contains the second variable elements.
        /// </summary>
        public VisualElement SecondVariableContainer;


        /// <summary>
        /// Button that switches the second variable field when clicked.
        /// </summary>
        public CommonButton SecondVariableSwitchFieldButton;


        /// <summary>
        /// Element that contains the second reflectable elements.
        /// </summary>
        public VisualElement SecondReflectableElementsContainer;


        /// <summary>
        /// Element that contains the second binding flags and second field info scroller elements.
        /// </summary>
        public VisualElement SecondBindingFlagsFieldInfoContainer;


        /// <summary>
        /// View for the second reflectable object field.
        /// </summary>
        public ReflectableObjectFieldView<Object> SecondReflectableObjectFieldView;


        /// <summary>
        /// Enum flags for the second reflectable object field.
        /// </summary>
        public BindingFlags SecondBindingFlags; 


        /// <summary>
        /// View for the second text field.
        /// </summary>
        public CommonTextFieldView SecondTextFieldView;


        /// <summary>
        /// Element that contains the second float field and the hint label.
        /// </summary>
        public VisualElement SecondFloatFieldHintLabelContainer;


        /// <summary>
        ///  View for the second float field.
        /// </summary>
        public CommonFloatFieldView SecondFloatFieldView;


        /// <summary>
        /// Dropdown for the operators dropdown elements.
        /// </summary>
        public Dropdown OperationDropdown;


        /// <summary>
        /// Dropdown for the chain with dropdown elements.
        /// </summary>
        public Dropdown ChainWithDropdown;


        /// <summary>
        /// The property of the current operation type of the modifier.
        /// </summary>
        public ConditionModifierOperationType OperationType
        {
            get
            {
                return m_operationType;
            }
            set
            {
                m_operationType = value;
                UpdateFieldsDisplay();
            }
        }


        /// <summary>
        /// Current operation type of the modifier.
        /// </summary>
        ConditionModifierOperationType m_operationType = ConditionModifierOperationType.String;


        /// <summary>
        /// The property of the second reflectable field displaying state.
        /// </summary>
        public bool IsDisplaySecondReflectableElements
        {
            get
            {
                return m_isDisplaySecondReflectableField;
            }
            set
            {
                m_isDisplaySecondReflectableField = value;
                UpdateFieldsDisplay();
            }
        }


        /// <summary>
        /// Is the modifier displaying the second reflectable field?
        /// </summary>
        bool m_isDisplaySecondReflectableField = false;


        /// <summary>
        /// Constructor of the condition modifier view class.
        /// </summary>
        public ConditionModifierView()
        {
            SecondReflectableObjectFieldView = new(
                placeholderText: StringConfig.ConditionModifier_SecondReflectableObjectField_PlaceholderText
            );

            SecondTextFieldView = new(
                placeholderText: StringConfig.ConditionModifier_SecondTextField_PlaceholderText
            );

            SecondFloatFieldView = new();
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Changes the move up button enabled state.
        /// </summary>
        /// <param name="value">The value to set to.</param>
        public void SetEnabledMoveUpButton(bool value) => MoveUpButton.SetEnabled(value: value);


        /// <summary>
        /// Changes the move down button enabled state.
        /// </summary>
        /// <param name="value">The value to set to.</param>
        public void SetEnabledMoveDownButton(bool value) => MoveDownButton.SetEnabled(value: value);


        /// <summary>
        /// Changes the remove button enabled state.
        /// </summary>
        /// <param name="value">The value to set to.</param>
        public void SetEnabledRemoveButton(bool value) => RemoveButton.SetEnabled(value: value);


        /// <summary>
        /// Update the modifier's fields display.
        /// </summary>
        private void UpdateFieldsDisplay()
        {
            SecondVariableContainer.SetDisplay(
                m_operationType == ConditionModifierOperationType.String ||
                m_operationType == ConditionModifierOperationType.Float
            );
            SecondReflectableElementsContainer.SetDisplay(
                IsDisplaySecondReflectableElements
            );
            SecondTextFieldView.Field.SetDisplay(
                !IsDisplaySecondReflectableElements &&
                m_operationType == ConditionModifierOperationType.String
            );
            SecondFloatFieldHintLabelContainer.SetDisplay(
                !IsDisplaySecondReflectableElements &&
                m_operationType == ConditionModifierOperationType.Float
            );
        }
    }
}