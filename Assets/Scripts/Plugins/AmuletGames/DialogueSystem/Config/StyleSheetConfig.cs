using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    [CreateAssetMenu(menuName = "### AG ###/Dialogue System/Config/New Style Sheets Config")]
    public class StyleSheetConfig : ScriptableObject
    {
        #region Channels.
        [Header("Channels")]
        public StyleSheet DSInputOptionChannelStyle;
        public StyleSheet DSOutputOptionChannelStyle;
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

        #region Modules.
        [Header("Modules")]
        public StyleSheet DSGraphViewerStyle;
        public StyleSheet DSHeadbarStyle;
        public StyleSheet DSInputHintStyle;
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
        public StyleSheet DSNodesShareStyle;
        #endregion

        #region Ports.
        [Header("Ports")]
        public StyleSheet DSPortStyle;
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