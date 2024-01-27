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
        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(PreviewNode node, PreviewNodeData data)
        {
            base.Save(node, data);

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
            PortSerializer.Save(port: View.InputPort, data: Data.InputPortData);
            PortSerializer.Save(port: View.OutputPort, data: Data.OutputPortData);
        }


        /// <summary>
        /// Save the portrait object fields.
        /// </summary>
        void SavePortraitObjectFields()
        {
            Data.LeftPortraitSprite = View.LeftPortraitObjectFieldView.Value;
            Data.RightPortraitSprite = View.RightPortraitObjectFieldView.Value;
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(PreviewNode node, PreviewNodeData data)
        {
            base.Load(node, data);

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
            PortSerializer.Load(View.InputPort, Data.InputPortData);
            PortSerializer.Load(View.OutputPort, Data.OutputPortData);
        }


        /// <summary>
        /// Load the portrait object fields.
        /// </summary>
        void LoadPortraitObjectFields()
        {
            View.LeftPortraitObjectFieldView.Load(Data.LeftPortraitSprite);
            View.RightPortraitObjectFieldView.Load(Data.RightPortraitSprite);

            View.LeftPortraitImage.image = View.LeftPortraitObjectFieldView.Value.texture;
            View.RightPortraitImage.image = View.RightPortraitObjectFieldView.Value.texture;
        }
    }
}