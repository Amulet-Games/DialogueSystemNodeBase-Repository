using System;

namespace AG
{
    /// <summary>
    /// Class that stores config data for any node creation in the dialogue system.
    /// <br>The values here would be used by other module class when creating nodes,</br>
    /// <br>and unlike other config classes, the values here can be altered and saved.</br>
    /// </summary>
    [Serializable]
    public class DSNodesConfig
    {
        // ----------------------------- Node Width -----------------------------
        /// <summary>
        /// The min width value of the boolean node.
        /// </summary>
        public const int BooleanNodeMinWidth = 519;


        /// <summary>
        /// The max width value of the boolean node.
        /// </summary>
        public const int BooleanNodeMaxWidthBuffer = 25;


        /// <summary>
        /// The min width value of the end node.
        /// </summary>
        public const int EndNodeMinWidth = 157;


        /// <summary>
        /// The max width value of the end node.
        /// </summary>
        public const int EndNodeMaxWidthBuffer = 200;


        /// <summary>
        /// The min width value of the event node.
        /// </summary>
        public const int EventNodeMinWidth = 491;


        /// <summary>
        /// The max width value of the event node.
        /// </summary>
        public const int EventNodeMaxWidthBuffer = 50;


        /// <summary>
        /// The min width value of the option node.
        /// </summary>
        public const int OptionNodeMinWidth = 519;


        /// <summary>
        /// The max width value of the option node.
        /// </summary>
        public const int OptionNodeMaxWidthBuffer = 25;


        /// <summary>
        /// The min width value of the path node.
        /// </summary>
        public const int PathNodeMinWidth = 424;


        /// <summary>
        /// The max width value of the path node.
        /// </summary>
        public const int PathNodeMaxWidthBuffer = 50;


        /// <summary>
        /// The min width value of the start node.
        /// </summary>
        public const int StartNodeMinWidth = 142;


        /// <summary>
        /// The max width value of the start node.
        /// </summary>
        public const int StartNodeMaxWidthBuffer = 200;


        /// <summary>
        /// The min width value of the story node.
        /// </summary>
        public const int StoryNodeMinWidth = 424;


        /// <summary>
        /// The max width value of the story node.
        /// </summary>
        public const int StoryNodeMaxWidthBuffer = 50;


        // ----------------------------- Node Creation Details -----------------------------
        /// <summary>
        /// The value to use when calculating the final position of the node in the Y azis on the graph when it's created by user manually.
        /// </summary>
        public const float ManualCreateYOffset = 25.5f;


        /// <summary>
        /// The value that tells which side of the node should be aligned to horizontally when it's created on the graph.
        /// <para></para>
        /// <br>Note that the value'll only be used when the node is created from graphView's NodeCreationRequest method.</br>
        /// </summary>
        public static C_Alignment_HorizontalType HorizontalAlignType = C_Alignment_HorizontalType.Middle;
    }
}