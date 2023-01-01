/*
using System;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class DialogueSegment : SegmentFrameBase.Regular<DialogueSegmentData>
    {
        /// <summary>
        /// Enum container for the users to choose how many textline they want within a dialogue. 
        /// </summary>
        public TextlineNumberTypeEnumContainer TextlineNumberTypeEnumContainer;


        /// <summary>
        /// Object container for the dialogue system's character scriptable object.
        /// </summary>
        public ObjectContainer<DialogueCharacter> CharacterObjectContainer;


        /// <summary>
        /// Object container for the dialogue's audio.
        /// </summary>
        public LanguageAudioClipContainer AudioClipContainer;


        /// <summary>
        /// Text container for the first dialogue's textline.
        /// </summary>
        public LanguageTextContainer FirstTextlineTextContainer;


        /// <summary>
        /// Enum container for the users to choose how they want to trigger the second line of dialogue
        /// <br>within the same segment.</br>
        /// </summary>
        public SecondLineTriggerTypeEnumContainer SecondLineTriggerTypeEnumContainer;


        /// <summary>
        /// Text container for the second dialogue's textline.
        /// </summary>
        public LanguageTextContainer SecondTextlineTextContainer;


        /// <summary>
        /// Float container for the users to input the delta time duration that they want to wait
        /// <br>to trigger the second line of dialogue.</br>
        /// </summary>
        public FloatContainer DurationFloatContainer;


        /// <summary>
        /// CSV GUID.
        /// </summary>
        public string CsvGUID;


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
        /// Constructor of the dialogue segment component class.
        /// </summary>
        public DialogueSegment()
        {
            // Title
            TextlineNumberTypeEnumContainer = new();

            // First content
            CharacterObjectContainer = new();
            AudioClipContainer = new();
            FirstTextlineTextContainer = new();

            // Second content
            SecondLineTriggerTypeEnumContainer = new();
            DurationFloatContainer = new();
            SecondTextlineTextContainer = new();

            // CSV
            CsvGUID = Guid.NewGuid().ToString();
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreateRootElements(NodeBase node)
        {
            // Title
            Box titleBox;
            Label titleLabel;
            EnumField textlineNumberTypeEnumField;

            // First content box 
            ObjectField characterObjectField;
            ObjectField audioClipObjectField;
            TextField firstTextlineTextField;

            // Trigger type cell box
            Box secondLineTriggerTypeCellBox;
            Label secondLineTriggerTypeLabel;
            EnumField secondLineTriggerTypeEnumField;

            // Delta time duration cell box
            Label durationLabel;
            FloatField durationFloatField;

            // Second textline
            TextField secondTextlineTextField;

            SetupBoxContainer();

            SetupSegmentTitle();

            SetupTextlineNumberTypeEnumField();

            SetupSegmentExpandButton();

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
                titleBox = new();
                titleBox.AddToClassList(StylesConfig.Segment_Common_Title_Box);
                titleBox.AddToClassList(StylesConfig.Segment_Dialogue_Title_Box);

                ContentBox = new();
                ContentBox.AddToClassList(StylesConfig.Segment_Dialogue_Content_Box);

                secondContentBox = new();
                secondContentBox.AddToClassList(StylesConfig.Segment_Dialogue_SecondContent_Box);

                secondLineTriggerTypeCellBox = new();
                secondLineTriggerTypeCellBox.AddToClassList(StylesConfig.Segment_Dialogue_SecondLineTriggerType_Box);

                deltaTimeDurationCellBox = new();
                deltaTimeDurationCellBox.AddToClassList(StylesConfig.Segment_Dialogue_Duration_Box);
            }

            void SetupSegmentTitle()
            {
                titleLabel = LabelFactory.GetNewLabel
                (
                    labelText: StringsConfig.DialogueSegmentTitleLabelText,
                    labelUSS01: StylesConfig.Segment_Common_Title_Label
                );
            }

            void SetupSegmentExpandButton()
            {
                ExpandButton = ButtonFactory.GetNewButton
                (
                    isAlert: false,
                    buttonSprite: AssetsConfig.SegmentExpandButtonIconSprite,
                    buttonClickAction: SwitchSegmentIsExpanded,
                    buttonUSS01: StylesConfig.Segment_Common_ExpandSegment_Button
                );
            }

            void SetupTextlineNumberTypeEnumField()
            {
                textlineNumberTypeEnumField = EnumFieldFactory.GetNewEnumField
                (
                    enumContainer: TextlineNumberTypeEnumContainer,
                    containerValueChangedAction: TextlineNumberTypeEnumContainerValueChangedAction,
                    fieldUSS01: StylesConfig.Segment_Common_Title_EnumField
                );
            }

            void SetupCharacterObjectField()
            {
                characterObjectField = ObjectFieldFactory.GetNewObjectField
                (
                    objectContainer: CharacterObjectContainer,
                    fieldIcon: AssetsConfig.LanguageFieldHintIconSprite,
                    fieldUSS01: StylesConfig.Segment_Dialogue_Character_ObjectField
                );
            }

            void SetupAudioClipObjectField()
            {
                audioClipObjectField = LanguageFieldFactory.GetNewAudioClipField
                (
                    languageAudioClipContainer: AudioClipContainer,
                    fieldIcon: AssetsConfig.LanguageFieldHintIconSprite,
                    fieldUSS01: StylesConfig.Segment_Dialogue_AudioClip_ObjectField
                );
            }

            void SetupFirstTextlineTextField()
            {
                firstTextlineTextField = LanguageFieldFactory.GetNewTextField
                (
                    languageTextContainer: FirstTextlineTextContainer,
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
                    enumContainer: SecondLineTriggerTypeEnumContainer,
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
                    floatContainer: DurationFloatContainer,
                    fieldUSS01: StylesConfig.Segment_Dialogue_Duration_FloatField
                );
            }

            void SetupSecondTextlineTextField()
            {
                secondTextlineTextField = LanguageFieldFactory.GetNewTextField
                (
                    languageTextContainer: SecondTextlineTextContainer,
                    fieldIcon: AssetsConfig.LanguageFieldHintIconSprite,
                    isMultiLine: true,
                    placeholderText: StringsConfig.DialogueSegmentTextlinePlaceholderText,
                    fieldUSS01: StylesConfig.Segment_Dialogue_Second_Textline_TextField
                );
            }

            void AddFieldsToBox()
            {
                titleBox.Add(titleLabel);
                titleBox.Add(textlineNumberTypeEnumField);
                titleBox.Add(ExpandButton);

                ContentBox.Add(characterObjectField);
                ContentBox.Add(audioClipObjectField);
                ContentBox.Add(firstTextlineTextField);
                ContentBox.Add(secondContentBox);

                secondContentBox.Add(secondLineTriggerTypeCellBox);
                secondLineTriggerTypeCellBox.Add(secondLineTriggerTypeLabel);
                secondLineTriggerTypeCellBox.Add(secondLineTriggerTypeEnumField);

                secondContentBox.Add(deltaTimeDurationCellBox);
                deltaTimeDurationCellBox.Add(durationLabel);
                deltaTimeDurationCellBox.Add(durationFloatField);

                secondContentBox.Add(secondTextlineTextField);
            }

            void AddBoxToMainContainer()
            {
                node.mainContainer.Add(titleBox);
                node.mainContainer.Add(ContentBox);
            }

            void SegmentCreatedAction()
            {
                // Expand the segment.
                SwitchSegmentIsExpanded();

                // Update second content display.
                UpdateSecondContentBoxDisplay();

                // Update delta time duration display.
                UpdateDeltaTimeDurationBoxDisplay();
            }
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Action that invoked when the textline number type enum container value is changed.
        /// </summary>
        void TextlineNumberTypeEnumContainerValueChangedAction() => UpdateSecondContentBoxDisplay();


        /// <summary>
        /// Action that invoked when the second line trigger type enum container value is changed.
        /// </summary>
        void SecondLineTriggerTypeEnumContainerValueChangedAction() => UpdateDeltaTimeDurationBoxDisplay();


        // ----------------------------- Serialization -----------------------------
        /// <inheritdoc />
        public override void SaveSegmentValues(DialogueSegmentData data)
        {
            SaveTitleBoxContainer();

            SaveFirstContentBoxContainers();

            SaveSecondContentBoxContainers();

            Save_CSV_GUID();

            SaveIsExpanded();

            void SaveTitleBoxContainer()
            {
                // Textline number type enum.
                data.TextlineNumberTypeEnumIndex = TextlineNumberTypeEnumContainer.Value;
            }

            void SaveFirstContentBoxContainers()
            {
                // Character SO.
                data.DialogueCharacter = CharacterObjectContainer.Value;

                // Audio clip.
                AudioClipContainer.SaveContainerValue(data.AudioClipLanguageGeneric);

                // First textline text.
                FirstTextlineTextContainer.SaveContainerValue(data.FirstTextlineTextLanguageGeneric);
            }

            void SaveSecondContentBoxContainers()
            {
                // Second line trigger type enum.
                data.SecondLineTriggerTypeEnumIndex = SecondLineTriggerTypeEnumContainer.Value;

                // Duration float.
                data.DurationFloat = DurationFloatContainer.Value;

                // Second textline text.
                SecondTextlineTextContainer.SaveContainerValue(data.SecondTextlineTextLanguageGeneric);
            }

            void Save_CSV_GUID()
            {
                // CSV GUID.
                data.CsvGUID = CsvGUID;
            }
            
            void SaveIsExpanded()
            {
                // isExpanded.
                data.IsExpanded = IsExpanded;
            }
        }


        /// <inheritdoc />
        public override void LoadSegmentValues(DialogueSegmentData data)
        {
            LoadTitleBoxContainer();

            LoadFirstContentBoxContainers();

            LoadSecondContentBoxContainers();

            Load_CSV_Guid();

            LoadIsExpandedValue(data);

            SegmentLoadedAction();

            void LoadTitleBoxContainer()
            {
                // Textline number type enum.
                TextlineNumberTypeEnumContainer.LoadContainerValue(data.TextlineNumberTypeEnumIndex);
            }

            void LoadFirstContentBoxContainers()
            {
                // Character SO.
                CharacterObjectContainer.LoadContainerValue(data.DialogueCharacter);

                // Audio clip.
                AudioClipContainer.LoadContainerValue(data.AudioClipLanguageGeneric);

                // First textline text.
                FirstTextlineTextContainer.LoadContainerValue(data.FirstTextlineTextLanguageGeneric);
            }

            void LoadSecondContentBoxContainers()
            {
                // Second line trigger type enum.
                SecondLineTriggerTypeEnumContainer.LoadContainerValue(data.SecondLineTriggerTypeEnumIndex);

                // Duration float.
                DurationFloatContainer.LoadContainerValue(data.DurationFloat);

                // Second textline text.
                SecondTextlineTextContainer.LoadContainerValue(data.SecondTextlineTextLanguageGeneric);
            }

            void Load_CSV_Guid()
            {
                // CSV GUID.
                CsvGUID = data.CsvGUID;
            }

            void SegmentLoadedAction()
            {
                UpdateSecondContentBoxDisplay();

                UpdateDeltaTimeDurationBoxDisplay();
            }
        }


        // ----------------------------- Update Display Tasks -----------------------------
        /// <summary>
        /// Hide or show the segment's second content box when the textline number type is changed.
        /// </summary>
        void UpdateSecondContentBoxDisplay()
        {
            VisualElementHelper.UpdateElementDisplay
            (
                condition: TextlineNumberTypeEnumContainer.IsSingleTextlineNumberType(),
                element: secondContentBox
            );
        }


        /// <summary>
        /// Hide or show the segment's delta time duration box when the second line trigger type is changed.
        /// </summary>
        void UpdateDeltaTimeDurationBoxDisplay()
        {
            VisualElementHelper.UpdateElementDisplay
            (
                condition: SecondLineTriggerTypeEnumContainer.IsInputTriggerType(),
                element: deltaTimeDurationCellBox
            );
        }


        // ----------------------------- Update Language Fields Services -----------------------------
        /// <summary>
        /// Update the language specific fields to match the current selected language in editor.
        /// </summary>
        public void UpdateLanguageFields()
        {
            FirstTextlineTextContainer.UpdateLanguageField();
            AudioClipContainer.UpdateLanguageField();
        }
    }
}
*/