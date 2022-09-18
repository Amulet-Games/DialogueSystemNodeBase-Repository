using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG
{
    public class DSStartNode : DSNodeFrameBase<DSStartNodePresenter, DSStartNodeSerializer, DSStartNodeCallback>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Construtor of start node.
        /// </summary>
        /// <param name="position">The vector2 position on the graph where this node'll be placed to once it's created.</param>
        /// <param name="graphView">Dialogue system's graph view module.</param>
        public DSStartNode(Vector2 position, DSGraphView graphView)
            : base(DSStringsConfig.StartNodeDefaultLabelText, position, graphView)
        {
            SetupFrameFields();

            CreateNodeElements();

            CreateNodePorts();

            RefreshPortsLayout();

            AddStyleSheet();

            InvokeInitalizedAction();

            void SetupFrameFields()
            {
                DSStartNodeModel model = new DSStartNodeModel();

                Presenter = new DSStartNodePresenter(this, model);
                Serializer = new DSStartNodeSerializer(this, model);
                Callback = new DSStartNodeCallback(this, model);
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
                styleSheets.Add(DSStylesConfig.StartNodeStyle);
            }

            void InvokeInitalizedAction()
            {
                Callback.InitializedAction();
            }
        }
    }
}