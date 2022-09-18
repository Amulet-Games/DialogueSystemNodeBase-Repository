using UnityEngine;

namespace AG
{
    public class DSEventNode : DSNodeFrameBase<DSEventNodePresenter, DSEventNodeSerializer, DSEventNodeCallback>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of event node.
        /// </summary>
        /// <param name="position">The vector2 position on the graph where this node'll be placed to once it's created.</param>
        /// <param name="graphView">Dialogue system's graph view module.</param>
        public DSEventNode(Vector2 position, DSGraphView graphView)
            : base(DSStringsConfig.EventNodeDefaultLabelText, position, graphView)
        {
            SetupFrameFields();

            CreateNodeElements();

            CreateNodePorts();

            RefreshPortsLayout();

            AddStyleSheet();

            InvokeInitalizedAction();

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

            void CreateNodePorts()
            {
                Presenter.CreateNodePorts();
            }

            void AddStyleSheet()
            {
                styleSheets.Add(DSStylesConfig.EventNodeStyle);
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