using UnityEngine;

namespace AG
{
    public class DSEventNode : DSNodeFrameBase<DSEventNodePresenter, DSEventNodeSerializer, DSEventNodeCallback>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of event node.
        /// </summary>
        /// <param name="position">The vector2 position of where this node'll be created on the graph.</param>
        /// <param name="graphView">Dialogue system's graph view module.</param>
        public DSEventNode(Vector2 position, DSGraphView graphView)
            : base("Event", position, graphView)
        {
            SetupFrameFields();

            CreateNodeElements();

            AddPorts();

            RefreshPortsLayout();

            AddStyleSheet();

            InvokeNodeAddedAction();

            void SetupFrameFields()
            {
                DSEventNodeModel model = new DSEventNodeModel();

                Presenter = new DSEventNodePresenter(this, model);
                Serializer = new DSEventNodeSerializer(this, model);
                Callback = new DSEventNodeCallback(this, model);
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
                styleSheets.Add(DSStylesConfig.eventNodeStyle);
                styleSheets.Add(DSStylesConfig.dsModifiersStyle);
                styleSheets.Add(DSStylesConfig.dsSegmentsStyle);
                styleSheets.Add(DSStylesConfig.dsIntegrantsStyle);
                styleSheets.Add(DSStylesConfig.dsRootedModifiersStyle);
            }

            void InvokeNodeAddedAction()
            {
                Callback.NodeAddedAction();
            }
        }
    }
}