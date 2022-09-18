using UnityEngine;

namespace AG
{
    public class DSOptionNode : DSNodeFrameBase<DSOptionNodePresenter, DSOptionNodeSerializer, DSOptionNodeCallback>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Construtor of option node.
        /// </summary>
        /// <param name="position">The vector2 position on the graph where this node'll be placed to once it's created.</param>
        /// <param name="graphView">Dialogue system's graph view module.</param>
        public DSOptionNode(Vector2 position, DSGraphView graphView) 
            : base(DSStringsConfig.OptionNodeDefaultLabelText, position, graphView)
        {
            SetupFrameFields();

            CreateNodeElements();

            CreateNodePorts();

            RefreshPortsLayout();

            AddStyleSheet();

            InvokeInitalizedAction();

            void SetupFrameFields()
            {
                DSOptionNodeModel model = new DSOptionNodeModel();

                Presenter = new DSOptionNodePresenter(this, model);
                Serializer = new DSOptionNodeSerializer(this, model);
                Callback = new DSOptionNodeCallback(this, model);
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
                styleSheets.Add(DSStylesConfig.OptionNodeStyle);
                styleSheets.Add(DSStylesConfig.DSModifiersStyle);
                styleSheets.Add(DSStylesConfig.DSSegmentsStyle);
                styleSheets.Add(DSStylesConfig.DSIntegrantsStyle);
            }

            void InvokeInitalizedAction()
            {
                Callback.InitializedAction();
            }
        }
    }
}