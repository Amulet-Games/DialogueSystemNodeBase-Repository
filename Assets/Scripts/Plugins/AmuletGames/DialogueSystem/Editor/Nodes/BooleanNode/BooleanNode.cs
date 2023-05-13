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
        /// Constructor of the boolean node component class.
        /// </summary>
        /// <param name="details">The node creation details to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public BooleanNode
        (
            NodeCreationDetails details,
            GraphViewer graphViewer
        )
            : base(StringConfig.Instance.BooleanNode_TitleText, graphViewer)
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
                    minWidth: NodeConfig.BooleanNodeMinWidth,
                    widthBuffer: NodeConfig.BooleanNodeWidthBuffer
                );
            }

            void PostProcessNodePosition()
            {
                Presenter.PostProcessNodePosition(details);
            }

            void AddStyleSheet()
            {
                var styleSheetConfig = ConfigResourcesManager.Instance.StyleSheetConfig;
                styleSheets.Add(styleSheetConfig.DSBooleanNodeStyle);
                styleSheets.Add(styleSheetConfig.DSModifierStyle);
                styleSheets.Add(styleSheetConfig.DSSegmentStyle);
                styleSheets.Add(styleSheetConfig.DSContentButtonStyle);
                styleSheets.Add(styleSheetConfig.DSRootedModifierStyle);
            }
        }


        // ----------------------------- Constructor (Load) -----------------------------
        /// <summary>
        /// Constructor of the boolean node component class.
        /// <para>Specifically used when the node is created by the previously saved data.</para>
        /// </summary>
        /// <param name="data">The node data to load from.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public BooleanNode
        (
            BooleanNodeData data,
            GraphViewer graphViewer
        )
            : base(StringConfig.Instance.BooleanNode_TitleText, graphViewer)
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
                    minWidth: NodeConfig.BooleanNodeMinWidth,
                    widthBuffer: NodeConfig.BooleanNodeWidthBuffer
                );
            }

            void AddStyleSheet()
            {
                var styleSheetConfig = ConfigResourcesManager.Instance.StyleSheetConfig;
                styleSheets.Add(styleSheetConfig.DSBooleanNodeStyle);
                styleSheets.Add(styleSheetConfig.DSModifierStyle);
                styleSheets.Add(styleSheetConfig.DSSegmentStyle);
                styleSheets.Add(styleSheetConfig.DSContentButtonStyle);
                styleSheets.Add(styleSheetConfig.DSRootedModifierStyle);
            }
        }
    }
}