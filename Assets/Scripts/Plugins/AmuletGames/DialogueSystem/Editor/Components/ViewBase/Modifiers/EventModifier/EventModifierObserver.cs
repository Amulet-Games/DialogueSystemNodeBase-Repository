using UnityEngine.UIElements;

namespace AG.DS
{
    public class EventModifierObserver
    {
        /// <summary>
        /// The targeting event modifier view.
        /// </summary>
        EventModifierView view;


        /// <summary>
        /// Reference of the event modifier group view.
        /// </summary>
        EventModifierGroupView groupView;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the event modifier observer class.
        /// </summary>
        /// <param name="view">The event modifier view to set for.</param>
        /// <param name="groupView">The event modifier group view to set for,</param>
        public EventModifierObserver
        (
            EventModifierView view,
            EventModifierGroupView groupView
        )
        {
            this.view = view;
            this.groupView = groupView;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the event modifier.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterFolderEvents();

            RegisterMoveUpButtonClickEvent();

            RegisterMoveDownButtonClickEvent();

            RegisterRenameButtonClickEvent();

            RegisterRemoveButtonClickEvent();

            RegisterDialogueEventFieldEvents();

            RegisterDelaySecondsIntegerFieldEvents();
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
            => new CommonButtonObserver(
                isAlert: true,
                button: view.MoveUpButton,
                clickEvent: MoveUpButtonClickEvent).RegisterEvents();


        /// <summary>
        /// Register ClickEvent to the move down button.
        /// </summary>
        void RegisterMoveDownButtonClickEvent()
            => new CommonButtonObserver(
                isAlert: true,
                button: view.MoveDownButton,
                clickEvent: MoveDownButtonClickEvent).RegisterEvents();


        /// <summary>
        /// Register ClickEvent to the rename button.
        /// </summary>
        void RegisterRenameButtonClickEvent()
            => new CommonButtonObserver(
                isAlert: true,
                button: view.RenameButton,
                clickEvent: RenameButtonClickEvent).RegisterEvents();


        /// <summary>
        /// Register ClickEvent to the remove button.
        /// </summary>
        void RegisterRemoveButtonClickEvent()
            => new CommonButtonObserver(
                isAlert: true,
                button: view.RemoveButton,
                clickEvent: RemoveButtonClickEvent).RegisterEvents();


        /// <summary>
        /// Register events to the dialogue event field.
        /// </summary>
        void RegisterDialogueEventFieldEvents()
            => new CommonObjectFieldObserver<DialogueEvent>(
                view: view.DialogueEventFieldView).RegisterEvents();


        /// <summary>
        /// Register events to the delay seconds field.
        /// </summary>
        void RegisterDelaySecondsIntegerFieldEvents()
            => new CommonDoubleFieldObserver(
                view.DelaySecondsFieldView).RegisterEvents();


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the move up button is clicked.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void MoveUpButtonClickEvent(ClickEvent evt)
        {
            groupView.Swap(modifier: view, swapUp: true);
        }


        /// <summary>
        /// The event to invoke when the move down button is clicked.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void MoveDownButtonClickEvent(ClickEvent evt)
        {
            groupView.Swap(modifier: view, swapUp: false);
        }


        /// <summary>
        /// The event to invoke when the rename button is clicked.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void RenameButtonClickEvent(ClickEvent evt)
        {
            view.Folder.StartEditingFolderTitle();
        }


        /// <summary>
        /// The event to invoke when the remove button is clicked.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void RemoveButtonClickEvent(ClickEvent evt)
        {
            groupView.Remove(view);
            groupView.UpdateReferences();
        }
    }
}