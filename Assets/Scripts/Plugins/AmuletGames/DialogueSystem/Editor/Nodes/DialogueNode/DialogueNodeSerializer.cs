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
        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(DialogueNode node, DialogueNodeModel model)
        {
            base.Save(node, model);

            SaveNodeBaseValues();

            SaveNodeTitle();

            SavePorts();

            SaveCharacterObjectField();

            SaveDialogueNodeStitcher();
        }


        /// <summary>
        /// Save the node ports.
        /// </summary>
        void SavePorts()
        {
            Model.InputPortModel = PortManager.Instance.Save(View.InputDefaultPort);
            Model.OutputPortModel = PortManager.Instance.Save(View.OutputDefaultPort);
        }


        /// <summary>
        /// Save the character object field.
        /// </summary>
        void SaveCharacterObjectField()
        {
            Model.DialogueCharacter = View.CharacterObjectFieldView.Value;
        }


        /// <summary>
        /// Save the dialogue node stitcher.
        /// </summary>
        void SaveDialogueNodeStitcher()
        {
            View.DialogueNodeStitcher.SaveStitcherValues(Model.DialogueNodeStitcherModel);
        }


        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Load(DialogueNode node, DialogueNodeModel model)
        {
            base.Load(node, model);

            LoadNodeBaseValues();

            LoadNodeTitle();

            LoadPorts();

            LoadCharacterObjectField();

            LoadDialogueNodeStitcher();
        }


        /// <summary>
        /// Load the node ports.
        /// </summary>
        void LoadPorts()
        {
            View.InputDefaultPort.Load(Model.InputPortModel);
            View.OutputDefaultPort.Load(Model.OutputPortModel);
        }


        /// <summary>
        /// Load the character object field.
        /// </summary>
        void LoadCharacterObjectField()
        {
            View.CharacterObjectFieldView.Load(Model.DialogueCharacter);
        }


        /// <summary>
        /// Load the dialogue node stitcher.
        /// </summary>
        void LoadDialogueNodeStitcher()
        {
            View.DialogueNodeStitcher.LoadStitcherValues(Model.DialogueNodeStitcherModel);
        }
    }
}