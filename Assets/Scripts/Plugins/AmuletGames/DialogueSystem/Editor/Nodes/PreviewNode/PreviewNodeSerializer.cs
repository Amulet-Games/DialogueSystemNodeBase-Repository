namespace AG.DS
{
    /// <inheritdoc />
    public class PreviewNodeSerializer : NodeSerializerFrameBase
    <
        PreviewNode,
        PreviewNodeView,
        PreviewNodeCallback,
        PreviewNodeModel
    >
    {
        /// <inheritdoc />
        public override void Save(PreviewNode node, PreviewNodeModel model)
        {
            base.Save(node, model);

            SavePorts();

            SavePortraitObjectFields();

            void SavePorts()
            {
                node.View.InputDefaultPort.Save(model.InputPortModel);
                node.View.OutputDefaultPort.Save(model.OutputPortModel);
            }

            void SavePortraitObjectFields()
            {
                model.LeftPortraitSprite = node.View.LeftPortraitObjectFieldView.Value;
                model.RightPortraitSprite = node.View.RightPortraitObjectFieldView.Value;
            }
        }


        /// <inheritdoc />
        public override void Load(PreviewNode node, PreviewNodeModel model)
        {
            base.Load(node, model);

            LoadPorts();

            LoadPortraitObjectFields();

            void LoadPorts()
            {
                node.View.InputDefaultPort.Load(model.InputPortModel);
                node.View.OutputDefaultPort.Load(model.OutputPortModel);
            }

            void LoadPortraitObjectFields()
            {
                node.View.LeftPortraitObjectFieldView.Load(model.LeftPortraitSprite);
                node.View.RightPortraitObjectFieldView.Load(model.RightPortraitSprite);

                node.View.LeftPortraitImage.image = node.View.LeftPortraitObjectFieldView.Value.texture;
                node.View.RightPortraitImage.image = node.View.RightPortraitObjectFieldView.Value.texture;
            }
        }
    }
}