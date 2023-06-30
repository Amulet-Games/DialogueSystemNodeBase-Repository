namespace AG.DS
{
    public class OptionEdge : EdgeFrameBase<OptionPort>
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
                PortType = PortType.OPTION
            };

            dsModel.EdgeModels.Add(model);
        }


        // ----------------------------- Disconnect -----------------------------
        /// <inheritdoc />
        public override void Disconnect()
        {
            Input.Disconnect(this);
            Input.HideConnectStyle();

            Output.Disconnect(this);
            Output.HideConnectStyle();

            input = null;
            output = null;
        }
    }
}