using UnityEngine;

namespace AG
{
    public class DSStartNode : DSNodeFrameBase<DSStartNodePresenter, DSStartNodeSerializer, DSStartNodeCallback>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Construtor of start node.
        /// </summary>
        /// <param name="position">The vector2 position of where this node'll be created on the graph.</param>
        /// <param name="graphView">Dialogue system's graph view module.</param>
        public DSStartNode(Vector2 position, DSGraphView serializeHandler)
            : base("Start", position, serializeHandler)
        {
            SetupFrameFields();

            CreateNodePorts();

            RefreshPortsLayout();

            AddStyleSheet();

            InvokeNodeAddedAction();

            void SetupFrameFields()
            {
                DSStartNodeModel model = new DSStartNodeModel();

                Presenter = new DSStartNodePresenter(this, model);
                Serializer = new DSStartNodeSerializer(this, model);
                Callback = new DSStartNodeCallback(this, model);
            }

            void CreateNodePorts()
            {
                Presenter.CreateNodePorts();
            }

            void AddStyleSheet()
            {
                styleSheets.Add(DSStylesConfig.StartNodeStyle);
            }

            void InvokeNodeAddedAction()
            {
                Callback.NodeAddedAction();
            }
        }
    }
}