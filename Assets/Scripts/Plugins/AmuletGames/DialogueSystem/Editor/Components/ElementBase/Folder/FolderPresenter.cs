namespace AG.DS
{
    public class FolderPresenter
    {
        /// <summary>
        /// Method for creating a new folder element.
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
                folder = new();
                folder.AddToClassList(StyleConfig.Folder_Main);
            }

            void SetupContainers()
            {
                folder.TitleContainer = new();
                folder.TitleContainer.AddToClassList(StyleConfig.Folder_Title_Container);

                folder.ContentContainer = new();
                folder.ContentContainer.AddToClassList(StyleConfig.Folder_ContentContainer);
            }

            void SetupTitleTextField()
            {
                folder.TitleTextFieldView.TextField = FolderTitleTextFieldPresenter.CreateElement
                (
                    folderTitle: folderTitle,
                    fieldUSS: StyleConfig.Folder_Title_TextField
                );
            }

            void SetupExpandButton()
            {
                folder.ExpandButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.FolderExpandButtonCloseIconSprite,
                    buttonUSS: StyleConfig.Folder_ExpandFolder_Button
                );

                folder.ExpandButton.AddBackgroundHighlighter();
            }

            void AddElementsToContainer()
            {
                folder.TitleContainer.Add(folder.ExpandButton);
                folder.TitleContainer.Add(folder.TitleTextFieldView.TextField);
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