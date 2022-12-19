using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class PreviewNodePresenter : NodePresenterFrameBase
    <
        PreviewNode,
        PreviewNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------

        /// <summary>
        /// Constructor of the preview node presenter module class.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public PreviewNodePresenter(PreviewNode node, PreviewNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreateNodeElements()
        {
            base.CreateNodeElements();

            AddPortraitImages();

            AddSpriteObjectFields();

            void AddPortraitImages()
            {
                // New box container.
                var portraitImageElementsBox = new Box();
                portraitImageElementsBox.AddToClassList(StylesConfig.PreviewNode_ImagesBox);

                // New images.
                Model.LeftPortraitImage = ImageFactory.GetNewImage
                (
                    imageUSS01: StylesConfig.PreviewNode_Image,
                    imageUSS02: StylesConfig.PreviewNode_Image_L
                );

                Model.RightPortraitImage = ImageFactory.GetNewImage
                (
                    imageUSS01: StylesConfig.PreviewNode_Image,
                    imageUSS02: StylesConfig.PreviewNode_Image_R
                );

                // Add to box
                portraitImageElementsBox.Add(Model.LeftPortraitImage);
                portraitImageElementsBox.Add(Model.RightPortraitImage);

                // Add to node
                Node.mainContainer.Add(portraitImageElementsBox);
            }

            void AddSpriteObjectFields()
            {
                // New box container.
                var imageObjectFieldsBox = new Box();
                imageObjectFieldsBox.AddToClassList(StylesConfig.PreviewNode_ObjectFieldsBox);

                // New object fields.
                var leftSpriteField = ObjectFieldFactory.GetNewObjectField
                (
                    objectContainer: Model.LeftSpriteContainer,
                    containerValueChangedAction: LeftSpriteObjectContainerValueChangedAction,
                    fieldIcon: AssetsConfig.ImageFieldIconSprite,
                    fieldUSS01: StylesConfig.PreviewNode_ObjectField,
                    fieldUSS02: StylesConfig.PreviewNode_ObjectField_L
                );

                var rightSpriteField = ObjectFieldFactory.GetNewObjectField
                (
                    objectContainer: Model.RightSpriteContainer,
                    containerValueChangedAction: RightSpriteObjectContainerValueChangedAction,
                    fieldIcon: AssetsConfig.ImageFieldIconSprite,
                    fieldUSS01: StylesConfig.PreviewNode_ObjectField,
                    fieldUSS02: StylesConfig.PreviewNode_ObjectField_R
                );

                // Add to box
                imageObjectFieldsBox.Add(leftSpriteField);
                imageObjectFieldsBox.Add(rightSpriteField);

                // Add to node
                Node.mainContainer.Add(imageObjectFieldsBox);
            }
        }


        /// <inheritdoc />
        public override void CreateNodePorts()
        {
            // Input port.
            Model.InputPort = DefaultPort.CreateRootElements<Edge>
            (
                node: Node,
                direction: Direction.Input,
                capacity: Port.Capacity.Single,
                portlabel: StringsConfig.NodeInputLabelText,
                isSiblings: false
            );

            // Output port.
            Model.OutputPort = DefaultPort.CreateRootElements<Edge>
            (
                node: Node,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                portlabel: StringsConfig.NodeOutputLabelText,
                isSiblings: false
            );
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Action that invoked when the left sprite object container value is changed.
        /// </summary>
        void LeftSpriteObjectContainerValueChangedAction() =>
                ImageElementHelper.UpdateImagePreview
                    (sprite: Model.LeftSpriteContainer.Value, image: Model.LeftPortraitImage);


        /// <summary>
        /// Action that invoked when the right sprite object container value is changed.
        /// </summary>
        void RightSpriteObjectContainerValueChangedAction() =>
                ImageElementHelper.UpdateImagePreview
                    (sprite: Model.RightSpriteContainer.Value, image: Model.RightPortraitImage);


        // ----------------------------- Add Contextual Menu Items Services -----------------------------
        /// <inheritdoc />
        public override void AddContextualManuItems(ContextualMenuPopulateEvent evt)
        {
            bool isInputPortConnected;
            bool isOutputPortConnected;

            SetupLocalFields();

            AppendDisconnectInputPortAction();

            AppendDisconnectOuputPortAction();

            AppendDisconnectAllPortsAction();

            void SetupLocalFields()
            {
                isInputPortConnected = Model.InputPort.connected;
                isOutputPortConnected = Model.OutputPort.connected;
            }

            void AppendDisconnectInputPortAction()
            {
                Model.InputPort.AddContextualManuItems
                (
                    evt: evt,
                    itemName: StringsConfig.DisconnectInputPortLabelText
                );
            }

            void AppendDisconnectOuputPortAction()
            {
                Model.OutputPort.AddContextualManuItems
                (
                    evt: evt,
                    itemName: StringsConfig.DisconnectOutputPortLabelText
                );
            }

            void AppendDisconnectAllPortsAction()
            {
                // Disconnect All
                evt.menu.AppendAction
                (
                    actionName: StringsConfig.DisconnectAllPortLabelText,
                    action: actionEvent => DisconnectAllActionEvent(),
                    status: isInputPortConnected || isOutputPortConnected
                            ? DropdownMenuAction.Status.Normal
                            : DropdownMenuAction.Status.Disabled
                );

                void DisconnectAllActionEvent()
                {
                    // Disconnect Input port.
                    if (isInputPortConnected) Model.InputPort.DisconnectPort();
                    // Disconnect Ouput port.
                    if (isOutputPortConnected) Model.OutputPort.DisconnectPort();
                }
            }
        }
    }
}