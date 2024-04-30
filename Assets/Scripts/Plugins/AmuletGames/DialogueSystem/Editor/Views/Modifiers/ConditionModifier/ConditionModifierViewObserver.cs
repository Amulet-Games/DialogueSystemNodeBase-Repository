using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG.DS
{
    using SwitchButton = ConditionModifierView.VariableGroup.SwitchButton;
    using VariableGroup = ConditionModifierView.VariableGroup;

    public class ConditionModifierViewObserver
    {
        /// <summary>
        /// The targeting condition modifier view.
        /// </summary>
        ConditionModifierView view;


        /// <summary>
        /// Reference of the condition modifier search tree entry provider.
        /// </summary>
        ConditionModifierViewSearchTreeEntryProvider searchTreeEntryProvider;


        /// <summary>
        /// Reference of the condition modifier group view.
        /// </summary>
        ConditionModifierGroupView groupView;


        /// <summary>
        /// Constructor of the condition modifier view observer class.
        /// </summary>
        /// <param name="view">The condition modifier view to set for.</param>
        /// <param name="searchTreeEntryProvider">The condition modifier search tree entry provider to set for.</param>
        /// <param name="groupView">The condition modifier group view to set for,</param>
        public ConditionModifierViewObserver
        (
            ConditionModifierView view,
            ConditionModifierViewSearchTreeEntryProvider searchTreeEntryProvider,
            ConditionModifierGroupView groupView
        )
        {
            this.view = view;
            this.searchTreeEntryProvider = searchTreeEntryProvider;
            this.groupView = groupView;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the condition modifier view.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterFolderEvents();

            RegisterMoveUpButtonClickEvent();

            RegisterMoveDownButtonClickEvent();

            RegisterRenameButtonClickEvent();

            RegisterRemoveButtonClickEvent();

            RegisterFirstVariableGroupEvents();

            RegisterSecondVariableGroupEvents();

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
        /// Register events to the first variable group.
        /// </summary>
        void RegisterFirstVariableGroupEvents()
            => new VariableGroupObserver(
                group: view.FirstVariableGroup, searchTreeEntryProvider).RegisterEvents();


        /// <summary>
        /// Register events to the second variable group.
        /// </summary>
        void RegisterSecondVariableGroupEvents()
            => new VariableGroupObserver(
                group: view.SecondVariableGroup, searchTreeEntryProvider).RegisterEvents();


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
        /// The event to invoke when the operation dropdown selected item has changed.
        /// </summary>
        /// <param name="itemAdditionalInfo">The additional info of the selected dropdown item.</param>
        void OperationDropdownSelectedItemChangeEvent(string itemAdditionalInfo)
        {
            view.m_OperationType = itemAdditionalInfo switch
            {
                "Match" => ConditionModifierView.OperationType.String,
                "Equal" or
                "EqualOrBigger" or
                "EqualOrSmaller" or
                "Bigger" or
                "Smaller" => ConditionModifierView.OperationType.Number,
                "CustomLogic" => ConditionModifierView.OperationType.CustomLogic,
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


        class VariableGroupObserver
        {
            /// <summary>
            /// The targeting variable group element.
            /// </summary>
            VariableGroup group;


            /// <summary>
            /// Reference of the condition modifier search tree entry provider.
            /// </summary>
            ConditionModifierViewSearchTreeEntryProvider searchTreeEntryProvider;


            /// <summary>
            /// Constructor of the variable group observer class.
            /// </summary>
            /// <param name="group">The variable group element to set for.</param>
            /// <param name="searchTreeEntryProvider">The condition modifier search tree entry provider to set for.</param>
            public VariableGroupObserver
            (
                VariableGroup group,
                ConditionModifierViewSearchTreeEntryProvider searchTreeEntryProvider
            )
            {
                this.group = group;
                this.searchTreeEntryProvider = searchTreeEntryProvider;
            }


            // ----------------------------- Register Events -----------------------------
            /// <summary>
            /// Register events to the variable group.
            /// </summary>
            public void RegisterEvents()
            {
                RegisterSwitchButtonEvents();

                RegisterVariableSearchWindowSelectorEvents();

                RegisterFieldInfoSearchWindowSelectorEvents();

                RegisterTextFieldEvents();

                RegisterFloatFieldEvents();
            }


            /// <summary>
            /// Register events to the switch button.
            /// </summary>
            void RegisterSwitchButtonEvents()
                => new SwitchButtonObserver(
                    button: group.m_SwitchButton,
                    variableGroup: group).RegisterEvents();


            /// <summary>
            /// Register events to the variable search window selector.
            /// </summary>
            void RegisterVariableSearchWindowSelectorEvents()
                => new SearchWindowSelectorObserver(
                    selector: group.VariableSearchWindowSelector,
                    selectedEntryChangedEvent: VariableSearchWindowSelectorSelectedEntryChangedEvent,
                    getSearchTreeEntriesEvent: () => searchTreeEntryProvider.CreateVariableSelectorSearchTreeEntries()).RegisterEvents();


            /// <summary>
            /// Register events to the field info search window selector.
            /// </summary>
            void RegisterFieldInfoSearchWindowSelectorEvents()
                => new SearchWindowSelectorObserver(
                    selector: group.FieldInfoSearchWindowSelector,
                    selectedEntryChangedEvent: FieldInfoSearchWindowSelectorSelectedEntryChangedEvent,
                    getSearchTreeEntriesEvent: () => searchTreeEntryProvider.CreateFieldInfoSelectorSearchTreeEntries(
                                               (GameObject)group.VariableSearchWindowSelector.SelectedEntry.userData)).RegisterEvents();


            /// <summary>
            /// Register events to the text field.
            /// </summary>
            void RegisterTextFieldEvents()
                => new CommonTextFieldViewObserver(view: group.TextFieldView).RegisterEvents();


            /// <summary>
            /// Register events to the float field.
            /// </summary>
            void RegisterFloatFieldEvents()
                => new CommonFloatFieldObserver(view: group.FloatFieldView).RegisterEvents();


            // ----------------------------- Event -----------------------------
            /// <summary>
            /// The event to invoke when the variable search window selector's selected entry has changed.
            /// </summary>
            /// <param name="entry">The new selected search tree entry.</param>
            void VariableSearchWindowSelectorSelectedEntryChangedEvent(SearchTreeEntry entry)
            {
                group.FieldInfoSearchWindowSelector.SelectedEntry = searchTreeEntryProvider.NullValuePropertySearchTreeEntry;
                group.FieldInfoContainer.SetDisplay(entry.userData != null);
            }


            /// <summary>
            /// The event to invoke when the field info search window selector's selected entry has changed.
            /// </summary>
            /// <param name="entry">The new selected search tree entry.</param>
            void FieldInfoSearchWindowSelectorSelectedEntryChangedEvent(SearchTreeEntry entry) { }
        }


        class SwitchButtonObserver
        {
            /// <summary>
            /// The targeting switch button element.
            /// </summary>
            SwitchButton button;


            /// <summary>
            /// Reference of the variable group element.
            /// </summary>
            VariableGroup variableGroup;


            /// <summary>
            /// Constructor of the switch button observer class.
            /// </summary>
            /// <param name="button">The switch button to set for</param>
            /// <param name="variableGroup">The variable group element to set for.</param>
            public SwitchButtonObserver
            (
                SwitchButton button,
                VariableGroup variableGroup
            )
            {
                this.button = button;
                this.variableGroup = variableGroup;
            }


            // ----------------------------- Register Events -----------------------------
            /// <summary>
            /// Register events to the switch button.
            /// </summary>
            public void RegisterEvents()
            {
                RegisterSwitchButtonClickEvent();
            }


            /// <summary>
            /// Register events to the button.
            /// </summary>
            void RegisterSwitchButtonClickEvent()
                => new ButtonObserver(
                    isAlert: true,
                    button: button,
                    clickEvent: ClickEvent).RegisterEvents();


            // ----------------------------- Event -----------------------------
            /// <summary>
            /// The event to invoke when the switch button is clicked.
            /// </summary>
            void ClickEvent()
            {
                variableGroup.IsDisplaySceneElements = !variableGroup.IsDisplaySceneElements;
            }
        }
    }
}