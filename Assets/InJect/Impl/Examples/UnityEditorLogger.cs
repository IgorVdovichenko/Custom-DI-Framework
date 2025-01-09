using UnityEngine;

namespace InJect.Impl.Examples
{
    public class UnityEditorLogger: ILogger
    {
        public void Print(object message)
        {
            Debug.Log(message);
        }
    }
}