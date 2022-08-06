using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG
{
    public class DSBranchNode : DSNodeFrameBase<DSBranchNodePresenter, DSBranchNodeSerializer, DSBranchNodeCallback>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Construtor of branch node.
        /// </summary>
        /// <param name="position">The vector2 position of where this node'll be created on the graph.</param>
        /// <param name="graphView">Dialogue system's graph view module.</param>
        public DSBranchNode(Vector2 position, DSGraphView graphView)
            : base("Branch", position, graphView)
        {
            SetupFrameFields();

            CreateNodeElements();

            AddPorts();

            RefreshPortsLayout();

            AddStyleSheet();

            InvokeNodeAddedAction();

            void SetupFrameFields()
            {
                DSBranchNodeModel model = new DSBranchNodeModel();

                Presenter = new DSBranchNodePresenter(this, model);
                Serializer = new DSBranchNodeSerializer(this, model);
                Callback = new DSBranchNodeCallback(this, model);
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
                styleSheets.Add(DSStylesConfig.branchNodeStyle);
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