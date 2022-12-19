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
                    mainBox = new Box();
                    mainBox.AddToClassList(StylesConfig.Node_NodeTitle_MainBox);
                }

                void SetupTitleTextField()
                {
                    nodeTitleField = TextFieldFactory.GetNewNodeTitleField
                    (
                        textContainer: Model.NodeTitle_TextContainer,
                        currentTitleText: Node.title,
                        fieldUSS01: StylesConfig.Node_NodeTitle_TextField
                    );
                }

                void SetupEditTitleButton()
                {
                    Model.EditTitleButton = ButtonFactory.GetNewButton
                    (
                        isAlert: false,
                        btnSprite: AssetsConfig.NodeTitleEditButtonIconSprite,
                        btnPressedAction: ButtonClickedAction,
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
        public virtual void CreateNodePorts() { }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Action that invoked after the node title edit button is pressed.
        /// <para>ButtonClickedAction - ButtonsMaker - EditTitleButton.</para>
        /// </summary>
        void ButtonClickedAction()
        {
            TextField nodeTitleField = Model.NodeTitle_TextContainer.TextField;

            // Set focusable to true so that it'll trigger FocusInEvent later.
            nodeTitleField.focusable = true;

            // Focus on the node title field.
            nodeTitleField.Focus();
        }
    }
}