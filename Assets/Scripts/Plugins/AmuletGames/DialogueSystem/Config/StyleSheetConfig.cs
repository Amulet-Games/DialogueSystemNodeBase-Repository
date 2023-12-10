using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    [CreateAssetMenu(menuName = "### AG ###/Dialogue System/Config/Append Style Sheets Config")]
    public class StyleSheetConfig : ScriptableObject
    {
        #region Edges.
        [Header("Edges")]
        public StyleSheet DSDefaultEdgeStyle;
        public StyleSheet DSOptionEdgeStyle;
        #endregion

        #region Modifiers.
        [Header("Modifiers")]
        public StyleSheet DSConditionModifierGroupStyle;
        public StyleSheet DSConditionModifierStyle;
        public StyleSheet DSEventModifierGroupStyle;
        public StyleSheet DSEventModifierStyle;
        public StyleSheet DSMessageModifierGroupStyle;
        public StyleSheet DSMessageModifierStyle;
        #endregion

        #region Modules.
        [Header("Modules")]
        public StyleSheet DSGraphViewerStyle;
        public StyleSheet DSHeadBarStyle;
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
        public StyleSheet DSNodeCommonStyle;
        #endregion

        #region Others.
        [Header("Others.")]
        public StyleSheet DSContentButtonStyle;
        public StyleSheet DSFolderStyle;
        #endregion

        #region Port Cells.
        [Header("Port Cells")]
        public StyleSheet DSOptionPortCellStyle;
        #endregion

        #region Ports.
        [Header("Ports")]
        public StyleSheet DSDefaultPortStyle;
        public StyleSheet DSOptionPortStyle;
        public StyleSheet DSPortStyle;
        #endregion

        #region Radio.
        [Header("Radio")]
        public StyleSheet DSRadioGroupStyle;
        public StyleSheet DSRadioStyle;
        #endregion

        #region Dropdown.
        [Header("Dropdown")]
        public StyleSheet DSDropdownStyle;
        public StyleSheet DSDropdownElementStyle;
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