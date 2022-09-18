using UnityEngine.UIElements;
using UnityEngine;

namespace AG
{
    /// <summary>
    /// Dialogue system node presenter's frame base class.
    /// </summary>
    /// <typeparam name="TNode">Node type</typeparam>
    /// <typeparam name="TNodeModel">Node model type</typeparam>
    public abstract class DSNodePresenterFrameBase<TNode, TNodeModel> 
        : DSNodePresenterBase
        where TNode : DSNodeBase
        where TNodeModel : DSNodeModelBase
    {
        /// <summary>
        /// Responsible for communicating with the other module classes,
        /// <br>and creating the frame base when it's first initialized.</br>
        /// </summary>
        protected TNode Node;


        /// <summary>
        /// Holds all the components and data that'll be used on the connecting node,
        /// <br>and allows other framework classes to utilize them for different purposes.</br>.
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
                    mainBox.AddToClassList(DSStylesConfig.Node_NodeTitle_MainBox);
                }

                void SetupTitleTextField()
                {
                    nodeTitleField = DSTextFieldsMaker.GetNewNodeTitleField(Model.NodeTitle_TextContainer, Node.title, DSStylesConfig.Node_NodeTitle_TextField);
                }

                void SetupEditTitleButton()
                {
                    Model.EditTitleButton = DSButtonsMaker.GetNewButtonNonAlert(DSAssetsConfig.EditNodeTitleButtonIconImage, ButtonClickedAction, DSStylesConfig.Node_EditTitle_Button);
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
        /// <para>ButtonClickedAction - DSButtonsMaker - EditTitleButton.</para>
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