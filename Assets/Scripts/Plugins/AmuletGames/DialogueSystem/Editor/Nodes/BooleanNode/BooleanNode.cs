namespace AG.DS
{
    public class BooleanNode : NodeFrameBase
    <
        BooleanNode,
        BooleanNodeModel,
        BooleanNodePresenter,
        BooleanNodeSerializer,
        BooleanNodeCallback,
        BooleanNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Construtor of the boolean node component class.
        /// </summary>
        /// <param name="details">The connecting creation details to set for.</param>
        /// <param name="graphViewer">Reference of the dialogue system's graph viewer module.</param>
        public BooleanNode
        (
            NodeCreationDetails details,
            GraphViewer graphViewer
        )
            : base(StringsConfig.BooleanNodeDefaultTitleText, graphViewer)
        {
            SetupFrameFields();

            CreateNodeElements();

            CreateNodePorts();

            RefreshPorts();

            AddStyleSheet();

            ManualCreatedAction();

            PostCreatedAction();

            void SetupFrameFields()
            {
                BooleanNodeModel model = new(node: this);

                Presenter = new(node: this, model: model);
                Serializer = new(node: this, model: model);
                Callback = new(node: this, model: model, details: details);
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
                styleSheets.Add(StylesConfig.DSBooleanNodeStyle);
                styleSheets.Add(StylesConfig.DSModifiersStyle);
                styleSheets.Add(StylesConfig.DSSegmentsStyle);
                styleSheets.Add(StylesConfig.DSIntegrantsStyle);
                styleSheets.Add(StylesConfig.DSRootedModifiersStyle);
            }
        }


        // ----------------------------- Constructor (Load) -----------------------------
        /// <summary>
        /// Construtor of the boolean node component class.
        /// <para>Specifically used when the node is created by the previously saved data.</para>
        /// </summary>
        /// <param name="data">The given node data to load from.</param>
        /// <param name="graphViewer">Reference of the dialogue system's graph viewer module.</param>
        public BooleanNode
        (
            BooleanNodeData data,
            GraphViewer graphViewer
        )
            : base(StringsConfig.BooleanNodeDefaultTitleText, graphViewer)
        {
            SetupFrameFields();

            CreateNodeElements();

            CreateNodePorts();

            RefreshPorts();

            AddStyleSheet();

            LoadNode(data);

            LoadCreatedAction();

            PostCreatedAction();

            void SetupFrameFields()
            {
                BooleanNodeModel model = new(node: this);

                Presenter = new(node: this, model: model);
                Serializer = new(node: this, model: model);
                Callback = new(node: this, model: model, details: null);
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
                styleSheets.Add(StylesConfig.DSBooleanNodeStyle);
                styleSheets.Add(StylesConfig.DSModifiersStyle);
                styleSheets.Add(StylesConfig.DSSegmentsStyle);
                styleSheets.Add(StylesConfig.DSIntegrantsStyle);
                styleSheets.Add(StylesConfig.DSRootedModifiersStyle);
            }
        }
    }
}