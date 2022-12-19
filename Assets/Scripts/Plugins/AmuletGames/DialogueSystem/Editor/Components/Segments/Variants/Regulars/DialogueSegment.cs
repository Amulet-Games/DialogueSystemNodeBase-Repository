using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class DialogueSegment : SegmentFrameBase.Regular<DialogueSegmentData>
    {
        /// <summary>
        /// Enum container for the users to choose how many textline they want within a dialogue. 
        /// </summary>
        [SerializeField] TextlineNumberTypeEnumContainer textlineNumberTypeEnumContainer;


        /// <summary>
        /// Object container for the dialogue system's character scriptable object.
        /// </summary>
        [SerializeField] ObjectContainer<DialogueCharacter> characterObjectContainer;


        /// <summary>
        /// Object container for the dialogue's audio.
        /// </summary>
        [SerializeField] LanguageAudioClipContainer audioClipContainer;


        /// <summary>
        /// Text container for the first dialogue's textline.
        /// </summary>
        [SerializeField] LanguageTextContainer firstTextlineTextContainer;


        /// <summary>
        /// Enum container for the users to choose how they want to trigger the second line of dialogue
        /// <br>within the same segment.</br>
        /// </summary>
        [SerializeField] SecondLineTriggerTypeEnumContainer secondLineTriggerTypeEnumContainer;


        /// <summary>
        /// Text container for the second dialogue's textline.
        /// </summary>
        [SerializeField] LanguageTextContainer secondTextlineTextContainer;


        /// <summary>
        /// Float container for the users to input the delta time duration that they want to wait
        /// <br>to trigger the second line of dialogue.</br>
        /// </summary>
        [SerializeField] FloatContainer durationFloatContainer;


        /// <summary>
        /// CSV GUID.
        /// </summary>
        [SerializeField] string csvGUID;


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
            textlineNumberTypeEnumContainer = new();

            // First content
            characterObjectContainer = new();
            audioClipContainer = new();
            firstTextlineTextContainer = new();

            // Second content
            secondLineTriggerTypeEnumContainer = new();
            durationFloatContainer = new();
            secondTextlineTextContainer = new();

            // CSV
            csvGUID = Guid.NewGuid().ToString();
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void SetupSegment(NodeBase node)
        {
            Box segmentTitleBox;

            // Title
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

            ExpandSegementUponCreated();

            ToggleDisplaysUponCreated();

            void SetupBoxContainer()
            {
                ContentBox = new Box();
                ContentBox.AddToClassList(StylesConfig.Segment_Dialogue_ContentBox);

                secondContentBox = new Box();
                secondContentBox.AddToClassList(StylesConfig.Segment_Dialogue_SecondContentBox);

                secondLineTriggerTypeCellBox = new Box();
                secondLineTriggerTypeCellBox.AddToClassList(StylesConfig.Segment_Dialogue_SecondLineTriggerType_CellBox);

                deltaTimeDurationCellBox = new Box();
                deltaTimeDurationCellBox.AddToClassList(StylesConfig.Segment_Dialogue_Duration_CellBox);
            }

            void SetupSegmentTitle()
            {
                segmentTitleBox = SegmentFactory.AddSegmentTitle
                (
                    titleText: StringsConfig.DialogueSegmentTitleLabelText,
                    titleBoxUSS01: StylesConfig.Segment_TitleBox_Dialogue
                );
            }

            void SetupSegmentExpandButton()
            {
                ExpandButton = SegmentFactory.AddSegmentExpandButton
                (
                    action: SwitchSegmentIsExpanded
                );
            }

            void SetupTextlineNumberTypeEnumField()
            {
                textlineNumberTypeEnumField = EnumFieldFactory.GetNewEnumField
                (
                    enumContainer: textlineNumberTypeEnumContainer,
                    containerValueChangedAction: TextlineNumberTypeEnumContainerValueChangedAction,
                    fieldUSS01: StylesConfig.Segment_TitleEnum_EnumField
                );
            }

            void SetupCharacterObjectField()
            {
                characterObjectField = ObjectFieldFactory.GetNewObjectField
                (
                    objectContainer: characterObjectContainer,
                    fieldIcon: AssetsConfig.LanguageFieldHintIconSprite,
                    fieldUSS01: StylesConfig.Segment_Dialogue_Character_ObjectField
                );
            }

            void SetupAudioClipObjectField()
            {
                audioClipObjectField = LanguageFieldFactory.GetNewAudioClipField
                (
                    languageAudioClipContainer: audioClipContainer,
                    fieldIcon: AssetsConfig.LanguageFieldHintIconSprite,
                    fieldUSS01: StylesConfig.Segment_Dialogue_AudioClip_ObjectField
                );
            }

            void SetupFirstTextlineTextField()
            {
                firstTextlineTextField = LanguageFieldFactory.GetNewTextField
                (
                    languageTextContainer: firstTextlineTextContainer,
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
                    enumContainer: secondLineTriggerTypeEnumContainer,
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
                    floatContainer: durationFloatContainer,
                    fieldUSS01: StylesConfig.Segment_Dialogue_Duration_FloatField
                );
            }

            void SetupSecondTextlineTextField()
            {
                secondTextlineTextField = LanguageFieldFactory.GetNewTextField
                (
                    languageTextContainer: secondTextlineTextContainer,
                    fieldIcon: AssetsConfig.LanguageFieldHintIconSprite,
                    isMultiLine: true,
                    placeholderText: StringsConfig.DialogueSegmentTextlinePlaceholderText,
                    fieldUSS01: StylesConfig.Segment_Dialogue_Second_Textline_TextField
                );
            }

            void AddFieldsToBox()
            {
                segmentTitleBox.Add(textlineNumberTypeEnumField);
                segmentTitleBox.Add(ExpandButton);

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
                node.mainContainer.Add(segmentTitleBox);
                node.mainContainer.Add(ContentBox);
            }

            void ExpandSegementUponCreated()
            {
                SwitchSegmentIsExpanded();
            }

            void ToggleDisplaysUponCreated()
            {
                ToggleSecondContentBoxDisplay();

                ToggleDeltaTimeDurationCellBoxDisplay();
            }
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Action that invoked when the textline number type enum container value is changed.
        /// </summary>
        void TextlineNumberTypeEnumContainerValueChangedAction() => ToggleSecondContentBoxDisplay();


        /// <summary>
        /// Action that invoked when the second line trigger type enum container value is changed.
        /// </summary>
        void SecondLineTriggerTypeEnumContainerValueChangedAction() => ToggleDeltaTimeDurationCellBoxDisplay();


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
                data.TextlineNumberTypeEnumIndex = textlineNumberTypeEnumContainer.Value;
            }

            void SaveFirstContentBoxContainers()
            {
                // Character SO.
                data.DialogueCharacter = characterObjectContainer.Value;

                // Audio clip.
                audioClipContainer.SaveContainerValue(data.AudioClipLanguageGeneric);

                // First textline text.
                firstTextlineTextContainer.SaveContainerValue(data.FirstTextlineTextLanguageGeneric);
            }

            void SaveSecondContentBoxContainers()
            {
                // Second line trigger type enum.
                data.SecondLineTriggerTypeEnumIndex = secondLineTriggerTypeEnumContainer.Value;

                // Duration float.
                data.DurationFloat = durationFloatContainer.Value;

                // Second textline text.
                secondTextlineTextContainer.SaveContainerValue(data.SecondTextlineTextLanguageGeneric);
            }

            void Save_CSV_GUID()
            {
                // CSV GUID.
                data.CsvGUID = csvGUID;
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

            ToggleDisplayUponLoaded();

            void LoadTitleBoxContainer()
            {
                // Textline number type enum.
                textlineNumberTypeEnumContainer.LoadContainerValue(data.TextlineNumberTypeEnumIndex);
            }

            void LoadFirstContentBoxContainers()
            {
                // Character SO.
                characterObjectContainer.LoadContainerValue(data.DialogueCharacter);

                // Audio clip.
                audioClipContainer.LoadContainerValue(data.AudioClipLanguageGeneric);

                // First textline text.
                firstTextlineTextContainer.LoadContainerValue(data.FirstTextlineTextLanguageGeneric);
            }

            void LoadSecondContentBoxContainers()
            {
                // Second line trigger type enum.
                secondLineTriggerTypeEnumContainer.LoadContainerValue(data.SecondLineTriggerTypeEnumIndex);

                // Duration float.
                durationFloatContainer.LoadContainerValue(data.DurationFloat);

                // Second textline text.
                secondTextlineTextContainer.LoadContainerValue(data.SecondTextlineTextLanguageGeneric);
            }

            void Load_CSV_Guid()
            {
                // CSV GUID.
                csvGUID = data.CsvGUID;
            }

            void ToggleDisplayUponLoaded()
            {
                ToggleSecondContentBoxDisplay();

                ToggleDeltaTimeDurationCellBoxDisplay();
            }
        }


        // ----------------------------- Toggle Display Tasks -----------------------------
        /// <summary>
        /// Hide or show the segment's second content box when the textline number type is changed.
        /// </summary>
        void ToggleSecondContentBoxDisplay()
        {
            VisualElementHelper.ToggleElementDisplay
            (
                condition: textlineNumberTypeEnumContainer.IsSingleTextlineNumberType(),
                element: secondContentBox
            );
        }


        /// <summary>
        /// Hide or show the segment's delta time duration cell box when the second line trigger type is changed.
        /// </summary>
        void ToggleDeltaTimeDurationCellBoxDisplay()
        {
            VisualElementHelper.ToggleElementDisplay
            (
                condition: secondLineTriggerTypeEnumContainer.IsInputTriggerType(),
                element: deltaTimeDurationCellBox
            );
        }


        // ----------------------------- Update Language Fields Services -----------------------------
        /// <summary>
        /// Update the language specific fields to match the current selected language in editor.
        /// </summary>
        public void UpdateLanguageFields()
        {
            firstTextlineTextContainer.UpdateLanguageField();
            audioClipContainer.UpdateLanguageField();
        }
    }
}