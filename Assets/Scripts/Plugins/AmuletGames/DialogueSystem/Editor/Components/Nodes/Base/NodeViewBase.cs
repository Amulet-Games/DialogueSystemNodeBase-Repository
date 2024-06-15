using UnityEngine.UIElements;

namespace AG.DS
{
    /// <summary>
    /// Holds all the element references for the node element.
    /// </summary>
    public abstract class NodeViewBase
    {
        public class ContentButtonView
        {
            /// <summary>
            /// Reference of the button.
            /// </summary>
            public Button Button;


            /// <summary>
            /// Label for the button text.
            /// </summary>
            public Label TextLabel;


            /// <summary>
            /// Image for the button icon.
            /// </summary>
            public Image IconImage;
        }


        /// <summary>
        /// View for the node title field.
        /// </summary>
        public NodeTitleTextFieldView NodeTitleFieldView;


        /// <summary>
        /// Button for editing the node title.
        /// </summary>
        public Button EditTitleButton;
    }
}