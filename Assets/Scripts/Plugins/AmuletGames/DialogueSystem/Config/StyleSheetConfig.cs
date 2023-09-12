using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    [CreateAssetMenu(menuName = "### AG ###/Dialogue System/Config/New Style Sheets Config")]
    public class StyleSheetConfig : ScriptableObject
    {
        #region Modules.
        [Header("Modules")]
        public StyleSheet DSGraphViewerStyle;
        public StyleSheet DSHeadBarStyle;
        public StyleSheet DSInputHintStyle;
        #endregion

        #region Modifiers.
        [Header("Modifiers")]
        public StyleSheet DSEventModifierStyle;
        #endregion

        #region Modifier Groups.
        [Header("Modifier Groups")]
        public StyleSheet DSEventModifierGroupStyle;
        #endregion

        #region Elements.
        [Header("Elements.")]
        public StyleSheet DSContentButtonStyle;
        public StyleSheet DSFolderStyle;
        #endregion

        #region Nodes.
        [Header("Nodes")]
        public StyleSheet DSBooleanNodeStyle;
        public StyleSheet DSDialogueNodeStyle;
        public StyleSheet DSEndNodeStyle;
        public StyleSheet DSEventNodeStyle;
        public StyleSheet DSOptionBranchNodeStyle;
        public StyleSheet DSOptionRootNodeStyle;
        public StyleSheet DSPreviewNodeStyle;
        public StyleSheet DSStartNodeStyle;
        public StyleSheet DSStoryNodeStyle;
        public StyleSheet DSNodeCommonStyle;
        #endregion

        #region Port Groups.
        [Header("Port Groups")]
        public StyleSheet DSOptionPortGroupStyle;
        #endregion

        #region Ports.
        [Header("Ports")]
        public StyleSheet DSDefaultPortStyle;
        public StyleSheet DSOptionPortStyle;
        public StyleSheet DSPortStyle;
        #endregion

        #region Edges.
        [Header("Edges")]
        public StyleSheet DSDefaultEdgeStyle;
        public StyleSheet DSOptionEdgeStyle;
        #endregion

        #region Globals.
        [Header("Globals")]
        public StyleSheet DSGlobalStyle;
        #endregion

        #region Legacy.
        [Header("Legacy.")]
        public StyleSheet DSModifierStyle;
        public StyleSheet DSRootedModifierStyle;
        public StyleSheet DSSegmentStyle;
        #endregion
    }
}