using System;

namespace AG.DS
{
    /// <summary>
    /// Class that stores config data for any node creation in the dialogue system.
    /// <br>The values here would be used by other module class when creating nodes,</br>
    /// <br>and unlike other config classes, the values here can be altered and saved.</br>
    /// </summary>
    [Serializable]
    public class NodeConfig
    {
        // ----------------------------- Node Width -----------------------------
        /// <summary>
        /// The min width value of the boolean node.
        /// </summary>
        public const int BooleanNodeMinWidth = 531;


        /// <summary>
        /// The width buffer value of the boolean node.
        /// </summary>
        public const int BooleanNodeWidthBuffer = 25;


        /// <summary>
        /// The min width value of the dialogue node.
        /// </summary>
        public const int DialogueNodeMinWidth = 491;


        /// <summary>
        /// The width buffer value of the dialogue node.
        /// </summary>
        public const int DialogueNodeWidthBuffer = 50;


        /// <summary>
        /// The min width value of the end node.
        /// </summary>
        public const int EndNodeMinWidth = 142;


        /// <summary>
        /// The width buffer value of the end node.
        /// </summary>
        public const int EndNodeWidthBuffer = 200;


        /// <summary>
        /// The min width value of the event node.
        /// </summary>
        public const int EventNodeMinWidth = 491;


        /// <summary>
        /// The width buffer value of the event node.
        /// </summary>
        public const int EventNodeWidthBuffer = 50;


        /// <summary>
        /// The min width value of the option branch node.
        /// </summary>
        public const int OptionBranchNodeMinWidth = 491;


        /// <summary>
        /// The width buffer value of the option branch node.
        /// </summary>
        public const int OptionBranchNodeWidthBuffer = 50;


        /// <summary>
        /// The min width value of the option root node.
        /// </summary>
        public const int OptionRootNodeMinWidth = 491;


        /// <summary>
        /// The width buffer value of the option root node.
        /// </summary>
        public const int OptionRootNodeWidthBuffer = 50;


        /// <summary>
        /// The min width value of the preview node.
        /// </summary>
        public const int PreviewNodeMinWidth = 456;


        /// <summary>
        /// The width buffer value of the preview node.
        /// </summary>
        public const int PreviewNodeWidthBuffer = 50;


        /// <summary>
        /// The min width value of the start node.
        /// </summary>
        public const int StartNodeMinWidth = 142;


        /// <summary>
        /// The width buffer value of the start node.
        /// </summary>
        public const int StartNodeWidthBuffer = 200;


        /// <summary>
        /// The min width value of the story node.
        /// </summary>
        public const int StoryNodeMinWidth = 424;


        /// <summary>
        /// The width buffer value of the story node.
        /// </summary>
        public const int StoryNodeWidthBuffer = 50;


        // ----------------------------- Node Creation Details -----------------------------
        /// <summary>
        /// The value to use when calculating the final position of the node in the Y azis on the graph when it's created by user manually.
        /// </summary>
        public const float ManualCreateYOffset = 25.5f;
    }
}