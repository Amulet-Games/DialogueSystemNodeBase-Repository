namespace AG.DS
{
    /// <inheritdoc />
    public class EndNodeSerializer : NodeSerializerFrameBase
    <
        EndNode,
        EndNodeModel,
        EndNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the end node serializer module class.
        /// </summary>
        /// <param name="node">Node of which this serializer is connecting upon.</param>
        /// <param name="model">Model of which this serializer is connecting upon.</param>
        public EndNodeSerializer(EndNode node, EndNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void SaveNode(DialogueSystemData dsData)
        {
            EndNodeData data = new();

            SaveBaseValues(data: data);

            SavePortsGUID();

            SaveDialogueOverHandleType();

            AddData();

            void SavePortsGUID()
            {
                data.InputPortGUID = Model.InputPort.name;
            }

            void SaveDialogueOverHandleType()
            {
                data.DialogueOverHandleTypeEnumIndex =
                    Model.dialogueOverHandleType_EnumContainer.Value;
            }

            void AddData()
            {
                dsData.EndNodeData.Add(data);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void LoadNode(EndNodeData data)
        {
            LoadBaseValues(data);

            LoadPortsGUID();

            LoadDialogueOverHandleType();

            void LoadPortsGUID()
            {
                Model.InputPort.name = data.InputPortGUID;
            }

            void LoadDialogueOverHandleType()
            {
                Model.dialogueOverHandleType_EnumContainer.LoadContainerValue
                (
                    data: data.DialogueOverHandleTypeEnumIndex
                );
            }
        }
    }
}