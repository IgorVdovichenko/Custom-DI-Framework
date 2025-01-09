using System.IO;
using InJect.Impl.Examples.Calculation;
using JetBrains.Annotations;
using UnityEngine;
using IReader = InJect.Impl.Examples.Solid.Readers.Api.IReader;

namespace InJect.Impl.Examples.Solid.Readers
{
    [UsedImplicitly]
    public sealed class JsonReader : IReader
    {
        private readonly string _path;

        public JsonReader(string path)
        {
            _path = path;
        }
        
        public double[] Read()
        {
            var json = File.ReadAllText(_path);
            return JsonUtility.FromJson<Data>(json).values;
        }
    }
}