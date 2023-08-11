using UnityEngine.UIElements;

namespace AG.DS
{
    public class FolderObserver
    {
        /// <summary>
        /// The targeting folder element.
        /// </summary>
        Folder folder;


        /// <summary>
        /// Constructor of the folder observer class.
        /// </summary>
        /// <param name="folder">The folder element to set for.</param>
        public FolderObserver(Folder folder)
        {
            this.folder = folder;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the folder.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterExpandButtonClickEvent();

            RegisterTitleTextFieldEvents();
        }


        /// <summary>
        /// Register ClickEvent to the expand button.
        /// </summary>
        void RegisterExpandButtonClickEvent()
            => new CommonButtonObserver(
                isAlert: false,
                button: folder.ExpandButton,
                clickEvent: ExpandButtonClickEvent).RegisterEvents();


        /// <summary>
        /// Register events to the title text field.
        /// </summary>
        void RegisterTitleTextFieldEvents()
            => new FolderTitleTextFieldObserver(
                view: folder.TitleTextFieldView).RegisterEvents();


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the expand button is clicked.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void ExpandButtonClickEvent(ClickEvent evt)
        {
            folder.SetExpanded(value: !folder.Expanded);
        }
    }
}