using InJect.Impl.Examples.Solid.Writers.Api;
using JetBrains.Annotations;
using UnityEngine;

namespace InJect.Impl.Examples.Solid.Writers
{
    [UsedImplicitly]
    public sealed class UnityConsoleWriter : IWriter
    {
        public void Write(double result)
        {
            Debug.Log($"RESULT: {result}");
        }
    }
}