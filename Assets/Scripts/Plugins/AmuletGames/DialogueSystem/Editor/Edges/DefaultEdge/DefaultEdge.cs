namespace AG.DS
{
    public class DefaultEdge : EdgeFrameBase<DefaultPort>
    {
        // ----------------------------- Action -----------------------------
        /// <inheritdoc />
        public override void PreManualRemoveAction()
        {
            Disconnect();
        }


        // ----------------------------- Serialization -----------------------------
        /// <inheritdoc />
        public override void Save(DialogueSystemModel dsModel)
        {
            var model = new EdgeModelBase()
            {
                InputPortGUID = input.name,
                OutputPortGUID = output.name,
                PortType = PortType.DEFAULT
            };

            dsModel.EdgeModels.Add(model);
        }


        // ----------------------------- Disconnect -----------------------------
        /// <inheritdoc />
        public override void Disconnect()
        {
            Input.Disconnect(this);
            Output.Disconnect(this);

            input = null;
            output = null;
        }
    }
}