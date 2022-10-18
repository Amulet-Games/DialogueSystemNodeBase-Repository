namespace AG
{
    public class DSPathNodeSerializer : DSNodeSerializerFrameBase<DSPathNode, DSPathNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of path node serializer.
        /// </summary>
        /// <param name="node">Node of which this serializer is connecting upon.</param>
        /// <param name="model">Model of which this serializer is connecting upon.</param>
        public DSPathNodeSerializer(DSPathNode node, DSPathNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Save -----------------------------
        /// <summary>
        /// Create a new path node's model and save the current model's data into it.
        /// </summary>
        /// <param name="edges">List of edges that are currently in the graph.</param>
        /// <returns>A new copy of selected path node model.</returns>
        public DSPathNodeModel SaveNode()
        {
            DSPathNodeModel newNodeModel = new DSPathNodeModel(Node);

            SaveBaseValues(newNodeModel);

            SavePortsGuid();

            SaveOptionEntry();

            SaveOptionWindow();

            SaveDualPortraitsSegment();

            SaveDialogueSegment();

            return newNodeModel;

            void SavePortsGuid()
            {
                newNodeModel.SavedInputPortGuid = Model.InputPort.name;
            }

            void SaveOptionEntry()
            {
                newNodeModel.OptionEntry.SaveEntryValues(Model.OptionEntry);
            }

            void SaveOptionWindow()
            {
                newNodeModel.OptionWindow.SaveWindowValues(Model.OptionWindow);
            }

            void SaveDualPortraitsSegment()
            {
                newNodeModel.DualPortraitsSegment.SaveSegmentValues(Model.DualPortraitsSegment);
            }

            void SaveDialogueSegment()
            {
                newNodeModel.DialogueSegment.SaveSegmentValues(Model.DialogueSegment);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void LoadNode(DSPathNodeModel source)
        {
            LoadBaseValues(source);

            LoadPortsGuid();

            LoadOptionEntry();

            LoadOptionEntries();

            LoadDualPortraitsSegment();

            LoadDialogueSegment();

            RefreshPortsLayout();

            void LoadPortsGuid()
            {
                Model.InputPort.name = source.SavedInputPortGuid;
            }

            void LoadOptionEntry()
            {
                Model.OptionEntry.LoadEntryValues(source.OptionEntry);
            }

            void LoadOptionEntries()
            {
                Model.OptionWindow.LoadWindowValues(source.OptionWindow);
            }

            void LoadDualPortraitsSegment()
            {
                Model.DualPortraitsSegment.LoadSegmentValues(source.DualPortraitsSegment);
            }

            void LoadDialogueSegment()
            {
                Model.DialogueSegment.LoadSegmentValues(source.DialogueSegment);
            }

            void RefreshPortsLayout()
            {
                // Refresh Ports Layout.
                Node.RefreshPorts();
            }
        }
    }
}