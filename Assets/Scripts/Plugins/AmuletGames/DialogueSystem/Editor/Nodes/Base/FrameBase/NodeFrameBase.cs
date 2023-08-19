using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public abstract class NodeFrameBase
    <
        TNode,
        TNodeView
    > 
        : NodeBase
        where TNode : NodeBase
        where TNodeView : NodeViewFrameBase<TNodeView>
    {
        /// <summary>
        /// Reference of the node view.
        /// </summary>
        public TNodeView View;


        /// <summary>
        /// Setup for the node frame base class.
        /// </summary>
        /// <param name="view">The node view to set for.</param>
        /// <param name="callback">The node callback to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public virtual TNode Setup
        (
            TNodeView view,
            INodeCallback callback,
            GraphViewer graphViewer
        )
        {
            View = view;
            Callback = callback;
            GraphViewer = graphViewer;
            NodeBorder = ElementAt(0);
            Guid = System.Guid.NewGuid();

            return null;
        }


        /// <summary>
        /// Setup the selection border element.
        /// </summary>
        protected void SetupSelectionBorder()
        {
            // Remove unused elements
            {
                // Remove #selection-border from the node.
                Remove(ElementAt(1));
            }
        }


        /// <summary>
        /// Setup the node border element.
        /// </summary>
        protected void SetupNodeBorder()
        {
            RemoveUnusedElements();

            SetupDetail();

            SetupStyleClass();

            void RemoveUnusedElements()
            {
                // Remove the #contents visual element.
                NodeBorder.Remove(NodeBorder.ElementAt(1));
            }

            void SetupDetail()
            {
                NodeBorder.style.overflow = Overflow.Visible;
                NodeBorder.focusable = true;
            }

            void SetupStyleClass()
            {
                NodeBorder.name = "";
                NodeBorder.AddToClassList(StyleConfig.Node_Border);
            }
        }


        /// <summary>
        /// Setup the title container element.
        /// </summary>
        protected void SetupTitleContainer()
        {
            RemoveUnusedElements();

            SetupDetail();

            SetupStyleClass();

            void RemoveUnusedElements()
            {
                // Remove #title-label.
                titleContainer.Remove(titleContainer.ElementAt(0));

                // Remove #title-button-container.
                titleContainer.Remove(titleContainer.ElementAt(0));
            }

            void SetupDetail()
            {
                titleContainer.SetPickingMode(PickingMode.Position);
            }

            void SetupStyleClass()
            {
                titleContainer.name = "";
                titleContainer.AddToClassList(StyleConfig.Node_Title_Container);
            }
        }


        /// <summary>
        /// Setup the top container element.
        /// </summary>
        protected void SetupTopContainer()
        {
            Reposition();

            RemoveUnusedElements();

            SetupStyleClass();

            void Reposition()
            {
                // Place the top container inside the node border.
                NodeBorder.Insert(index: 1, element: topContainer);
            }

            void RemoveUnusedElements()
            {
                // Remove the #divider visual element.
                topContainer.Remove(topContainer.ElementAt(1));
            }

            void SetupStyleClass()
            {
                topContainer.name = "";
                topContainer.AddToClassList(StyleConfig.Node_Top_Container);
            }
        }


        /// <summary>
        /// Setup the input container element.
        /// </summary>
        protected void SetupInputContainer()
        {
            // Setup style class
            {
                inputContainer.name = "";
                inputContainer.AddToClassList(StyleConfig.Node_Input_Container);
            }
        }


        /// <summary>
        /// Setup the output container element.
        /// </summary>
        protected void SetupOutputContainer()
        {
            // Setup style class
            {
                outputContainer.name = "";
                outputContainer.AddToClassList(StyleConfig.Node_Output_Container);
            }
        }


        /// <summary>
        /// Setup the main container element.
        /// </summary>
        protected void SetupMainContainer()
        {
            // Setup detail
            {
                mainContainer.SetPickingMode(PickingMode.Position);
            }
        }


        /// <summary>
        /// Setup the default style class.
        /// </summary>
        protected void SetupDefaultStyleClass()
        {
            ClearClassList();
            AddToClassList(StyleConfig.Node);
        }


        /// <summary>
        /// Setup the default style sheets.
        /// </summary>
        protected void SetupDefaultStyleSheets()
        {
            styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSGlobalStyle);
            styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSNodeCommonStyle);
        }
    }
}