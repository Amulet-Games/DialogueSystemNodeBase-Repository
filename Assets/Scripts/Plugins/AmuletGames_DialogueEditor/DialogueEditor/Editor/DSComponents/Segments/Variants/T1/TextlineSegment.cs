using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG
{
    [Serializable]
    public class TextlineSegment : DSSegmentFrameBase.T1<TextlineSegment>
    {
        /// <summary>
        /// Text container for the dialogue's texts.
        /// </summary>
        LanguageTextContainer language_TextContainer;
        
        /// <summary>
        /// Object container for the dialogue's audio clip.
        /// </summary>
        LanguageAudioClipContainer language_AudioClipContainer;

        /// <summary>
        /// CSV Guid
        /// </summary>
        string csvGuid;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of textline segment
        /// </summary>
        public TextlineSegment()
        {
            language_TextContainer = new LanguageTextContainer();
            language_AudioClipContainer = new LanguageAudioClipContainer();
            csvGuid = Guid.NewGuid().ToString();
        }


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create all the UIElements that are needed in this segment.
        /// </summary>
        /// <param name="node">Node of which this segment is created for.</param>
        public override void SetupSegment(DSNodeBase node)
        {
            Box segmentTitleBox;

            TextField LG_Text_TextField;
            ObjectField LG_AudioClip_ObjectField;

            SetupBoxContainer();

            SetupSegmentTitle();

            SetupSegmentButton();

            SetupTextField();

            SetupAudioClipField();

            AddFieldsToBox();

            AddBoxToMainContainer();

            ExpandSegementUponCreated();

            void SetupBoxContainer()
            {
                ContentBox = new Box();
                ContentBox.AddToClassList(DSStylesConfig.Segment_Textline_ContentBox);
            }

            void SetupSegmentTitle()
            {
                segmentTitleBox = DSSegmentsMaker.AddSegmentTitle("Textline", DSStylesConfig.Segment_TitleBox_Textline);
            }

            void SetupSegmentButton()
            {
                ExpandButton = DSSegmentsMaker.AddSegmentExpandButton(SwitchSegmentIsExpanded);
            }

            void SetupTextField()
            {
                LG_Text_TextField = DSLanguageFieldsMaker.GetNewLanguageField_Text(language_TextContainer, "Text", DSStylesConfig.Segment_Textline_TextField);
            }

            void SetupAudioClipField()
            {
                LG_AudioClip_ObjectField = DSLanguageFieldsMaker.GetNewLanguageField_AudioClip(language_AudioClipContainer, DSStylesConfig.Segment_Textline_ObjectField);
            }

            void AddFieldsToBox()
            {
                segmentTitleBox.Add(ExpandButton);
                ContentBox.Add(LG_Text_TextField);
                ContentBox.Add(LG_AudioClip_ObjectField);
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
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save segment's value from another previously created segment.
        /// </summary>
        /// <param name="source">The segment of which its values are going to be saved in.</param>
        public override void SaveSegmentValues(TextlineSegment source)
        {
            // Save segment's isExpanded state
            IsExpanded = source.IsExpanded;

            // Save language text field container.
            language_TextContainer.SaveContainerValue(source.language_TextContainer);

            // Save language audio clip object field.
            language_AudioClipContainer.SaveContainerValue(source.language_AudioClipContainer);

            // Save CSV Guid
            csvGuid = source.csvGuid;
        }


        /// <summary>
        /// Load segment's value from another previously saved segment.
        /// </summary>
        /// <param name="source">The segment that was previously saved and now it's used to load from.</param>
        public override void LoadSegmentValues(TextlineSegment source)
        {
            // Load language text field container.
            language_TextContainer.LoadContainerValue(source.language_TextContainer);

            // Load language audio clip object field.
            language_AudioClipContainer.LoadContainerValue(source.language_AudioClipContainer);

            // Load CSV Guid
            csvGuid = source.csvGuid;

            // Load isExpanded state.
            LoadIsExpandedValue(source);
        }


        // ----------------------------- Reload Language Services -----------------------------
        /// <summary>
        /// Update the language specific fields' language to match the current selected language in editor.
        /// </summary>
        public void ReloadLanguage()
        {
            language_TextContainer.ReloadLanguage();
            language_AudioClipContainer.ReloadLanguage();
        }
    }
}