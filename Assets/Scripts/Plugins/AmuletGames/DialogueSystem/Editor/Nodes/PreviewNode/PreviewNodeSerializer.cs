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
        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(PreviewNode node, PreviewNodeModel model)
        {
            base.Save(node, model);

            SaveNodeBaseValues();

            SaveNodeTitle();

            SavePorts();

            SavePortraitObjectFields();
        }


        /// <summary>
        /// Save the node ports.
        /// </summary>
        void SavePorts()
        {
            View.InputDefaultPort.Save(Model.InputPortModel);
            View.OutputDefaultPort.Save(Model.OutputPortModel);
        }


        /// <summary>
        /// Save the portrait object fields.
        /// </summary>
        void SavePortraitObjectFields()
        {
            Model.LeftPortraitSprite = View.LeftPortraitObjectFieldView.Value;
            Model.RightPortraitSprite = View.RightPortraitObjectFieldView.Value;
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(PreviewNode node, PreviewNodeModel model)
        {
            base.Load(node, model);

            LoadNodeBaseValues();

            LoadNodeTitle();

            LoadPorts();

            LoadPortraitObjectFields();
        }


        /// <summary>
        /// Load the node ports.
        /// </summary>
        void LoadPorts()
        {
            View.InputDefaultPort.Load(Model.InputPortModel);
            View.OutputDefaultPort.Load(Model.OutputPortModel);
        }


        /// <summary>
        /// Load the portrait object fields.
        /// </summary>
        void LoadPortraitObjectFields()
        {
            View.LeftPortraitObjectFieldView.Load(Model.LeftPortraitSprite);
            View.RightPortraitObjectFieldView.Load(Model.RightPortraitSprite);

            View.LeftPortraitImage.image = View.LeftPortraitObjectFieldView.Value.texture;
            View.RightPortraitImage.image = View.RightPortraitObjectFieldView.Value.texture;
        }
    }
}