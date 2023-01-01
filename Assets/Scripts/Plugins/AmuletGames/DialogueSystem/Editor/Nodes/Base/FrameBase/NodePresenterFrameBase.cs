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
        /// Create all the UIElements that exist within the connecting node.
        /// </summary>
        public virtual void CreateNodeElements()
        {
            SetupNodeTitleSection();

            void SetupNodeTitleSection()
            {
                Box mainBox;

                TextField nodeTitleField;

                ConnectModelElementsToLocalRefs();

                SetupTitleMainBox();

                SetupTitleTextField();

                SetupEditTitleButton();

                AddElementsToBox();

                AddBoxToTitleContainer();

                void ConnectModelElementsToLocalRefs()
                {
                    mainBox = Model.TitleMainBox;
                }

                void SetupTitleMainBox()
                {
                    mainBox = new();
                    mainBox.AddToClassList(StylesConfig.Node_NodeTitle_Main_Box);
                }

                void SetupTitleTextField()
                {
                    nodeTitleField = TextFieldFactory.GetNewDelayableTextField
                    (
                        textContainer: Model.NodeTitleTextContainer,
                        defaultText: Node.title,
                        fieldUSS01: StylesConfig.Node_NodeTitle_TextField
                    );
                }

                void SetupEditTitleButton()
                {
                    Model.EditTitleButton = ButtonFactory.GetNewButton
                    (
                        isAlert: false,
                        buttonSprite: AssetsConfig.NodeTitleEditButtonIconSprite,
                        buttonClickAction: NodeTitleEditButtonClickAction,
                        buttonUSS01: StylesConfig.Node_EditTitle_Button
                    );
                }

                void AddElementsToBox()
                {
                    // Node title Field.
                    mainBox.Add(nodeTitleField);

                    // Edit node title button.
                    mainBox.Add(Model.EditTitleButton);
                }

                void AddBoxToTitleContainer()
                {
                    Node.titleContainer.Add(mainBox);
                }
            }
        }


        /// <summary>
        /// Create all the ports that exist within the connecting node.
        /// </summary>
        public abstract void CreateNodePorts();


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// The action to invoke when the node title edit button is clicked.
        /// <para>See: <see cref="CreateNodeElements"/></para>
        /// </summary>
        void NodeTitleEditButtonClickAction()
        {
            TextField nodeTitleField = Model.NodeTitleTextContainer.TextField;

            // Set focusable to true so that it'll trigger FocusInEvent later.
            nodeTitleField.focusable = true;

            // Focus on the node title field.
            nodeTitleField.Focus();
        }


        // ----------------------------- Post Process Node Width Services -----------------------------
        /// <summary>
        /// Set the connecting node's minimum and maximum width value.
        /// </summary>
        /// <param name="minWidth">The minimum node's width to set for.</param>
        /// <param name="widthBuffer">The width buffer to to set for, combine it with the minimum width to get the node's maximum width.</param>
        public void PostProcessNodeWidth(float minWidth, float widthBuffer)
        {
            SetNodeMinWidth();

            SetMaxWidthProperties();

            void SetNodeMinWidth()
            {
                // Set the node min width.
                Node.style.minWidth = minWidth;
            }

            void SetMaxWidthProperties()
            {
                // Set the node max width.
                Node.style.maxWidth = minWidth + widthBuffer;

                TextField nodeTitleField = Model.NodeTitleTextContainer.TextField;
                nodeTitleField.RegisterCallback<GeometryChangedEvent>(GeometryChangedAction);

                void GeometryChangedAction(GeometryChangedEvent evt)
                {
                    // Set the title field max width once it's fully created in the editor.
                    nodeTitleField.style.maxWidth =
                        nodeTitleField.contentRect.width + widthBuffer;

                    // Unregister the action once the setup is done.
                    nodeTitleField.UnregisterCallback<GeometryChangedEvent>(GeometryChangedAction);
                }
            }
        }


        // ----------------------------- Post Process Node Position Services -----------------------------
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
                Node.SetPosition(newPos: new Rect(details.PlacePosition, Vector2Utility.Zero));
            }

            void TemporaryHideNode()
            {
                Node.AddToClassList(StylesConfig.Global_Visible_Hidden);
            }

            void PostProcessManualCreationProperties()
            {
                Node.RegisterCallback<GeometryChangedEvent>(GeometryChangedAction);

                void GeometryChangedAction(GeometryChangedEvent evt)
                {
                    // Post process node position details.
                    PostProcessPositionDetails(details);

                    // Unregister the action once the setup is done.
                    Node.UnregisterCallback<GeometryChangedEvent>(GeometryChangedAction);
                }
            }
        }


        /// <summary>
        /// Adjust the node's position for the second time base on the creation details.
        /// </summary>
        /// <param name="details">The connecting creation details to set for.</param>
        protected abstract void PostProcessPositionDetails(NodeCreationDetails details);
    }
}