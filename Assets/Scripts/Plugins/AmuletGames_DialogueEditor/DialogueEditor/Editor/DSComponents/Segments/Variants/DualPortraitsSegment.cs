using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

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
        SpriteContainer left_SpriteContainer;


        /// <summary>
        /// Object container for showing the right side character sprite in the preview image.
        /// </summary>
        SpriteContainer right_SpriteContainer;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of dual portraits segment
        /// </summary>
        public DualPortraitsSegment()
        {
            left_SpriteContainer = new SpriteContainer();
            right_SpriteContainer = new SpriteContainer();
        }


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create all the UIElements that are needed in this segment.
        /// </summary>
        /// <param name="node">Node of which this segment is created for.</param>
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

                portraitImageElementsBox = new Box();
                portraitImageElementsBox.AddToClassList(DSStylesConfig.segment_DualPortraits_ImagesBox);

                imageObjectFieldsBox = new Box();
                imageObjectFieldsBox.AddToClassList(DSStylesConfig.segment_DualPortraits_ObjectFieldsBox);
            }

            void SetupSegmentTitle()
            {
                segmentTitleBox = DSSegmentsMaker.AddSegmentTitle("Image", DSStylesConfig.segment_TitleBox_DualPortraits);
            }

            void SetupSegmentButton()
            {
                ExpandButton = DSSegmentsMaker.AddSegmentExpandButton(SwitchSegmentIsExpanded);
            }

            void SetupImages()
            {
                leftPortraitImage = DSImagesMaker.GetNewImage(DSStylesConfig.segment_DualPortraits_Images, DSStylesConfig.segment_DualPortraits_Image_L);
                rightPortraitImage = DSImagesMaker.GetNewImage(DSStylesConfig.segment_DualPortraits_Images, DSStylesConfig.segment_DualPortraits_Image_R);
            }

            void SetupObjectFields()
            {
                leftSpriteField = DSObjectFieldsMaker.GetNewSpriteField(left_SpriteContainer, leftPortraitImage, DSStylesConfig.segment_DualPortraits_ObjectFields, DSStylesConfig.segment_DualPortraits_ObjectField_L);
                rightSpriteField = DSObjectFieldsMaker.GetNewSpriteField(right_SpriteContainer, rightPortraitImage, DSStylesConfig.segment_DualPortraits_ObjectFields, DSStylesConfig.segment_DualPortraits_ObjectField_R);
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
        /// <summary>
        /// Save segment's value from another previously created segment.
        /// </summary>
        /// <param name="source">The segment of which it's values are going to be saved in.</param>
        public override void SaveSegmentValues(DualPortraitsSegment source)
        {
            // Save segment's isExpanded state
            IsExpanded = source.IsExpanded;

            // Save left side sprite container.
            left_SpriteContainer.SaveContainerValue(source.left_SpriteContainer);

            // Save right side sprite container. 
            right_SpriteContainer.SaveContainerValue(source.right_SpriteContainer);
        }


        /// <summary>
        /// Load segment's value from another previously saved segment.
        /// </summary>
        /// <param name="source">The segment that was previously saved and now it's used to load from.</param>
        public override void LoadSegmentValues(DualPortraitsSegment source)
        {
            // Load left side sprite container.
            left_SpriteContainer.LoadContainerValue(source.left_SpriteContainer);

            // Load right side sprite container. 
            right_SpriteContainer.LoadContainerValue(source.right_SpriteContainer);

            // Update the preivew image if there is any.
            DSObjectFieldUtility.UpdateImagePreview(left_SpriteContainer.Value, leftPortraitImage);
            DSObjectFieldUtility.UpdateImagePreview(right_SpriteContainer.Value, rightPortraitImage);

            // Load isExpanded state.
            LoadIsExpandedValue(source);
        }
    }
}