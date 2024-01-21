namespace AG.DS
{
    public class EventModifierObserver
    {
        /// <summary>
        /// The targeting event modifier view.
        /// </summary>
        EventModifierView view;


        /// <summary>
        /// Reference of the event modifier group element.
        /// </summary>
        EventModifierGroup group;


        /// <summary>
        /// Constructor of the event modifier observer class.
        /// </summary>
        /// <param name="view">The event modifier view to set for.</param>
        /// <param name="group">The event modifier group element to set for,</param>
        public EventModifierObserver
        (
            EventModifierView view,
            EventModifierGroup group
        )
        {
            this.view = view;
            this.group = group;
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

            RegisterDelaySecondsFieldEvents();
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
        /// Register events to the dialogue event field.
        /// </summary>
        void RegisterDialogueEventFieldEvents()
            => new CommonObjectFieldObserver<DialogueEvent>(view: view.DialogueEventFieldView).RegisterEvents();


        /// <summary>
        /// Register events to the delay seconds field.
        /// </summary>
        void RegisterDelaySecondsFieldEvents()
            => new CommonFloatFieldObserver(view: view.DelaySecondsFieldView).RegisterEvents();


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the move up button is clicked.
        /// </summary>
        void MoveUpButtonClickEvent()
        {
            group.Swap(modifier: view, swapUp: true);
        }


        /// <summary>
        /// The event to invoke when the move down button is clicked.
        /// </summary>
        void MoveDownButtonClickEvent()
        {
            group.Swap(modifier: view, swapUp: false);
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
            group.Remove(view);
            group.UpdateReferences();
        }
    }
}