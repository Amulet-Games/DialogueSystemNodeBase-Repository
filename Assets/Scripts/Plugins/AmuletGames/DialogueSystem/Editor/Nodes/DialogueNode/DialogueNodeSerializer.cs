namespace AG.DS
{
    /// <inheritdoc />
    public class DialogueNodeSerializer : NodeSerializerFrameBase
    <
        DialogueNode,
        DialogueNodeModel,
        DialogueNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the dialogue node serializer module class.
        /// </summary>
        /// <param name="node">Node of which this serializer is connecting upon.</param>
        /// <param name="model">Model of which this serializer is connecting upon.</param>
        public DialogueNodeSerializer(DialogueNode node, DialogueNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void SaveNode(DialogueSystemData dsData)
        {
            DialogueNodeData data = new();

            SaveBaseValues(data: data);

            SavePortsGUID();

            SaveCharacterObjectContainer();

            AddData();

            void SavePortsGUID()
            {
                data.InputPortGUID = Model.InputPort.name;
                data.OutputPortGUID = Model.OutputPort.name;
            }

            void SaveCharacterObjectContainer()
            {
                data.DialogueCharacter = Model.CharacterObjectContainer.Value;
            }

            void AddData()
            {
                dsData.DialogueNodeData.Add(data);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void LoadNode(DialogueNodeData data)
        {
            LoadBaseValues(data);

            LoadPortsGUID();

            LoadCharacterObjectContainer();

            void LoadPortsGUID()
            {
                Model.InputPort.name = data.InputPortGUID;
                Model.OutputPort.name = data.OutputPortGUID;
            }

            void LoadCharacterObjectContainer()
            {
                Model.CharacterObjectContainer.LoadContainerValue(data.DialogueCharacter);
            }
        }
    }
}