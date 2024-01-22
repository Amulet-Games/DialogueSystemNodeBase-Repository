using System;
using Object = UnityEngine.Object;

namespace AG.DS
{
    public class ConditionModifierObserver
    {
        /// <summary>
        /// The targeting condition modifier view.
        /// </summary>
        ConditionModifierView view;


        /// <summary>
        /// Reference of the condition modifier group view.
        /// </summary>
        ConditionModifierGroupView groupView;


        /// <summary>
        /// Constructor of the condition modifier observer class.
        /// </summary>
        /// <param name="view">The condition modifier view to set for.</param>
        /// <param name="groupView">The condition modifier group view to set for,</param>
        public ConditionModifierObserver
        (
            ConditionModifierView view,
            ConditionModifierGroupView groupView
        )
        {
            this.view = view;
            this.groupView = groupView;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the condition modifier.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterFolderEvents();

            RegisterMoveUpButtonClickEvent();

            RegisterMoveDownButtonClickEvent();

            RegisterRenameButtonClickEvent();

            RegisterRemoveButtonClickEvent();

            RegisterSecondVariableSwitchFieldButtonClickEvent();

            RegisterSecondReflectableObjectFieldEvents();

            RegisterSecondReflectableObjectFieldChangedEvent();

            RegisterSecondBindingFlagsEvents();

            RegisterSecondTextFieldEvents();

            RegisterSecondFloatFieldEvents();

            RegisterOperationDropdownEvents();

            RegisterChainWithDropdownEvents();
        }


        /// <summary>
        /// Register events to the folder.
        /// </summary>
        void RegisterFolderEvents()
            => new FolderObserver(folder: view.Folder).RegisterEvents();


        /// <summary>
        /// Register ClickEvent to the move up button.
        /// </summary>
        void RegisterMoveUpButtonClickEvent()
            => new ButtonObserver(
                isAlert: true,
                button: view.MoveUpButton,
                clickEvent: MoveUpButtonClickEvent).RegisterEvents();


        /// <summary>
        /// Register ClickEvent to the move down button.
        /// </summary>
        void RegisterMoveDownButtonClickEvent()
            => new ButtonObserver(
                isAlert: true,
                button: view.MoveDownButton,
                clickEvent: MoveDownButtonClickEvent).RegisterEvents();


        /// <summary>
        /// Register ClickEvent to the rename button.
        /// </summary>
        void RegisterRenameButtonClickEvent()
            => new ButtonObserver(
                isAlert: true,
                button: view.RenameButton,
                clickEvent: RenameButtonClickEvent).RegisterEvents();


        /// <summary>
        /// Register ClickEvent to the remove button.
        /// </summary>
        void RegisterRemoveButtonClickEvent()
            => new ButtonObserver(
                isAlert: true,
                button: view.RemoveButton,
                clickEvent: RemoveButtonClickEvent).RegisterEvents();


        /// <summary>
        /// Register ClickEvent to the second variable switch field button.
        /// </summary>
        void RegisterSecondVariableSwitchFieldButtonClickEvent()
            => new ButtonObserver(
                isAlert: true,
                button: view.SecondVariableSwitchFieldButton,
                clickEvent: SecondVariableSwitchFieldButtonClickEvent).RegisterEvents();


        /// <summary>
        /// Register events to the second reflectable object field.
        /// </summary>
        void RegisterSecondReflectableObjectFieldEvents()
            => new ReflectableObjectFieldObserver<Object>(
                view: view.SecondReflectableObjectFieldView).RegisterEvents();


        /// <summary>
        /// Register ValueChangeEvent to the second reflectable object field view.
        /// </summary>
        void RegisterSecondReflectableObjectFieldChangedEvent()
            => view.SecondReflectableObjectFieldView.ValueChangedEvent += SecondReflectableObjectViewValueChangedEvent;


        /// <summary>
        /// Register events to the second binding flags.
        /// </summary>
        void RegisterSecondBindingFlagsEvents()
            => new BindingFlagsObserver(
                enumFlags: view.SecondBindingFlags,
                selectedItemsChangedEvent: SecondBindingFlagsSelectedFlagsChangedEvent).RegisterEvents();


