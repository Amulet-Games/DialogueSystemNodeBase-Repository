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
        /// Reference of the node element.
        /// </summary>
        protected TNode Node;


        /// <summary>
        /// Reference of the node model.
        /// </summary>
        protected TNodeModel Model;


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Method for creating the node's title elements.
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
                nodeTitleContainer.AddToClassList(StyleConfig.Node_Title_Container);
            }

            void SetupTitleTextField()
            {
                Model.NodeTitleTextFieldModel.TextField = NodeTitleTextFieldPresenter.CreateElement
                (
                    titleText: Node.title,
                    fieldUSS01: StyleConfig.Node_Title_TextField
                );
            }

            void SetupEditTitleButton()
            {
                Model.EditTitleButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.EditButtonIconSprite,
                    buttonUSS01: StyleConfig.Node_EditTitle_Button
                );
            }

            void AddElementsToContainer()
            {
                // Node title field.
                nodeTitleContainer.Add(Model.NodeTitleTextFieldModel.TextField);

                // Edit title button.
                nodeTitleContainer.Add(Model.EditTitleButton);
            }

            void AddContainerToNode()
            {
                Node.titleContainer.Add(nodeTitleContainer);
            }
        }


        /// <summary>
        /// Method for creating the node's port elements.
        /// </summary>
        public virtual void CreatePortElements() { }


        /// <summary>
        /// Method for creating the node's content elements.
        /// </summary>
        public virtual void CreateContentElements() { }


        // ----------------------------- Set Node Position -----------------------------
        /// <summary>
        /// Set the node position base on the value from the details.
        /// </summary>
        /// <param name="details">The node create details to set for.</param>
        public void SetNodePosition(NodeCreateDetails details)
        {
            Node.RegisterCallback<GeometryChangedEvent>(GeometryChangedEvent);

            void GeometryChangedEvent(GeometryChangedEvent evt)
            {
                // Adjust the node's position after it's created.
                GeometryChangedAdjustNodePosition(details);

                // Unregister the action once the setup is done.
                Node.UnregisterCallback<GeometryChangedEvent>(GeometryChangedEvent);
            }
        }


        /// <summary>
        /// Adjust the node's position base on the value from the details.
        /// </summary>
        /// <param name="details">The node create details to set for.</param>
        protected abstract void GeometryChangedAdjustNodePosition(NodeCreateDetails details);
    }
}