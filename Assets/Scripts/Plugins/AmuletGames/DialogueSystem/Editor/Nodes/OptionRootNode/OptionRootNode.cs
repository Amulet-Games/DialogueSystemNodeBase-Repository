﻿namespace AG.DS
{
    public class OptionRootNode : NodeFrameBase
    <
        OptionRootNode,
        OptionRootNodeModel,
        OptionRootNodePresenter,
        OptionRootNodeSerializer,
        OptionRootNodeCallback,
        OptionRootNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option root node component class.
        /// </summary>
        /// <param name="details">The node creation details to set for.</param>
        /// <param name="graphViewer">The graph viewer module to set for.</param>
        public OptionRootNode
        (
            NodeCreationDetails details,
            GraphViewer graphViewer
        )
            : base(StringConfig.Instance.OptionRootNode_TitleText, graphViewer)
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
                    minWidth: NodeConfig.OptionRootNodeMinWidth,
                    widthBuffer: NodeConfig.OptionRootNodeWidthBuffer
                );
            }

            void PostProcessNodePosition()
            {
                Presenter.PostProcessNodePosition(details);
            }

            void AddStyleSheet()
            {
                var styleSheetConfig = ConfigResourcesManager.Instance.StyleSheetConfig;
                styleSheets.Add(styleSheetConfig.DSOptionRootNodeStyle);
                styleSheets.Add(styleSheetConfig.DSSegmentStyle);
                styleSheets.Add(styleSheetConfig.DSContentButtonStyle);
            }
        }


        // ----------------------------- Constructor (Load) -----------------------------
        /// <summary>
        /// Constructor of the option root node component class.
        /// <para>Specifically used when the node is created by the previously saved data.</para>
        /// </summary>
        /// <param name="data">The node data to load from.</param>
        /// <param name="graphViewer">The graph viewer module to set for.</param>
        public OptionRootNode
        (
            OptionRootNodeData data,
            GraphViewer graphViewer
        )
            : base(StringConfig.Instance.OptionRootNode_TitleText, graphViewer)
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
                    minWidth: NodeConfig.OptionRootNodeMinWidth,
                    widthBuffer: NodeConfig.OptionRootNodeWidthBuffer
                );
            }

            void AddStyleSheet()
            {
                var styleSheetConfig = ConfigResourcesManager.Instance.StyleSheetConfig;
                styleSheets.Add(styleSheetConfig.DSOptionRootNodeStyle);
                styleSheets.Add(styleSheetConfig.DSSegmentStyle);
                styleSheets.Add(styleSheetConfig.DSContentButtonStyle);
            }
        }
    }
}