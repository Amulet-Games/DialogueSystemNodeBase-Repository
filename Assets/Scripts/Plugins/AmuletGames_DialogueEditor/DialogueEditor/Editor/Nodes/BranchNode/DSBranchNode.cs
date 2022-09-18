using UnityEngine;

namespace AG
{
    public class DSBranchNode : DSNodeFrameBase<DSBranchNodePresenter, DSBranchNodeSerializer, DSBranchNodeCallback>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Construtor of branch node.
        /// </summary>
        /// <param name="position">The vector2 position on the graph where this node'll be placed to once it's created.</param>
        /// <param name="graphView">Dialogue system's graph view module.</param>
        public DSBranchNode(Vector2 position, DSGraphView graphView)
            : base(DSStringsConfig.BranchNodeDefaultLabelText, position, graphView)
        {
            SetupFrameFields();

            CreateNodeElements();

            CreateNodePorts();

            RefreshPortsLayout();

            AddStyleSheet();

            InvokeInitalizedAction();

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

            void CreateNodePorts()
            {
                Presenter.CreateNodePorts();
            }

            void AddStyleSheet()
            {
                styleSheets.Add(DSStylesConfig.BranchNodeStyle);
                styleSheets.Add(DSStylesConfig.DSModifiersStyle);
                styleSheets.Add(DSStylesConfig.DSSegmentsStyle);
                styleSheets.Add(DSStylesConfig.DSIntegrantsStyle);
                styleSheets.Add(DSStylesConfig.DSRootedModifiersStyle);
            }

            void InvokeInitalizedAction()
            {
                Callback.InitializedAction();
            }
        }
    }
}