﻿namespace AG.DS
{
    /// <inheritdoc />
    public class DialogueNodeSerializer : NodeSerializerFrameBase
    <
        DialogueNode,
        DialogueNodeView,
        DialogueNodeData
    >
    {
        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(DialogueNode node, DialogueNodeData data)
        {
            base.Save(node, data);

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
            PortSerializer.Save(port: View.InputPort, data: Data.InputPortData);
            PortSerializer.Save(port: View.OutputPort, data: Data.OutputPortData);
        }


        /// <summary>
        /// Save the character object field.
        /// </summary>
        void SaveCharacterObjectField()
        {
            Data.DialogueSpeaker = View.DialogueSpeakerFieldView.Value;
        }


        /// <summary>
        /// Save the dialogue node stitcher.
        /// </summary>
        void SaveDialogueNodeStitcher()
        {
            
        }


        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Load(DialogueNode node, DialogueNodeData data)
        {
            base.Load(node, data);

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
            PortSerializer.Load(View.InputPort, Data.InputPortData);
            PortSerializer.Load(View.OutputPort, Data.OutputPortData);
        }


        /// <summary>
        /// Load the character object field.
        /// </summary>
        void LoadCharacterObjectField()
        {
            View.DialogueSpeakerFieldView.Load(Data.DialogueSpeaker);
        }


        /// <summary>
        /// Load the dialogue node stitcher.
        /// </summary>
        void LoadDialogueNodeStitcher()
        {
            
        }
    }
}