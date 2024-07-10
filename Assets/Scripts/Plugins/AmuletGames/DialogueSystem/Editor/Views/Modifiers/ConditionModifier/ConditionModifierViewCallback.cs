namespace AG.DS
{
    using VariableGroup = ConditionModifierView.VariableGroup;

    public class ConditionModifierViewCallback
    {
        class VariableGroupCallback
        {
            /// <summary>
            /// The callback to invoke when the group is created on the graph by the user.
            /// </summary>
            /// <param name="group">The variable group element to set for.</param>
            /// <param name="searchTreeEntryProvider">The condition modifier search tree entry provider to set for.</param>
            public static void OnCreateByUser
            (
                VariableGroup group,
                ConditionModifierViewSearchTreeEntryProvider searchTreeEntryProvider
            )
            {
                SearchWindowSelectorCallback.OnCreateByUser
                (
                    selector: group.VariableSearchWindowSelector,
                    nullValueEntry: searchTreeEntryProvider.NullValueVariableSearchTreeEntry
                );

                SearchWindowSelectorCallback.OnCreateByUser
                (
                    selector: group.FieldInfoSearchWindowSelector,
                    nullValueEntry: searchTreeEntryProvider.NullValueVariableSearchTreeEntry
                );

                CommonTextFieldViewCallback.OnCreateByUser(view: group.TextFieldView);
                CommonFloatFieldCallback.OnCreateByUser(view: group.FloatFieldView);
            }
        }


        /// <summary>
        /// The callback to invoke when the modifier view is created on the graph by the system or user.
        /// </summary>
        /// <param name="view">The condition modifier view to set for.</param>
        /// <param name="searchTreeEntryProvider">The condition modifier search tree entry provider to set for.</param>
        /// <param name="byUser">Is the modifier created by the user.</param>
        public static void OnCreate
        (
            ConditionModifierView view,
            ConditionModifierViewSearchTreeEntryProvider searchTreeEntryProvider,
            bool byUser
        )
        {
            if (byUser)
            {
                FolderCallback.OnCreateByUser(view.Folder);

                VariableGroupCallback.OnCreateByUser(group: view.FirstVariableGroup, searchTreeEntryProvider);
                VariableGroupCallback.OnCreateByUser(group: view.SecondVariableGroup, searchTreeEntryProvider);

                DropdownCallback.OnCreateByUser(view.OperationDropdown);
                DropdownCallback.OnCreateByUser(view.ChainWithDropdown);

                OnCreateByUser(view);
            }

            DropdownCallback.OnCreate(view.OperationDropdown);
            DropdownCallback.OnCreate(view.ChainWithDropdown);
        }


        /// <summary>
        /// The callback to invoke when the modifier view is created on the graph by the user.
        /// </summary>
        /// <param name="view">The condition modifier view to set for.</param>
        static void OnCreateByUser(ConditionModifierView view)
        {
            view.m_OperationType = ConditionModifierView.OperationType.String;
        }
    }
}