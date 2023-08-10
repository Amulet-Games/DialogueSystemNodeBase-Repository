namespace AG.DS
{
    /// <inheritdoc />
    public class DialogueNodeSerializer : NodeSerializerFrameBase
    <
        DialogueNode,
        DialogueNodeView,
        DialogueNodeCallback,
        DialogueNodeModel
    >
    {
        /// <inheritdoc />
        public override void Save(DialogueNode node, DialogueNodeModel model)
        {
            base.Save(node, model);

            SavePorts();

            SaveCharacterObjectContainer();

            SaveDialogueNodeStitcher();

            void SavePorts()
            {
                node.View.InputDefaultPort.Save(model.InputPortModel);
                node.View.OutputDefaultPort.Save(model.OutputPortModel);
            }

            void SaveCharacterObjectContainer()
            {
                model.DialogueCharacter = node.View.CharacterObjectFieldView.Value;
            }

            void SaveDialogueNodeStitcher()
            {
                node.View.DialogueNodeStitcher.SaveStitcherValues(model.DialogueNodeStitcherModel);
            }
        }


        /// <inheritdoc />
        public override void Load(DialogueNode node, DialogueNodeModel model)
        {
            base.Load(node, model);

            LoadPorts();

            LoadCharacterObjectContainer();

            LoadDialogueNodeStitcher();

            void LoadPorts()
            {
                node.View.InputDefaultPort.Load(model.InputPortModel);
                node.View.OutputDefaultPort.Load(model.OutputPortModel);
            }
        
            void LoadCharacterObjectContainer()
            {
                node.View.CharacterObjectFieldView.Load(model.DialogueCharacter);
            }

            void LoadDialogueNodeStitcher()
            {
                node.View.DialogueNodeStitcher.LoadStitcherValues(model.DialogueNodeStitcherModel);
            }
        }
    }
}