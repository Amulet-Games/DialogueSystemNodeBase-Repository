namespace AG.DS
{
    public class FolderPresenter
    {
        /// <summary>
        /// Method for creating the elements for the folder view.
        /// </summary>
        /// <param name="view">The targeting folder view to set for.</param>
        /// <param name="titleText">The title text to set for the folder.</param>
        public static void CreateElement
        (
            FolderView view,
            string titleText
        )
        {
            SetupMainContainer();

            SetupTitleContainer();

            SetupTitleTextField();

            SetupExpandButton();

            SetupContentContainer();

            AddElementsToContainer();

            AddContainersToFolder();

            void SetupMainContainer()
            {
                view.MainContainer = new();
                view.MainContainer.AddToClassList(StyleConfig.Folder_MainContainer);
            }

            void SetupTitleContainer()
            {
                view.TitleContainer = new();
                view.TitleContainer.AddToClassList(StyleConfig.Folder_Title_Container);
            }

            void SetupTitleTextField()
            {
                view.TitleTextFieldView.TextField = FolderTitleTextFieldPresenter.CreateElement
                (
                    titleText: titleText,
                    fieldUSS: StyleConfig.Folder_Title_TextField
                );
            }

            void SetupExpandButton()
            {
                view.ExpandButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.FolderExpandButtonCloseIconSprite,
                    buttonUSS: StyleConfig.Folder_ExpandFolder_Button
                );
            }

            void SetupContentContainer()
            {
                view.ContentContainer = new();
                view.ContentContainer.AddToClassList(StyleConfig.Folder_ContentContainer);
            }

            void AddElementsToContainer()
            {
                view.TitleContainer.Add(view.ExpandButton);
                view.TitleContainer.Add(view.TitleTextFieldView.TextField);
            }

            void AddContainersToFolder()
            {
                view.MainContainer.Add(view.TitleContainer);
                view.MainContainer.Add(view.ContentContainer);
            }
        }
    }
}