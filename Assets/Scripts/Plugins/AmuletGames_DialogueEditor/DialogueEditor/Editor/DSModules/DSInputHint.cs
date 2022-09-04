using UnityEngine.UIElements;
using UnityEngine;

namespace AG
{
    public class DSInputHint
    {
        /// <summary>
        /// Reference of the dialogue system's graph view module.
        /// </summary>
        readonly DSGraphView graphView;


        /// <summary>
        /// The main box container of the input hint.
        /// </summary>
        Box mainBox;


        /// <summary>
        /// The text label of the input hint.
        /// </summary>
        Label hintLabel;


        /// <summary>
        /// Vertical offset value in between the target field and the hint itself.
        /// </summary>
        float hintTopOffset = 31f;

        /// <summary>
        /// Horizontal offset value in between the target field and the hint itself.
        /// </summary>
        float hintLeftOffset = 18f;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the dialogue system's input hint module.
        /// </summary>
        /// <param name="graphView">Dialogue system's graph view module.</param>
        public DSInputHint(DSGraphView graphView)
        {
            this.graphView = graphView;
        }


        // ----------------------------- Post Setup -----------------------------
        /// <summary>
        /// Post setup for the class, used to initialize internal fields, call the internal maker's method to create
        /// <br>the input hint and its child visual elements on the graph.</br>
        /// <para></para>
        /// <br>It's called by dialogue editor window, and executed after the creation of graph view module class.</br>
        /// </summary>
        public void PostSetup()
        {
            CreateInputHintVisualElements();
        }


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create a new input hint and all its child visual elements, then hide it from the graph
        /// <br>until it is called to show again.</br>
        /// </summary>
        void CreateInputHintVisualElements()
        {
            Image inputHintIconImage;

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
                mainBox.AddToClassList(DSStylesConfig.InputHint_Hint_MainBox);
            }

            void SetupImage()
            {
                inputHintIconImage = DSImagesMaker.GetNewImage(DSStylesConfig.InputHint_HintIcon_Image);
                inputHintIconImage.image = DSAssetsConfig.InputHintIconSprite.texture;
            }

            void SetupLabel()
            {
                hintLabel = DSLabelsMaker.GetNewLabel("", DSStylesConfig.InputHint_HintText_Label);
            }

            void AddStyleSheet()
            {
                mainBox.styleSheets.Add(DSStylesConfig.DSGlobalStyle);
                mainBox.styleSheets.Add(DSStylesConfig.DSInputHintStyle);
            }

            void AddFieldsToBox()
            {
                mainBox.Add(inputHintIconImage);
                mainBox.Add(hintLabel);
            }

            void AddElementsToWindowRoot()
            {
                graphView.contentViewContainer.Add(mainBox);
            }
        }


        // ----------------------------- Show Hint Services -----------------------------
        /// <summary>
        /// Show the input hint next to a visual element.
        /// </summary>
        /// <param name="hintText">The text of the hint to show.</param>
        /// <param name="targetWorldBoundRect">
        /// The world bound property from the visual element that the hint is targeting.
        /// <br>Read More: https://docs.unity3d.com/ScriptReference/Bounds.html</br>
        /// </param>
        public void ShowHint(string hintText, Rect targetWorldBoundRect)
        {
            float targetHintPosX;
            float targetHintPosY;

            // Show the hint.
            DSElementDisplayUtility.ShowElement(mainBox);

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

                // Divide it with the graph view size to keep position even after zooming in and out.
                targetHintPosX /= graphView.scale;

                // Lastly add the top offset value to the field that the hint is targeting to.
                mainBox.style.left = targetHintPosX += hintLeftOffset;
            }

            void CalculateHintBoxYPos()
            {
                // Calculate the height position point of the field that this hint is going to target.
                targetHintPosY = targetWorldBoundRect.y - targetWorldBoundRect.height;
                //Debug.Log("Max.y = " + targetWorldBoundRect.max.y);

                // Remove the vertical offset value that created by the Graph View Container.
                targetHintPosY += graphView.contentViewContainer.worldBound.y * -1;

                // Divide it with the graph view size to keep position even after zooming in and out.
                targetHintPosY /= graphView.scale;

                // Lastly add the top offset value to the field that the hint is targeting to.
                mainBox.style.top = targetHintPosY += hintTopOffset;
            }
        }


        /// <summary>
        /// Hide the current showing input hint.
        /// </summary>
        public void HideHint()
        {
            DSElementDisplayUtility.HideElement(mainBox);
        }
    }
}