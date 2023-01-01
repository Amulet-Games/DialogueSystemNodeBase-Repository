using UnityEditor;
using UnityEngine.UIElements;

namespace AG.DS
{
    public static class StylesConfig
    {
        #region Global.
        public static StyleSheet DSGlobalStyle;
        public const string Global_Display_None = "global_Display_None";
        public const string Global_Visible_Hidden = "global_Visible_Hidden";
        public const string Global_Interactable_Disable = "global_Picking_Ignore";
        #endregion

        #region Modules.

        #region - StyleSheets.
        public static StyleSheet DSGraphViewStyle;
        public static StyleSheet DSHeadBarStyle;
        public static StyleSheet DSInputHintStyle;
        #endregion

        #region - HeadBar.
        public const string HeadBar_Main_Box = "headBar_Main_Box";
        public const string HeadBar_LeftSide_Box = "headBar_LeftSide_Box";
        public const string HeadBar_SaveGraph_Button = "headBar_SaveGraph_Button";
        public const string HeadBar_LoadGraph_Button = "headBar_LoadGraph_Button";
        public const string HeadBar_LanguageSelection_ToolbarMenu = "headBar_LanguageSelection_ToolbarMenu";
        public const string HeadBar_GraphTitle_TextField = "headBar_GraphTitle_TextField";
        #endregion

        #region - Input Hint.
        public const string InputHint_Main_Box = "inputHint_Main_Box";
        public const string InputHint_Icon_Image = "inputHint_Icon_Image";
        public const string InputHint_Text_Label = "inputHint_Text_Label";
        #endregion

        #endregion

        #region Components.

        #region - StyleSheets.
        public static StyleSheet DSModifiersStyle;
        public static StyleSheet DSRootedModifiersStyle;
        public static StyleSheet DSSegmentsStyle;
        public static StyleSheet DSFolderStyle;
        public static StyleSheet DSIntegrantsStyle;
        public static StyleSheet DSOutputOptionChannelsStyle;
        public static StyleSheet DSInputOptionChannelsStyle;
        #endregion

        #region - Modifiers.

        #region - Message.
        public const string Modifier_Message_Main_Box = "modifier_Message_Main_Box";
        public const string Modifier_Message_RemoveModifier_Button = "modifier_Message_RemoveModifier_Button";

        /*< -------------------- Root -------------------- >*/
        public const string Modifier_Message_Rooted_Main_Box = "modifier_Message_Rooted_Main_Box";
        #endregion

        #region - Event.
        public const string Modifier_Event_Main_Box = "modifier_Event_Main_Box";
        public const string Modifier_Event_ObjectField = "modifier_Event_ObjectField";
        public const string Modifier_Event_RemoveModifier_Button = "modifier_Event_RemoveModifier_Button";

        /*< -------------------- Root -------------------- >*/
        public const string Modifier_Event_Rooted_Main_Box = "modifier_Event_Rooted_Main_Box";
        public const string Modifier_Event_Rooted_ObjectField = "modifier_Event_Rooted_ObjectField";
        #endregion

        #region - Condition.
        public const string Modifier_Condition_Main_Box = "modifier_Condition_Main_Box";
        public const string Modifier_Condition_FirstTerm_ObjectField = "modifier_Condition_FirstTerm_ObjectField";

        public const string Modifier_Condition_Operator_EnumField = "modifier_Condition_Operator_EnumField";
        public const string Modifier_Condition_Operator_Icon = "modifier_Condition_Operator_Icon";

        public const string Modifier_Condition_SecondTerm_TextField = "modifier_Condition_SecondTerm_TextField";
        public const string Modifier_Condition_SecondTerm_FloatField = "modifier_Condition_SecondTerm_FloatField";
        public const string Modifier_Condition_SecondTerm_ObjectField = "modifier_Condition_SecondTerm_ObjectField";

        public const string Modifier_Condition_Button_Box = "modifier_Condition_Button_Box";
        public const string Modifier_Condition_ChangeFieldType_Button = "modifier_Condition_ChangeFieldType_Button";
        public const string Modifier_Condition_RemoveModifier_Button = "modifier_Condition_RemoveModifier_Button";

        /*< -------------------- Root -------------------- >*/
        public const string Modifier_Condition_Rooted_Main_Box = "modifier_Condition_Rooted_Main_Box";
        public const string Modifier_Condition_Rooted_FirstTerm_ObjectField = "modifier_Condition_Rooted_FirstTerm_ObjectField";

        public const string Modifier_Condition_Rooted_Operator_EnumField = "modifier_Condition_Rooted_Operator_EnumField";
        public const string Modifier_Condition_Rooted_Operator_Icon = "modifier_Condition_Rooted_Operator_Icon";

        public const string Modifier_Condition_Rooted_SecondTerm_TextField = "modifier_Condition_Rooted_SecondTerm_TextField";
        public const string Modifier_Condition_Rooted_SecondTerm_FloatField = "modifier_Condition_Rooted_SecondTerm_FloatField";
        public const string Modifier_Condition_Rooted_SecondTerm_ObjectField = "modifier_Condition_Rooted_SecondTerm_ObjectField";

