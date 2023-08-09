namespace AG.DS
{
    /// <inheritdoc />
    public class DialogueNodeSerializer : NodeSerializerFrameBase
    <
        DialogueNode,
        DialogueNodeView,
        DialogueNodeModel
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
        public override void Save(DialogueSystemModel dsModel)
        {
            DialogueNodeModel model = new();

            SaveBaseValues(model);

            SavePorts();

            SaveCharacterObjectContainer();

            SaveDialogueNodeStitcher();

            AddToDsModel();

            void SavePorts()
            {
                View.InputDefaultPort.Save(model.InputPortModel);
                View.OutputDefaultPort.Save(model.OutputPortModel);
            }

            void SaveCharacterObjectContainer()
            {
                model.DialogueCharacter = View.CharacterObjectFieldView.Value;
            }

            void SaveDialogueNodeStitcher()
            {
                View.DialogueNodeStitcher.SaveStitcherValues(model.DialogueNodeStitcherModel);
            }

            void AddToDsModel()
            {
                dsModel.NodeModels.Add(model);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(DialogueNodeModel model)
        {
            base.Load(model);

            LoadPorts();

            LoadCharacterObjectContainer();

            LoadDialogueNodeStitcher();

            void LoadPorts()
            {
                View.InputDefaultPort.Load(model.InputPortModel);
                View.OutputDefaultPort.Load(model.OutputPortModel);
            }
        
            void LoadCharacterObjectContainer()
            {
                View.CharacterObjectFieldView.Load(model.DialogueCharacter);
            }

            void LoadDialogueNodeStitcher()
            {
                View.DialogueNodeStitcher.LoadStitcherValues(model.DialogueNodeStitcherModel);
            }
        }
    }
}