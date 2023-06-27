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
        public override void Save(DialogueSystemData dsData)
        {
            var data = new EdgeDataBase()
            {
                InputPortGUID = input.name,
                OutputPortGUID = output.name,
                PortType = PortType.OPTION
            };

            dsData.EdgeData.Add(data);
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