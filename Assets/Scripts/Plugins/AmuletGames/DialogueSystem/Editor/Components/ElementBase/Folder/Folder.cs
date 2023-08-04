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
        /// Button that can hide or show the folder's content section when clicked.
        /// </summary>
        public Button ExpandButton;


        /// <summary>
        /// View for the title text field.
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
        /// <param name="folderTitle">The folder title to set for.</param>
        public Folder(string folderTitle)
        {
            TitleTextFieldView = new(value: folderTitle);
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the folder values to the folder model.
        /// </summary>
        /// <param name="model">The folder model to set for.</param>
        public void Save(FolderModel model)
        {
            model.TitleText = TitleTextFieldView.Value;
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
        /// Set a new value to the IsExpand field.
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
        /// Start editing the folder title.
        /// </summary>
        public void StartEditingFolderTitle()
        {
            var fieldInput = TitleTextFieldView.Field.GetFieldInput();
            fieldInput.focusable = true;
            fieldInput.Focus();
        }
    }
}