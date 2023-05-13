using UnityEngine.UIElements;

namespace AG.DS
{
    public class EventModifierCallback
    {
        /// <summary>
        /// The targeting event modifier model.
        /// </summary>
        EventModifierModel model;


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
        /// <param name="model">The targeting event modifier model to set for.</param>
        /// <param name="moveUpButtonClickEvent">The MoveUpButtonClickEvent to set for,</param>
        /// <param name="moveDownButtonClickEvent">The MoveDownButtonClickEvent to set for.</param>
        /// <param name="renameButtonClickEvent">The RenameButtonClickEvent to set for.</param>
        /// <param name="removeButtonClickEvent">The RemoveButtonClickEvent to set for.</param>
        public EventModifierCallback
        (
            EventModifierModel model,
            EventCallback<ClickEvent> moveUpButtonClickEvent,
            EventCallback<ClickEvent> moveDownButtonClickEvent,
            EventCallback<ClickEvent> renameButtonClickEvent,
            EventCallback<ClickEvent> removeButtonClickEvent
        )
        {
            this.model = model;
            this.moveUpButtonClickEvent = moveUpButtonClickEvent;
            this.moveDownButtonClickEvent = moveDownButtonClickEvent;
            this.renameButtonClickEvent = renameButtonClickEvent;
            this.removeButtonClickEvent = removeButtonClickEvent;
        }


        // ----------------------------- Reset Internal -----------------------------
        /// <summary>
        /// Reset all the internal properties within the callback class.
        /// </summary>
        /// <param name="model">The targeting event modifier model to set for.</param>
        /// <param name="moveUpButtonClickEvent">The MoveUpButtonClickEvent to set for,</param>
        /// <param name="moveDownButtonClickEvent">The MoveDownButtonClickEvent to set for.</param>
        /// <param name="renameButtonClickEvent">The RenameButtonClickEvent to set for.</param>
        /// <param name="removeButtonClickEvent">The RemoveButtonClickEvent to set for.</param>
        /// <returns>The renewed event modifier callback class.</returns>
        public EventModifierCallback ResetInternal
        (
            EventModifierModel model,
            EventCallback<ClickEvent> moveUpButtonClickEvent,
            EventCallback<ClickEvent> moveDownButtonClickEvent,
            EventCallback<ClickEvent> renameButtonClickEvent,
            EventCallback<ClickEvent> removeButtonClickEvent
        )
        {
            this.model = model;
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

            var commonButtonCallback = new CommonButtonCallback();
            RegisterMoveUpButtonClickEvent(callback: commonButtonCallback);
            RegisterMoveDownButtonClickEvent(callback: commonButtonCallback);
            RegisterRenameButtonClickEvent(callback: commonButtonCallback);
            RegisterRemoveButtonClickEvent(callback: commonButtonCallback);

            RegisterDialogueEventObjectFieldEvents();

            RegisterDelaySecondsIntegerFieldEvents();
        }


        /// <summary>
        /// Register events to the folder.
        /// </summary>
        void RegisterFolderEvents()
        {
            new FolderCallback(folder: model.FolderModel).RegisterEvents();
        }


        /// <summary>
        /// Register ClickEvent to the move up button.
        /// </summary>
        void RegisterMoveUpButtonClickEvent(CommonButtonCallback callback)
        {
            callback.ResetInternal(
                isAlert: true,
                button: model.MoveUpButton,
                clickEvent: moveUpButtonClickEvent).RegisterEvents();
        }


        /// <summary>
        /// Register ClickEvent to the move down button.
        /// </summary>
        void RegisterMoveDownButtonClickEvent(CommonButtonCallback callback)
        {
            callback.ResetInternal(
                isAlert: true,
                button: model.MoveDownButton,
                clickEvent: moveDownButtonClickEvent).RegisterEvents();
        }


        /// <summary>
        /// Register ClickEvent to the rename button.
        /// </summary>
        void RegisterRenameButtonClickEvent(CommonButtonCallback callback)
        {
            callback.ResetInternal(
                isAlert: true,
                button: model.RenameButton,
                clickEvent: renameButtonClickEvent).RegisterEvents();
        }


        /// <summary>
        /// Register ClickEvent to the remove button.
        /// </summary>
        void RegisterRemoveButtonClickEvent(CommonButtonCallback callback)
        {
            callback.ResetInternal(
                isAlert: true,
                button: model.RemoveButton,
                clickEvent: removeButtonClickEvent).RegisterEvents();
        }


        /// <summary>
        /// Register events to the dialogue event object field.
        /// </summary>
        void RegisterDialogueEventObjectFieldEvents()
        {
            new CommonObjectFieldCallback<DialogueEvent>(
                    model: model.DialogueEventObjectFieldModel).RegisterEvents();
        }


        /// <summary>
        /// Register events to the delay seconds integer field.
        /// </summary>
        void RegisterDelaySecondsIntegerFieldEvents()
        {
            new CommonIntegerFieldCallback(
                model.DelaySecondsIntegerFieldModel).RegisterEvents();
        }
    }
}