/*
using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class DualPortraitsSegment : SegmentFrameBase.Regular<DualPortraitsSegmentData>
    {
        /// <summary>
        /// Object container for showing the left side character sprite in the preview image.
        /// </summary>
        [SerializeField] ObjectContainer<Sprite> leftSpriteContainer;


        /// <summary>
        /// Object container for showing the right side character sprite in the preview image.
        /// </summary>
        [SerializeField] ObjectContainer<Sprite> rightSpriteContainer;


        /// <summary>
        /// Image element for showing off the preview image of the left side character speaking.
        /// </summary>
        [NonSerialized] Image leftPortraitImage;


        /// <summary>
        /// Image element for showing off the preview image of the right side character speaking.
        /// </summary>
        [NonSerialized] Image rightPortraitImage;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the dual portraits segment component class.
        /// </summary>
        public DualPortraitsSegment()
        {
            leftSpriteContainer = new();
            rightSpriteContainer = new();
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void SetupSegment(NodeBase node)
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
                /// Add these two line in the StylesConfig.cs in order to use the style below.
                /// public const string Segment_TitleBox_DualPortraits = "segment_TitleBox_DualPortraits";
                /// public const string Segment_DualPortraits_ContentBox = "segment_DualPortraits_ContentBox";

                ContentBox = new Box();
                ContentBox.AddToClassList(StylesConfig.Segment_DualPortraits_ContentBox);

                portraitImageElementsBox = new Box();
                portraitImageElementsBox.AddToClassList(StylesConfig.PreviewNode_ImagesBox);

                imageObjectFieldsBox = new Box();
                imageObjectFieldsBox.AddToClassList(StylesConfig.PreviewNode_ObjectFieldsBox);
            }

            void SetupSegmentTitle()
            {
                segmentTitleBox = SegmentFactory.AddSegmentTitle
                (
                    titleText: StringsConfig.DualPortraitsSegmentTitleLabelText,
                    titleBoxUSS01: StylesConfig.Segment_TitleBox_DualPortraits
                );
            }

            void SetupSegmentButton()
            {
                ExpandButton = SegmentFactory.AddSegmentExpandButton
                (
                    action: SwitchSegmentIsExpanded
                );
            }

            void SetupImages()
            {
                leftPortraitImage = ImageFactory.GetNewImage
                (
                    imageUSS01: StylesConfig.PreviewNode_Image,
                    imageUSS02: StylesConfig.PreviewNode_Image_L
                );

                rightPortraitImage = ImageFactory.GetNewImage
                (
                    imageUSS01: StylesConfig.PreviewNode_Image,
                    imageUSS02: StylesConfig.PreviewNode_Image_R
                );
            }

            void SetupObjectFields()
            {
                leftSpriteField = ObjectFieldFactory.GetNewObjectField
                (
                    objectContainer: leftSpriteContainer,
                    containerValueChangedAction: LeftSpriteObjectContainerValueChangedAction,
                    fieldUSS01: StylesConfig.PreviewNode_ObjectField,
                    fieldUSS02: StylesConfig.PreviewNode_ObjectField_L
                );

                rightSpriteField = ObjectFieldFactory.GetNewObjectField
                (
                    objectContainer: rightSpriteContainer,
                    containerValueChangedAction: RightSpriteObjectContainerValueChangedAction,
                    fieldUSS01: StylesConfig.PreviewNode_ObjectField,
                    fieldUSS02: StylesConfig.PreviewNode_ObjectField_R
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


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Action that invoked when the segment's left sprite object container value is changed.
        /// </summary>
        void LeftSpriteObjectContainerValueChangedAction() =>
                ImageElementHelper.UpdateImagePreview
                    (sprite: leftSpriteContainer.Value, image: leftPortraitImage);


        /// <summary>
        /// Action that invoked when the segment's right sprite object container value is changed.
        /// </summary>
        void RightSpriteObjectContainerValueChangedAction() =>
                ImageElementHelper.UpdateImagePreview
                    (sprite: rightSpriteContainer.Value, image: rightPortraitImage);


        // ----------------------------- Serialization -----------------------------
        /// <inheritdoc />
        public override void SaveSegmentValues(DualPortraitsSegmentData data)
        {
            // Left side sprite.
            data.LeftPortraitSprite = leftSpriteContainer.Value;

            // Right side sprite. 
            data.RightPortraitSprite = rightSpriteContainer.Value;

            // isExpanded.
            data.IsExpanded = IsExpanded;
        }


        /// <inheritdoc />
        public override void LoadSegmentValues(DualPortraitsSegmentData data)
        {
            // Left side sprite.
            leftSpriteContainer.LoadContainerValue(data.LeftPortraitSprite);

            // Right side sprite. 
            rightSpriteContainer.LoadContainerValue(data.RightPortraitSprite);

            // Update preivew images.
            ImageElementHelper.UpdateImagePreview
                (sprite: leftSpriteContainer.Value, image: leftPortraitImage);

            ImageElementHelper.UpdateImagePreview
                (sprite: rightSpriteContainer.Value, image: rightPortraitImage);

            // isExpanded.
            LoadIsExpandedValue(data);
        }
    }
}
*/