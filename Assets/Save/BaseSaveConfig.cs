using System.IO;
using UnityEngine;

namespace SpacePortals
{
    public abstract class BaseSaveConfig : ScriptableObject
    {
        private const string TypeSaveFile = ".json";

        [SerializeField] private string _fileName;

        public string FileName => _fileName + TypeSaveFile;
        public string SavePatch => Path.Combine(Application.persistentDataPath, _fileName);
    }
}

