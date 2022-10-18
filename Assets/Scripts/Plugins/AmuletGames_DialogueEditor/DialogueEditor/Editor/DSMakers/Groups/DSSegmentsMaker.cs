using System;
using UnityEngine.UIElements;

namespace AG
{
    public class DSSegmentsMaker
    {
        /// <summary>
        /// Create a new segment title with specificed title name and USS style.
        /// </summary>
        /// <param name="titleText">The text for the name of the segment that are about to be created.</param>
        /// <param name="titleBoxSpecialStyle">The special USS style for the segment's title.</param>
        /// <returns>The box element of the new segment title.</returns>
        public static Box AddSegmentTitle(string titleText, string titleBoxSpecialStyle)
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
                segmentTitleBox.AddToClassList(DSStylesConfig.Segment_TitleBox_Common);
                segmentTitleBox.AddToClassList(titleBoxSpecialStyle);
            }

            void SetupTitleLabel()
            {
                titleLabel = DSLabelsMaker.GetNewLabel(titleText, DSStylesConfig.Segment_Title_Label);
            }

            void AddFieldsToBox()
            {
                segmentTitleBox.Add(titleLabel);
            }
        }


        /// <summary>
        /// Create a new segment's expand button in it's title part.
        /// </summary>
        /// <param name="segmentExpandedAction">The action to invoke when expand button is pressed.</param>
        /// <returns>A new button to show or hide the segment that it's connecting to.</returns>
        public static Button AddSegmentExpandButton(Action segmentExpandedAction)
            =>
            DSButtonsMaker.GetNewButtonNonAlert
            (
                DSAssetsConfig.SegmentExpandButtonIcon,
                segmentExpandedAction,
                DSStylesConfig.Segment_ExpandSegment_Button
            );
    }
}