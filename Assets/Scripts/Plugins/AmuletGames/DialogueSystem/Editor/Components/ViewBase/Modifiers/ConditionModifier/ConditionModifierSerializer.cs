namespace AG.DS
{
    public class ConditionModifierSerializer
    {
        /// <summary>
        /// Save the condition modifier values.
        /// </summary>
        /// <param name="view">The condition modifier view to set for.</param>
        /// <param name="model">The condition modifier model to set for.</param>
        public void Save
        (
            ConditionModifierView view,
            ConditionModifierModel model
        )
        {
            SaveFolder();

            SaveOperationDropdown();

            SaveChainWithDropdown();

            void SaveFolder()
            {
                view.Folder.Save(model.FolderModel);
            }

            void SaveOperationDropdown()
            {
                view.OperationDropdown.Save(model.OperationDropdownModel);
            }

            void SaveChainWithDropdown()
            {
                view.ChainWithDropdown.Save(model.ChainWithDropdownModel);
            }
        }


        /// <summary>
        /// Load the condition modifier values.
        /// </summary>
        /// <param name="view">The condition modifier view to set for.</param>
        /// <param name="model">The condition modifier model to set for.</param>
        public void Load
        (
            ConditionModifierView view,
            ConditionModifierModel model
        )
        {
            LoadFolder();

            LoadOperationDropdown();

            LoadChainWithDropdown();

            void LoadFolder()
            {
                view.Folder.Load(model.FolderModel);
            }

            void LoadOperationDropdown()
            {
                view.OperationDropdown.Load(model.OperationDropdownModel);
            }

            void LoadChainWithDropdown()
            {
                view.ChainWithDropdown.Load(model.ChainWithDropdownModel);
            }
        }
    }
}