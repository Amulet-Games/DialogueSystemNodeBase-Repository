using System;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG
{
    public class DSSegmentMaker
    {
        public static void GetNewSegment_ImagesPreview(BaseNode node, List<ImagesPreviewSegment> imagesPreviewSegments, List<DSSegmentBase> baseSegments, ImagesPreviewSegment loadedSegment)
        {
            ImagesPreviewSegment newImagesPreviewSegment;

            // This is the main box, it put the image header and body together.
            Box mainBox;

            // This consists with Label for Title "Image", and Button Element to remove this segment.
            Box segmentTitleBox;

            // This consists with two Images Elements that from both left and right side.
            Box previewImagesBox;

            // This consists with two ObjectField that afrom both left and right side.
            Box imageObjectsBox;

            Image newLeftPreviewImage;
            Image newRightPreviewImage;

            ObjectField newLeftImageObjectField;
            ObjectField newRightImageObjectField;

            CreateImageData();

            SetupBoxContainer();

            SetupSegmentTitle();

            SetupImages();

            SetupObjectFields();

            CheckLoadedSegment();

            AddFieldsToBox();

            AddBoxToMainContainer();

            void CreateImageData()
            {
                newImagesPreviewSegment = new ImagesPreviewSegment();
                imagesPreviewSegments.Add(newImagesPreviewSegment);
                baseSegments.Add(newImagesPreviewSegment);
            }

            void SetupBoxContainer()
            {
                mainBox = new Box();

                previewImagesBox = new Box();
                previewImagesBox.AddToClassList(DSStylesConfig.segment_ImagePreview_ImagesBox);

                imageObjectsBox = new Box();
                imageObjectsBox.AddToClassList(DSStylesConfig.segment_ImagePreview_ObjectFieldsBox);
            }

            void SetupSegmentTitle()
            {
                segmentTitleBox = AddSegmentTitle("Image", DSStylesConfig.segment_ImagePreview_TitleBox, RemoveSegmentFromList);
            }

            void SetupImages()
            {
                newLeftPreviewImage = DSBuiltInFieldsMaker.GetNewImage(DSStylesConfig.segment_ImagePreivew_Images, DSStylesConfig.segment_ImagePreivew_Image_L);
                newRightPreviewImage = DSBuiltInFieldsMaker.GetNewImage(DSStylesConfig.segment_ImagePreivew_Images, DSStylesConfig.segment_ImagePreivew_Image_R);
            }

            void SetupObjectFields()
            {
                newLeftImageObjectField = DSBuiltInFieldsMaker.GetNewSpriteField(newImagesPreviewSegment.l_avatar_SpriteContainer, newLeftPreviewImage, DSStylesConfig.segment_ImagePreivew_ObjectField_L);
                newRightImageObjectField = DSBuiltInFieldsMaker.GetNewSpriteField(newImagesPreviewSegment.r_avatar_SpriteContainer, newRightPreviewImage, DSStylesConfig.segment_ImagePreivew_ObjectField_R);
            }

            void CheckLoadedSegment()
            {
                if (loadedSegment != null)
                {
                    newImagesPreviewSegment.LoadSegmentValue(loadedSegment, newLeftPreviewImage, newRightPreviewImage);
                }
            }

            void AddFieldsToBox()
            {
                previewImagesBox.Add(newLeftPreviewImage);
                previewImagesBox.Add(newRightPreviewImage);

                imageObjectsBox.Add(newLeftImageObjectField);
                imageObjectsBox.Add(newRightImageObjectField);

                mainBox.Add(segmentTitleBox);
                mainBox.Add(previewImagesBox);
                mainBox.Add(imageObjectsBox);
            }

            void AddBoxToMainContainer()
            {
                node.mainContainer.Add(mainBox);
            }

            #region Callbacks.
            /// SegmentRemovedEvent - Internal - Image Preview Segment Title
            void RemoveSegmentFromList()
            {
                // Remove segment from node's data.
                imagesPreviewSegments.Remove(newImagesPreviewSegment);
                baseSegments.Remove(newImagesPreviewSegment);

                // Remove modifier from node's container.
                node.DeleteVisualElement(mainBox, N_NodeContainerType.Main);
            }
            #endregion
        }

        public static void GetNewSegment_SpeakerName(BaseNode node, List<SpeakerNameSegment> speakerNameSegments, List<DSSegmentBase> baseSegments, SpeakerNameSegment loadedSegment)
        {
            SpeakerNameSegment newSpeakerNameSegment;

            // This is the main box, it put the name header and body together.
            Box mainBox;

            // This consists with Label for Title "Name", and Button Element to remove this segment.
            Box segmentTitleBox;

            TextField speakerNameTextField;

            CreateTextData();

            SetupBoxContainer();

            SetupSegmentTitle();

            SetupTextField();

            CheckLoadedSegment();

            AddFieldsToBox();

            AddBoxToMainContainer();

            void CreateTextData()
            {
                newSpeakerNameSegment = new SpeakerNameSegment();
                speakerNameSegments.Add(newSpeakerNameSegment);
                baseSegments.Add(newSpeakerNameSegment);
            }

            void SetupBoxContainer()
            {
                mainBox = new Box();
            }

            void SetupSegmentTitle()
            {
                segmentTitleBox = AddSegmentTitle("Name", DSStylesConfig.segment_SpeakerName_TitleBox, RemoveSegmentFromList);
            }

            void SetupTextField()
            {
                speakerNameTextField = DSBuiltInFieldsMaker.GetNewTextField(newSpeakerNameSegment.name_TextsContainer, "Name", DSStylesConfig.segment_SpeakerName_TextField);
            }

            void CheckLoadedSegment()
            {
                if (loadedSegment != null)
                {
                    newSpeakerNameSegment.LoadSegmentValue(loadedSegment);
                }
            }

            void AddFieldsToBox()
            {
                mainBox.Add(segmentTitleBox);
                mainBox.Add(speakerNameTextField);
            }

            void AddBoxToMainContainer()
            {
                node.mainContainer.Add(mainBox);
            }

            #region Callbacks.
            /// SegmentRemovedEvent - Internal - Speaker Name Segment Title
            void RemoveSegmentFromList()
            {
                // Remove segment from node's data.
                speakerNameSegments.Remove(newSpeakerNameSegment);
                baseSegments.Remove(newSpeakerNameSegment);

                // Remove modifier from node's container.
                node.DeleteVisualElement(mainBox, N_NodeContainerType.Main);
            }
            #endregion
        }

        public static void GetNewSegment_Textline(BaseNode node, List<TextlineSegment> textlineSegments, List<DSSegmentBase> baseSegments,TextlineSegment loadedSegment)
        {
            TextlineSegment newTextlineSegment;

            // This is the main box, it put the textline header and body together.
            Box mainBox;

            // This consists with Label for Title "Text", and Button Element to remove this segment.
            Box segmentTitleBox;

            // This consists with TextField for LG_Texts, and ObjectField for LG_AudioClips.
            Box languageTextlineBox;

            CreateTextlineData();

            SetupBoxContainer();

            SetupSegmentTitle();

            SetupSegmentTextline();

            CheckLoadedSegment();

            AddBoxesToSegment();

            AddBoxToMainContainer();

            void CreateTextlineData()
            {
                newTextlineSegment = new TextlineSegment();
                textlineSegments.Add(newTextlineSegment);
                baseSegments.Add(newTextlineSegment);
            }

            void SetupBoxContainer()
            {
                mainBox = new Box();
            }

            void SetupSegmentTitle()
            {
                segmentTitleBox = AddSegmentTitle("Textline", DSStylesConfig.segment_LGTextline_TitleBox, RemoveSegmentFromList);
            }

            void SetupSegmentTextline()
            {
                languageTextlineBox = DSLanguageGroupsMaker.GetNewLanguageGroup_Textline(newTextlineSegment.LG_Texts_Container, newTextlineSegment.LG_AudioClips_Container);
            }

            void CheckLoadedSegment()
            {
                if (loadedSegment != null)
                {
                    newTextlineSegment.LoadSegmentValue(loadedSegment);
                }
            }

            void AddBoxesToSegment()
            {
                mainBox.Add(segmentTitleBox);
                mainBox.Add(languageTextlineBox);
            }

            void AddBoxToMainContainer()
            {
                node.mainContainer.Add(mainBox);
            }

            #region Callbacks.
            /// SegmentRemovedEvent - Internal - Textline Segment Title
            void RemoveSegmentFromList()
            {
                // Remove segment from node's data.
                textlineSegments.Remove(newTextlineSegment);
                baseSegments.Remove(newTextlineSegment);

                // Remove modifier from node's container.
                node.DeleteVisualElement(mainBox, N_NodeContainerType.Main);
            }
            #endregion
        }

        static Box AddSegmentTitle(string titleText, string titleBoxSpecialStyle, Action SegmentRemovedEvent)
        {
            Box segmentTitleBox;

            Label titleLabel;
            Button removeButton;

            SetupBoxContainer();

            SetupTitleLabel();

            SetupButton_RemoveSegment();

            AddFieldsToBox();

            return segmentTitleBox;

            void SetupBoxContainer()
            {
                segmentTitleBox = new Box();
                segmentTitleBox.AddToClassList(DSStylesConfig.segment_Title_MainBox);
                segmentTitleBox.AddToClassList(titleBoxSpecialStyle);
            }

            void SetupTitleLabel()
            {
                titleLabel = DSBuiltInFieldsMaker.GetNewLabel(titleText, DSStylesConfig.segment_Title_Label);
            }

            void SetupButton_RemoveSegment()
            {
                removeButton = DSBuiltInFieldsMaker.GetNewButton("X", SegmentRemovedEvent, DSStylesConfig.segment_Title_RemoveButton);
            }

            void AddFieldsToBox()
            {
                segmentTitleBox.Add(titleLabel);
                segmentTitleBox.Add(removeButton);
            }
        }
    }
}