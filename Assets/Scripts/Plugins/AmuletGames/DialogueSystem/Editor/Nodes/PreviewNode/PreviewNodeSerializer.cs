namespace AG.DS
{
    /// <inheritdoc />
    public class PreviewNodeSerializer : NodeSerializerFrameBase
    <
        PreviewNode,
        PreviewNodeView,
        PreviewNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the preview node serializer class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="view">The node view to set for.</param>
        public PreviewNodeSerializer(PreviewNode node, PreviewNodeView view)
        {
            Node = node;
            View = view;
        }


        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(DialogueSystemModel dsModel)
        {
            PreviewNodeModel model = new();

            SaveBaseValues(model);

            SavePorts();

            SaveSpriteObjectContainers();

            AddToDsModel();

            void SavePorts()
            {
                View.InputDefaultPort.Save(model.InputPortModel);
                View.OutputDefaultPort.Save(model.OutputPortModel);
            }

            void SaveSpriteObjectContainers()
            {
                // Left side sprite.
                model.LeftPortraitSprite = View.LeftPortraitObjectFieldView.Value;

                // Right side sprite. 
                model.RightPortraitSprite = View.RightPortraitObjectFieldView.Value;
            }

            void AddToDsModel()
            {
                dsModel.NodeModels.Add(model);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(PreviewNodeModel model)
        {
            LoadBaseValues(model);

            LoadPorts();

            LoadSpriteObjectContainers();

            void LoadPorts()
            {
                View.InputDefaultPort.Load(model.InputPortModel);
                View.OutputDefaultPort.Load(model.OutputPortModel);
            }

            void LoadSpriteObjectContainers()
            {
                // Left side sprite.
                View.LeftPortraitObjectFieldView.Load(model.LeftPortraitSprite);

                // Right side sprite. 
                View.RightPortraitObjectFieldView.Load(model.RightPortraitSprite);

                // Update preview images.
                View.LeftPortraitImage.image = View.LeftPortraitObjectFieldView.Value.texture;
                View.RightPortraitImage.image = View.RightPortraitObjectFieldView.Value.texture;
            }
        }
    }
}