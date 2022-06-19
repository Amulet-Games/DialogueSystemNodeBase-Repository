namespace AG
{
    public interface IConditionModifierUtility
    {
        void ToggleUnmetConditionDisplayOptionVisible();

        void AddModifierToData(ConditionModifier conditionModifier);

        void RemoveModifierFromData(ConditionModifier conditionModifier);
    }
}