        /// <summary>
        /// Register events to the second text field.
        /// </summary>
        void RegisterSecondTextFieldEvents()
            => new CommonTextFieldObserver(
                view: view.SecondTextFieldView).RegisterEvents();


        /// <summary>
        /// Register events to the second float field.
        /// </summary>
        void RegisterSecondFloatFieldEvents()
            => new CommonFloatFieldObserver(
                view: view.SecondFloatFieldView).RegisterEvents();


        /// <summary>
        /// Register events to the operation dropdown.
        /// </summary>
        void RegisterOperationDropdownEvents()
            => new DropdownObserver(
                dropdown: view.OperationDropdown,
                selectedItemChangedEvent: OperationDropdownSelectedItemChangeEvent).RegisterEvents();


        /// <summary>
        /// Register events to the chain with dropdown.
        /// </summary>
        void RegisterChainWithDropdownEvents()
            => new DropdownObserver(dropdown: view.ChainWithDropdown,
                selectedItemChangedEvent: ChainWithDropdownSelectedItemChangeEvent).RegisterEvents();


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the move up button is clicked.
        /// </summary>
        void MoveUpButtonClickEvent()
        {
            groupView.Swap(modifier: view, swapUp: true);
        }


        /// <summary>
        /// The event to invoke when the move down button is clicked.
        /// </summary>
        void MoveDownButtonClickEvent()
        {
            groupView.Swap(modifier: view, swapUp: false);
        }


        /// <summary>
        /// The event to invoke when the rename button is clicked.
        /// </summary>
        void RenameButtonClickEvent()
        {
            view.Folder.StartEditingFolderTitle();
        }


        /// <summary>
        /// The event to invoke when the remove button is clicked.
        /// </summary>
        void RemoveButtonClickEvent()
        {
            groupView.Remove(view);
            groupView.UpdateReferences();
        }


        /// <summary>
        /// The event to invoke when the second variable switch field button is clicked.
        /// </summary>
        void SecondVariableSwitchFieldButtonClickEvent()
        {
            view.IsDisplaySecondReflectableElements = !view.IsDisplaySecondReflectableElements;
        }


        /// <summary>
        /// The event to invoke when the second reflectable object view value has changed.
        /// </summary>
        void SecondReflectableObjectViewValueChangedEvent()
        {
            view.SecondBindingFlagsFieldInfoContainer.SetDisplay(
                value: view.SecondReflectableObjectFieldView.Value != null
            );
        }


        /// <summary>
        /// The event to invoke when the second binding flags selected flags has changed.
        /// </summary>
        /// <param name="selectedFlags"></param>
        void SecondBindingFlagsSelectedFlagsChangedEvent(BindingFlags.Bindings selectedFlags)
        {

        }


        /// <summary>
        /// The event to invoke when the operation dropdown selected item has changed.
        /// </summary>
        /// <param name="itemAdditionalInfo">The additional info of the selected dropdown item.</param>
        void OperationDropdownSelectedItemChangeEvent(string itemAdditionalInfo)
        {
            view.OperationType = itemAdditionalInfo switch
            {
                "Match" => ConditionModifierOperationType.String,
                "Equal" or
                "EqualOrBigger" or
                "EqualOrSmaller" or
                "Bigger" or
                "Smaller" => ConditionModifierOperationType.Float,
                "CustomLogic" => ConditionModifierOperationType.CustomLogic,
                _ => throw new ArgumentException("Invalid operation dropdown item addition info: " + itemAdditionalInfo)
            };
        }


        /// <summary>
        /// The event to invoke when the chain with dropdown selected item has changed.
        /// </summary>
        /// <param name="selectedItemAdditionalInfo">The additional info of the selected dropdown item.</param>
        void ChainWithDropdownSelectedItemChangeEvent(string itemAdditionalInfo)
        {
            var debugInfo = itemAdditionalInfo switch
            {
                "All" => "Chain With: All",
                "Group1" => "Chain With: Group 1",
                "Group2" => "Chain With: Group 2",
                "Group3" => "Chain With: Group 3",
                _ => throw new ArgumentException("Invalid operation dropdown item addition info: " + itemAdditionalInfo)
            };
        }
    }
}