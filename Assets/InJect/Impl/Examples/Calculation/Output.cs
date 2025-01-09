using JetBrains.Annotations;
using UnityEngine;

namespace InJect.Impl.Examples.Calculation
{
    [UsedImplicitly]
    public class Output: IWriter
    {
        public void Write(double value)
        {
            Debug.Log($"Result: {value}");
        }
    }
}