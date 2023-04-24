namespace AG.DS
{
    public class FolderCallback
    {
        /// <summary>
        /// The targeting folder model.
        /// </summary>
        FolderModel folder;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the folder callback class.
        /// </summary>
        /// <param name="folder"></param>
        public FolderCallback(FolderModel folder)
        {
            this.folder = folder;
        }


        // ----------------------------- Register Events Service -----------------------------
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
                clickEvent: folder.ExpandButtonClickEvent).RegisterEvents();
        }


        /// <summary>
        /// Register events to the folder's title text field.
        /// </summary>
        void RegisterFolderTitleTextFieldEvents()
        {
            new FolderTitleTextFieldCallback(
                model: folder.TitleTextFieldModel).RegisterEvents();
        }
    }
}