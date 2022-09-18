using System;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG
{
    /// <summary>
    /// Dialogue system node's frame base class.
    /// </summary>
    /// <typeparam name="TNodePresenter">Node presenter type</typeparam>
    /// <typeparam name="TNodeSerializer">Node serializer type</typeparam>
    /// <typeparam name="TNodeCallback">Node callback type</typeparam>
    public abstract class DSNodeFrameBase<TNodePresenter, TNodeSerializer, TNodeCallback> 
        : DSNodeBase
        where TNodePresenter : DSNodePresenterBase
        where TNodeSerializer : DSNodeSerializerBase
        where TNodeCallback : DSNodeCallbackBase
    {
        /// <summary>
        /// Holds the methods for creating all the visual elements that are required for the node.
        /// <br>And methods that are require to have access to Model class.</br>
        /// </summary>
        public TNodePresenter Presenter;


        /// <summary>
        /// Responsible for serializing the node's data which are located in Model class.
        /// </summary>
        public TNodeSerializer Serializer;


        /// <summary>
        /// Holds the callback methods for the connecting node,
        /// <br>so that other static event classes can invoked them when the time comes.</br>
        /// </summary>
        public TNodeCallback Callback;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor for node's frame base class.
        /// </summary>
        /// <param name="nodeTitleText">The title label text for this node.</param>
        /// <param name="position">The vector2 position on the graph where this node'll be placed to once it's created.</param>
        /// <param name="graphView">Dialogue system's graph view module.</param>
        public DSNodeFrameBase(string nodeTitleText, Vector2 position, DSGraphView graphView)
        {
            SetupBaseFields();

            SetNodePosition();

            AddElementToGraph();

            AddStyleSheet();

            OverrideContainersDefaultStyle();

            OverrideBorderDefaultStyle();

            void SetupBaseFields()
            {
                // Set a new node GUID.
                NodeGuid = Guid.NewGuid().ToString();

                // Set default title.
                title = nodeTitleText;

                // Implement refs.
                GraphView = graphView;
            }

            void SetNodePosition()
            {
                // Move the node to the specificed location on the graph.
                SetPosition(new Rect(position, DSVector2Utility.Zero));
            }

            void AddElementToGraph()
            {
                GraphView.AddElement(this);
            }

            void AddStyleSheet()
            {
                // Setup the base node's USS styles.
                styleSheets.Add(DSStylesConfig.DSGlobalStyle);
                styleSheets.Add(DSStylesConfig.DSNodesShareStyle);
            }

            void OverrideContainersDefaultStyle()
            {
                // Override defualt picking mode.
                titleContainer.pickingMode = PickingMode.Position;
                mainContainer.pickingMode = PickingMode.Position;

                // Remove the default USS names.
                outputContainer.name = "";
                inputContainer.name = "";

                // Add to custom USS class.
                outputContainer.AddToClassList(DSStylesConfig.Node_Output_Container);
                inputContainer.AddToClassList(DSStylesConfig.Node_Input_Container);
            }

            void OverrideBorderDefaultStyle()
            {
                // Get the node border from node's children.
                VisualElement nodeBorder = ElementAt(0);

                // Brings the it to the front of any children element's under this nodes.
                nodeBorder.BringToFront();

                // Override default properties.
                nodeBorder.style.overflow = Overflow.Visible;
                nodeBorder.focusable = true;

                // Remove the default USS names and add to custom class.
                nodeBorder.name = "";
                nodeBorder.AddToClassList(DSStylesConfig.Node_Border);
            }
        }


        // ----------------------------- Callbacks -----------------------------
        /// <inheritdoc />
        public override void PreManualRemovedAction() => Callback.PreManualRemovedAction();


        /// <inheritdoc />
        public override void PostManualRemovedAction() => Callback.PostManualRemovedAction();


        /// <inheritdoc />
        public override void ManualCreatedAction(DSNodeCreationDetails creationDetails)
        {
            Presenter.CreationDetails = creationDetails;
            Callback.ManualCreatedAction();
        }


        // ----------------------------- Overrides -----------------------------
        /// <summary>
        /// Add menu items to the node contextual menu.
        /// <para>Read More https://docs.unity3d.com/ScriptReference/ContextMenu.html</para>
        /// </summary>
        /// <param name="evt">The event holding the menu to populate.</param>
        public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
        {
            // Add items that will execute an action in the drop-down menu. The items is added at the end of the current item list.
            evt.menu.AppendAction("Disconnect Input Port", actionEvent => DisconnectInputPorts(), Presenter.IsInputPortConnected() ? DropdownMenuAction.Status.Normal : DropdownMenuAction.Status.Disabled);
            evt.menu.AppendAction("Disconnect Output Port", actionEvent => DisconnectOutputPorts(), Presenter.IsOutputPortConnected() ? DropdownMenuAction.Status.Normal : DropdownMenuAction.Status.Disabled);

            base.BuildContextualMenu(evt);
        }


        // ----------------------------- Setup New Manual Created Node Services -----------------------------
        /// <summary>
        /// Setup for the node after it's created on the graph manually, which is mainly adjusting its position and
        /// <br>connecting it to a connector port if there's one.</br>
        /// </summary>
        public void SetupNewManualCreatedNode()
        {
            HideNodeFromGraph();

            NodeManualCreationPreSetupAction();

            // Apply a few frames of delay to let any UI / graph elements fully setup.
            EditorApplication.delayCall += () =>
            {
                if (double.IsNaN(localBound.height))
                {
                    schedule.Execute(_ =>
                    {
                        NodeManualCreationSetupAction();
                        ShowNodeOnGraph();
                    });
                }
                else
                {
                    NodeManualCreationSetupAction();
                    ShowNodeOnGraph();
                }
            };

            void HideNodeFromGraph()
            {
                AddToClassList(DSStylesConfig.DSGlobal_Visible_Hidden);
            }

            void NodeManualCreationPreSetupAction()
            {
                Presenter.NodeManualCreationPreSetupAction();
            }

            void NodeManualCreationSetupAction()
            {
                Presenter.NodeManualCreationSetupAction();
            }

            void ShowNodeOnGraph()
            {
                // Remove the node from hidden class
                RemoveFromClassList(DSStylesConfig.DSGlobal_Visible_Hidden);
            }
        }
    }
}