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
        public override void Save(DialogueSystemData dsData)
        {
            var data = new EdgeDataBase()
            {
                InputPortGUID = input.name,
                OutputPortGUID = output.name,
                PortType = PortType.DEFAULT
            };

            dsData.EdgeData.Add(data);
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