using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    public abstract class NodeFrameBase
    <
        TNode,
        TNodeModel,
        TNodePresenter,
        TNodeSerializer,
        TNodeCallback,
        TNodeData
    > 
        : NodeBase
        where TNode : NodeBase
        where TNodeModel : NodeModelFrameBase<TNode>
        where TNodePresenter : NodePresenterFrameBase<TNode, TNodeModel>
        where TNodeSerializer : NodeSerializerFrameBase<TNode, TNodeModel, TNodeData>
        where TNodeCallback : NodeCallbackFrameBase<TNode, TNodeModel>
        where TNodeData : NodeDataBase
    {
        /// <summary>
        /// Reference of the model module.
        /// </summary>
        protected TNodeModel Model;


        /// <summary>
        /// Reference of the presenter module.
        /// </summary>
        protected TNodePresenter Presenter;


        /// <summary>
        /// Reference of the callback module.
        /// </summary>
        protected TNodeCallback Callback;


        /// <summary>
        /// Reference of the serializer module.
        /// </summary>
        public TNodeSerializer Serializer;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the node frame base class.
        /// </summary>
        /// <param name="nodeTitle">The node title to set for.</param>
        /// <param name="graphViewer">The graph viewer module to set for.</param>
        public NodeFrameBase
        (
            string nodeTitle,
            GraphViewer graphViewer
        )
        {
            SetupBaseFields();

            AddToGraph();

            AddStyleSheet();

            OverrideBorderDefaultStyle();

            OverrideContainersDefaultStyle();

            RemoveUnusedElements();

            AddCustomElements();

            void SetupBaseFields()
            {
                NodeGUID = Guid.NewGuid().ToString();

                title = nodeTitle;

                GraphViewer = graphViewer;
            }

            void AddToGraph()
            {
                GraphViewer.Add(this);
            }

            void AddStyleSheet()
            {
                var styleSheetConfig = ConfigResourcesManager.Instance.StyleSheetConfig;
                styleSheets.Add(styleSheetConfig.DSGlobalStyle);
                styleSheets.Add(styleSheetConfig.DSNodesShareStyle);
            }

            void OverrideBorderDefaultStyle()
            {
                // Get the node border from node's children.
                NodeBorder = ElementAt(0);

                // Brings the it to the front of any children element's under this nodes.
                NodeBorder.BringToFront();

                // Override default properties.
                NodeBorder.style.overflow = Overflow.Visible;
                NodeBorder.focusable = true;

                // Remove the default USS names and add to custom class.
                NodeBorder.name = "";
                NodeBorder.AddToClassList(StyleConfig.Instance.Node_Border);
            }

            void OverrideContainersDefaultStyle()
            {
                // Title Container
                titleContainer.pickingMode = PickingMode.Position;

                // Top Container
                NodeBorder.Insert(index: 1, element: topContainer);

                // Input Container
                inputContainer.name = "";
                inputContainer.AddToClassList(StyleConfig.Instance.Node_Input_Container);

                // Output Container
                outputContainer.name = "";
                outputContainer.AddToClassList(StyleConfig.Instance.Node_Output_Container);

                // Main Container
                mainContainer.pickingMode = PickingMode.Position;
            }

            void RemoveUnusedElements()
            {
                // Remove #selection-border from the node.
                Remove(ElementAt(0));

                // Remove #title-label from the title container.
                titleContainer.Remove(titleContainer.ElementAt(0));

                // Remove #title-button-container from the title container.
                titleContainer.Remove(titleContainer.ElementAt(0));

                // Remove the #divider visual element from the top container.
                topContainer.Remove(topContainer.ElementAt(1));

                // Remove the #contents visual element from the node's border
                NodeBorder.Remove(NodeBorder.ElementAt(2));
            }

            void AddCustomElements()
            {
                // Create a new Content Container and add to the node.
                ContentContainer = new();
                ContentContainer.AddToClassList(StyleConfig.Instance.Node_Content_Container);
                
                mainContainer.Add(ContentContainer);
            }
        }


        // ----------------------------- Action -----------------------------
        /// <inheritdoc />
        protected override void NodeCreatedAction()
        {
            Callback.RegisterEvents();
        }


        /// <inheritdoc />
        public override void PreManualRemoveAction()
        {
            Model.RemoveCachePortsAll();
            Model.DisconnectPortsAll();

            Callback.UnregisterEvents();
        }


        // ----------------------------- Serialization -----------------------------
        /// <inheritdoc />
        public override void Save(DialogueSystemData dsData) => Serializer.Save(dsData);


        // ----------------------------- Overrides -----------------------------
        /// <summary>
        /// Add menu items to the node contextual menu.
        /// <para>Read More https://docs.unity3d.com/ScriptReference/ContextMenu.html</para>
        /// </summary>
        /// <param name="evt">The event holding the menu to populate.</param>
        public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
        {
            Presenter.AddContextualMenuItems(evt);
            evt.menu.AppendSeparator();
        }
    }
}