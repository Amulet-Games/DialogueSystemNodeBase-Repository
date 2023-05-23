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
        /// <param name="details">The node create details to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public BooleanNode
        (
            NodeCreateDetails details,
            GraphViewer graphViewer
        )
            : base(StringConfig.Instance.BooleanNode_TitleText, graphViewer)
        {
            SetupFrameFields();

            CreateNodeElements();

            SetNodeWidth();

            SetNodePosition();

            AddStyleSheet();

            CreatedAction();

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

            void SetNodeWidth()
            {
                Presenter.SetNodeWidth
                (
                    minWidth: NodeConfig.BooleanNodeMinWidth,
                    widthBuffer: NodeConfig.BooleanNodeWidthBuffer
                );
            }

            void SetNodePosition()
            {
                Presenter.SetNodePosition(details);
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


        // ----------------------------- Constructor (New) -----------------------------
        /// <summary>
        /// Constructor of the boolean node component class.
        /// <para>Specifically used when the node is created by the previously saved data.</para>
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public BooleanNode
        (
            GraphViewer graphViewer
        )
            : base(StringConfig.Instance.BooleanNode_TitleText, graphViewer)
        {
            // Setup frame fields
            {
                Model = new(node: this);
                Presenter = new(node: this, model: Model);
                Serializer = new(node: this, model: Model);
                Callback = new(node: this, model: Model);
            }

            // Create elements
            {
                Presenter.CreateTitleElements();
                Presenter.CreatePortElements();
                Presenter.CreateContentElements();
            }

            // Setup node width
            {
                Presenter.SetNodeWidth
                (
                    minWidth: NodeConfig.BooleanNodeMinWidth,
                    widthBuffer: NodeConfig.BooleanNodeWidthBuffer
                );
            }

            // Add style sheet
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