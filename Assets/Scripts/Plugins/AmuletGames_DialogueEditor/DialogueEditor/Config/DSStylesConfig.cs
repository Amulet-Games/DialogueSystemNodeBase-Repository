using UnityEditor;
using UnityEngine.UIElements;

namespace AG
{
    public static class DSStylesConfig
    {
        #region Global.
        public static StyleSheet DSGlobalStyle;
        public const string Global_Display_None = "global_Display_None";
        public const string Global_Visible_Hidden = "global_Visible_Hidden";
        #endregion

        #region Modules.

        #region - StyleSheets.
        public static StyleSheet DSGraphViewStyle;
        public static StyleSheet DSHeadBarStyle;
        public static StyleSheet DSInputHintStyle;
        #endregion

        #region - Head Bar.
        public const string HeadBar_MainBox = "headBar_MainBox";
        public const string HeadBar_LeftSide_SubBox = "headBar_LeftSide_SubBox";
        public const string HeadBar_SaveGraph_Button = "headBar_SaveGraph_Button";
        public const string HeadBar_LoadGraph_Button = "headBar_LoadGraph_Button";
        public const string HeadBar_LanguageSelection_ToolbarMenu = "headBar_LanguageSelection_ToolbarMenu";
        public const string HeadBar_GraphTitle_TextField = "headBar_GraphTitle_TextField";
        #endregion

        #region - Input Hint.
        public const string InputHint_Hint_MainBox = "inputHint_Hint_MainBox";
        public const string InputHint_HintIcon_Image = "inputHint_HintIcon_Image";
        public const string InputHint_HintText_Label = "inputHint_HintText_Label";
        #endregion

        #endregion

        #region Components.

        #region - StyleSheets.
        public static StyleSheet DSModifiersStyle;
        public static StyleSheet DSRootedModifiersStyle;
        public static StyleSheet DSSegmentsStyle;
        public static StyleSheet DSIntegrantsStyle;
        public static StyleSheet DSOptionEntriesStyle;
        public static StyleSheet DSOptionTracksStyle;
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

        #region - Commons.
        public const string Segment_TitleBox_Common = "segment_TitleBox_Common";
        public const string Segment_Title_Label = "segment_Title_Label";
        #endregion

        #region - Expand Button.
        public const string Segment_ExpandSegment_Button = "segment_ExpandSegment_Button";
        #endregion

        #region - Title Enum Field.
        public const string Segment_TitleEnum_EnumField = "segment_TitleEnum_EnumField";
        #endregion

        #region - Dual Portraits.
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

        #region - Dialogue.
        public const string Segment_TitleBox_Dialogue = "segment_TitleBox_Dialogue";
        public const string Segment_Dialogue_ContentBox = "segment_Dialogue_ContentBox";
        public const string Segment_Dialogue_Character_ObjectField = "segment_Dialogue_Character_ObjectField";
        public const string Segment_Dialogue_First_Textline_TextField = "segment_Dialogue_First_Textline_TextField";
        public const string Segment_Dialogue_AudioClip_ObjectField = "segment_Dialogue_AudioClip_ObjectField";
        
        public const string Segment_Dialogue_SecondContentBox = "segment_Dialogue_SecondContentBox";

        public const string Segment_Dialogue_SecondLineTriggerType_CellBox = "segment_Dialogue_SecondLineTriggerType_CellBox";
        public const string Segment_Dialogue_SecondLineTriggerType_Label = "segment_Dialogue_SecondLineTriggerType_Label";
        public const string Segment_Dialogue_SecondLineTriggerType_EnumField = "segment_Dialogue_SecondLineTriggerType_EnumField";

        public const string Segment_Dialogue_Duration_CellBox = "segment_Dialogue_Duration_CellBox";
        public const string Segment_Dialogue_Duration_Label = "segment_Dialogue_Duration_Label";
        public const string Segment_Dialogue_Duration_FloatField = "segment_Dialogue_Duration_FloatField";

        public const string Segment_Dialogue_Second_Textline_TextField = "segment_Dialogue_Second_Textline_TextField";
        #endregion

        #region - Condition.
        public const string Segment_TitleBox_Condition = "segment_TitleBox_Condition";
        public const string Segment_Condition_MainBox = "segment_Condition_MainBox";
        public const string Segment_Condition_ContentBox = "segment_Condition_ContentBox";
        #endregion

        #region - Event.
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

        #region - Commons.
        public const string Channel_Option_RemoveEntry_Button = "channel_Option_RemoveEntry_Button";
        #endregion

        #region - Option.
        // Entry
        public const string Channel_Option_Entry_Port = "channel_Option_Entry_Port";
        public const string Channel_Option_Entry_Connector = "channel_Option_Entry_Connector";
        public const string Channel_Option_Entry_Label = "channel_Option_Entry_Label";
        public const string Channel_Option_Entry_Cap = "channel_Option_Entry_Cap";

        public const string Channel_Option_Entry_Port_Connected = "channel_Option_Entry_Port_Connected";

        // Window Entry
        public const string Channel_Option_Window_Entry_Port = "channel_Option_Window_Entry_Port";
        public const string Channel_Option_Window_Entry_Label = "channel_Option_Window_Entry_Label";

        // Track
        public const string Channel_Option_Track_Port = "channel_Option_Track_Port";
        public const string Channel_Option_Track_Connector = "channel_Option_Track_Connector";
        public const string Channel_Option_Track_Label = "channel_Option_Track_Label";
        public const string Channel_Option_Track_Cap = "channel_Option_Track_Cap";

        public const string Channel_Option_Track_Port_Connected = "channel_Option_Track_Port_Connected";

