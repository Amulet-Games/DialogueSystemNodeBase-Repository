using UnityEditor;
using UnityEngine.UIElements;

namespace AG
{
    public static class DSStylesConfig
    {
        #region Global.
        public static StyleSheet DSGlobalStyle;
        public const string DSGlobal_Display_None = "dsGlobal_Display_None";
        #endregion

        #region Graph View.
        public static StyleSheet DSGraphViewStyle;
        #endregion

        #region Components.

        #region - StyleSheets.
        public static StyleSheet DSModifiersStyle;
        public static StyleSheet DSRootedModifiersStyle;
        public static StyleSheet DSSegmentsStyle;
        public static StyleSheet DSIntegrantsStyle;
        public static StyleSheet DSEntriesStyle;
        public static StyleSheet DSTracksStyle;
        #endregion

        #region - Modifiers.

        #region - Commons
        public const string Modifier_RemoveModifier_Button = "modifier_RemoveModifier_Button";
        #endregion

        #region - Condition
        public const string Modifier_Condition_MainBox = "modifier_Condition_MainBox";
        public const string Modifier_Condition_TextField = "modifier_Condition_TextField";
        public const string Modifier_Condition_EnumField = "modifier_Condition_EnumField";
        public const string Modifier_Condition_FloatField = "modifier_Condition_FloatField";

        public const string Modifier_Condition_Rooted_MainBox = "modifier_Condition_Rooted_MainBox";
        public const string Modifier_Condition_Rooted_TextField = "modifier_Condition_Rooted_TextField";
        public const string Modifier_Condition_Rooted_EnumField = "modifier_Condition_Rooted_EnumField";
        public const string Modifier_Condition_Rooted_FloatField = "modifier_Condition_Rooted_FloatField";
        #endregion

        #region - Event
        public const string Modifier_Event_MainBox = "modifier_Event_MainBox";
        public const string Modifier_Event_ObjectField = "modifier_Event_ObjectField";

        public const string Modifier_Event_Rooted_MainBox = "modifier_Event_Rooted_MainBox";
        public const string Modifier_Event_Rooted_ObjectField = "modifier_Event_Rooted_ObjectField";
        #endregion

        #endregion

        #region - Segments.

        #region - Commons
        public const string Segment_TitleBox_Common = "segment_TitleBox_Common";
        public const string Segment_Title_Label = "segment_Title_Label";
        #endregion

        #region - Expand Button.
        public const string Segment_ExpandSegment_Button = "segment_ExpandSegment_Button";
        #endregion

        #region - Image Preview
        public const string Segment_TitleBox_DualPortraits = "segment_TitleBox_DualPortraits";
        public const string Segment_DualPortraits_ContentBox = "segment_DualPortraits_ContentBox";

        public const string Segment_DualPortraits_ImagesBox = "segment_DualPortraits_ImagesBox";
        public const string Segment_DualPortraits_Images = "segment_DualPortraits_Images";
        public const string Segment_DualPortraits_Image_L = "segment_DualPortraits_Image_L";
        public const string Segment_DualPortraits_Image_R = "segment_DualPortraits_Image_R";

        public const string Segment_DualPortraits_ObjectFieldsBox = "segment_DualPortraits_ObjectFieldsBox";
        public const string Segment_DualPortraits_ObjectFields = "segment_DualPortraits_ObjectFields";
        public const string Segment_DualPortraits_ObjectField_L = "segment_DualPortraits_ObjectField_L";
        public const string Segment_DualPortraits_ObjectField_R = "segment_DualPortraits_ObjectField_R";
        #endregion

        #region - Speaker Name
        public const string Segment_TitleBox_SpeakerName = "segment_TitleBox_SpeakerName";
        public const string Segment_SpeakerName_ContentBox = "segment_SpeakerName_ContentBox";
        public const string Segment_SpeakerName_TextField = "segment_SpeakerName_TextField";
        #endregion

        #region - Textline
        public const string Segment_TitleBox_Textline = "segment_TitleBox_Textline";
        public const string Segment_Textline_ContentBox = "segment_Textline_ContentBox";
        public const string Segment_Textline_TextField = "segment_Textline_TextField";
        public const string Segment_Textline_ObjectField = "segment_Textline_ObjectField";
        #endregion

        #region - Condition
        public const string Segment_TitleBox_Condition = "segment_TitleBox_Condition";
        public const string Segment_Condition_MainBox = "segment_Condition_MainBox";
        public const string Segment_Condition_ContentBox = "segment_Condition_ContentBox";
        public const string Segment_Condition_UnmetOptionDisplayEnumField = "segment_Condition_UnmetOptionDisplayEnumField";
        #endregion

        #region - Event
        public const string Segment_TitleBox_Event = "segment_TitleBox_Event";
        public const string Segment_Event_MainBox = "segment_Event_MainBox";
        public const string Segment_Event_ContentBox = "segment_Event_ContentBox";
        #endregion

        #endregion

        #region - Integrants.

        #region - Content Button.
        public const string Integrant_ContentButton_MainBox = "integrant_ContentButton_MainBox";
        public const string Integrant_ContentButton_Label = "integrant_ContentButton_Label";
        public const string Integrant_ContentButton_AddOptionEntry_Image = "integrant_ContentButton_AddChoiceEntry_Image";
        public const string Integrant_ContentButton_AddCondition_Image = "integrant_ContentButton_AddCondition_Image";
        public const string Integrant_ContentButton_AddEvent_Image = "integrant_ContentButton_AddEvent_Image";
        #endregion

        #endregion

        #region - Channel.

