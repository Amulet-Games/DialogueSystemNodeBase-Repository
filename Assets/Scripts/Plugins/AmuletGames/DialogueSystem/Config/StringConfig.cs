using System;

namespace AG.DS
{
    public class StringConfig
    {
        /// <summary>
        /// The singleton reference of the class.
        /// </summary>
        public static StringConfig Instance { get; private set; } = null;

        #region Window Labels.
        public readonly string Editor_WindowAlreadyOpened_WarningText = "Action is ignored since a dialogue editor window is already opened.";
        public readonly string Editor_WindowAlreadySaved_WarningText = "Action is ignored since there's no unsaved changes.";
        public readonly string Editor_WindowAlreadyLoaded_WarningText = "Action is ignored since there's nothing changed from the last time it loaded.";
        #endregion

        #region Headbar Labels.
        public readonly string HeaderBar_GraphEditor_TitleText = "New Dialogue Editor Graph";
        public readonly string Headbar_SaveButton_LabelText = "Save";
        public readonly string Headbar_LoadButton_LabelText = "Load";
        #endregion

        #region Input Hint Texts.
        public readonly string InputHint_LanguageFieldHint_LabelText = "This field is language dependent.";
        #endregion

        #region Search Entry Labels.
        public readonly string SearchEntry_AncestorEntry_LabelText = "Dialogue Editor";
        public readonly string SearchEntry_FamilyEntry_Nodes_LabelText = "Nodes";
        public readonly string SearchEntry_ChildEntry_BooleanNode_LabelText = "Boolean Node";
        public readonly string SearchEntry_ChildEntry_DialogueNode_LabelText = "Dialogue Node";
        public readonly string SearchEntry_ChildEntry_EndNode_LabelText = "End Node";
        public readonly string SearchEntry_ChildEntry_EventNode_LabelText = "Event Node";
        public readonly string SearchEntry_ChildEntry_OptionBranchNode_LabelText = "Option Branch Node";
        public readonly string SearchEntry_ChildEntry_OptionRootNode_LabelText = "Option Root Node";
        public readonly string SearchEntry_ChildEntry_PreviewNode_LabelText = "Preview Node";
        public readonly string SearchEntry_ChildEntry_StartNode_LabelText = "Start Node";
        public readonly string SearchEntry_ChildEntry_StoryNode_LabelText = "Story Node";
        #endregion

        #region Contextual Menu Item Labels.
        public readonly string ContextualMenuItem_DisconnectInputPort_LabelText = "Disconnect Input Port";
        public readonly string ContextualMenuItem_DisconnectOutputPort_LabelText = "Disconnect Output Port";
        public readonly string ContextualMenuItem_DisconnectTrueOutputPort_LabelText = "Disconnect True Output Port";
        public readonly string ContextualMenuItem_DisconnectFalseOutputPort_LabelText = "Disconnect False Output Port";
        public readonly string ContextualMenuItem_DisconnectContinueOutputPort_LabelText = "Disconnect Continue Output Port";
        public readonly string ContextualMenuItem_DisconnectOptionInputPort_LabelText = "Disconnect ";
        public readonly string ContextualMenuItem_DisconnectOptionOutputPort_LabelText = "Disconnect ";
        public readonly string ContextualMenuItem_DisconnectAllPort_LabelText = "Disconnect All";
        #endregion

        #region Node Title Labels.
        public readonly string BooleanNode_TitleText = "Boolean";
        public readonly string DialogueNode_TitleText = "Dialogue";
        public readonly string EndNode_TitleText = "End";
        public readonly string EventNode_TitleText = "Event";
        public readonly string OptionBranchNode_TitleText = "Option Branch";
        public readonly string OptionRootNode_TitleText = "Option Root";
        public readonly string PreviewNode_TitleText = "Preview";
        public readonly string StartNode_TitleText = "Start";
        public readonly string StoryNode_TitleText = "Story";
        #endregion

        #region Input / Output Port Labels.
        public string DefaultPort_Input_LabelText = "Input";
        public string DefaultPort_Output_LabelText = "Output";
        public string DefaultPort_True_LabelText = "True";
        public string DefaultPort_False_LabelText = "False";
        public string OptionPort_Connect_Input_LabelText = "Option ";
        public string OptionPort_Connect_Output_LabelText = "Option ";
        public string OptionPort_Disconnect_Input_LabelText = "Track";
        public string OptionPort_Disconnect_Output_LabelText = "Entry";
        #endregion

        #region Content Button Labels.
        public readonly string ContentButton_AddCondition_LabelText = "Add Condition";
        public readonly string ContentButton_AddEvent_LabelText = "Add Event";
        public readonly string ContentButton_AddEntry_LabelText = "Add Entry";
        public readonly string ContentButton_AddMessage_LabelText = "Add Message";
        #endregion

        #region TextField Placeholder Texts.
        public string DialogueSegmentCharacterPlaceholderText = "Character";
        public string DialogueSegmentTextlinePlaceholderText = "Textline";
        public string ConditionModifierCompareToStringPlaceholderText = "String";
        #endregion

        #region Segment Title Labels.
        public string EventSegmentTitleLabelText = "Scriptable Events";
        public string ConditionSegmentTitleLabelText = "Conditions";
        #endregion

        #region Event Modifier Texts.
        public readonly string EventModifier_Folder_TitleText = "Event ";
        public readonly string EventModifier_DialogueEvent_LabelText = "Dialogue Event";
        public readonly string EventModifier_StartDelay_LabelText = "Start Delay";
        public readonly string EventModifier_DelaySeconds_LabelText = "seconds";
        #endregion

        #region Message Modifier Texts.
        public string MessageModifier_Folder_TitleText = "Message ";
        public string MessageModifierProgressTypeLabelText = "Progress Type";
        public string DurationLabelText = "Duration";
        #endregion

        #region Option Root Group Labels.
        public readonly string OptionRootGroup_TitleLabelText = "Root Title";
        public readonly string OptionRootGroup_FieldPlaceholderText = "�gDid you have lunch yet?�h";
        #endregion

        #region Option Branch Labels.
        public readonly string OptionBranchGroup_TitleLabelText = "Branch Title";
        public readonly string OptionBranchGroup_FieldPlaceholderText = "�gYeah I had it in the indian restaurant.�h";
        #endregion


        // ----------------------------- Setup -----------------------------
        /// <summary>
        /// Setup for the class.
        /// </summary>
        public static void Setup()
        {
            Instance ??= new();
        }


        // ----------------------------- Dispose -----------------------------
        /// <summary>
        /// Dispose for the class.
        /// </summary>
        public void Dispose()
        {
            Instance = null;
        }
    }
}