        public const string Modifier_Condition_Rooted_Button_Box = "modifier_Condition_Rooted_Button_Box";
        public const string Modifier_Condition_Rooted_ChangeFieldType_Button = "modifier_Condition_Rooted_ChangeFieldType_Button";
        #endregion

        #endregion

        #region - Segments.

        #region - Commons.
        public const string Segment_Common_Title_Box = "segment_Common_Title_Box";
        public const string Segment_Common_Title_Label = "segment_Common_Title_Label";
        public const string Segment_Common_Title_EnumField = "segment_Common_Title_EnumField";
        public const string Segment_Common_ExpandSegment_Button = "segment_Common_ExpandSegment_Button";
        #endregion

        #region - Dialogue.
        public const string Segment_Dialogue_Title_Box = "segment_Dialogue_Title_Box";
        public const string Segment_Dialogue_Content_Box = "segment_Dialogue_Content_Box";
        public const string Segment_Dialogue_Character_ObjectField = "segment_Dialogue_Character_ObjectField";
        public const string Segment_Dialogue_First_Textline_TextField = "segment_Dialogue_First_Textline_TextField";
        public const string Segment_Dialogue_AudioClip_ObjectField = "segment_Dialogue_AudioClip_ObjectField";
        
        public const string Segment_Dialogue_SecondContent_Box = "segment_Dialogue_SecondContent_Box";

        public const string Segment_Dialogue_SecondLineTriggerType_Box = "segment_Dialogue_SecondLineTriggerType_Box";
        public const string Segment_Dialogue_SecondLineTriggerType_Label = "segment_Dialogue_SecondLineTriggerType_Label";
        public const string Segment_Dialogue_SecondLineTriggerType_EnumField = "segment_Dialogue_SecondLineTriggerType_EnumField";

        public const string Segment_Dialogue_Duration_Box = "segment_Dialogue_Duration_Box";
        public const string Segment_Dialogue_Duration_Label = "segment_Dialogue_Duration_Label";
        public const string Segment_Dialogue_Duration_FloatField = "segment_Dialogue_Duration_FloatField";

        public const string Segment_Dialogue_Second_Textline_TextField = "segment_Dialogue_Second_Textline_TextField";
        #endregion

        #region - Condition.
        public const string Segment_Condition_Main_Box = "segment_Condition_Main_Box";
        public const string Segment_Condition_Title_Box = "segment_Condition_Title_Box";
        public const string Segment_Condition_Content_Box = "segment_Condition_Content_Box";
        #endregion

        #region - Event.
        public const string Segment_Event_Main_Box = "segment_Event_Main_Box";
        public const string Segment_Event_Title_Box = "segment_Event_Title_Box";
        public const string Segment_Event_Content_Box = "segment_Event_Content_Box";
        #endregion

        #endregion

        #region - Folders.
        public const string Folder_Common_Title_Box = "folder_Common_Title_Box";
        public const string Folder_Common_Content_Box = "folder_Common_Content_Box";
        public const string Folder_Common_ExpandFolder_Button = "folder_Common_ExpandFolder_Button";
        public const string Folder_Common_Title_TextField = "folder_Common_Title_TextField";
        #endregion

        #region - Integrants.

        #region - Content Button.
        public const string Integrant_ContentButton_Main_Box = "integrant_ContentButton_Main_Box";
        public const string Integrant_ContentButton_Label = "integrant_ContentButton_Label";
        public const string Integrant_ContentButton_AddCondition_Image = "integrant_ContentButton_AddCondition_Image";
        public const string Integrant_ContentButton_AddEntry_Image = "integrant_ContentButton_AddEntry_Image";
        public const string Integrant_ContentButton_AddEvent_Image = "integrant_ContentButton_AddEvent_Image";
        public const string Integrant_ContentButton_AddMessage_Image = "integrant_ContentButton_AddMessage_Image";
        #endregion

        #endregion

        #region - Channel.

        #region - Commons.
        public const string Channel_Option_Output_RemoveChannel_Button = "channel_Option_Output_RemoveChannel_Button";
        #endregion

        #region - Option.
        // Output
        public const string Channel_Option_Output_Port = "channel_Option_Output_Port";
        public const string Channel_Option_Output_Connector = "channel_Option_Output_Connector";
        public const string Channel_Option_Output_Label = "channel_Option_Output_Label";
        public const string Channel_Option_Output_Cap = "channel_Option_Output_Cap";

        public const string Channel_Option_Output_Port_Connected = "channel_Option_Output_Port_Connected";

        // Input
        public const string Channel_Option_Input_Port = "channel_Option_Input_Port";
        public const string Channel_Option_Input_Connector = "channel_Option_Input_Connector";
        public const string Channel_Option_Input_Label = "channel_Option_Input_Label";
        public const string Channel_Option_Input_Cap = "channel_Option_Input_Cap";

        public const string Channel_Option_Input_Port_Connected = "channel_Option_Input_Port_Connected";

