using UnityEngine;

namespace AG.DS
{
    using ContentButtonView = NodeViewBase.ContentButtonView;

    /// <summary>
    /// Holds the methods for creating the elements for the node element.
    /// </summary>
    public abstract class NodePresenterBase
    {
        public class ContentButtonViewPresenter
        {
            /// <summary>
            /// Create the elements for the content button view.
            /// </summary>
            /// <param name="view">The content button view to set for.</param>
            /// <param name="buttonText">The button text to set for.</param>
            /// <param name="buttonIconSprite">The button icon sprite to set for.</param>
            public static void CreateElement
            (
                ContentButtonView view,
                string buttonText,
                Sprite buttonIconSprite
            )
            {
                CreateButton();

                CreateButtonLabel();

                CreateIconImage();

                AddElementsToContentButton();

                void CreateButton()
                {
                    view.Button = new();
                    view.Button.AddToClassList(StyleConfig.ContentButtonView_Button);
                }

                void CreateButtonLabel()
                {
                    view.TextLabel = LabelPresenter.CreateElement
                    (
                        text: buttonText,
                        USS: StyleConfig.ContentButtonView_Text_Label
                    );
                }

                void CreateIconImage()
                {
                    view.IconImage = ImagePresenter.CreateElement
                    (
                        sprite: buttonIconSprite,
                        USS01: StyleConfig.ContentButtonView_Icon_Image
                    );
                }

                void AddElementsToContentButton()
                {
                    view.Button.Add(view.TextLabel);
                    view.Button.Add(view.IconImage);
                }
            }
        }
    }
}