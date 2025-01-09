using System.IO;
using JetBrains.Annotations;
using UnityEngine;

namespace InJect.Impl.Examples.Calculation
{
    [UsedImplicitly]
    public class Input: IReader
    {
        private const string Path = @"D:\UnityProjects\InJect\Assets\InJect\Impl\Examples\Calculation\Data.json";

        public double[] ReadData()
        {
            var data = File.ReadAllText(Path);
            return JsonUtility.FromJson<Data>(data).values;
        }
    }
}