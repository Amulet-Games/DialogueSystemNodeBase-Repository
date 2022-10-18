namespace AG
{
    public class DSEndNodeSerializer : DSNodeSerializerFrameBase<DSEndNode, DSEndNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of end node's serializer.
        /// </summary>
        /// <param name="node">Node of which this serializer is connecting upon.</param>
        /// <param name="model">Model of which this serializer is connecting upon.</param>
        public DSEndNodeSerializer(DSEndNode node, DSEndNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Save -----------------------------
        /// <summary>
        /// Create a new end node's model and save the current model's data into it.
        /// </summary>
        /// <returns>A new copy of selected end node model.</returns>
        public DSEndNodeModel SaveNode()
        {
            DSEndNodeModel target = new DSEndNodeModel(Node);

            SaveBaseValues(target);

            SavePortsGuid();

            SaveDialogueOverHandleType();

            return target;

            void SavePortsGuid()
            {
                target.SavedInputPortGuid = Model.InputPort.name;
            }

            void SaveDialogueOverHandleType()
            {
                target.dialogueOverHandleType_EnumContainer.SaveContainerValue(Model.dialogueOverHandleType_EnumContainer);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void LoadNode(DSEndNodeModel source)
        {
            LoadBaseValues(source);

            LoadPortsGuid();

            LoadDialogueOverHandleType();

            void LoadPortsGuid()
            {
                Model.InputPort.name = source.SavedInputPortGuid;
            }

            void LoadDialogueOverHandleType()
            {
                Model.dialogueOverHandleType_EnumContainer.LoadContainerValue(source.dialogueOverHandleType_EnumContainer);
            }
        }
    }
}