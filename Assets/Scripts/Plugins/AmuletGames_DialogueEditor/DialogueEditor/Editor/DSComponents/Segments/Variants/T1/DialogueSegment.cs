using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG
{
    [Serializable]
    public class DialogueSegment : DSSegmentFrameBase.T1<DialogueSegment>
    {
        /// <summary>
        /// Enum container for the users to choose how many textline they want within a dialogue. 
        /// </summary>
        [SerializeField] TextlineNumberTypeEnumContainer textlineNumberTypeEnumContainer;


        /// <summary>
        /// Object container for the dialogue system's character scriptable object.
        /// </summary>
        [SerializeField] DSObjectContainer<DSCharacter> characterObjectContainer;


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
        /// CSV Guid
        /// </summary>
        [SerializeField] string csvGuid;


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
        /// Constructor of dialogue segment
        /// </summary>
        public DialogueSegment()
        {
            SetupTitleBoxContainers();

            SetupFirstContentBoxContainers();

            SetupSecondContentBoxContainers();

            SetupCSVGuid();

            void SetupTitleBoxContainers()
            {
                textlineNumberTypeEnumContainer = new TextlineNumberTypeEnumContainer();
            }

            void SetupFirstContentBoxContainers()
            {
                characterObjectContainer = new DSObjectContainer<DSCharacter>();
                audioClipContainer = new LanguageAudioClipContainer();
                firstTextlineTextContainer = new LanguageTextContainer();
            }

            void SetupSecondContentBoxContainers()
            {
                secondLineTriggerTypeEnumContainer = new SecondLineTriggerTypeEnumContainer();
                durationFloatContainer = new FloatContainer();
                secondTextlineTextContainer = new LanguageTextContainer();
            }

            void SetupCSVGuid()
            {
                csvGuid = Guid.NewGuid().ToString();
            }
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void SetupSegment(DSNodeBase node)
        {
            Box segmentTitleBox;

            // Title
            EnumField textlineNumberTypeEnumField;

            // First Content Box 
            ObjectField characterObjectField;
            ObjectField audioClipObjectField;
            TextField firstTextlineTextField;

            // Trigger Type Cell Box
            Box secondLineTriggerTypeCellBox;
            Label secondLineTriggerTypeLabel;
            EnumField secondLineTriggerTypeEnumField;

            // Delta Time Duration Cell Box
            Label durationLabel;
            FloatField durationFloatField;

            // Second Textline
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
                ContentBox.AddToClassList(DSStylesConfig.Segment_Dialogue_ContentBox);

                secondContentBox = new Box();
                secondContentBox.AddToClassList(DSStylesConfig.Segment_Dialogue_SecondContentBox);

                secondLineTriggerTypeCellBox = new Box();
                secondLineTriggerTypeCellBox.AddToClassList(DSStylesConfig.Segment_Dialogue_SecondLineTriggerType_CellBox);

                deltaTimeDurationCellBox = new Box();
                deltaTimeDurationCellBox.AddToClassList(DSStylesConfig.Segment_Dialogue_Duration_CellBox);
            }

            void SetupSegmentTitle()
            {
                segmentTitleBox = DSSegmentsMaker.AddSegmentTitle
                (
                    DSStringsConfig.DialogueSegmentTitleLabelText,
                    DSStylesConfig.Segment_TitleBox_Dialogue
                );
            }

            void SetupSegmentExpandButton()
            {
                ExpandButton = DSSegmentsMaker.AddSegmentExpandButton(SwitchSegmentIsExpanded);
            }

            void SetupTextlineNumberTypeEnumField()
            {
                textlineNumberTypeEnumField = DSEnumFieldsMaker.GetNewEnumField
                (
                    textlineNumberTypeEnumContainer,
                    TextlineNumberTypeEnumFieldValueChangedAction,
                    DSStylesConfig.Segment_TitleEnum_EnumField
                );
            }

            void SetupCharacterObjectField()
            {
                characterObjectField = DSObjectFieldsMaker.GetNewObjectField
                (
                    characterObjectContainer,
                    DSAssetsConfig.InputHintIconSprite,
                    DSStylesConfig.Segment_Dialogue_Character_ObjectField
                );
            }

            void SetupAudioClipObjectField()
            {
                audioClipObjectField = DSLanguageFieldsMaker.GetNewAudioClipField
                (
                    audioClipContainer,
                    DSAssetsConfig.InputHintIconSprite,
                    DSStylesConfig.Segment_Dialogue_AudioClip_ObjectField
                );
            }

            void SetupFirstTextlineTextField()
            {
                firstTextlineTextField = DSLanguageFieldsMaker.GetNewTextField
                (
                    firstTextlineTextContainer,
                    DSAssetsConfig.InputHintIconSprite,
                    true,
                    DSStringsConfig.DialogueSegmentTextlinePlaceHolderText,
                    DSStylesConfig.Segment_Dialogue_First_Textline_TextField
                );
            }

            void SetupSecondLineTriggerTypeLabel()
            {
                secondLineTriggerTypeLabel = DSLabelsMaker.GetNewLabel
                (
                    DSStringsConfig.SecondLineTriggerTypeLabelText,
                    DSStylesConfig.Segment_Dialogue_SecondLineTriggerType_Label
                );
            }

            void SetupSecondLineTriggerTypeEnumField()
            {
                secondLineTriggerTypeEnumField = DSEnumFieldsMaker.GetNewEnumField
                (
                    secondLineTriggerTypeEnumContainer,
                    SecondLineTriggerTypeEnumFieldValueChangedAction,
                    DSStylesConfig.Segment_Dialogue_SecondLineTriggerType_EnumField
                );
            }

            void SetupDurationLabel()
            {
                durationLabel = DSLabelsMaker.GetNewLabel
                (
                    DSStringsConfig.DurationLabelText,
                    DSStylesConfig.Segment_Dialogue_Duration_Label
                );
            }

            void SetupDurationFloatField()
            {
                durationFloatField = DSFloatFieldsMaker.GetNewFloatField
                (
                    durationFloatContainer,
                    DSStylesConfig.Segment_Dialogue_Duration_FloatField
                );
            }

            void SetupSecondTextlineTextField()
            {
                secondTextlineTextField = DSLanguageFieldsMaker.GetNewTextField
                (
                    secondTextlineTextContainer,
                    DSAssetsConfig.InputHintIconSprite,
                    true,
                    DSStringsConfig.DialogueSegmentTextlinePlaceHolderText,
                    DSStylesConfig.Segment_Dialogue_Second_Textline_TextField
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
        /// Action that invoked when the textline number type enum field value is changed.
        /// </summary>
        void TextlineNumberTypeEnumFieldValueChangedAction() => ToggleSecondContentBoxDisplay();


        /// <summary>
        /// Action that invoked when the second line trigger type enum field value is changed.
        /// </summary>
        void SecondLineTriggerTypeEnumFieldValueChangedAction() => ToggleDeltaTimeDurationCellBoxDisplay();


        // ----------------------------- Serialization -----------------------------
        /// <inheritdoc />
        public override void SaveSegmentValues(DialogueSegment source)
        {
            SaveTitleBoxContainer();

            SaveFirstContentBoxContainers();

            SaveSecondContentBoxContainers();

            SaveCSVGuid();

            SaveIsExpanded();

            void SaveTitleBoxContainer()
            {
                // Save textline number type enum container
                textlineNumberTypeEnumContainer.SaveContainerValue(source.textlineNumberTypeEnumContainer);
            }

            void SaveFirstContentBoxContainers()
            {
                // Save character SO container.
                characterObjectContainer.SaveContainerValue(source.characterObjectContainer);

                // Save audio clip object container.
                audioClipContainer.SaveContainerValue(source.audioClipContainer);

                // Save first textline text container.
                firstTextlineTextContainer.SaveContainerValue(source.firstTextlineTextContainer);
            }

            void SaveSecondContentBoxContainers()
            {
                // Save second line trigger type enum container.
                secondLineTriggerTypeEnumContainer.SaveContainerValue(source.secondLineTriggerTypeEnumContainer);

                // Save duration float container.
                durationFloatContainer.SaveContainerValue(source.durationFloatContainer);

                // Save second textline text container.
                secondTextlineTextContainer.SaveContainerValue(source.secondTextlineTextContainer);
            }

            void SaveCSVGuid()
            {
                // Save CSV Guid
                csvGuid = source.csvGuid;
            }
            
            void SaveIsExpanded()
            {
                // Save segment's isExpanded state
                IsExpanded = source.IsExpanded;
            }
        }


        /// <inheritdoc />
        public override void LoadSegmentValues(DialogueSegment source)
        {
            LoadTitleBoxContainer();

            LoadFirstContentBoxContainers();

            LoadSecondContentBoxContainers();

            LoadCSVGuid();

            LoadIsExpandedValue(source);

            ToggleDisplayUponLoaded();

            void LoadTitleBoxContainer()
            {
                // Load textline number type enum container
                textlineNumberTypeEnumContainer.LoadContainerValue(source.textlineNumberTypeEnumContainer);
            }

            void LoadFirstContentBoxContainers()
            {
                // Load character SO container.
                characterObjectContainer.LoadContainerValue(source.characterObjectContainer);

                // Load audio clip object container.
                audioClipContainer.LoadContainerValue(source.audioClipContainer);

                // Load first textline text container.
                firstTextlineTextContainer.LoadContainerValue(source.firstTextlineTextContainer);
            }

            void LoadSecondContentBoxContainers()
            {
                // Load second line trigger type enum container.
                secondLineTriggerTypeEnumContainer.LoadContainerValue(source.secondLineTriggerTypeEnumContainer);

                // Load duration float container.
                durationFloatContainer.LoadContainerValue(source.durationFloatContainer);

                // Load second textline text container.
                secondTextlineTextContainer.LoadContainerValue(source.secondTextlineTextContainer);
            }

            void LoadCSVGuid()
            {
                // Load CSV Guid
                csvGuid = source.csvGuid;
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
            DSElementDisplayUtility.ToggleElementDisplay
            (
                textlineNumberTypeEnumContainer.IsSingleTextlineNumberType(),
                secondContentBox
            );
        }


        /// <summary>
        /// Hide or show the segment's delta time duration cell box when the second line trigger type is changed.
        /// </summary>
        void ToggleDeltaTimeDurationCellBoxDisplay()
        {
            DSElementDisplayUtility.ToggleElementDisplay
            (
                secondLineTriggerTypeEnumContainer.IsInputTriggerType(),
                deltaTimeDurationCellBox
            );
        }


        // ----------------------------- Reload Language Services -----------------------------
        /// <summary>
        /// Update the language specific fields' language to match the current selected language in editor.
        /// </summary>
        public void ReloadLanguage()
        {
            firstTextlineTextContainer.ReloadLanguage();
            audioClipContainer.ReloadLanguage();
        }
    }
}