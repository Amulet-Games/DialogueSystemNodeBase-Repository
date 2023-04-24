namespace AG.DS
{
    public class EventNode : NodeFrameBase
    <
        EventNode,
        EventNodeModel,
        EventNodePresenter,
        EventNodeSerializer,
        EventNodeCallback,
        EventNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the event node component class.
        /// </summary>
        /// <param name="details">The node creation details to set for.</param>
        /// <param name="graphViewer">The graph viewer module to set for.</param>
        public EventNode
        (
            NodeCreationDetails details,
            GraphViewer graphViewer
        )
            : base(StringConfig.Instance.EventNode_TitleText, graphViewer)
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
                    minWidth: NodeConfig.EventNodeMinWidth,
                    widthBuffer: NodeConfig.EventNodeWidthBuffer
                );
            }

            void PostProcessNodePosition()
            {
                Presenter.PostProcessNodePosition(details);
            }

            void AddStyleSheet()
            {
                var styleSheetConfig = ConfigResourcesManager.Instance.StyleSheetConfig;
                styleSheets.Add(styleSheetConfig.DSEventNodeStyle);
                styleSheets.Add(styleSheetConfig.DSContentButtonStyle);
                styleSheets.Add(styleSheetConfig.DSFolderStyle);
                styleSheets.Add(styleSheetConfig.DSEventModifierStyle);
                styleSheets.Add(styleSheetConfig.DSEventModifierGroupStyle);
            }
        }


        // ----------------------------- Constructor (Load) -----------------------------
        /// <summary>
        /// Constructor of the event node component class.
        /// <para>Specifically used when the node is created by the previously saved data.</para>
        /// </summary>
        /// <param name="data">The node data to load from.</param>
        /// <param name="graphViewer">The graph viewer module to set for.</param>
        public EventNode
        (
            EventNodeData data,
            GraphViewer graphViewer
        )
            : base(StringConfig.Instance.EventNode_TitleText, graphViewer)
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
                    minWidth: NodeConfig.EventNodeMinWidth,
                    widthBuffer: NodeConfig.EventNodeWidthBuffer
                );
            }

            void AddStyleSheet()
            {
                var styleSheetConfig = ConfigResourcesManager.Instance.StyleSheetConfig;
                styleSheets.Add(styleSheetConfig.DSEventNodeStyle);
                styleSheets.Add(styleSheetConfig.DSContentButtonStyle);
                styleSheets.Add(styleSheetConfig.DSFolderStyle);
                styleSheets.Add(styleSheetConfig.DSEventModifierStyle);
                styleSheets.Add(styleSheetConfig.DSEventModifierGroupStyle);
            }
        }
    }
}