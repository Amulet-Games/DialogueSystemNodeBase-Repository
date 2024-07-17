namespace AG.DS
{
    public class BlackboardSectionPresenter
    {
        public static BlackboardSection CreateElement(string sectionTitle)
        {
            var section = new BlackboardSection(title: sectionTitle);

            section.AddToClassList(className: StyleConfig.Blackboard_Section);

            return section;
        }
    }
}