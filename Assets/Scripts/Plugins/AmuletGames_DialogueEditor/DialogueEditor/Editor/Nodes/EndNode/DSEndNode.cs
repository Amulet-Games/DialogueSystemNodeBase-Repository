using UnityEngine;

namespace AG
{
    public class DSEndNode : DSNodeFrameBase<DSEndNodePresenter, DSEndNodeSerializer, DSEndNodeCallback>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Construtor of end node.
        /// </summary>
        /// <param name="position">The vector2 position of where this node'll be created on the graph.</param>
        /// <param name="graphView">Dialogue system's graph view module.</param>
        public DSEndNode(Vector2 position, DSGraphView graphView)
            : base("End", position, graphView)
        {
            SetupFrameFields();

            CreateNodeElements();

            CreateNodePorts();

            RefreshPortsLayout();

            AddStyleSheet();

            InvokeNodeAddedAction();

            void SetupFrameFields()
            {
                DSEndNodeModel model = new DSEndNodeModel();

                Presenter = new DSEndNodePresenter(this, model);
                Serializer = new DSEndNodeSerializer(this, model);
                Callback = new DSEndNodeCallback(this, model);
            }

            void CreateNodeElements()
            {
                Presenter.CreateNodeElements();
            }

            void CreateNodePorts()
            {
                Presenter.CreateNodePorts();
            }

            void AddStyleSheet()
            {
                styleSheets.Add(DSStylesConfig.EndNodeStyle);
            }

            void InvokeNodeAddedAction()
            {
                Callback.NodeAddedAction();
            }
        }
    }
}