using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    [CreateAssetMenu(menuName = "### AG ###/Dialogue System/Config/Append Style Sheets Config")]
    public class StyleSheetConfig : ScriptableObject
    {
        #region Dropdown.
        [Header("Dropdown")]
        public StyleSheet DropdownItemStyle;
        public StyleSheet DropdownStyle;
        #endregion

        #region Edges.
        [Header("Edges")]
        public StyleSheet DefaultEdgeStyle;
        public StyleSheet OptionEdgeStyle;
        #endregion

        #region Enum Flags.
        [Header("Enum Flags")]
        public StyleSheet EnumFlagsStyle;
        public StyleSheet FlagElementStyle;
        #endregion

        #region Modifiers.
        [Header("Modifiers")]
        public StyleSheet ConditionModifierGroupStyle;
        public StyleSheet ConditionModifierStyle;
        public StyleSheet EventModifierGroupStyle;
        public StyleSheet EventModifierStyle;
        public StyleSheet MessageModifierGroupStyle;
        public StyleSheet MessageModifierStyle;
        #endregion

        #region Modules.
        [Header("Modules")]
        public StyleSheet GraphViewerStyle;
        public StyleSheet HeadbarStyle;
        public StyleSheet InputHintStyle;
        #endregion

        #region Nodes.
        [Header("Nodes")]
        public StyleSheet BooleanNodeStyle;
        public StyleSheet DialogueNodeStyle;
        public StyleSheet EndNodeStyle;
        public StyleSheet EventNodeStyle;
        public StyleSheet OptionBranchNodeStyle;
        public StyleSheet OptionRootNodeStyle;
        public StyleSheet PreviewNodeStyle;
        public StyleSheet StartNodeStyle;
        public StyleSheet StoryNodeStyle;
        public StyleSheet NodeCommonStyle;
        #endregion

        #region Others.
        [Header("Others.")]
        public StyleSheet ContentButtonStyle;
        public StyleSheet FolderStyle;
        #endregion

        #region Port Cells.
        [Header("Port Cells")]
        public StyleSheet OptionPortCellStyle;
        public StyleSheet OptionPortGroupCellStyle;
        #endregion

        #region Ports.
        [Header("Ports")]
        public StyleSheet PortStyle;
        #endregion

        #region Radio.
        [Header("Radio")]
        public StyleSheet RadioGroupStyle;
        public StyleSheet RadioStyle;
        #endregion

        #region Globals.
        [Header("Globals")]
        public StyleSheet GlobalStyle;
        #endregion

        #region Legacy.
        [Header("Legacy.")]
        public StyleSheet DSModifierStyle;
        public StyleSheet DSRootedModifierStyle;
        public StyleSheet DSSegmentStyle;
        #endregion
    }
}