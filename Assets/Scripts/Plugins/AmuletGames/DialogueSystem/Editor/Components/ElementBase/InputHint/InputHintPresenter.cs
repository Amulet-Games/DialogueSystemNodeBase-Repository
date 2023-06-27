namespace AG.DS
{
    public class InputHintPresenter
    {
        /// <summary>
        /// Method for creating a new input hint element.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <returns>A new input hint element.</returns>
        public static InputHint CreateElement(GraphViewer graphViewer)
        {
            InputHint inputHint;

            CreateInputHint();

            SetupDetail();

            SetupHintIconImage();

            SetupHintTextLabel();

            AddElementsToInputHint();

            AddStyleSheet();

            HideDisplayByDefault();

            return inputHint;

            void CreateInputHint()
            {
                inputHint = new();
                inputHint.AddToClassList(StyleConfig.InputHint_Main);
            }

            void SetupDetail()
            {
                inputHint.GraphViewer = graphViewer;
            }

            void SetupHintIconImage()
            {
                inputHint.HintIconImage = CommonImagePresenter.CreateElement
                (
                    imageSprite: ConfigResourcesManager.SpriteConfig.LanguageFieldHintIconSprite,
                    imageUSS01: StyleConfig.InputHint_IconImage
                );
            }

            void SetupHintTextLabel()
            {
                inputHint.HintTextLabel = CommonLabelPresenter.CreateElement
                (
                    labelText: "",
                    labelUSS: StyleConfig.InputHint_TextLabel
                );
            }

            void AddElementsToInputHint()
            {
                inputHint.Add(inputHint.HintIconImage);
                inputHint.Add(inputHint.HintTextLabel);
            }

            void AddStyleSheet()
            {
                inputHint.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSGlobalStyle);
                inputHint.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSInputHintStyle);
            }

            void HideDisplayByDefault()
            {
                inputHint.HideElement();
            }
        }
    }
}