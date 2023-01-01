using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class StoryNodePresenter : NodePresenterFrameBase
    <
        StoryNode,
        StoryNodeModel
    >
    {
        /// <summary>
        /// A box container that store all the visual elements related to the second textline content.
        /// </summary>
        Box secondContentBox;


        /// <summary>
        /// A box container that store all the visual elements related to the delta time trigger type and its duration.
        /// </summary>
        Box deltaTimeDurationCellBox;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the story node presenter module class.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public StoryNodePresenter(StoryNode node, StoryNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreateNodeElements()
        {
            // First content box 
            Box firstContentBox;
            ObjectField characterObjectField;
            ObjectField audioClipObjectField;
            TextField firstTextlineTextField;

            // Trigger type box
            Box secondLineTriggerTypeBox;
            Label secondLineTriggerTypeLabel;
            EnumField secondLineTriggerTypeEnumField;

            // Delta time duration cell box
            Label durationLabel;
            FloatField durationFloatField;

            // Second textline
            TextField secondTextlineTextField;

            base.CreateNodeElements();

            SetupBoxContainer();

            SetupCharacterObjectField();

            SetupAudioClipObjectField();

            SetupFirstTextlineTextField();

            SetupSecondLineTriggerTypeLabel();

            SetupSecondLineTriggerTypeEnumField();

            SetupDurationLabel();

            SetupDurationFloatField();

            SetupSecondTextlineTextField();

            AddFieldsToBox();

            AddBoxToMainContainer();

            SegmentCreatedAction();

            void SetupBoxContainer()
            {
                firstContentBox = new();
                firstContentBox.AddToClassList(StylesConfig.Segment_Dialogue_Content_Box);

                secondContentBox = new();
                secondContentBox.AddToClassList(StylesConfig.Segment_Dialogue_SecondContent_Box);

                secondLineTriggerTypeBox = new();
                secondLineTriggerTypeBox.AddToClassList(StylesConfig.Segment_Dialogue_SecondLineTriggerType_Box);

                deltaTimeDurationCellBox = new();
                deltaTimeDurationCellBox.AddToClassList(StylesConfig.Segment_Dialogue_Duration_Box);
            }

            void SetupCharacterObjectField()
            {
                characterObjectField = ObjectFieldFactory.GetNewObjectField
                (
                    objectContainer: Model.CharacterObjectContainer,
                    fieldIcon: AssetsConfig.LanguageFieldHintIconSprite,
                    fieldUSS01: StylesConfig.Segment_Dialogue_Character_ObjectField
                );
            }

            void SetupAudioClipObjectField()
            {
                audioClipObjectField = LanguageFieldFactory.GetNewAudioClipField
                (
                    languageAudioClipContainer: Model.AudioClipContainer,
                    fieldIcon: AssetsConfig.LanguageFieldHintIconSprite,
                    fieldUSS01: StylesConfig.Segment_Dialogue_AudioClip_ObjectField
                );
            }

            void SetupFirstTextlineTextField()
            {
                firstTextlineTextField = LanguageFieldFactory.GetNewTextField
                (
                    languageTextContainer: Model.FirstTextlineTextContainer,
                    fieldIcon: AssetsConfig.LanguageFieldHintIconSprite,
                    isMultiLine: true,
                    placeholderText: StringsConfig.DialogueSegmentTextlinePlaceholderText,
                    fieldUSS01: StylesConfig.Segment_Dialogue_First_Textline_TextField
                );
            }

            void SetupSecondLineTriggerTypeLabel()
            {
                secondLineTriggerTypeLabel = LabelFactory.GetNewLabel
                (
                    labelText: StringsConfig.SecondLineTriggerTypeLabelText,
                    labelUSS01: StylesConfig.Segment_Dialogue_SecondLineTriggerType_Label
                );
            }

            void SetupSecondLineTriggerTypeEnumField()
            {
                secondLineTriggerTypeEnumField = EnumFieldFactory.GetNewEnumField
                (
                    enumContainer: Model.SecondLineTriggerTypeEnumContainer,
                    containerValueChangedAction: SecondLineTriggerTypeEnumContainerValueChangedAction,
                    fieldUSS01: StylesConfig.Segment_Dialogue_SecondLineTriggerType_EnumField
                );
            }

            void SetupDurationLabel()
            {
                durationLabel = LabelFactory.GetNewLabel
                (
                    labelText: StringsConfig.DurationLabelText,
                    labelUSS01: StylesConfig.Segment_Dialogue_Duration_Label
                );
            }

            void SetupDurationFloatField()
            {
                durationFloatField = FloatFieldFactory.GetNewFloatField
                (
                    floatContainer: Model.DurationFloatContainer,
                    fieldUSS01: StylesConfig.Segment_Dialogue_Duration_FloatField
                );
            }

            void SetupSecondTextlineTextField()
            {
                secondTextlineTextField = LanguageFieldFactory.GetNewTextField
                (
                    languageTextContainer: Model.SecondTextlineTextContainer,
                    fieldIcon: AssetsConfig.LanguageFieldHintIconSprite,
                    isMultiLine: true,
                    placeholderText: StringsConfig.DialogueSegmentTextlinePlaceholderText,
                    fieldUSS01: StylesConfig.Segment_Dialogue_Second_Textline_TextField
                );
            }

            void AddFieldsToBox()
            {
                firstContentBox.Add(characterObjectField);
                firstContentBox.Add(audioClipObjectField);
                firstContentBox.Add(firstTextlineTextField);
                firstContentBox.Add(secondContentBox);

                secondContentBox.Add(secondLineTriggerTypeBox);
                secondLineTriggerTypeBox.Add(secondLineTriggerTypeLabel);
                secondLineTriggerTypeBox.Add(secondLineTriggerTypeEnumField);

                secondContentBox.Add(deltaTimeDurationCellBox);
                deltaTimeDurationCellBox.Add(durationLabel);
                deltaTimeDurationCellBox.Add(durationFloatField);

                secondContentBox.Add(secondTextlineTextField);
            }

            void AddBoxToMainContainer()
            {
                Node.mainContainer.Add(firstContentBox);
            }

            void SegmentCreatedAction()
            {
                // Update delta time duration display.
                UpdateDeltaTimeDurationBoxDisplay();
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

            // Refresh ports.
            Node.RefreshPorts();
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Action that invoked when the second line trigger type enum container value is changed.
        /// </summary>
        void SecondLineTriggerTypeEnumContainerValueChangedAction() => UpdateDeltaTimeDurationBoxDisplay();


        // ----------------------------- Update Display Tasks -----------------------------
        /// <summary>
        /// Hide or show the segment's delta time duration box when the second line trigger type is changed.
        /// </summary>
        void UpdateDeltaTimeDurationBoxDisplay()
        {
            VisualElementHelper.UpdateElementDisplay
            (
                condition: Model.SecondLineTriggerTypeEnumContainer.IsInputTriggerType(),
                element: deltaTimeDurationCellBox
            );
        }


        // ----------------------------- Add Contextual Menu Items Services -----------------------------
        /// <inheritdoc />
        public override void AddContextualManuItems(ContextualMenuPopulateEvent evt)
        {
        }


        // ----------------------------- Post Process Position Details Services -----------------------------
        /// <inheritdoc />
        protected override void PostProcessPositionDetails(NodeCreationDetails details)
        {
            AlignConnectorPosition();

            ConnectConnectorPort();

            ShowNodeOnGraph();

            void AlignConnectorPosition()
            {
                // Create a new vector2 result variable to cache the node's current local bound position.
                Vector2 result = Node.localBound.position;

                switch (details.HorizontalAlignType)
                {
                    case C_Alignment_HorizontalType.Left:

                        // Height offset.
                        result.y -= (Node.titleContainer.worldBound.height + Model.OutputPort.localBound.position.y + NodesConfig.ManualCreateYOffset) / Node.GraphViewer.scale;

                        // Width offset.
                        result.x -= Node.localBound.width;

                        break;
                    case C_Alignment_HorizontalType.Middle:

                        // Height offset.
                        result.y -= (Node.titleContainer.worldBound.height + Model.InputPort.localBound.position.y + NodesConfig.ManualCreateYOffset) / Node.GraphViewer.scale;

                        // Width offset.
                        result.x -= Node.localBound.width / 2;

                        break;
                    case C_Alignment_HorizontalType.Right:

                        // Height offset.
                        result.y -= (Node.titleContainer.worldBound.height + Model.InputPort.localBound.position.y + NodesConfig.ManualCreateYOffset) / Node.GraphViewer.scale;
                        break;
                }

                // Apply the final position result to the node.
                Node.SetPosition(newPos: new Rect(result, Vector2Utility.Zero));
            }

            void ConnectConnectorPort()
            {
                // If connnector port is null then return.
                if (details.ConnectorPort == null)
                    return;

                // Create local reference for the connector port.
                Port connectorPort = details.ConnectorPort;

                // If the connector port is connecting to another port, disconnect them first.
                if (connectorPort.connected)
                {
                    Node.GraphViewer.DisconnectPort(port: connectorPort);
                }

                // Connect the ports and retrieve the new edge.
                Edge edge;
                if (connectorPort.IsInput())
                {
                    edge = Node.GraphViewer.ConnectPorts
                           (
                               outputPort: Model.OutputPort,
                               inputPort: connectorPort
                           );
                }
                else
                {
                    edge = Node.GraphViewer.ConnectPorts
                           (
                               outputPort: connectorPort,
                               inputPort: Model.InputPort
                           );
                }

                // Register default edge callbacks to the edge.
                DefaultEdgeCallbacks.Register(edge: edge);
            }

            void ShowNodeOnGraph()
            {
                Node.RemoveFromClassList(StylesConfig.Global_Visible_Hidden);
            }
        }
    }
}