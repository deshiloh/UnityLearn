using System;
using System.IO;
using UnityEngine;

namespace SaveSystem
{
    public class SaveLoadSystem : MonoBehaviour
    {
        public HeroStats heroStats;
        private string _saveDirectory;
        private string _fileName;

        private void Awake()
        {
            _saveDirectory = "/saves";
            _fileName = "/save.txt";
        }

        public void SaveGame()
        {
            var dir = Application.persistentDataPath + _saveDirectory;
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var json = JsonUtility.ToJson(heroStats.heroStats);
            File.WriteAllText(dir + _fileName, json);
        }

        public void LoadGame()
        {
            var saveFilePath = Application.persistentDataPath + _saveDirectory + _fileName;
            if (File.Exists(saveFilePath))
            {
                var json = File.ReadAllText(saveFilePath);
                heroStats.heroStats = JsonUtility.FromJson<Stats>(json);
                heroStats.UpdatePanelCharacter();
            }
            else
            {
                print("Le fichier n'existe pas");
            }
        }
    }
}