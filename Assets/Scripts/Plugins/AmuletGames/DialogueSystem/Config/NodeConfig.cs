using System;

namespace AG.DS
{
    /// <summary>
    /// Class that stores the config data relating to node creation.
    /// </summary>
    public static class NodeConfig
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


        /// <summary>
        /// The value to use when calculating the final position of the node in relation to the Y axis of the graph.
        /// </summary>
        public const float ManualCreateYOffset = 25.5f;
    }
}