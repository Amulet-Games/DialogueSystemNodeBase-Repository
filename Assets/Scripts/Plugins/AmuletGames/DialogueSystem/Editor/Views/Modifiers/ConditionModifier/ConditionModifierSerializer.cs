namespace AG.DS
{
    public class ConditionModifierSerializer
    {
        /// <summary>
        /// Save the condition modifier values.
        /// </summary>
        /// <param name="view">The condition modifier view to set for.</param>
        /// <param name="data">The condition modifier data to set for.</param>
        public static void Save
        (
            ConditionModifierView view,
            ConditionModifierData data
        )
        {
            SaveFolder();

            SaveOperationDropdown();

            SaveChainWithDropdown();

            void SaveFolder()
            {
                view.Folder.Save(data.FolderData);
            }

            void SaveOperationDropdown()
            {
                view.OperationDropdown.Save(data.OperationDropdownData);
            }

            void SaveChainWithDropdown()
            {
                view.ChainWithDropdown.Save(data.ChainWithDropdownData);
            }
        }


        /// <summary>
        /// Load the condition modifier values.
        /// </summary>
        /// <param name="view">The condition modifier view to set for.</param>
        /// <param name="data">The condition modifier data to set for.</param>
        public static void Load
        (
            ConditionModifierView view,
            ConditionModifierData data
        )
        {
            LoadFolder();

            LoadOperationDropdown();

            LoadChainWithDropdown();

            void LoadFolder()
            {
                view.Folder.Load(data.FolderData);
            }

            void LoadOperationDropdown()
            {
                view.OperationDropdown.Load(data.OperationDropdownData);
            }

            void LoadChainWithDropdown()
            {
                view.ChainWithDropdown.Load(data.ChainWithDropdownData);
            }
        }
    }
}