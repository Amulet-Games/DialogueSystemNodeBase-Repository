namespace AG.DS
{
    /// <inheritdoc />
    public class PreviewNodeSerializer : NodeSerializerFrameBase
    <
        PreviewNode,
        PreviewNodeView,
        PreviewNodeData
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
        public override void Save(DialogueSystemData dsData)
        {
            PreviewNodeData data = new();

            SaveBaseValues(data: data);

            SavePorts();

            SaveSpriteObjectContainers();

            AddData();

            void SavePorts()
            {
                View.InputDefaultPort.Save(data.InputPortData);
                View.OutputDefaultPort.Save(data.OutputPortData);
            }

            void SaveSpriteObjectContainers()
            {
                // Left side sprite.
                data.LeftPortraitSprite = View.LeftPortraitObjectFieldView.Value;

                // Right side sprite. 
                data.RightPortraitSprite = View.RightPortraitObjectFieldView.Value;
            }

            void AddData()
            {
                dsData.NodeData.Add(data);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(PreviewNodeData data)
        {
            LoadBaseValues(data);

            LoadPorts();

            LoadSpriteObjectContainers();

            void LoadPorts()
            {
                View.InputDefaultPort.Load(data.InputPortData);
                View.OutputDefaultPort.Load(data.OutputPortData);
            }

            void LoadSpriteObjectContainers()
            {
                // Left side sprite.
                View.LeftPortraitObjectFieldView.Load(data.LeftPortraitSprite);

                // Right side sprite. 
                View.RightPortraitObjectFieldView.Load(data.RightPortraitSprite);

                // Update preview images.
                View.LeftPortraitImage.image = View.LeftPortraitObjectFieldView.Value.texture;
                View.RightPortraitImage.image = View.RightPortraitObjectFieldView.Value.texture;
            }
        }
    }
}