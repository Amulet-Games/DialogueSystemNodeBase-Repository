using UnityEngine.UIElements;

namespace AG.DS
{
    public class Folder : VisualElement
    {
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
        /// Text view for the folder title.
        /// </summary>
        public FolderTitleTextFieldView TitleTextFieldView;


        /// <summary>
        /// Is the folder expanded?
        /// </summary>
        public bool IsExpand { get; private set; }


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the folder element class.
        /// </summary>
        public Folder()
        {
            TitleTextFieldView = new();
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the folder values to the folder model.
        /// </summary>
        /// <param name="model">The folder model to set for.</param>
        public void Save(FolderModel model)
        {
            model.TitleText = TitleTextFieldView.TextField.value;
            model.IsExpand = IsExpand;
        }


        /// <summary>
        /// Load the folder values from the folder model.
        /// </summary>
        /// <param name="model">The folder model to set for.</param>
        public void Load(FolderModel model)
        {
            TitleTextFieldView.Load(model.TitleText);
            SetIsExpand(value: model.IsExpand);
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Set the folder's IsExpand value and update its display.
        /// </summary>
        /// <param name="value">The value to set for.</param>
        public void SetIsExpand(bool value)
        {
            IsExpand = value;

            ContentContainer.SetDisplay(value: IsExpand);

            if (IsExpand) {
                RemoveFromClassList(StyleConfig.Folder_Closed);
            } else {
                AddToClassList(StyleConfig.Folder_Closed);
            }
            
            // Change expand folder button's sprite
            ExpandButton.style.backgroundImage = IsExpand
                ? ConfigResourcesManager.SpriteConfig.FolderExpandButtonOpenIconSprite.texture
                : ConfigResourcesManager.SpriteConfig.FolderExpandButtonCloseIconSprite.texture;
        }


        /// <summary>
        /// Add the given element to the folder title container.
        /// </summary>
        /// <param name="element">The element to set for.</param>
        public void AddElementToTitle(VisualElement element) => TitleContainer.Add(child: element);


        /// <summary>
        /// Add the given element to the folder content container.
        /// </summary>
        /// <param name="element">The element to set for.</param>
        public void AddElementToContent(VisualElement element) => ContentContainer.Add(child: element);


        /// <summary>
        /// Edit the folder's title by given focus to the folder title text field.
        /// </summary>
        public void EditFolderTitle()
        {
            var fieldInput = TitleTextFieldView.TextField.GetFieldInput();
            fieldInput.focusable = true;
            fieldInput.Focus();
        }
    }
}