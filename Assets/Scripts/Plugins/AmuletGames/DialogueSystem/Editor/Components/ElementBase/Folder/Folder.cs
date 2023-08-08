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
        /// View for the title text field.
        /// </summary>
        public FolderTitleTextFieldView TitleTextFieldView;


        /// <summary>
        /// The folder expanded state.
        /// </summary>
        public bool Expanded { get; private set; }


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
            model.Expanded = Expanded;
        }


        /// <summary>
        /// Load the folder values from the folder model.
        /// </summary>
        /// <param name="model">The folder model to set for.</param>
        public void Load(FolderModel model)
        {
            TitleTextFieldView.Load(model.TitleText);
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
            var fieldInput = TitleTextFieldView.Field.GetFieldInput();
            fieldInput.focusable = true;
            fieldInput.Focus();
        }
    }
}