using UnityEngine.UIElements;

namespace AG.DS
{
    public class FolderModel
    {
        /// <summary>
        /// The element that contains the title and content container.
        /// </summary>
        public VisualElement MainContainer;

        /// <summary>
        /// The element that contains other visual elements within the folder's title section.
        /// </summary>
        public VisualElement TitleContainer;


        /// <summary>
        /// The element that contains other visual elements within the folder's content section.
        /// </summary>
        public VisualElement ContentContainer;


        /// <summary>
        /// Button that expand or shrink the folder's content when clicked.
        /// </summary>
        public Button ExpandButton;


        /// <summary>
        /// Text model for the folder title.
        /// </summary>
        public FolderTitleTextFieldModel TitleTextFieldModel;


        /// <summary>
        /// Is the folder expanded?
        /// </summary>
        public bool IsExpand { get; private set; }


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the folder model class.
        /// </summary>
        public FolderModel()
        {
            TitleTextFieldModel = new();
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the folder values to the given data.
        /// </summary>
        /// <param name="data">The given data to save to.</param>
        public void Save(FolderData data)
        {
            data.TitleText = TitleTextFieldModel.TextField.value;
            data.IsExpand = IsExpand;
        }


        /// <summary>
        /// Load the folder values from the given data.
        /// </summary>
        /// <param name="data">The given data to load from.</param>
        public void Load(FolderData data)
        {
            TitleTextFieldModel.Load(data.TitleText);
            SetIsExpand(value: data.IsExpand);
        }


        // ----------------------------- IsExpand Utility -----------------------------
        /// <summary>
        /// Set the folder's IsExpand value and update its display.
        /// </summary>
        /// <param name="value">The value to set for.</param>
        public void SetIsExpand(bool value)
        {
            IsExpand = value;

            // change content container display.
            ContentContainer.SetDisplay(value: IsExpand);

            // Change expanded style class.
            if (IsExpand)
            {
                MainContainer.AddToClassList(StyleConfig.Folder_Expanded);
            }
            else
            {
                MainContainer.RemoveFromClassList(StyleConfig.Folder_Expanded);
            }

            // Change expand folder button's sprite
            ExpandButton.style.backgroundImage = IsExpand
                ? ConfigResourcesManager.SpriteConfig.FolderExpandButtonOpenIconSprite.texture
                : ConfigResourcesManager.SpriteConfig.FolderExpandButtonCloseIconSprite.texture;
        }


        // ----------------------------- Add To Container -----------------------------
        /// <summary>
        /// Add the given element to the folder title container.
        /// </summary>
        /// <param name="element">The element to add.</param>
        public void AddElementToTitle(VisualElement element) => TitleContainer.Add(child: element);


        /// <summary>
        /// Add the given element to the folder content container.
        /// </summary>
        /// <param name="element">The element to add.</param>
        public void AddElementToContent(VisualElement element) => ContentContainer.Add(child: element);


        // ----------------------------- Edit Folder Title -----------------------------
        /// <summary>
        /// Edit the folder's title by given focus to the folder title text field.
        /// </summary>
        public void EditFolderTitle()
        {
            var fieldInput = TitleTextFieldModel.TextField.GetElementInput();
            fieldInput.focusable = true;
            fieldInput.Focus();
        }
    }
}