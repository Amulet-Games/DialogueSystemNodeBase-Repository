namespace AG.DS
{
    /// <inheritdoc />
    public class PreviewNodeSerializer : NodeSerializerFrameBase
    <
        PreviewNode,
        PreviewNodeModel,
        PreviewNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the preview node serializer class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        public PreviewNodeSerializer(PreviewNode node, PreviewNodeModel model)
        {
            Node = node;
            Model = model;
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
                Model.InputDefaultPort.Save(data.InputPortData);
                Model.OutputDefaultPort.Save(data.OutputPortData);
            }

            void SaveSpriteObjectContainers()
            {
                // Left side sprite.
                data.LeftPortraitSprite = Model.LeftPortraitObjectFieldModel.Value;

                // Right side sprite. 
                data.RightPortraitSprite = Model.RightPortraitObjectFieldModel.Value;
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
                Model.InputDefaultPort.Load(data.InputPortData);
                Model.OutputDefaultPort.Load(data.OutputPortData);
            }

            void LoadSpriteObjectContainers()
            {
                // Left side sprite.
                Model.LeftPortraitObjectFieldModel.Load(data.LeftPortraitSprite);

                // Right side sprite. 
                Model.RightPortraitObjectFieldModel.Load(data.RightPortraitSprite);

                // Update preview images.
                Model.LeftPortraitImage.image = Model.LeftPortraitObjectFieldModel.Value.texture;
                Model.RightPortraitImage.image = Model.RightPortraitObjectFieldModel.Value.texture;
            }
        }
    }
}