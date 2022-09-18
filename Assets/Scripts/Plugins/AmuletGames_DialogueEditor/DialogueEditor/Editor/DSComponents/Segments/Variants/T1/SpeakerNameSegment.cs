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
        /// <inheritdoc />
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
                ContentBox.AddToClassList(DSStylesConfig.Segment_SpeakerName_ContentBox);
            }

            void SetupSegmentTitle()
            {
                segmentTitleBox = DSSegmentsMaker.AddSegmentTitle("Name", DSStylesConfig.Segment_TitleBox_SpeakerName);
            }

            void SetupSegmentButton()
            {
                ExpandButton = DSSegmentsMaker.AddSegmentExpandButton(SwitchSegmentIsExpanded);
            }

            void SetupTextField()
            {
                speakerNameTextField = DSTextFieldsMaker.GetNewTextField(speakerName_TextContainer, "Name", DSStylesConfig.Segment_SpeakerName_TextField);
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
        /// <inheritdoc />
        public override void SaveSegmentValues(SpeakerNameSegment source)
        {
            // Save segment's isExpanded state
            IsExpanded = source.IsExpanded;

            // Save speaker name text field container.
            speakerName_TextContainer.SaveContainerValue(source.speakerName_TextContainer);
        }


        /// <inheritdoc />
        public override void LoadSegmentValues(SpeakerNameSegment source)
        {
            // Load speaker name text field container.
            speakerName_TextContainer.LoadContainerValue(source.speakerName_TextContainer);

            // Load isExpanded state.
            LoadIsExpandedValue(source);
        }
    }
}