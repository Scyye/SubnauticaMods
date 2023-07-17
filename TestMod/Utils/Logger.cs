using UnityEngine;

namespace TestMod.Utils
{
    public class Logger
    {
        private string ModName;
        
        public Logger(string ModName)
        {
            this.ModName = ModName;
        }

        public void Log(string str)
        {
            Debug.Log($"[{ModName}] {str}");
        }

        public void LogError(string str)
        {
            Debug.Log($"[{ModName}] [ERROR] {str}");
        }
    }
}