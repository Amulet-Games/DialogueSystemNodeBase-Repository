using System;

namespace AG
{
    [Serializable]
    public class StringVariable : VariableFrameBase<string>
    {
        // ----------------------------- Comparison Methods -----------------------------
        /// <inheritdoc />
        public override bool Equal(string target) => VariableValue == target;
    }
}