        // Edge
        public const string Channel_Option_Edge = "channel_Option_Edge";
        public const string Channel_Option_Edge_Selected = "channel_Option_Edge_Selected";
        #endregion

        #endregion

        #endregion

        #region Nodes.

        #region - StyleSheets.
        public static StyleSheet DSNodesShareStyle;
        public static StyleSheet DSBooleanNodeStyle;
        public static StyleSheet DSEndNodeStyle;
        public static StyleSheet DSEventNodeStyle;
        public static StyleSheet DSOptionNodeStyle;
        public static StyleSheet DSPathNodeStyle;
        public static StyleSheet DSStartNodeStyle;
        public static StyleSheet DSStoryNodeStyle;
        #endregion

        #region - Border.
        public const string Node_Border = "node_Border";
        #endregion

        #region - Node Title.
        public const string Node_NodeTitle_MainBox = "node_NodeTitle_MainBox";
        public const string Node_NodeTitle_TextField = "node_NodeTitle_TextField";
        public const string Node_EditTitle_Button = "node_EditTitle_Button";
        #endregion

        #region - Input / Ouput Containers.
        public const string Node_Input_Container = "node_Input_Container";
        public const string Node_Output_Container = "node_Output_Container";
        public const string Node_Output_Container_Window = "node_Output_Container_Window";
        #endregion

        #region - Empty Fields.
        public const string Node_TextField_Empty = "node_TextField_Empty";
        public const string Node_ObjectField_Empty = "node_ObjectField_Empty";
        public const string Node_FloatField_Empty = "node_FloatField_Empty";
        #endregion

        #region - Fields Icons.
        public const string Node_ObjectField_Icon = "node_ObjectField_Icon";
        public const string Node_TextField_Icon = "node_TextField_Icon";
        #endregion

        #region - End Node.
        public const string EndNode_GraphEndHandleType_EnumField = "endNode_GraphEndHandleType_EnumField";
        #endregion

        #region - Option Node.
        public const string OptionNode_OptionHeader_TextField = "optionNode_OptionHeader_TextField";
        #endregion

        #endregion

        #region Ports.

        #region StyleSheets.
        public static StyleSheet DSPortsStyle;
        #endregion

        #region - Connectors.
        public const string Default_Input_Connector = "default_Input_Connector";
        public const string Default_Output_Connector = "default_Output_Connector";
        #endregion

        #region - Labels.
        public const string Default_Input_Label = "default_Input_Label";
        public const string Default_Output_Label = "default_Output_Label";
        #endregion

        #region - Caps.
        public const string Default_Input_Cap = "default_Input_Cap";
        public const string Default_Output_Cap = "default_Output_Cap";
        #endregion

        #region - Ports.
        public const string Default_Input_Port = "default_Input_Port";
        public const string Default_Output_Port = "default_Output_Port";
        public const string Default_Port_Sibling = "default_port_Sibling";
        #endregion

        #endregion

        #region Edges.
        public const string Default_Edge = "default_Edge";
        public const string Default_Edge_Selected = "default_Edge_Selected";
        #endregion

        #region Windows.

        #region Node Title Edit Window.
        public static StyleSheet DSNodeTitleEditWindowStyle;
        #endregion

        #endregion


        // ----------------------------- Setup -----------------------------
        /// <summary>
        /// Setup for the class, used to initialize internal fields.
        /// </summary>
        public static void Setup()
        {
            SetupStyleSheet_Global();

            SetupStyleSheet_Modules();

            SetupStyleSheet_Components();

            SetupStyleSheet_Nodes();

            SetupStyleSheet_Ports();

            SetupStyleSheet_Windows();

            void SetupStyleSheet_Global()
            {
                DSGlobalStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/DSGlobalStyle.uss");
            }

            void SetupStyleSheet_Modules()
            {
                DSGraphViewStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Modules/DSGraphViewStyle.uss");
                DSInputHintStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Modules/DSInputHintStyle.uss");
                DSHeadBarStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Modules/DSHeadBarStyle.uss");
            }

            void SetupStyleSheet_Components()
            {
                // Modifiers
                DSModifiersStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Components/Modifiers/DSModifiersStyle.uss");
                DSRootedModifiersStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Components/Modifiers/DSRootedModifiersStyle.uss");
                
                // Others
                DSSegmentsStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Components/DSSegmentsStyle.uss");
                DSIntegrantsStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Components/DSIntegrantsStyle.uss");
                
                // Option Channels
                DSOptionEntriesStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Components/Channels/Option/DSOptionEntriesStyle.uss");
                DSOptionTracksStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Components/Channels/Option/DSOptionTracksStyle.uss");
            }

            void SetupStyleSheet_Nodes()
            {
                // Share Style
                DSNodesShareStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/DSNodesShareStyle.uss");
                
                // Variants
                DSBooleanNodeStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/Variants/DSBooleanNodeStyle.uss");
                DSEndNodeStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/Variants/DSEndNodeStyle.uss");
                DSEventNodeStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/Variants/DSEventNodeStyle.uss");
                DSOptionNodeStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/Variants/DSOptionNodeStyle.uss");
                DSPathNodeStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/Variants/DSPathNodeStyle.uss");
                DSStartNodeStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/Variants/DSStartNodeStyle.uss");
                DSStoryNodeStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/Variants/DSStoryNodeStyle.uss");
            }

            void SetupStyleSheet_Ports()
            {
                DSPortsStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Ports/DSPortsStyle.uss");
            }

            void SetupStyleSheet_Windows()
            {
                DSNodeTitleEditWindowStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Windows/DSNodeTitleEditWindowStyle.uss");
            }
        }
    }
}