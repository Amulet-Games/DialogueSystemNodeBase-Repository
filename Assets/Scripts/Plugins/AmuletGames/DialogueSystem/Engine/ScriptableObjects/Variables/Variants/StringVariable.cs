using System;

namespace AG
{
    [Serializable]
    public class StringVariable : VariableFrameBase<string>
    {
        // ----------------------------- Compare Value Services -----------------------------
        /// <inheritdoc />
        public override bool Equal(string target) => VariableValue == target;
    }
}
