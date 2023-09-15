namespace AG.DS
{
    public class InputHintPresenter
    {
        /// <summary>
        /// Create a new input hint element.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <returns>A new input hint element.</returns>
        public static InputHint CreateElement(GraphViewer graphViewer)
        {
            InputHint inputHint;

            CreateInputHint();

            CreateHintIconImage();

            CreateHintTextLabel();

            AddElementsToInputHint();

            AddStyleSheet();

            HideDisplayByDefault();

            return inputHint;

            void CreateInputHint()
            {
                inputHint = new(graphViewer);
                inputHint.AddToClassList(StyleConfig.InputHint);
            }

            void CreateHintIconImage()
            {
                inputHint.HintIconImage = CommonImagePresenter.CreateElement
                (
                    imageSprite: ConfigResourcesManager.SpriteConfig.LanguageFieldHintIconSprite,
                    imageUSS01: StyleConfig.InputHint_HintIcon_Image
                );
            }

            void CreateHintTextLabel()
            {
                inputHint.HintTextLabel = CommonLabelPresenter.CreateElement
                (
                    labelText: "",
                    labelUSS: StyleConfig.InputHint_HintText_Label
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