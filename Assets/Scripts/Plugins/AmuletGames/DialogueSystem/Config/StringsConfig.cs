namespace AG.DS
{
    public static class StringsConfig
    {
        // ----------------------------- Window Labels -----------------------------
        public const string DialogueEditorWindowLabelText = "Dialogue Editor";
        public const string WindowAlreadyOpenedWarningText = "Action is ignored since a dialogue editor window is already opened.";
        public const string WindowAlreadySavedWarningText = "Action is ignored since there's no unsaved changes.";
        public const string WindowAlreadyLoadedWarningText = "Action is ignored since there's nothing changed from the last time it loaded.";
        public const string InputHintAlreadyExistsWarningText = "A reference of the Input Hint is already initialized but you're still trying to create a new one inside the code.";

        // ----------------------------- HeadBar Labels -----------------------------
        public const string DefaultGraphTitleFieldText = "New Dialogue Editor Graph";
        public const string HeadBarSaveButtonLabelText = "Save";
        public const string HeadBarLoadButtonLabelText = "Load";

        // ----------------------------- Input Hint Texts -----------------------------
        public const string LanguageFieldInputHintText = "This field is language dependent.";

        // ----------------------------- Search Entry Labels -----------------------------
        public const string AncestorEntryLabelText = "Dialogue Editor";
        public const string NodesFamilyEntryLabelText = "Nodes";
        public const string BooleanNodeChildEntryLabelText = "Boolean Node";
        public const string DialogueNodeChildEntryLabelText = "Dialogue Node";
        public const string EndNodeChildEntryLabelText = "End Node";
        public const string EventNodeChildEntryLabelText = "Event Node";
        public const string OptionTrackNodeChildEntryLabelText = "Option Track Node";
        public const string OptionWindowNodeChildEntryLabelText = "Option Window Node";
        public const string PreviewWindowNodeChildEntryLabelText = "Preview Node";
        public const string StartNodeChildEntryLabelText = "Start Node";
        public const string StoryNodeChildEntryLabelText = "Story Node";

        // ----------------------------- Node Titles -----------------------------
        public const string BooleanNodeDefaultTitleText = "Boolean";
        public const string DialogueNodeDefaultTitleText = "Dialogue";
        public const string EndNodeDefaultTitleText = "End";
        public const string EventNodeDefaultTitleText = "Event";
        public const string OptionTrackNodeDefaultTitleText = "Option Track";
        public const string OptionWindowNodeDefaultTitleText = "Option Window";
        public const string PreviewNodeDefaultTitleText = "Preview";
        public const string StartNodeDefaultTitleText = "Start";
        public const string StoryNodeDefaultTitleText = "Story";

        // ----------------------------- Port Labels -----------------------------
        public const string NodeInputLabelText = "Input";
        public const string NodeOutputLabelText = "Output";
        public const string BooleanNodeTrueOutputLabelText = "True";
        public const string BooleanNodeFalseOutputLabelText = "False";
        public const string OptionChannelConnectedInputLabelText = "Option ";
        public const string OptionChannelConnectedOutputLabelText = "Option ";
        public const string OptionChannelEmptyInputLabelText = "Track";
        public const string OptionChannelEmptyOutputLabelText = "Entry";


        // ----------------------------- Content Button Labels -----------------------------
        public const string AddConditionLabelText = "Add Condition";
        public const string AddEventLabelText = "Add Event";
        public const string AddEntryLabelText = "Add Entry";


        // ----------------------------- Contextual Menu Item Labels -----------------------------
        public const string DisconnectInputPortLabelText = "Disconnect Input Port";
        public const string DisconnectOutputPortLabelText = "Disconnect Output Port";
        public const string DisconnectTrueOutputPortLabelText = "Disconnect True Port";
        public const string DisconnectFalseOutputPortLabelText = "Disconnect False Port";
        public const string DisconnectContinueOutputPortLabelText = "Disconnect Continue Port";
        public const string DisconnectInputChannelLabelText = "Disconnect ";
        public const string DisconnectOutputChannelLabelText = "Disconnect ";
        public const string DisconnectAllPortLabelText = "Disconnect All";


        // ----------------------------- TextField Placeholder Texts -----------------------------
        public const string OptionTrackNodeHeadlinePlaceholderText = "Headline";
        public const string OptionWindowNodeHeadlinePlaceholderText = "Headline";
        public const string DialogueSegmentCharacterPlaceholderText = "Character";
        public const string DialogueSegmentTextlinePlaceholderText = "Textline";
        public const string ConditionModifierCompareToStringPlaceholderText = "String";


        // ----------------------------- Segment Title Labels -----------------------------
        public const string DialogueSegmentTitleLabelText = "Dialogue";
        public const string DualPortraitsSegmentTitleLabelText = "Image";
        public const string EventSegmentTitleLabelText = "Scriptable Events";
        public const string ConditionSegmentTitleLabelText = "Conditions";


        // ----------------------------- Label Element Texts -----------------------------
        public const string SecondLineTriggerTypeLabelText = "Trigger Type";
        public const string DurationLabelText = "Duration";
    }
}