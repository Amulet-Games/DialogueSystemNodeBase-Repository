using System;

namespace AG
{
    [Serializable]
    public class StringVariable : VariableFrameBase<string>
    {
        /// <inheritdoc />
        public override bool Equal(string target) => Value == target;
    }
}
