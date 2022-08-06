using UnityEditor;
using UnityEngine.UIElements;

namespace AG
{
    public static class DSStylesConfig
    {
        #region Global.
        /// - StyleSheets.
        public static StyleSheet dsGlobalStyle;

        /// - Class.
        public static string dsGlobal_Display_None = "dsGlobal_Display_None";
        #endregion

        #region Components.

        #region - StyleSheets.
        public static StyleSheet dsModifiersStyle;
        public static StyleSheet dsSegmentsStyle;
        public static StyleSheet dsIntegrantsStyle;
        public static StyleSheet dsRootedModifiersStyle;
        #endregion

        #region - Modifiers.

        #region - Commons
        public static string modifier_RemoveModifier_Button = "modifier_RemoveModifier_Button";
        #endregion

        #region - Condition
        public static string modifier_Condition_MainBox = "modifier_Condition_MainBox";
        public static string modifier_Condition_TextField = "modifier_Condition_TextField";
        public static string modifier_Condition_EnumField = "modifier_Condition_EnumField";
        public static string modifier_Condition_FloatField = "modifier_Condition_FloatField";

        public static string modifier_Condition_Rooted_TextField = "modifier_Condition_Rooted_TextField";
        public static string modifier_Condition_Rooted_EnumField = "modifier_Condition_Rooted_EnumField";
        public static string modifier_Condition_Rooted_FloatField = "modifier_Condition_Rooted_FloatField";
        #endregion

        #region - Event
        public static string modifier_Event_MainBox = "modifier_Event_MainBox";
        public static string modifier_Event_ObjectField = "modifier_Event_ObjectField";

        public static string modifier_Event_Rooted_ObjectField = "modifier_Event_Rooted_ObjectField";
        #endregion

        #endregion

        #region - Segments.

        #region - Commons
        public static string segment_TitleBox_Common = "segment_TitleBox_Common";
        public static string segment_Title_Label = "segment_Title_Label";
        #endregion

        #region - Expand Button.
        public static string segment_ExpandSegment_Button = "segment_ExpandSegment_Button";
        #endregion

        #region - Image Preview
        public static string segment_TitleBox_DualPortraits = "segment_TitleBox_DualPortraits";

        public static string segment_DualPortraits_ImagesBox = "segment_DualPortraits_ImagesBox";
        public static string segment_DualPortraits_Images = "segment_DualPortraits_Images";
        public static string segment_DualPortraits_Image_L = "segment_DualPortraits_Image_L";
        public static string segment_DualPortraits_Image_R = "segment_DualPortraits_Image_R";

        public static string segment_DualPortraits_ObjectFieldsBox = "segment_DualPortraits_ObjectFieldsBox";
        public static string segment_DualPortraits_ObjectFields = "segment_DualPortraits_ObjectFields";
        public static string segment_DualPortraits_ObjectField_L = "segment_DualPortraits_ObjectField_L";
        public static string segment_DualPortraits_ObjectField_R = "segment_DualPortraits_ObjectField_R";
        #endregion

        #region - Speaker Name
        public static string segment_TitleBox_SpeakerName = "segment_TitleBox_SpeakerName";
        public static string segment_SpeakerName_ContentBox = "segment_SpeakerName_ContentBox";
        public static string segment_SpeakerName_TextField = "segment_SpeakerName_TextField";
        #endregion

        #region - Textline
        public static string segment_TitleBox_Textline = "segment_TitleBox_Textline";
        public static string segment_Textline_ContentBox = "segment_Textline_ContentBox";
        public static string segment_Textline_TextField = "segment_Textline_TextField";
        public static string segment_Textline_ObjectField = "segment_Textline_ObjectField";
        #endregion

        #region - Condition
        public static string segment_TitleBox_Condition = "segment_TitleBox_Condition";
        public static string segment_Condition_MainBox = "segment_Condition_MainBox";
        public static string segment_Condition_ContentBox = "segment_Condition_ContentBox";
        public static string segment_Condition_ConditionDisplayEnumField = "segment_Condition_ConditionDisplayEnumField";
        #endregion

        #region - Event
        public static string segment_TitleBox_Event = "segment_TitleBox_Event";
        public static string segment_Event_MainBox = "segment_Event_MainBox";
        public static string segment_Event_ContentBox = "segment_Event_ContentBox";
        #endregion

