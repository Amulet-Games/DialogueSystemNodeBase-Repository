using UnityEngine;
using UnityEngine.UIElements;

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
        /// <param name="details">The connecting creation details to set for.</param>
        /// <param name="graphViewer">Reference of the dialogue system's graph viewer module.</param>
        public EventNode
        (
            NodeCreationDetails details,
            GraphViewer graphViewer
        )
            : base(StringsConfig.EventNodeDefaultTitleText, graphViewer)
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
                EventNodeModel model = new();

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
                    minWidth: NodesConfig.EventNodeMinWidth,
                    widthBuffer: NodesConfig.EventNodeWidthBuffer
                );
            }

            void PostProcessNodePosition()
            {
                Presenter.PostProcessNodePosition(details);
            }

            void AddStyleSheet()
            {
                styleSheets.Add(StylesConfig.DSEventNodeStyle);
                styleSheets.Add(StylesConfig.DSModifiersStyle);
                styleSheets.Add(StylesConfig.DSSegmentsStyle);
                styleSheets.Add(StylesConfig.DSIntegrantsStyle);
                styleSheets.Add(StylesConfig.DSRootedModifiersStyle);
            }
        }


        // ----------------------------- Constructor (Load) -----------------------------
        /// <summary>
        /// Constructor of the event node component class.
        /// <para>Specifically used when the node is created by the previously saved data.</para>
        /// </summary>
        /// <param name="data">The given node data to load from.</param>
        /// <param name="graphViewer">Reference of the dialogue system's graph viewer module.</param>
        public EventNode
        (
            EventNodeData data,
            GraphViewer graphViewer
        )
            : base(StringsConfig.EventNodeDefaultTitleText, graphViewer)
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
                EventNodeModel model = new();

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
                    minWidth: NodesConfig.EventNodeMinWidth,
                    widthBuffer: NodesConfig.EventNodeWidthBuffer
                );
            }

            void AddStyleSheet()
            {
                styleSheets.Add(StylesConfig.DSEventNodeStyle);
                styleSheets.Add(StylesConfig.DSModifiersStyle);
                styleSheets.Add(StylesConfig.DSSegmentsStyle);
                styleSheets.Add(StylesConfig.DSIntegrantsStyle);
                styleSheets.Add(StylesConfig.DSRootedModifiersStyle);
            }
        }
    }
}