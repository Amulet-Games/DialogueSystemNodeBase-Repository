using System;

namespace AG
{
    [Serializable]
    public class BoolVariable : VariableFrameBase<bool>
    {
        // ----------------------------- Compare Value Services -----------------------------
        /// <inheritdoc />
        public override bool True() => VariableValue == true;


        /// <inheritdoc />
        public override bool False() => VariableValue == false;
    }
}