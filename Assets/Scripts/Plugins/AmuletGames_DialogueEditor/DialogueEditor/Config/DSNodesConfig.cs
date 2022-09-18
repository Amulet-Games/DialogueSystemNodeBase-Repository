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