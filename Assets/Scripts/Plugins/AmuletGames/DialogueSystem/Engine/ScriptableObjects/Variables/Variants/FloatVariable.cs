using System;
using UnityEngine;

namespace AG
{
    [Serializable]
    public class FloatVariable : VariableFrameBase<float>
    {
        const float FloatingPointComparisonThershold = 0.01f;


        // ----------------------------- Comparison Methods -----------------------------
        /// <inheritdoc />
        public override bool Equal(float target) => Mathf.Approximately(VariableValue, target);


        /// <inheritdoc />
        public override bool EqualOrBigger(float target)
            => VariableValue - target > FloatingPointComparisonThershold
                || Mathf.Approximately(VariableValue, target);


        /// <inheritdoc />
        public override bool EqualOrSmaller(float target)
            => target - VariableValue > FloatingPointComparisonThershold
                || Mathf.Approximately(VariableValue, target);


        /// <inheritdoc />
        public override bool Bigger(float target)
            => VariableValue - target > FloatingPointComparisonThershold;


        /// <inheritdoc />
        public override bool Smaller(float target)
            => target - VariableValue > FloatingPointComparisonThershold;
    }
}