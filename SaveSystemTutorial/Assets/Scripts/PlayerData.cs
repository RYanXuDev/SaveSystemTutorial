using UnityEngine;

namespace SaveSystemTutorial
{    
    public class PlayerData : MonoBehaviour
    {
        #region Fields

        [SerializeField] string playerName = "Player Name";
        [SerializeField] int level = 0;
        [SerializeField] int coin = 0;

        [System.Serializable] class SaveData
        {
            public string playerName;

            public int playerLevel;
            public int playerCoin;
            
            public Vector3 playerPosition;
        }
        
        const string PLAYER_DATA_KEY = "PlayerData";
        const string PLAYER_DATA_FILE_NAME = "PlayerData.sav";
        #endregion

        #region Properties

        public string Name => playerName;

        public int Level => level;
        public int Coin => coin;

        public Vector3 Position => transform.position;

        #endregion

        #region Save and Load

        public void Save()
        {
            // SaveByPlayerPrefs();
            SaveByJson();
        }

        public void Load()
        {
            // LoadFromPlayerPrefs();
            LoadFromJson();
        }

        #endregion

        #region PlayerPrefs

        void SaveByPlayerPrefs()
        {
            SaveSystem.SaveByPlayerPrefs(PLAYER_DATA_KEY, SavingData());
        }

        void LoadFromPlayerPrefs()
        {
            var json = SaveSystem.LoadFromPlayerPrefs(PLAYER_DATA_KEY);
            var saveData = JsonUtility.FromJson<SaveData>(json);
            LoadData(saveData);
        }

        #endregion

        #region JSON

        void SaveByJson()
        {
            SaveSystem.SaveByJson(PLAYER_DATA_FILE_NAME, SavingData());
            // SaveSystem.SaveByJson($"{System.DateTime.Now:yyyy.dd.M HH-mm-ss}.sav", SavingData());
        }

        void LoadFromJson()
        {
            var saveData = SaveSystem.LoadFromJson<SaveData>(PLAYER_DATA_FILE_NAME);

            LoadData(saveData);
        }

        #endregion

        #region Help Functions

        SaveData SavingData()
        {
            var saveData = new SaveData();

            saveData.playerName = playerName;
            saveData.playerLevel = level;
            saveData.playerCoin = coin;
            saveData.playerPosition = transform.position;
            
            return saveData;
        }

        void LoadData(SaveData saveData)
        {
            playerName = saveData.playerName;
            level = saveData.playerLevel;
            coin = saveData.playerCoin;
            transform.position = saveData.playerPosition;
        }

        #if UNITY_EDITOR        
        [UnityEditor.MenuItem("Developer/Delete Player Data Prefs")]
        public static void DeletePlayerDataPrefs()
        {
            PlayerPrefs.DeleteKey(PLAYER_DATA_KEY);
        }

        [UnityEditor.MenuItem("Developer/Delete Player Data Save File")]
        public static void DeletePlayerDataSaveFile()
        {
            SaveSystem.DeleteSaveFile(PLAYER_DATA_FILE_NAME);
        }
        #endif

        #endregion
    }
}