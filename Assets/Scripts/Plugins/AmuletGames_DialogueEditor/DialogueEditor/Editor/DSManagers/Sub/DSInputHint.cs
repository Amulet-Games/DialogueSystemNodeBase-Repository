using UnityEngine;
using UnityEngine.UIElements;

namespace AG
{
    public class DSInputHint
    {
        [Header("Config")]
        private float hintTopOffset = 19.5f;
        private float hintLeftOffset = 18f;

        [Header("Refs")]
        private DSGraphView graphView;

        [Header("Visual Element Refs")]
        private Box mainBox;                   /// This is the main box, it puts the hint image and body together.
        private Label hintLabel;

        #region Setup.
        public DSInputHint(DSGraphView graphView)
        {
            this.graphView = graphView;
        }

        public void PostSetup()
        {
            SetupVisualElements();

            void SetupVisualElements()
            {
                Image hintImage;

                SetupBoxContainer();

                SetupImage();

                SetupLabel();

                AddStyleSheet();

                AddFieldsToBox();

                AddElementsToWindowRoot();

                HideHint();

                void SetupBoxContainer()
                {
                    mainBox = new Box();
                    mainBox.AddToClassList(DSStylesConfig.inputHint_MainBox);
                }

                void SetupImage()
                {
                    hintImage = DSBuiltInFieldsMaker.GetNewImage(DSStylesConfig.inputHint_HintImage);
                    hintImage.image = DSBuiltInFieldsMaker.hintImageSpriteAsset.texture;
                }

                void SetupLabel()
                {
                    hintLabel = DSBuiltInFieldsMaker.GetNewLabel("", DSStylesConfig.inputHint_HintLabel);
                }

                void AddStyleSheet()
                {
                    mainBox.styleSheets.Add(DSStylesConfig.dsGlobalStyle);
                    mainBox.styleSheets.Add(DSStylesConfig.dsInputHintStyle);
                }

                void AddFieldsToBox()
                {
                    mainBox.Add(hintImage);
                    mainBox.Add(hintLabel);
                }

                void AddElementsToWindowRoot()
                {
                    graphView.contentViewContainer.Add(mainBox);
                }
            }
        }
        #endregion

        public void ShowHint(string hintText, Rect targetWorldBoundRect)
        {
            // GOAL: Show the hint label next to a visual element

            float targetHintPosX;
            float targetHintPosY;

            // Show the hint.
            DSFieldUtilityEditor.ShowElement(mainBox);

            // Set hint position.
            CalculateHintBoxXPos();
            CalculateHintBoxYPos();

            // Set label text.
            hintLabel.text = hintText;

            void CalculateHintBoxXPos()
            {
                // Calculate the end point of the field that this hint is going to refered to.
                targetHintPosX = targetWorldBoundRect.x + targetWorldBoundRect.width;

                // Remove the horizontal offset value that created by the Graph View Container.
                targetHintPosX += graphView.contentViewContainer.worldBound.x * -1;

                // Add the left offset value to create space between this hint and the field.
                targetHintPosX += hintLeftOffset;

                // To keep the correct position even after graph view zooming.
                mainBox.style.left = targetHintPosX / graphView.scale;
            }

            void CalculateHintBoxYPos()
            {
                // Calculate the height position point of the field that this hint is going to target.
                targetHintPosY = targetWorldBoundRect.y - targetWorldBoundRect.height;

                // Remove the vertical offset value that created by the Graph View Container.
                targetHintPosY += graphView.contentViewContainer.worldBound.y * -1;

                // Add the top offset value to match the position of this hint and the field.
                targetHintPosY += hintTopOffset;

                // To keep the correct position even after graph view zooming.
                mainBox.style.top = targetHintPosY / graphView.scale;
            }
        }

        public void HideHint()
        {
            // GOAL: Hide the current showin hint label.

            DSFieldUtilityEditor.HideElement(mainBox);
        }
    }
}