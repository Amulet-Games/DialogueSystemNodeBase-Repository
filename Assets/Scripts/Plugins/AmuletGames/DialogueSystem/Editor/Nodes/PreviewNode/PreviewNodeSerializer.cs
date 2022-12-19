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
        /// Constructor of the preivew node serializer module class.
        /// </summary>
        /// <param name="node">The connecting node module to set for.</param>
        /// <param name="model">The connecting model module to set for.</param>
        public PreviewNodeSerializer(PreviewNode node, PreviewNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void SaveNode(DialogueSystemData dsData)
        {
            var data = new PreviewNodeData();

            SaveBaseValues(data: data);

            SavePortsGUID();

            SaveSpriteObjectContainers();

            AddData();

            void SavePortsGUID()
            {
                data.InputPortGUID = Model.InputPort.name;
                data.OutputPortGUID = Model.OutputPort.name;
            }

            void SaveSpriteObjectContainers()
            {
                // Left side sprite.
                data.LeftPortraitSprite = Model.LeftSpriteContainer.Value;

                // Right side sprite. 
                data.RightPortraitSprite = Model.RightSpriteContainer.Value;
            }

            void AddData()
            {
                dsData.PreviewNodeData.Add(data);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void LoadNode(PreviewNodeData data)
        {
            LoadBaseValues(data);

            LoadPortsGUID();

            LoadSpriteObjectContainers();

            void LoadPortsGUID()
            {
                Model.InputPort.name = data.InputPortGUID;
                Model.OutputPort.name = data.OutputPortGUID;
            }

            void LoadSpriteObjectContainers()
            {
                // Left side sprite.
                Model.LeftSpriteContainer.LoadContainerValue(data.LeftPortraitSprite);

                // Right side sprite. 
                Model.RightSpriteContainer.LoadContainerValue(data.RightPortraitSprite);

                // Update preivew images.
                ImageElementHelper.UpdateImagePreview
                    (sprite: Model.LeftSpriteContainer.Value, image: Model.LeftPortraitImage);

                ImageElementHelper.UpdateImagePreview
                    (sprite: Model.RightSpriteContainer.Value, image: Model.RightPortraitImage);
            }
        }
    }
}