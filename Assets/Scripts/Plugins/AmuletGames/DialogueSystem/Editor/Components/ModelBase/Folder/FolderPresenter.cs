namespace AG.DS
{
    public class FolderPresenter
    {
        /// <summary>
        /// Method for creating the elements for the folder model.
        /// </summary>
        /// <param name="model">The targeting folder model to set for.</param>
        /// <param name="titleText">The title text to set for the folder.</param>
        public static void CreateElement
        (
            FolderModel model,
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
                model.MainContainer = new();
                model.MainContainer.AddToClassList(StyleConfig.Folder_MainContainer);
            }

            void SetupTitleContainer()
            {
                model.TitleContainer = new();
                model.TitleContainer.AddToClassList(StyleConfig.Folder_Title_Container);
            }

            void SetupTitleTextField()
            {
                model.TitleTextFieldModel.TextField = FolderTitleTextFieldPresenter.CreateElement
                (
                    titleText: titleText,
                    fieldUSS01: StyleConfig.Folder_Title_TextField
                );
            }

            void SetupExpandButton()
            {
                model.ExpandButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.FolderExpandButtonCloseIconSprite,
                    buttonUSS01: StyleConfig.Folder_ExpandFolder_Button
                );
            }

            void SetupContentContainer()
            {
                model.ContentContainer = new();
                model.ContentContainer.AddToClassList(StyleConfig.Folder_ContentContainer);
            }

            void AddElementsToContainer()
            {
                model.TitleContainer.Add(model.ExpandButton);
                model.TitleContainer.Add(model.TitleTextFieldModel.TextField);
            }

            void AddContainersToFolder()
            {
                model.MainContainer.Add(model.TitleContainer);
                model.MainContainer.Add(model.ContentContainer);
            }
        }
    }
}