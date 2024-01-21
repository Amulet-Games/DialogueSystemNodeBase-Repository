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
        /// The property of the folder expanded state.
        /// </summary>
        public bool Expanded
        {
            get
            {
                return m_expanded;
            }
            set
            {
                m_expanded = value;

                ContentContainer.SetDisplay(value: m_expanded);

                if (m_expanded)
                {
                    RemoveFromClassList(StyleConfig.Folder_Closed);
                }
                else
                {
                    AddToClassList(StyleConfig.Folder_Closed);
                }

                ExpandButton.style.backgroundImage = m_expanded
                    ? ConfigResourcesManager.SpriteConfig.FolderExpandButtonOpenIconSprite.texture
                    : ConfigResourcesManager.SpriteConfig.FolderExpandButtonCloseIconSprite.texture;
            }
        }


        /// <summary>
        /// The folder expanded state.
        /// </summary>
        private bool m_expanded;


        /// <summary>
        /// Constructor of the folder element.
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
        /// <param name="data">The folder data to set for.</param>
        public void Save(FolderData data)
        {
            data.TitleText = FolderTitleFieldView.Value;
            data.Expanded = Expanded;
        }


        /// <summary>
        /// Load the folder values.
        /// </summary>
        /// <param name="data">The folder data to set for.</param>
        public void Load(FolderData data)
        {
            FolderTitleFieldView.Load(data.TitleText);
            Expanded = data.Expanded;
        }


        // ----------------------------- Service -----------------------------
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