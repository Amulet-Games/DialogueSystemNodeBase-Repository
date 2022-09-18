using UnityEngine;

namespace AG
{
    public class DSEndNode : DSNodeFrameBase<DSEndNodePresenter, DSEndNodeSerializer, DSEndNodeCallback>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Construtor of end node.
        /// </summary>
        /// <param name="position">The vector2 position on the graph where this node'll be placed to once it's created.</param>
        /// <param name="graphView">Dialogue system's graph view module.</param>
        public DSEndNode(Vector2 position, DSGraphView graphView)
            : base(DSStringsConfig.EndNodeDefaultLabelText, position, graphView)
        {
            SetupFrameFields();

            CreateNodeElements();

            CreateNodePorts();

            RefreshPortsLayout();

            AddStyleSheet();

            InvokeInitalizedAction();

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

            void InvokeInitalizedAction()
            {
                Callback.InitializedAction();
            }
        }
    }
}