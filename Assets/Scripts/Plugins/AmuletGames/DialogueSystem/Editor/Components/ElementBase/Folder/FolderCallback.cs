using UnityEngine.UIElements;

namespace AG.DS
{
    public class FolderCallback
    {
        /// <summary>
        /// The targeting folder element.
        /// </summary>
        Folder folder;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the folder callback class.
        /// </summary>
        /// <param name="folder">The folder element to set for.</param>
        public FolderCallback(Folder folder)
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

            RegisterFolderTitleTextFieldEvents();
        }


        /// <summary>
        /// Register ClickEvent to the folder's expand button.
        /// </summary>
        void RegisterExpandButtonClickEvent()
        {
            new CommonButtonCallback(
                isAlert: false,
                button: folder.ExpandButton,
                clickEvent: ExpandButtonClickEvent).RegisterEvents();
        }


        /// <summary>
        /// Register events to the folder's title text field.
        /// </summary>
        void RegisterFolderTitleTextFieldEvents()
        {
            new FolderTitleTextFieldCallback(
                view: folder.TitleTextFieldView).RegisterEvents();
        }


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the folder's expand button is clicked.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void ExpandButtonClickEvent(ClickEvent evt)
        {
            folder.SetIsExpand(value: !folder.IsExpand);
        }
    }
}