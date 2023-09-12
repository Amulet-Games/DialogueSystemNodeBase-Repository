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
            PortContainer = new();
            InputContainer = new();
            OutputContainer = new();
            
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
        /// Setup the top container element.
        /// </summary>
        protected void SetupTopContainer()
        {
            RemoveUnusedElements();

            RepositionElement();

            SetupStyleClass();

            void RemoveUnusedElements()
            {
                topContainer.Clear();
            }

            void RepositionElement()
            {
                // Place the top container inside the node border.
                NodeBorder.Add(topContainer);
            }

            void SetupStyleClass()
            {
                topContainer.name = "";
                topContainer.AddToClassList(StyleConfig.Node_Top_Container);
            }
        }


        protected void SetupTitleContainer()
        {
            RemoveUnusedElements();

            RepositionElement();

            SetupDetail();

            SetupStyleClass();

            void RemoveUnusedElements()
            {
                titleContainer.Clear();
            }

            void RepositionElement()
            {
                // Place the title container inside the top container.
                topContainer.Add(titleContainer);
            }

            void SetupDetail()
            {
                topContainer.SetPickingMode(PickingMode.Position);
            }

            void SetupStyleClass()
            {
                titleContainer.name = "";
                titleContainer.AddToClassList(StyleConfig.Node_Title_Container);
            }
        }


        /// <summary>
        /// Setup the port container element.
        /// </summary>
        protected void SetupPortContainer()
        {
            RepositionElement();
            
            SetupStyleClass();

            void RepositionElement()
            {
                // Place the port container inside the node border.
                NodeBorder.Add(PortContainer);
            }

            void SetupStyleClass()
            {
                PortContainer.AddToClassList(StyleConfig.Node_Port_Container);
            }
        }


        /// <summary>
        /// Setup the input container element.
        /// </summary>
        protected void SetupInputContainer()
        {
            RepositionElement();

            SetupStyleClass();

            void RepositionElement()
            {
                // Place the input container inside the port container.
                PortContainer.Add(InputContainer);
            }

            void SetupStyleClass()
            {
                InputContainer.AddToClassList(StyleConfig.Node_Input_Container);
            }
        }


        /// <summary>
        /// Setup the output container element.
        /// </summary>
        protected void SetupOutputContainer()
        {
            Reposition();

            SetupStyleClass();

            void Reposition()
            {
                // Place the output container inside the port container.
                PortContainer.Add(OutputContainer);
            }

            void SetupStyleClass()
            {
                OutputContainer.AddToClassList(StyleConfig.Node_Output_Container);
            }
        }


        /// <summary>
        /// Setup the main container element.
        /// </summary>
        protected void SetupMainContainer()
        {
            // Setup detail
            mainContainer.SetPickingMode(PickingMode.Position);
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