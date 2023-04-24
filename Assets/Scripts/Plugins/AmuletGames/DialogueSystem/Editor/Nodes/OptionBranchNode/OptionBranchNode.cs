namespace AG.DS
{
    public class OptionBranchNode : NodeFrameBase
    <
        OptionBranchNode,
        OptionBranchNodeModel,
        OptionBranchNodePresenter,
        OptionBranchNodeSerializer,
        OptionBranchNodeCallback,
        OptionBranchNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option branch node component class.
        /// </summary>
        /// <param name="graphViewer">Reference of the dialogue system's graph viewer module.</param>
        /// <param name="details">The node creation details to set for.</param>
        public OptionBranchNode
        (
            NodeCreationDetails details,
            GraphViewer graphViewer
        )
            : base(StringConfig.Instance.OptionBranchNode_TitleText, graphViewer)
        {
            SetupFrameFields();

            CreateNodeElements();

            PostProcessNodeWidth();

            PostProcessNodePosition();

            AddStyleSheet();

            NodeCreatedAction();

            void SetupFrameFields()
            {
                Model = new(node: this);
                Presenter = new(node: this, model: Model);
                Serializer = new(node: this, model: Model);
                Callback = new(node: this, model: Model);
            }

            void CreateNodeElements()
            {
                Presenter.CreateTitleElements();
                Presenter.CreatePortElements();
                Presenter.CreateContentElements();
            }

            void PostProcessNodeWidth()
            {
                Presenter.PostProcessSetWidthValues
                (
                    minWidth: NodeConfig.OptionBranchNodeMinWidth,
                    widthBuffer: NodeConfig.OptionBranchNodeWidthBuffer
                );
            }

            void PostProcessNodePosition()
            {
                Presenter.PostProcessNodePosition(details);
            }

            void AddStyleSheet()
            {
                var styleSheetConfig = ConfigResourcesManager.Instance.StyleSheetConfig;
                styleSheets.Add(styleSheetConfig.DSOptionBranchNodeStyle);
                styleSheets.Add(styleSheetConfig.DSModifierStyle);
                styleSheets.Add(styleSheetConfig.DSSegmentStyle);
                styleSheets.Add(styleSheetConfig.DSContentButtonStyle);
            }
        }


        // ----------------------------- Constructor (Load) -----------------------------
        /// <summary>
        /// Constructor of the option branch node component class.
        /// <para>Specifically used when the node is created by the previously saved data.</para>
        /// </summary>
        /// <param name="data">The given node data to load from.</param>
        /// <param name="graphViewer">Reference of the dialogue system's graph viewer module.</param>
        public OptionBranchNode
        (
            OptionBranchNodeData data,
            GraphViewer graphViewer
        )
            : base(StringConfig.Instance.OptionBranchNode_TitleText, graphViewer)
        {
            SetupFrameFields();

            CreateNodeElements();

            PostProcessNodeWidth();

            AddStyleSheet();

            Serializer.Load(data);

            NodeCreatedAction();

            void SetupFrameFields()
            {
                Model = new(node: this);
                Presenter = new(node: this, model: Model);
                Serializer = new(node: this, model: Model);
                Callback = new(node: this, model: Model);
            }

            void CreateNodeElements()
            {
                Presenter.CreateTitleElements();
                Presenter.CreatePortElements();
                Presenter.CreateContentElements();
            }

            void PostProcessNodeWidth()
            {
                Presenter.PostProcessSetWidthValues
                (
                    minWidth: NodeConfig.OptionBranchNodeMinWidth,
                    widthBuffer: NodeConfig.OptionBranchNodeWidthBuffer
                );
            }

            void AddStyleSheet()
            {
                var styleSheetConfig = ConfigResourcesManager.Instance.StyleSheetConfig;
                styleSheets.Add(styleSheetConfig.DSOptionBranchNodeStyle);
                styleSheets.Add(styleSheetConfig.DSModifierStyle);
                styleSheets.Add(styleSheetConfig.DSSegmentStyle);
                styleSheets.Add(styleSheetConfig.DSContentButtonStyle);
            }
        }
    }
}