using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class SegmentFactory
    {
        /// <summary>
        /// Factory method for creating a new segment title box UIElement.
        /// </summary>
        /// <param name="titleText">The text for the name of the segment that are about to be created.</param>
        /// <param name="titleBoxUSS01">The first USS style to set for the title box.</param>
        /// <returns>A new segment title box UIElement.</returns>
        public static Box AddSegmentTitle(string titleText, string titleBoxUSS01)
        {
            Box segmentTitleBox;

            Label titleLabel;

            SetupBoxContainer();

            SetupTitleLabel();

            AddFieldsToBox();

            return segmentTitleBox;

            void SetupBoxContainer()
            {
                segmentTitleBox = new Box();
                segmentTitleBox.AddToClassList(StylesConfig.Segment_TitleBox_Common);
                segmentTitleBox.AddToClassList(titleBoxUSS01);
            }

            void SetupTitleLabel()
            {
                titleLabel = LabelFactory.GetNewLabel
                (
                    labelText: titleText,
                    labelUSS01: StylesConfig.Segment_Title_Label
                );
            }

            void AddFieldsToBox()
            {
                segmentTitleBox.Add(titleLabel);
            }
        }


        /// <summary>
        /// Helper method for creating a new segment expand button UIElement.
        /// </summary>
        /// <param name="action">The action to invoke when the button is pressed.</param>
        /// <returns>A new segment expand button UIElement.</returns>
        public static Button AddSegmentExpandButton(Action action) =>
            ButtonFactory.GetNewButton
            (
                isAlert: false,
                btnSprite: AssetsConfig.SegmentExpandButtonIconSprite,
                btnPressedAction: action,
                buttonUSS01: StylesConfig.Segment_ExpandSegment_Button
            );
    }
}