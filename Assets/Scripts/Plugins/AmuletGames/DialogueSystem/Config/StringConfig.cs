namespace AG.DS
{
    public static class StringConfig
    {
        #region Window Labels.
        public const string Editor_WindowDefaultTitleText = "New Dialogue Editor Graph";
        public const string Editor_WindowAlreadyOpened_WarningText = "Action is ignored since the dialogue system window of this asset is already opened.";
        public const string Editor_WindowAlreadySaved_WarningText = "Action is ignored since there's no unsaved changes.";
        public const string Editor_WindowAlreadyLoaded_WarningText = "Action is ignored since there's nothing changed from the last time it loaded.";
        #endregion

        #region HeadBar Labels.
        public const string HeadBar_SaveButton_LabelText = "Save";
        public const string HeadBar_LoadButton_LabelText = "Load";
        #endregion

        #region Input Hint Texts.
        public const string InputHint_HintTextLabel_LabelText = "This field is language dependent.";
        #endregion

        #region Search Entry Labels.
        public const string SearchEntry_AncestorEntry_LabelText = "Dialogue Editor";
        public const string SearchEntry_FamilyEntry_Nodes_LabelText = "Nodes";
        public const string SearchEntry_ChildEntry_BooleanNode_LabelText = "Boolean Node";
        public const string SearchEntry_ChildEntry_DialogueNode_LabelText = "Dialogue Node";
        public const string SearchEntry_ChildEntry_EndNode_LabelText = "End Node";
        public const string SearchEntry_ChildEntry_EventNode_LabelText = "Event Node";
        public const string SearchEntry_ChildEntry_OptionBranchNode_LabelText = "Option Branch Node";
        public const string SearchEntry_ChildEntry_OptionRootNode_LabelText = "Option Root Node";
        public const string SearchEntry_ChildEntry_PreviewNode_LabelText = "Preview Node";
        public const string SearchEntry_ChildEntry_StartNode_LabelText = "Start Node";
        public const string SearchEntry_ChildEntry_StoryNode_LabelText = "Story Node";
        #endregion

        #region Contextual Menu Item Labels.
        public const string ContextualMenuItem_DisconnectInputPort_LabelText = "Disconnect Input Port";
        public const string ContextualMenuItem_DisconnectOutputPort_LabelText = "Disconnect Output Port";
        public const string ContextualMenuItem_DisconnectTrueOutputPort_LabelText = "Disconnect True Output Port";
        public const string ContextualMenuItem_DisconnectFalseOutputPort_LabelText = "Disconnect False Output Port";
        public const string ContextualMenuItem_DisconnectContinueOutputPort_LabelText = "Disconnect Continue Output Port";
        public const string ContextualMenuItem_DisconnectOptionInputPort_LabelText = "Disconnect ";
        public const string ContextualMenuItem_DisconnectOptionOutputPort_LabelText = "Disconnect ";
        public const string ContextualMenuItem_DisconnectAllPort_LabelText = "Disconnect All";
        #endregion

        #region Node Title Labels.
        public const string BooleanNode_NodeTitleField_DefaultText = "Boolean";
        public const string DialogueNode_NodeTitleField_DefaultText = "Dialogue";
        public const string EndNode_NodeTitleField_DefaultText = "End";
        public const string EventNode_NodeTitleField_DefaultText = "Event";
        public const string OptionBranchNode_NodeTitleField_DefaultText = "Option Branch";
        public const string OptionRootNode_NodeTitleField_DefaultText = "Option Root";
        public const string PreviewNode_NodeTitleField_DefaultText = "Preview";
        public const string StartNode_NodeTitleField_DefaultText = "Start";
        public const string StoryNode_NodeTitleField_DefaultText = "Story";
        #endregion

        #region Input / Output Port Labels.
        public const string DefaultPort_Input_LabelText = "Input";
        public const string DefaultPort_Output_LabelText = "Output";
        public const string DefaultPort_True_LabelText = "True";
        public const string DefaultPort_False_LabelText = "False";
        public const string OptionPort_Input_LabelText_Connect = "Option ";
        public const string OptionPort_Output_LabelText_Connect = "Option ";
        public const string OptionPort_Input_LabelText_Disconnect = "Track";
        public const string OptionPort_Output_LabelText_Disconnect = "Entry";
        #endregion

        #region Content Button Labels.
        public const string ContentButton_AddCondition_LabelText = "Add Condition";
        public const string ContentButton_AddEvent_LabelText = "Add Event";
        public const string ContentButton_AddEntry_LabelText = "Add Entry";
        public const string ContentButton_AddMessage_LabelText = "Add Message";
        #endregion

        #region TextField Placeholder Texts.
        public const string DialogueSegmentCharacterPlaceholderText = "Character";
        public const string DialogueSegmentTextlinePlaceholderText = "Textline";
        public const string ConditionModifierCompareToStringPlaceholderText = "String";
        #endregion

        #region Segment Title Labels.
        public const string EventSegmentTitleLabelText = "Scriptable Events";
        public const string ConditionSegmentTitleLabelText = "Conditions";
        #endregion

        #region Event Modifier Texts.
        public const string EventModifier_FolderTitleField_DefaultText = "Event ";
        public const string EventModifier_DialogueEventLabel_LabelText = "Dialogue Event";
        public const string EventModifier_DialogueEventField_PlaceholderText = "None (Dialogue Event)";
        public const string EventModifier_StartDelay_LabelText = "Start Delay";
        public const string EventModifier_DelaySeconds_LabelText = "seconds";
        #endregion

        #region Message Modifier Texts.
        public const string MessageModifier_FolderTitleField_DefaultText = "Message ";
        public const string MessageModifier_DialogueSpeakerField_PlaceholderText = "None (Dialogue Character)";
        public const string MessageModifierProgressTypeLabelText = "Progress Type";
        public const string DurationLabelText = "Duration";
        #endregion

        #region Option Root Node Texts.
        public const string OptionRootNode_RootTitleLabel_LabelText = "Root Title";
        public const string OptionRootNode_RootTitleField_PlaceholderText = "“Did you have lunch yet?”";
        #endregion

        #region Option Branch Node Texts.
        public const string OptionBranchNode_BranchTitleLabel_LabelText = "Branch Title";
        public const string OptionBranchNode_BranchTitleField_PlaceholderText = "“Yeah I had it in the Indian restaurant.”";
        #endregion

        #region Dialogue Node Texts.
        public const string DialogueNode_DialogueSpeakerLabel_LabelText = "Speaker";
        public const string DialogueNode_DialogueSpeakerField_PlaceholderText = "None (Dialogue Character)";
        #endregion
    }
}