        #region - Commons
        public const string Channel_RemoveEntry_Button = "channel_RemoveEntry_Button";
        #endregion

        #region - Option
        // Entry
        public const string Channel_Entry_Port = "channel_Entry_Port";
        public const string Channel_Entry_Connector = "channel_Entry_Connector";
        public const string Channel_Entry_Label = "channel_Entry_Label";
        public const string Channel_Entry_Cap = "channel_Entry_Cap";

        public const string Channel_Entry_Port_Connected = "channel_Entry_Port_Connected";

        // Track
        public const string Channel_Track_Port = "channel_Track_Port";
        public const string Channel_Track_Connector = "channel_Track_Connector";
        public const string Channel_Track_Label = "channel_Track_Label";
        public const string Channel_Track_Cap = "channel_Track_Cap";

        public const string Channel_Track_Port_Connected = "channel_Track_Port_Connected";
        #endregion

        #endregion

        #endregion

        #region Head Bar.
        public static StyleSheet DSHeadBarStyle;

        public const string HeadBar_Title_TextField = "headBar_Title_TextField";
        public const string HeadBar_LeftSide_SubBox = "headBar_LeftSide_SubBox";
        public const string HeadBar_SaveGraph_Button = "headBar_SaveGraph_Button";
        public const string HeadBar_LoadGraph_Button = "headBar_LoadGraph_Button";
        public const string HeadBar_LanguageSelection_ToolbarMenu = "headBar_LanguageSelection_ToolbarMenu";
        #endregion

        #region Input Hint.
        public static StyleSheet DSInputHintStyle;

        public const string InputHint_Hint_MainBox = "inputHint_Hint_MainBox";
        public const string InputHint_HintIcon_Image = "inputHint_HintIcon_Image";
        public const string InputHint_HintText_Label = "inputHint_HintText_Label";
        #endregion

        #region Nodes.

        #region - StyleSheets.
        public static StyleSheet DSNodesShareStyle;
        public static StyleSheet StartNodeStyle;
        public static StyleSheet DialogueNodeStyle;
        public static StyleSheet OptionNodeStyle;
        public static StyleSheet EventNodeStyle;
        public static StyleSheet BranchNodeStyle;
        public static StyleSheet EndNodeStyle;
        #endregion

        #region - Border.
        public const string Node_Border = "node_Border";
        #endregion

        #region - Input / Ouput Containers.
        public const string Node_Input_Container = "node_Input_Container";
        public const string Node_Output_Container = "node_Output_Container";
        public const string Node_Output_Container_Window = "node_Output_Container_Window";
        #endregion

        #region - Input / Ouput Ports.
        public const string Node_Input_Port = "node_Input_Port";
        public const string Node_Output_Port = "node_Output_Port";
        public const string Node_Port_Sibling = "node_Port_Sibling";
        #endregion

        #region - Input / Ouput Connectors.
        public const string Node_Input_Connector = "node_Input_Connector";
        public const string Node_Output_Connector = "node_Output_Connector";
        #endregion

        #region - Input / Ouput Labels.
        public const string Node_Input_Label = "node_Input_Label";
        public const string Node_Output_Label = "node_Output_Label";
        #endregion

        #region - Input / Ouput Cap.
        public const string Node_Input_Cap = "node_Input_Cap";
        public const string Node_Output_Cap = "node_Output_Cap";
        #endregion

        #region - Empty Fields.
        public const string Node_TextField_Empty = "node_TextField_Empty";
        public const string Node_ObjectField_Empty = "node_ObjectField_Empty";
        #endregion

        #region - End Node.
        public const string EndNode_GraphEndHandleType_EnumField = "endNode_GraphEndHandleType_EnumField";
        #endregion

        #endregion

        #region Setup.
        public static void Setup()
        {
            SetupStyleSheet_DSGlobal();

            SetupStyleSheet_GraphView();

            SetupStyleSheet_DSComponents();

            SetupStyleSheet_HeaderBar();

            SetupStyleSheet_InputHint();

            SetupStyleSheet_Nodes();

            void SetupStyleSheet_DSGlobal()
            {
                DSGlobalStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/DSGlobal.uss");
            }

            void SetupStyleSheet_GraphView()
            {
                DSGraphViewStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/GraphView/DSGraphViewStyle.uss");
            }

            void SetupStyleSheet_DSComponents()
            {
                DSModifiersStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Components/DSModifiersStyle.uss");
                DSRootedModifiersStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Components/DSRootedModifiersStyle.uss");
                DSSegmentsStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Components/DSSegmentsStyle.uss");
                DSIntegrantsStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Components/DSIntegrantsStyle.uss");
                DSEntriesStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Components/DSEntriesStyle.uss");
                DSTracksStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Components/DSTracksStyle.uss");
            }

            void SetupStyleSheet_InputHint()
            {
                DSInputHintStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/GraphView/DSInputHintStyle.uss");
            }

            void SetupStyleSheet_HeaderBar()
            {
                DSHeadBarStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/EditorWindow/DSHeadBarStyle.uss");
            }

            void SetupStyleSheet_Nodes()
            {
                DSNodesShareStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/DSNodesShareStyle.uss");
                StartNodeStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/Variants/StartNodeStyle.uss");
                DialogueNodeStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/Variants/DialogueNodeStyle.uss");
                OptionNodeStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/Variants/OptionNodeStyle.uss");
                EventNodeStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/Variants/EventNodeStyle.uss");
                BranchNodeStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/Variants/BranchNodeStyle.uss");
                EndNodeStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/Variants/EndNodeStyle.uss");
            }
        }
        #endregion
    }
}