using UnityEngine.UIElements;

namespace AG.DS
{
    public class EventModifierCallback
    {
        /// <summary>
        /// The targeting event modifier view.
        /// </summary>
        EventModifierView view;


        /// <summary>
        /// The event to invoke when the move up button is clicked.
        /// </summary>
        EventCallback<ClickEvent> moveUpButtonClickEvent;


        /// <summary>
        /// The event to invoke when the move down button is clicked.
        /// </summary>
        EventCallback<ClickEvent> moveDownButtonClickEvent;


        /// <summary>
        /// The event to invoke when the rename button is clicked.
        /// </summary>
        EventCallback<ClickEvent> renameButtonClickEvent;


        /// <summary>
        /// The event to invoke when the remove button is clicked.
        /// </summary>
        EventCallback<ClickEvent> removeButtonClickEvent;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the event modifier callback class.
        /// </summary>
        public EventModifierCallback() { }


        /// <summary>
        /// Constructor of the event modifier callback class.
        /// </summary>
        /// <param name="view">The event modifier view to set for.</param>
        /// <param name="moveUpButtonClickEvent">The MoveUpButtonClickEvent to set for,</param>
        /// <param name="moveDownButtonClickEvent">The MoveDownButtonClickEvent to set for.</param>
        /// <param name="renameButtonClickEvent">The RenameButtonClickEvent to set for.</param>
        /// <param name="removeButtonClickEvent">The RemoveButtonClickEvent to set for.</param>
        public EventModifierCallback
        (
            EventModifierView view,
            EventCallback<ClickEvent> moveUpButtonClickEvent,
            EventCallback<ClickEvent> moveDownButtonClickEvent,
            EventCallback<ClickEvent> renameButtonClickEvent,
            EventCallback<ClickEvent> removeButtonClickEvent
        )
        {
            this.view = view;
            this.moveUpButtonClickEvent = moveUpButtonClickEvent;
            this.moveDownButtonClickEvent = moveDownButtonClickEvent;
            this.renameButtonClickEvent = renameButtonClickEvent;
            this.removeButtonClickEvent = removeButtonClickEvent;
        }


        // ----------------------------- Reset Internal -----------------------------
        /// <summary>
        /// Reset all the internal properties within the callback class.
        /// </summary>
        /// <param name="view">The targeting event modifier view to set for.</param>
        /// <param name="moveUpButtonClickEvent">The MoveUpButtonClickEvent to set for,</param>
        /// <param name="moveDownButtonClickEvent">The MoveDownButtonClickEvent to set for.</param>
        /// <param name="renameButtonClickEvent">The RenameButtonClickEvent to set for.</param>
        /// <param name="removeButtonClickEvent">The RemoveButtonClickEvent to set for.</param>
        /// <returns>The renewed event modifier callback class.</returns>
        public EventModifierCallback ResetInternal
        (
            EventModifierView view,
            EventCallback<ClickEvent> moveUpButtonClickEvent,
            EventCallback<ClickEvent> moveDownButtonClickEvent,
            EventCallback<ClickEvent> renameButtonClickEvent,
            EventCallback<ClickEvent> removeButtonClickEvent
        )
        {
            this.view = view;
            this.moveUpButtonClickEvent = moveUpButtonClickEvent;
            this.moveDownButtonClickEvent = moveDownButtonClickEvent;
            this.renameButtonClickEvent = renameButtonClickEvent;
            this.removeButtonClickEvent = removeButtonClickEvent;
            return this;
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

            RegisterDialogueEventObjectFieldEvents();

            RegisterDelaySecondsIntegerFieldEvents();
        }


        /// <summary>
        /// Register events to the folder.
        /// </summary>
        void RegisterFolderEvents()
        {
            new FolderCallback(folder: view.FolderView).RegisterEvents();
        }


        /// <summary>
        /// Register ClickEvent to the move up button.
        /// </summary>
        void RegisterMoveUpButtonClickEvent()
            => new CommonButtonCallback(
                isAlert: true,
                button: view.MoveUpButton,
                clickEvent: moveUpButtonClickEvent).RegisterEvents();


        /// <summary>
        /// Register ClickEvent to the move down button.
        /// </summary>
        void RegisterMoveDownButtonClickEvent()
            => new CommonButtonCallback(
                isAlert: true,
                button: view.MoveDownButton,
                clickEvent: moveDownButtonClickEvent).RegisterEvents();


        /// <summary>
        /// Register ClickEvent to the rename button.
        /// </summary>
        void RegisterRenameButtonClickEvent()
            => new CommonButtonCallback(
                isAlert: true,
                button: view.RenameButton,
                clickEvent: renameButtonClickEvent).RegisterEvents();


        /// <summary>
        /// Register ClickEvent to the remove button.
        /// </summary>
        void RegisterRemoveButtonClickEvent()
            => new CommonButtonCallback(
                isAlert: true,
                button: view.RemoveButton,
                clickEvent: removeButtonClickEvent).RegisterEvents();


        /// <summary>
        /// Register events to the dialogue event object field.
        /// </summary>
        void RegisterDialogueEventObjectFieldEvents()
        {
            new CommonObjectFieldCallback<DialogueEvent>(
                    view: view.DialogueEventObjectFieldView).RegisterEvents();
        }


        /// <summary>
        /// Register events to the delay seconds integer field.
        /// </summary>
        void RegisterDelaySecondsIntegerFieldEvents()
        {
            new CommonIntegerFieldCallback(
                view.DelaySecondsIntegerFieldView).RegisterEvents();
        }
    }
}