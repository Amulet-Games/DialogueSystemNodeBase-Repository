using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG
{
    [Serializable]
    public class DualPortraitsSegment : DSSegmentFrameBase.T1<DualPortraitsSegment>
    {
        /// <summary>
        /// Image element for showing off the preview image of the left side character speaking.
        /// </summary>
        Image leftPortraitImage;


        /// <summary>
        /// Image element for showing off the preview image of the right side character speaking.
        /// </summary>
        Image rightPortraitImage;


        /// <summary>
        /// Object container for showing the left side character sprite in the preview image.
        /// </summary>
        DSObjectContainer<Sprite> left_SpriteContainer;


        /// <summary>
        /// Object container for showing the right side character sprite in the preview image.
        /// </summary>
        DSObjectContainer<Sprite> right_SpriteContainer;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of dual portraits segment
        /// </summary>
        public DualPortraitsSegment()
        {
            left_SpriteContainer = new DSObjectContainer<Sprite>();
            right_SpriteContainer = new DSObjectContainer<Sprite>();
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void SetupSegment(DSNodeBase node)
        {
            Box segmentTitleBox;

            Box portraitImageElementsBox;
            Box imageObjectFieldsBox;

            ObjectField leftSpriteField;
            ObjectField rightSpriteField;

            SetupBoxContainer();

            SetupSegmentTitle();

            SetupSegmentButton();

            SetupImages();

            SetupObjectFields();

            AddFieldsToBox();

            AddBoxToMainContainer();

            ExpandSegementUponCreated();

            void SetupBoxContainer()
            {
                ContentBox = new Box();
                ContentBox.AddToClassList(DSStylesConfig.Segment_DualPortraits_ContentBox);

                portraitImageElementsBox = new Box();
                portraitImageElementsBox.AddToClassList(DSStylesConfig.Segment_DualPortraits_ImagesBox);

                imageObjectFieldsBox = new Box();
                imageObjectFieldsBox.AddToClassList(DSStylesConfig.Segment_DualPortraits_ObjectFieldsBox);
            }

            void SetupSegmentTitle()
            {
                segmentTitleBox = DSSegmentsMaker.AddSegmentTitle
                (
                    DSStringsConfig.DualPortraitsSegmentTitleLabelText,
                    DSStylesConfig.Segment_TitleBox_DualPortraits
                );
            }

            void SetupSegmentButton()
            {
                ExpandButton = DSSegmentsMaker.AddSegmentExpandButton(SwitchSegmentIsExpanded);
            }

            void SetupImages()
            {
                leftPortraitImage = DSImagesMaker.GetNewImage
                (
                    DSStylesConfig.Segment_DualPortraits_Images,
                    DSStylesConfig.Segment_DualPortraits_Image_L
                );

                rightPortraitImage = DSImagesMaker.GetNewImage
                (
                    DSStylesConfig.Segment_DualPortraits_Images,
                    DSStylesConfig.Segment_DualPortraits_Image_R
                );
            }

            void SetupObjectFields()
            {
                leftSpriteField = DSObjectFieldsMaker.GetNewSpriteField
                (
                    left_SpriteContainer,
                    leftPortraitImage,
                    DSStylesConfig.Segment_DualPortraits_ObjectFields,
                    DSStylesConfig.Segment_DualPortraits_ObjectField_L
                );

                rightSpriteField = DSObjectFieldsMaker.GetNewSpriteField
                (
                    right_SpriteContainer,
                    rightPortraitImage,
                    DSStylesConfig.Segment_DualPortraits_ObjectFields,
                    DSStylesConfig.Segment_DualPortraits_ObjectField_R
                );
            }

            void AddFieldsToBox()
            {
                segmentTitleBox.Add(ExpandButton);

                portraitImageElementsBox.Add(leftPortraitImage);
                portraitImageElementsBox.Add(rightPortraitImage);

                imageObjectFieldsBox.Add(leftSpriteField);
                imageObjectFieldsBox.Add(rightSpriteField);

                ContentBox.Add(portraitImageElementsBox);
                ContentBox.Add(imageObjectFieldsBox);
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
        public override void SaveSegmentValues(DualPortraitsSegment source)
        {
            // Save left side sprite container.
            left_SpriteContainer.SaveContainerValue(source.left_SpriteContainer);

            // Save right side sprite container. 
            right_SpriteContainer.SaveContainerValue(source.right_SpriteContainer);

            // Save segment's isExpanded state
            IsExpanded = source.IsExpanded;
        }


        /// <inheritdoc />
        public override void LoadSegmentValues(DualPortraitsSegment source)
        {
            // Load left side sprite container.
            left_SpriteContainer.LoadContainerValue(source.left_SpriteContainer);

            // Load right side sprite container. 
            right_SpriteContainer.LoadContainerValue(source.right_SpriteContainer);

            // Update the preivew image if there is any.
            DSImageUtility.UpdateImagePreview(left_SpriteContainer.Value, leftPortraitImage);
            DSImageUtility.UpdateImagePreview(right_SpriteContainer.Value, rightPortraitImage);

            // Load isExpanded state.
            LoadIsExpandedValue(source);
        }
    }
}