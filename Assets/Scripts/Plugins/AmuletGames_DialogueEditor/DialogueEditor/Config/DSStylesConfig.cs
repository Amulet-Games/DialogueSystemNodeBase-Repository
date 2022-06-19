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
        #endregion

        #region - Modifiers.

        #region - Commons
        public static string modifier_Common_RemoveButton = "modifier_Common_RemoveButton";
        #endregion

        #region - Condition
        public static string modifier_Condition_MainBox = "modifier_Condition_MainBox";
        public static string modifier_Condition_TextField = "modifier_Condition_TextField";
        public static string modifier_Condition_EnumField = "modifier_Condition_EnumField";
        public static string modifier_Condition_FloatField = "modifier_Condition_FloatField";
        #endregion

        #region - Basic Event
        public static string modifier_BasicEvent_MainBox = "modifier_BasicEvent_MainBox";
        public static string modifier_BasicEvent_TextField = "modifier_BasicEvent_TextField";
        public static string modifier_BasicEvent_EnumField = "modifier_BasicEvent_EnumField";
        public static string modifier_BasicEvent_FloatField = "modifier_BasicEvent_FloatField";
        #endregion

        #region - Scriptable Event
        public static string modifier_ScriptableEvent_MainBox = "modifier_ScriptableEvent_MainBox";
        public static string modifier_ScriptableEvent_ObjectField = "modifier_ScriptableEvent_ObjectField";
        #endregion

        #endregion

        #region - Segments.

        #region - Commons
        public static string segment_Title_MainBox = "segment_Title_MainBox";
        public static string segment_Title_Label = "segment_Title_Label";
        public static string segment_Title_RemoveButton = "segment_Title_RemoveButton";
        #endregion

        #region - Image Preview
        // Title
        public static string segment_ImagePreview_TitleBox = "segment_ImagePreview_TitleBox";

        // Image Style
        public static string segment_ImagePreview_ImagesBox = "segment_ImagePreview_ImagesBox";
        public static string segment_ImagePreivew_Images = "segment_ImagePreivew_Images";
        public static string segment_ImagePreivew_Image_L = "segment_ImagePreivew_Image_L";
        public static string segment_ImagePreivew_Image_R = "segment_ImagePreivew_Image_R";

        // Object Field Style
        public static string segment_ImagePreview_ObjectFieldsBox = "segment_ImagePreview_ObjectFieldsBox";
        public static string segment_ImagePreivew_ObjectField_L = "segment_ImagePreivew_ObjectField_L";
        public static string segment_ImagePreivew_ObjectField_R = "segment_ImagePreivew_ObjectField_R";
        #endregion

        #region - Speaker Name
        // Title
        public static string segment_SpeakerName_TitleBox = "segment_SpeakerName_TitleBox";

        // Text Field Style
        public static string segment_SpeakerName_TextField = "segment_SpeakerName_TextField";
        #endregion

        #region - LG Textline
        // Title
        public static string segment_LGTextline_TitleBox = "segment_LGTextline_TitleBox";
        #endregion

        #endregion

        #endregion

        #region Editor Window.

        #region - StyleSheets.
        public static StyleSheet dsEditorWindowStyle;
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
        public static string inputHint_HintImage = "inputHint_HintImage";
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
        public static string nodeShare_TextField_Empty = "unity-text-field__placeholder";
        #endregion

        #region - Dialogue.
        public static string dialogueNode_AddChoiceButton = "dialogueNode_AddChoiceButton";
        #endregion

        #region - LGs.
        public static string languageGenerics_Text_TextField = "languageGenerics_Text_TextField";
        public static string languageGenerics_AudioClip_ObjectField = "languageGenerics_AudioClip_ObjectField";
        #endregion

        #region - Enum Settings.
        public static string unmetConditionDisplayOption_MainBox = "unmetConditionDisplayOption_MainBox";
        public static string unmetConditionDisplayOption_EnumField = "unmetConditionDisplayOption_EnumField";
        public static string unmetConditionDisplayOption_Label = "unmetConditionDisplayOption_Label";
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
            }

            void SetupStyleSheet_EditorWindow()
            {
                dsEditorWindowStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/EditorWindow/DSEditorWindowStyle.uss");
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