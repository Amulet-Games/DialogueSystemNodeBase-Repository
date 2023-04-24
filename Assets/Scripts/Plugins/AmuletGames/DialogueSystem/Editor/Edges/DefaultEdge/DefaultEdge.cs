namespace AG.DS
{
    public class DefaultEdge : EdgeFrameBase<DefaultEdgeModel>
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
            Model.Input.Disconnect(this);
            Model.Output.Disconnect(this);

            input = null;
            output = null;
        }
    }
}