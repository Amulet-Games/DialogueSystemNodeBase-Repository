namespace AG.DS
{
    public class FolderPresenter
    {
        /// <summary>
        /// Create a new folder element.
        /// </summary>
        /// <param name="folderTitle">The folder title to set for.</param>
        /// <returns>A new folder element.</returns>
        public static Folder CreateElement(string folderTitle)
        {
            Folder folder;

            CreateFolder();

            SetupContainers();

            SetupTitleTextField();

            SetupExpandButton();

            AddElementsToContainer();

            AddContainersToFolder();

            AddStyleSheet();

            return folder;

            void CreateFolder()
            {
                folder = new(folderTitle);
                folder.AddToClassList(StyleConfig.Folder);
            }

            void SetupContainers()
            {
                folder.TitleContainer = new();
                folder.TitleContainer.AddToClassList(StyleConfig.Folder_Title_Container);

                folder.ContentContainer = new();
                folder.ContentContainer.AddToClassList(StyleConfig.Folder_Content_Container);
            }

            void SetupTitleTextField()
            {
                FolderTitleTextFieldPresenter.CreateElement
                (
                    view: folder.FolderTitleFieldView,
                    fieldUSS: StyleConfig.Folder_FolderTitle_Field
                );
            }

            void SetupExpandButton()
            {
                folder.ExpandButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.FolderExpandButtonCloseIconSprite,
                    buttonUSS: StyleConfig.Folder_Expand_Button
                );

                folder.ExpandButton.AddBackgroundHighlighter();
            }

            void AddElementsToContainer()
            {
                folder.TitleContainer.Add(folder.ExpandButton);
                folder.TitleContainer.Add(folder.FolderTitleFieldView.Field);
            }

            void AddContainersToFolder()
            {
                folder.Add(folder.TitleContainer);
                folder.Add(folder.ContentContainer);
            }

            void AddStyleSheet()
            {
                folder.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSFolderStyle);
            }
        }
    }
}