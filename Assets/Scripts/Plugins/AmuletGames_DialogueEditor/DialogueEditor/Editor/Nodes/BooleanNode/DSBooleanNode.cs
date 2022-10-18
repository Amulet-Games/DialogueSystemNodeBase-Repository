namespace AG
{
    public class DSBooleanNode : DSNodeFrameBase<
        DSBooleanNode,
        DSBooleanNodeModel,
        DSBooleanNodePresenter,
        DSBooleanNodeSerializer,
        DSBooleanNodeCallback
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Construtor of boolean node.
        /// </summary>
        /// <param name="creationDetails">Reference of the dialogue system's node creation details.</param>
        /// <param name="graphView">Reference of the dialogue system's graph view module.</param>
        public DSBooleanNode(DSNodeCreationDetails creationDetails, DSGraphView graphView)
            : base(DSStringsConfig.BooleanNodeDefaultLabelText, graphView)
        {
            SetupFrameFields();

            SetupCreationDetail();

            CreateNodeElements();

            CreateNodePorts();

            RefreshPorts();

            AddStyleSheet();

            InitializedAction();

            ManualCreatedAction();

            void SetupFrameFields()
            {
                DSBooleanNodeModel model = new DSBooleanNodeModel(this);

                Presenter = new DSBooleanNodePresenter(this, model);
                Callback = new DSBooleanNodeCallback(this, model, new DSBooleanNodeSerializer(this, model));
            }

            void SetupCreationDetail()
            {
                Callback.Details = creationDetails;
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
                styleSheets.Add(DSStylesConfig.DSBooleanNodeStyle);
                styleSheets.Add(DSStylesConfig.DSModifiersStyle);
                styleSheets.Add(DSStylesConfig.DSSegmentsStyle);
                styleSheets.Add(DSStylesConfig.DSIntegrantsStyle);
                styleSheets.Add(DSStylesConfig.DSRootedModifiersStyle);
            }
        }


        // ----------------------------- Constructor (Load) -----------------------------
        /// <summary>
        /// Construtor of boolean node.
        /// Specifically used when the node is created by the previously saved model.
        /// </summary>
        /// <param name="sourceModel">Reference of the previous saved node's model.</param>
        /// <param name="graphView">Reference of the dialogue system's graph view module.</param>
        public DSBooleanNode(DSBooleanNodeModel sourceModel, DSGraphView graphView)
            : base(DSStringsConfig.BooleanNodeDefaultLabelText, graphView)
        {
            SetupFrameFields();

            CreateNodeElements();

            CreateNodePorts();

            RefreshPorts();

            AddStyleSheet();

            InitializedAction();

            LoadCreatedAction(sourceModel);

            void SetupFrameFields()
            {
                DSBooleanNodeModel model = new DSBooleanNodeModel(this);

                Presenter = new DSBooleanNodePresenter(this, model);
                Callback = new DSBooleanNodeCallback(this, model, new DSBooleanNodeSerializer(this, model));
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
                styleSheets.Add(DSStylesConfig.DSBooleanNodeStyle);
                styleSheets.Add(DSStylesConfig.DSModifiersStyle);
                styleSheets.Add(DSStylesConfig.DSSegmentsStyle);
                styleSheets.Add(DSStylesConfig.DSIntegrantsStyle);
                styleSheets.Add(DSStylesConfig.DSRootedModifiersStyle);
            }
        }
    }
}