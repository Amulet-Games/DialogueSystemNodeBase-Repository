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
            Data.InputPortData = PortManager.Instance.Save(View.InputDefaultPort);
            Data.OutputPortData = PortManager.Instance.Save(View.OutputDefaultPort);
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
            PortManager.Instance.Load(View.InputDefaultPort, Data.InputPortData);
            PortManager.Instance.Load(View.OutputDefaultPort, Data.OutputPortData);
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