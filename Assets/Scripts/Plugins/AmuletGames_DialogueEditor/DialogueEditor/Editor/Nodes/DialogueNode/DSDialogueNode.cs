using UnityEngine;

namespace AG
{
    public class DSDialogueNode : DSNodeFrameBase<DSDialogueNodePresenter, DSDialogueNodeSerializer, DSDialogueNodeCallback>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of dialogue node.
        /// </summary>
        /// <param name="position">The vector2 position of where this node'll be created on the graph.</param>
        /// <param name="graphView">Dialogue system's graph view module.</param>
        public DSDialogueNode(Vector2 position, DSGraphView graphView)
            : base("Dialogue", position, graphView)
        {
            SetupFrameFields();

            CreateNodeElements();

            AddPorts();

            RefreshPortsLayout();

            AddStyleSheet();

            InvokeNodeAddedAction();

            void SetupFrameFields()
            {
                DSDialogueNodeModel model = new DSDialogueNodeModel();

                Presenter = new DSDialogueNodePresenter(this, model, graphView);
                Serializer = new DSDialogueNodeSerializer(this, model);
                Callback = new DSDialogueNodeCallback(this, model);
            }

            void CreateNodeElements()
            {
                Presenter.CreateNodeElements();
            }

            void AddPorts()
            {
                Presenter.CreateNodePorts();
            }

            void AddStyleSheet()
            {
                styleSheets.Add(DSStylesConfig.dialogueNodeStyle);
                styleSheets.Add(DSStylesConfig.dsSegmentsStyle);
                styleSheets.Add(DSStylesConfig.dsIntegrantsStyle);
            }

            void InvokeNodeAddedAction()
            {
                Callback.NodeAddedAction();
            }
        }
    }
}