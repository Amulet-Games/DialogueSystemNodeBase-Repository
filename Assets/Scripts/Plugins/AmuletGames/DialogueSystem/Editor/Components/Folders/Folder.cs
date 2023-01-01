using UnityEngine.UIElements;

namespace AG.DS
{
    public class Folder
    {
        /// <summary>
        /// The box UIElement that stores all the visual elements that are included in the folder's title section.
        /// </summary>
        public Box TitleBox;


        /// <summary>
        /// The box UIElement that stores all the visual elements that are included in the folder's content section.
        /// </summary>
        public Box ContentBox;


        /// <summary>
        /// Button that can expand or shrink the folder's content when clicked.
        /// </summary>
        Button expandButton;


        /// <summary>
        /// Text container for the folder's title.
        /// </summary>
        public TextContainer TitleTextContainer;


        /// <summary>
        /// Is the folder expanded?
        /// </summary>
        bool isExpanded;


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create all the UIElements that are needed in the folder.
        /// </summary>
        /// <param name="node">Node of which this folder is created for.</param>
        public void CreateRootElements(string titleText)
        {
            TextField titleTextField;

            SetupBoxContainer();

            SetupTitleTextContainer();

            SetupExpandButton();

            AddFieldsToBox();

            FolderCreatedAction();

            void SetupBoxContainer()
            {
                TitleBox = new();
                TitleBox.AddToClassList(StylesConfig.Folder_Common_Title_Box);

                ContentBox = new();
                ContentBox.AddToClassList(StylesConfig.Folder_Common_Content_Box);
            }

            void SetupTitleTextContainer()
            {
                titleTextField = TextFieldFactory.GetNewDelayableTextField
                (
                    textContainer: TitleTextContainer,
                    defaultText: titleText,
                    fieldUSS01: StylesConfig.Folder_Common_Title_TextField
                );
            }

            void SetupExpandButton()
            {
                expandButton = ButtonFactory.GetNewButton
                (
                    isAlert: false,
                    buttonSprite: AssetsConfig.FolderExpandButtonCloseIconSprite,
                    buttonClickAction: SwitchFolderIsExpanded,
                    buttonUSS01: StylesConfig.Folder_Common_ExpandFolder_Button
                );
            }

            void AddFieldsToBox()
            {
                TitleBox.Add(expandButton);
                TitleBox.Add(titleTextField);
            }

            void FolderCreatedAction()
            {
                // Auto focus on the folder's title text field.
                titleTextField.Focus();
            }
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the folder values to the give data.
        /// </summary>
        /// <param name="data">The given data to save to.</param>
        public void SaveFolderValues(FolderData data)
        {
            // Save containers.
            data.TitleText = TitleTextContainer.Value;

            // Save IsExpanded
            data.IsExpanded = isExpanded;
        }


        /// <summary>
        /// Load the folder values from the give data.
        /// </summary>
        /// <param name="data">The given data to load from.</param>
        public void LoadFolderValues(FolderData data)
        {
            // Load containers.
            TitleTextContainer.LoadContainerValue(data.TitleText);

            // Load IsExpanded
            isExpanded = data.IsExpanded;
            UpdateSegmentIsExpanded();
        }


        // ----------------------------- IsExpanded Utility -----------------------------
        /// <summary>
        /// Switch the IsExpanded status and resize itself to show the changes.
        /// </summary>
        public void SwitchFolderIsExpanded()
        {
            isExpanded = !isExpanded;
            UpdateSegmentIsExpanded();
        }


        // ----------------------------- Update Folder IsExpanded Tasks -----------------------------
        /// <summary>
        /// Expand or shrink Folder based on its current IsExpanded status.
        /// </summary>
        void UpdateSegmentIsExpanded()
        {
            UpdateContentBoxDisplay();

            SwitchExpandButtonIcon();

            void UpdateContentBoxDisplay()
            {
                VisualElementHelper.UpdateElementDisplay
                (
                    condition: !isExpanded,
                    element: ContentBox
                );
            }

            void SwitchExpandButtonIcon()
            {
                expandButton.style.backgroundImage = isExpanded
                                                   ? AssetsConfig.FolderExpandButtonOpenIconSprite.texture
                                                   : AssetsConfig.FolderExpandButtonCloseIconSprite.texture;
            }
        }
    }
}