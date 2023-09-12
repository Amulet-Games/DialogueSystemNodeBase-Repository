using UnityEngine.UIElements;

namespace AG.DS
{
    public class Folder : VisualElement
    {
        /// <summary>
        /// Element that contains the folder title's elements.
        /// </summary>
        public VisualElement TitleContainer;


        /// <summary>
        /// Element that contains the folder content's elements.
        /// </summary>
        public VisualElement ContentContainer;


        /// <summary>
        /// Button that expands the folder when clicked.
        /// </summary>
        public Button ExpandButton;


        /// <summary>
        /// View for the folder title field.
        /// </summary>
        public FolderTitleTextFieldView FolderTitleFieldView;


        /// <summary>
        /// The folder expanded state.
        /// </summary>
        public bool Expanded { get; private set; }


        /// <summary>
        /// Constructor of the folder element class.
        /// </summary>
        /// <param name="folderTitle">The folder title to set for.</param>
        public Folder(string folderTitle)
        {
            FolderTitleFieldView = new(value: folderTitle);
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the folder values.
        /// </summary>
        /// <param name="model">The folder model to set for.</param>
        public void Save(FolderModel model)
        {
            model.TitleText = FolderTitleFieldView.Value;
            model.Expanded = Expanded;
        }


        /// <summary>
        /// Load the folder values.
        /// </summary>
        /// <param name="model">The folder model to set for.</param>
        public void Load(FolderModel model)
        {
            FolderTitleFieldView.Load(model.TitleText);
            SetExpanded(value: model.Expanded);
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Changes the folder expanded state
        /// </summary>
        /// <param name="value">The value to set for.</param>
        public void SetExpanded(bool value)
        {
            Expanded = value;

            ContentContainer.SetDisplay(value: Expanded);

            if (Expanded) {
                RemoveFromClassList(StyleConfig.Folder_Closed);
            } else {
                AddToClassList(StyleConfig.Folder_Closed);
            }
            
            ExpandButton.style.backgroundImage = Expanded
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
            var fieldInput = FolderTitleFieldView.Field.GetFieldInput();
            fieldInput.focusable = true;
            fieldInput.Focus();
        }
    }
}