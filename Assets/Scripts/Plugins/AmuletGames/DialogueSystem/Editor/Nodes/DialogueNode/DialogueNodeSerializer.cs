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
        /// <param name="node">The node module to set for.</param>
        /// <param name="model">The model module to set for.</param>
        public DialogueNodeSerializer(DialogueNode node, DialogueNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(DialogueSystemData dsData)
        {
            DialogueNodeData data = new();

            SaveBaseValues(data: data);

            SavePorts();

            SaveCharacterObjectContainer();

            SaveDialogueNodeStitcher();

            AddData();

            void SavePorts()
            {
                Model.InputDefaultPort.Save(data.InputPortData);
                Model.OutputDefaultPort.Save(data.OutputPortData);
            }

            void SaveCharacterObjectContainer()
            {
                data.DialogueCharacter = Model.CharacterObjectFieldModel.Value;
            }

            void SaveDialogueNodeStitcher()
            {
                Model.DialogueNodeStitcher.SaveStitcherValues(data.DialogueNodeStitcherData);
            }

            void AddData()
            {
                dsData.DialogueNodeData.Add(data);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(DialogueNodeData data)
        {
            LoadBaseValues(data);

            LoadPorts();

            LoadCharacterObjectContainer();

            LoadDialogueNodeStitcher();

            void LoadPorts()
            {
                Model.InputDefaultPort.Load(data.InputPortData);
                Model.OutputDefaultPort.Load(data.OutputPortData);
            }
        
            void LoadCharacterObjectContainer()
            {
                Model.CharacterObjectFieldModel.Load(data.DialogueCharacter);
            }

            void LoadDialogueNodeStitcher()
            {
                Model.DialogueNodeStitcher.LoadStitcherValues(data.DialogueNodeStitcherData);
            }
        }
    }
}