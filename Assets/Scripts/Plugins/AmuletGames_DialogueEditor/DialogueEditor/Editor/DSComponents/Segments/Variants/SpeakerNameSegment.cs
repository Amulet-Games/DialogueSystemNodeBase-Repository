using System;
using UnityEngine.UIElements;

namespace AG
{
    [Serializable]
    public class SpeakerNameSegment : DSSegmentFrameBase.T1<SpeakerNameSegment>
    {
        /// <summary>
        /// Text container for the name of the speaker.
        /// </summary>
        TextContainer speakerName_TextContainer;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of speaker name segment
        /// </summary>
        public SpeakerNameSegment()
        {
            speakerName_TextContainer = new TextContainer();
        }


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create all the UIElements that are needed in this segment.
        /// </summary>
        /// <param name="node">Node of which this segment is created for.</param>
        public override void SetupSegment(DSNodeBase node)
        {
            Box segmentTitleBox;

            TextField speakerNameTextField;

            SetupBoxContainer();

            SetupSegmentTitle();

            SetupSegmentButton();

            SetupTextField();

            AddFieldsToBox();

            AddBoxToMainContainer();

            ExpandSegementUponCreated();

            void SetupBoxContainer()
            {
                ContentBox = new Box();
                ContentBox.AddToClassList(DSStylesConfig.segment_SpeakerName_ContentBox);
            }

            void SetupSegmentTitle()
            {
                segmentTitleBox = DSSegmentsMaker.AddSegmentTitle("Name", DSStylesConfig.segment_TitleBox_SpeakerName);
            }

            void SetupSegmentButton()
            {
                ExpandButton = DSSegmentsMaker.AddSegmentExpandButton(SwitchSegmentIsExpanded);
            }

            void SetupTextField()
            {
                speakerNameTextField = DSTextFieldsMaker.GetNewTextField(speakerName_TextContainer, "Name", DSStylesConfig.segment_SpeakerName_TextField);
            }

            void AddFieldsToBox()
            {
                segmentTitleBox.Add(ExpandButton);
                ContentBox.Add(speakerNameTextField);
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
        /// <param name="source">The segment of which it's values are going to be saved in.</param>
        public override void SaveSegmentValues(SpeakerNameSegment source)
        {
            // Save segment's isExpanded state
            IsExpanded = source.IsExpanded;

            // Save speaker name text field container.
            speakerName_TextContainer.SaveContainerValue(source.speakerName_TextContainer);
        }


        /// <summary>
        /// Load segment's value from another previously saved segment.
        /// </summary>
        /// <param name="source">The segment that was previously saved and now it's used to load from.</param>
        public override void LoadSegmentValues(SpeakerNameSegment source)
        {
            // Load speaker name text field container.
            speakerName_TextContainer.LoadContainerValue(source.speakerName_TextContainer);

            // Load isExpanded state.
            LoadIsExpandedValue(source);
        }
    }
}