        #endregion

        #region - Integrants.

        #region - Content Button.
        public static string integrant_ContentButton_MainBox = "integrant_ContentButton_MainBox";
        public static string integrant_ContentButton_Label = "integrant_ContentButton_Label";
        public static string integrant_ContentButton_AddChoiceEntry_Image = "integrant_ContentButton_AddChoiceEntry_Image";
        public static string integrant_ContentButton_AddCondition_Image = "integrant_ContentButton_AddCondition_Image";
        public static string integrant_ContentButton_AddEvent_Image = "integrant_ContentButton_AddEvent_Image";
        #endregion

        #endregion

        #region - Entries.

        #region - Commons
        public static string entry_RemoveModifier_Button = "entry_RemoveModifier_Button";
        #endregion

        #endregion

        #endregion

        #region Editor Window.

        #region - StyleSheets.
        public static StyleSheet dsHeadBarStyle;
        #endregion

        #region - HeadBar.
        // Title
        public static string headBar_TitleTextField = "headBar_TitleTextField";

        // Box
        public static string headBar_LeftSideSubBox = "headBar_LeftSideSubBox";

        // Buttons
        public static string headBar_SaveButton = "headBar_SaveButton";
        public static string headBar_LoadButton = "headBar_LoadButton";

        // Toolbar Menu
        public static string headBar_LanguageToolbarMenu = "headBar_LanguageToolbarMenu";
        #endregion

        #endregion

        #region Graph View.

        #region - StyleSheets.
        public static StyleSheet dsGraphViewStyle;
        public static StyleSheet dsInputHintStyle;
        #endregion

        #region - Input Hint
        public static string inputHint_MainBox = "inputHint_MainBox";
        public static string inputHint_IconImage = "inputHint_IconImage";
        public static string inputHint_HintLabel = "inputHint_HintLabel";
        #endregion

        #endregion

        #region Nodes.

        #region - StyleSheets.
        public static StyleSheet _nodesShareStyle;
        public static StyleSheet startNodeStyle;
        public static StyleSheet dialogueNodeStyle;
        public static StyleSheet choiceNodeStyle;
        public static StyleSheet eventNodeStyle;
        public static StyleSheet branchNodeStyle;
        public static StyleSheet endNodeStyle;
        #endregion

        #region - Generals.
        public static string nodeShare_ObjectField_Empty = "nodeShare_ObjectField_Empty";
        public static string nodeShare_TextField_Empty = "nodeShare_TextField_Empty";
        #endregion

        #region - End Node.
        public static string endNode_GraphEndHandleType_EnumField = "endNode_GraphEndHandleType_EnumField";
        #endregion

        #endregion

        #region Setup.
        public static void Setup()
        {
            SetupStyleSheet_DSGlobal();

            SetupStyleSheet_DSComponents();

            SetupStyleSheet_EditorWindow();

            SetupStyleSheet_GraphView();

            SetupStyleSheet_Nodes();

            void SetupStyleSheet_DSGlobal()
            {
                dsGlobalStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/DSGlobal.uss");
            }

            void SetupStyleSheet_DSComponents()
            {
                dsModifiersStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Components/DSModifiersStyle.uss");
                dsSegmentsStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Components/DSSegmentsStyle.uss");
                dsIntegrantsStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Components/DSIntegrantsStyle.uss");
                dsRootedModifiersStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Components/DSRootedModifiersStyle.uss");
            }

            void SetupStyleSheet_EditorWindow()
            {
                dsHeadBarStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/EditorWindow/DSHeadBarStyle.uss");
            }

            void SetupStyleSheet_GraphView()
            {
                dsGraphViewStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/GraphView/DSGraphViewStyle.uss");
                dsInputHintStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/GraphView/DSInputHintStyle.uss");
            }

            void SetupStyleSheet_Nodes()
            {
                _nodesShareStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/_NodesShareStyle.uss");
                startNodeStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/StartNodeStyle.uss");
                dialogueNodeStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/DialogueNodeStyle.uss");
                choiceNodeStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/ChoiceNodeStyle.uss");
                eventNodeStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/EventNodeStyle.uss");
                branchNodeStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/BranchNodeStyle.uss");
                endNodeStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/EndNodeStyle.uss");
            }
        }
        #endregion
    }
}