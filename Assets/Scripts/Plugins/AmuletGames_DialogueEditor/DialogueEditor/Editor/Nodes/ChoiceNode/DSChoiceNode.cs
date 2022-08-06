using UnityEngine;

namespace AG
{
    public class DSChoiceNode : DSNodeFrameBase<DSChoiceNodePresenter, DSChoiceNodeSerializer, DSChoiceNodeCallback>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Construtor of choice node.
        /// </summary>
        /// <param name="position">The vector2 position of where this node'll be created on the graph.</param>
        /// <param name="graphView">Dialogue system's graph view module.</param>
        public DSChoiceNode(Vector2 position, DSGraphView graphView) 
            : base("Choice", position, graphView)
        {
            SetupFrameFields();

            CreateNodeElements();

            AddPorts();

            RefreshPortsLayout();

            AddStyleSheet();

            InvokeNodeAddedAction();

            void SetupFrameFields()
            {
                DSChoiceNodeModel model = new DSChoiceNodeModel();

                Presenter = new DSChoiceNodePresenter(this, model);
                Serializer = new DSChoiceNodeSerializer(this, model);
                Callback = new DSChoiceNodeCallback(this, model);
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
                styleSheets.Add(DSStylesConfig.choiceNodeStyle);
                styleSheets.Add(DSStylesConfig.dsModifiersStyle);
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