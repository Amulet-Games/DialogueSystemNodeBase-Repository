namespace AG.DS
{
    /// <inheritdoc />
    public class DialogueNodeSerializer : NodeSerializerFrameBase
    <
        DialogueNode,
        DialogueNodeView,
        DialogueNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the dialogue node serializer class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="view">The node view to set for.</param>
        public DialogueNodeSerializer(DialogueNode node, DialogueNodeView view)
        {
            Node = node;
            View = view;
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
                View.InputDefaultPort.Save(data.InputPortData);
                View.OutputDefaultPort.Save(data.OutputPortData);
            }

            void SaveCharacterObjectContainer()
            {
                data.DialogueCharacter = View.CharacterObjectFieldView.Value;
            }

            void SaveDialogueNodeStitcher()
            {
                View.DialogueNodeStitcher.SaveStitcherValues(data.DialogueNodeStitcherData);
            }

            void AddData()
            {
                dsData.NodeData.Add(data);
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
                View.InputDefaultPort.Load(data.InputPortData);
                View.OutputDefaultPort.Load(data.OutputPortData);
            }
        
            void LoadCharacterObjectContainer()
            {
                View.CharacterObjectFieldView.Load(data.DialogueCharacter);
            }

            void LoadDialogueNodeStitcher()
            {
                View.DialogueNodeStitcher.LoadStitcherValues(data.DialogueNodeStitcherData);
            }
        }
    }
}