        // Output Group 
        public const string Channel_Option_Group_Output_Port = "channel_Option_Group_Output_Port";
        public const string Channel_Option_Group_Output_Label = "channel_Option_Group_Output_Label";

        // Edge
        public const string Channel_Option_Edge = "channel_Option_Edge";
        public const string Channel_Option_Edge_Selected = "channel_Option_Edge_Selected";
        #endregion

        #endregion

        #region - Fields.

        #region - Empty Fields.
        public const string TextField_Empty = "textField_Empty";
        public const string ObjectField_Empty = "objectField_Empty";
        public const string FloatField_Empty = "floatField_Empty";
        #endregion

        #region - Fields Icons.
        public const string ObjectField_Icon = "objectField_Icon";
        public const string TextField_Icon = "textField_Icon";
        public const string FloatField_Icon = "floatField_Icon";
        #endregion

        #endregion

        #endregion

        #region Nodes.

        #region - StyleSheets.
        public static StyleSheet DSNodesShareStyle;
        public static StyleSheet DSBooleanNodeStyle;
        public static StyleSheet DSDialogueNodeStyle;
        public static StyleSheet DSEndNodeStyle;
        public static StyleSheet DSEventNodeStyle;
        public static StyleSheet DSOptionTrackNodeStyle;
        public static StyleSheet DSOptionWindowNodeStyle;
        public static StyleSheet DSPreviewNodeStyle;
        public static StyleSheet DSStartNodeStyle;
        public static StyleSheet DSStoryNodeStyle;
        #endregion

        #region - Border.
        public const string Node_Border = "node_Border";
        public const string Node_Border_Hover = "node_Border_Hover";
        #endregion

        #region - Node Title.
        public const string Node_NodeTitle_Main_Box = "node_NodeTitle_Main_Box";
        public const string Node_NodeTitle_TextField = "node_NodeTitle_TextField";
        public const string Node_EditTitle_Button = "node_EditTitle_Button";
        #endregion

        #region - Input / Ouput Containers.
        public const string Node_Input_Container = "node_Input_Container";
        public const string Node_Output_Container = "node_Output_Container";
        public const string Node_Output_Container_Window = "node_Output_Container_Window";
        #endregion

        #region - End Node.
        public const string EndNode_GraphEndHandleType_EnumField = "endNode_GraphEndHandleType_EnumField";
        #endregion

        #region - Option Track Node.
        public const string OptionTrackNode_Header_TextField = "optionTrackNode_Header_TextField";
        #endregion

        #region - Option Window Node.
        public const string OptionWindowNode_Header_TextField = "optionWindowNode_Header_TextField";
        #endregion

        #region - Preview Node.
        public const string PreviewNode_Image_Box = "previewNode_Image_Box";
        public const string PreviewNode_Image = "previewNode_Image";
        public const string PreviewNode_Image_L = "previewNode_Image_L";
        public const string PreviewNode_Image_R = "previewNode_Image_R";

        public const string PreviewNode_ObjectField_Box = "previewNode_ObjectField_Box";
        public const string PreviewNode_ObjectField = "previewNode_ObjectField";
        public const string PreviewNode_ObjectField_L = "previewNode_ObjectField_L";
        public const string PreviewNode_ObjectField_R = "previewNode_ObjectField_R";
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
                
                // Segments
                DSSegmentsStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Components/DSSegmentsStyle.uss");
                
                // Folders
                DSFolderStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Components/DSFoldersStyle.uss");

                // Integrants
                DSIntegrantsStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Components/DSIntegrantsStyle.uss");
                
                // Option Channels
                DSOutputOptionChannelsStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Components/Channels/Option/DSOutputOptionChannelsStyle.uss");
                DSInputOptionChannelsStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Components/Channels/Option/DSInputOptionChannelsStyle.uss");
            }

            void SetupStyleSheet_Nodes()
            {
                // Share Style
                DSNodesShareStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/DSNodesShareStyle.uss");
                
                // Variants
                DSBooleanNodeStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/Variants/DSBooleanNodeStyle.uss");
                DSDialogueNodeStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/Variants/DSDialogueNodeStyle.uss");
                DSEndNodeStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/Variants/DSEndNodeStyle.uss");
                DSEventNodeStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/Variants/DSEventNodeStyle.uss");
                DSOptionTrackNodeStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/Variants/DSOptionTrackNodeStyle.uss");
                DSOptionWindowNodeStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/Variants/DSOptionWindowNodeStyle.uss");
                DSPreviewNodeStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/Variants/DSPreviewNodeStyle.uss");
                DSStartNodeStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/Variants/DSStartNodeStyle.uss");
                DSStoryNodeStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Nodes/Variants/DSStoryNodeStyle.uss");
            }

            void SetupStyleSheet_Ports()
            {
                DSPortsStyle = (StyleSheet)EditorGUIUtility.Load("DialogueSystem/Ports/DSPortsStyle.uss");
            }
        }
    }
}