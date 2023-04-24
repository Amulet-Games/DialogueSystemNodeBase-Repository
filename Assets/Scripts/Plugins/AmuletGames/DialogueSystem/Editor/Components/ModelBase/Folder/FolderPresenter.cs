namespace AG.DS
{
    public class FolderPresenter
    {
        /// <summary>
        /// Method for creating the UIElements for the folder model.
        /// </summary>
        /// <param name="model">The targeting folder model to set for.</param>
        /// <param name="titleText">The title text to set for the folder.</param>
        public static void CreateElements
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
                model.MainContainer.AddToClassList(StyleConfig.Instance.Folder_MainContainer);
            }

            void SetupTitleContainer()
            {
                model.TitleContainer = new();
                model.TitleContainer.AddToClassList(StyleConfig.Instance.Folder_Title_Container);
            }

            void SetupTitleTextField()
            {
                model.TitleTextFieldModel.TextField = FolderTitleTextFieldPresenter.CreateElements
                (
                    titleText: titleText,
                    fieldUSS01: StyleConfig.Instance.Folder_Title_TextField
                );
            }

            void SetupExpandButton()
            {
                model.ExpandButton = CommonButtonPresenter.CreateElements
                (
                    buttonSprite: ConfigResourcesManager.Instance.SpriteConfig.FolderExpandButtonCloseIconSprite,
                    buttonUSS01: StyleConfig.Instance.Folder_ExpandFolder_Button
                );
            }

            void SetupContentContainer()
            {
                model.ContentContainer = new();
                model.ContentContainer.AddToClassList(StyleConfig.Instance.Folder_ContentContainer);
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