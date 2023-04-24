using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public abstract class NodePresenterFrameBase
    <
        TNode,
        TNodeModel
    > 
        : NodePresenterBase
        where TNode : NodeBase
        where TNodeModel : NodeModelBase
    {
        /// <summary>
        /// Reference of the connecting node module.
        /// </summary>
        protected TNode Node;


        /// <summary>
        /// Reference of the connecting model module.
        /// </summary>
        protected TNodeModel Model;


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Method for creating the title elements of the connecting node.
        /// </summary>
        public void CreateTitleElements()
        {
            VisualElement nodeTitleContainer;

            SetupContainers();

            SetupTitleTextField();

            SetupEditTitleButton();

            AddElementsToContainer();

            AddContainerToNode();

            void SetupContainers()
            {
                nodeTitleContainer = new();
                nodeTitleContainer.AddToClassList(StyleConfig.Instance.Node_Title_Container);
            }

            void SetupTitleTextField()
            {
                Model.NodeTitleTextFieldModel.TextField = NodeTitleTextFieldPresenter.CreateElements
                (
                    titleText: Node.title,
                    fieldUSS01: StyleConfig.Instance.Node_Title_TextField
                );

                new NodeTitleTextFieldCallback(
                    model: Model.NodeTitleTextFieldModel).RegisterEvents();
            }

            void SetupEditTitleButton()
            {
                Model.EditTitleButton = CommonButtonPresenter.CreateElements
                (
                    buttonSprite: ConfigResourcesManager.Instance.SpriteConfig.EditButtonIconSprite,
                    buttonUSS01: StyleConfig.Instance.Node_EditTitle_Button
                );

                new CommonButtonCallback(
                    isAlert: false,
                    button: Model.EditTitleButton,
                    clickEvent: NodeTitleEditButtonClickEvent).RegisterEvents();
            }

            void AddElementsToContainer()
            {
                // Node title Field.
                nodeTitleContainer.Add(Model.NodeTitleTextFieldModel.TextField);

                // Edit node title button.
                nodeTitleContainer.Add(Model.EditTitleButton);
            }

            void AddContainerToNode()
            {
                Node.titleContainer.Add(nodeTitleContainer);
            }
        }


        /// <summary>
        /// Method for creating the port elements of the connecting node.
        /// </summary>
        public virtual void CreatePortElements() { }


        /// <summary>
        /// Create all the UIElements that exist within the connecting node.
        /// </summary>
        public virtual void CreateContentElements() { }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// The event to invoke when the node title edit button is clicked.
        /// </summary>
        /// <param name="evt">Registering event.</param>
        void NodeTitleEditButtonClickEvent(ClickEvent evt)
        {
            var nodeTitleField = Model.NodeTitleTextFieldModel.TextField;

            nodeTitleField.focusable = true;
            nodeTitleField.Focus();
        }


        // ----------------------------- Post Process Node Width -----------------------------
        /// <summary>
        /// Set the connecting node's minimum and maximum width value.
        /// </summary>
        /// <param name="minWidth">The minimum node's width to set for.</param>
        /// <param name="widthBuffer">The width buffer to to set for, combine it with the minimum width to get the node's maximum width.</param>
        public void PostProcessSetWidthValues(float minWidth, float widthBuffer)
        {
            SetWidthValueNode();

            SetWidthValueNodeTitleTextField();

            void SetWidthValueNode()
            {
                Node.style.minWidth = minWidth;
                Node.style.maxWidth = minWidth + widthBuffer;
            }

            void SetWidthValueNodeTitleTextField()
            {
                var nodeTitleField = Model.NodeTitleTextFieldModel.TextField;
                nodeTitleField.RegisterCallback<GeometryChangedEvent>(GeometryChangedEvent);

                void GeometryChangedEvent(GeometryChangedEvent evt)
                {
                    // Set the title field max width once it's fully created in the editor.
                    nodeTitleField.style.maxWidth = nodeTitleField.contentRect.width + widthBuffer;

                    // Unregister the action once the setup is done.
                    nodeTitleField.UnregisterCallback<GeometryChangedEvent>(GeometryChangedEvent);
                }
            }
        }


        // ----------------------------- Post Process Node Position -----------------------------
        /// <summary>
        /// Set the connecting node's first position base on the creation details.
        /// </summary>
        /// <param name="details">The connecting creation details to set for.</param>
        public void PostProcessNodePosition(NodeCreationDetails details)
        {
            SetNodePosition();

            TemporaryHideNode();

            PostProcessManualCreationProperties();

            void SetNodePosition()
            {
                Node.SetPosition(newPos: new Rect(details.CreatePosition, Vector2Utility.Zero));
            }

            void TemporaryHideNode()
            {
                Node.AddToClassList(StyleConfig.Instance.Global_Visible_Hidden);
            }

            void PostProcessManualCreationProperties()
            {
                Node.RegisterCallback<GeometryChangedEvent>(GeometryChangedEvent);

                void GeometryChangedEvent(GeometryChangedEvent evt)
                {
                    // Post process node position details.
                    PostProcessPositionDetails(details);

                    // Unregister the action once the setup is done.
                    Node.UnregisterCallback<GeometryChangedEvent>(GeometryChangedEvent);
                }
            }
        }


        /// <summary>
        /// Adjust the node's position for the second time base on the creation details.
        /// </summary>
        /// <param name="details">The node creation details to set for.</param>
        protected abstract void PostProcessPositionDetails(NodeCreationDetails details);
    }
}