namespace AG.DS
{
    public class OptionWindowNode : NodeFrameBase
    <
        OptionWindowNode,
        OptionWindowNodeModel,
        OptionWindowNodePresenter,
        OptionWindowNodeSerializer,
        OptionWindowNodeCallback,
        OptionWindowNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option window node component class.
        /// </summary>
        /// <param name="details">The connecting creation details to set for.</param>
        /// <param name="graphViewer">Reference of the dialogue system's graph viewer module.</param>
        public OptionWindowNode
        (
            NodeCreationDetails details,
            GraphViewer graphViewer
        )
            : base(StringsConfig.OptionWindowNodeDefaultTitleText, graphViewer)
        {
            SetupFrameFields();

            CreateNodeElements();

            CreateNodePorts();

            PostProcessNodeWidth();

            PostProcessNodePosition();

            AddStyleSheet();

            NodeCreatedAction();

            void SetupFrameFields()
            {
                OptionWindowNodeModel model = new(node: this);

                Presenter = new(node: this, model: model);
                Serializer = new(node: this, model: model);
                Callback = new(node: this, model: model);
            }

            void CreateNodeElements()
            {
                Presenter.CreateNodeElements();
            }

            void CreateNodePorts()
            {
                Presenter.CreateNodePorts();
            }

            void PostProcessNodeWidth()
            {
                Presenter.PostProcessNodeWidth
                (
                    minWidth: NodesConfig.OptionWindowNodeMinWidth,
                    widthBuffer: NodesConfig.OptionWindowNodeWidthBuffer
                );
            }

            void PostProcessNodePosition()
            {
                Presenter.PostProcessNodePosition(details);
            }

            void AddStyleSheet()
            {
                styleSheets.Add(StylesConfig.DSOptionWindowNodeStyle);
                styleSheets.Add(StylesConfig.DSSegmentsStyle);
                styleSheets.Add(StylesConfig.DSIntegrantsStyle);
            }
        }


        // ----------------------------- Constructor (Load) -----------------------------
        /// <summary>
        /// Constructor of the option window node component class.
        /// <para>Specifically used when the node is created by the previously saved data.</para>
        /// </summary>
        /// <param name="data">The given node data to load from.</param>
        /// <param name="graphViewer">Reference of the dialogue system's graph viewer module.</param>
        public OptionWindowNode
        (
            OptionWindowNodeData data,
            GraphViewer graphViewer
        )
            : base(StringsConfig.OptionWindowNodeDefaultTitleText, graphViewer)
        {
            SetupFrameFields();

            CreateNodeElements();

            CreateNodePorts();

            PostProcessNodeWidth();

            AddStyleSheet();

            LoadNode(data);

            NodeCreatedAction();

            void SetupFrameFields()
            {
                OptionWindowNodeModel model = new(node: this);

                Presenter = new(node: this, model: model);
                Serializer = new(node: this, model: model);
                Callback = new(node: this, model: model);
            }

            void CreateNodeElements()
            {
                Presenter.CreateNodeElements();
            }

            void CreateNodePorts()
            {
                Presenter.CreateNodePorts();
            }

            void PostProcessNodeWidth()
            {
                Presenter.PostProcessNodeWidth
                (
                    minWidth: NodesConfig.OptionWindowNodeMinWidth,
                    widthBuffer: NodesConfig.OptionWindowNodeWidthBuffer
                );
            }

            void AddStyleSheet()
            {
                styleSheets.Add(StylesConfig.DSOptionWindowNodeStyle);
                styleSheets.Add(StylesConfig.DSSegmentsStyle);
                styleSheets.Add(StylesConfig.DSIntegrantsStyle);
            }
        }
    }
}