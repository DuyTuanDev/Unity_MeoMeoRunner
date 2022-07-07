using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    static public PlayerData Instance;
    public Text txtGold;
    public int gold;
    public int indexSkill;
    public bool kill1;
    public bool kill2;
    public bool kill3;
    public bool kill4;
    public bool kill5;
    public bool kill6;
    private void Awake() {
        Instance = this;
        LoadDataGame();
    }
    private void Start() {
        
    }
    public void SaveDataGame()
    {
        SaveData data = new SaveData();
        data.gold = gold; txtGold.text = gold.ToString();
        data.indexSkill = indexSkill;
        data.kill1 = kill1;
        data.kill2 = kill2;
        data.kill3 = kill3;
        data.kill4 = kill4;
        data.kill5 = kill5;
        data.kill6 = kill6;

        string json = JsonUtility.ToJson(data);
    
        File.WriteAllText(Application.persistentDataPath + "/DataMeoRunner.json", json);
    }
    public void LoadDataGame()
    {
        try
        {
            string path = Application.persistentDataPath + "/DataMeoRunner.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                SaveData data = JsonUtility.FromJson<SaveData>(json);

                gold = data.gold; txtGold.text = gold.ToString();
                indexSkill = data.indexSkill;
                kill1 = data.kill1;
                kill2 = data.kill2;
                kill3 = data.kill3;
                kill4 = data.kill4;
                kill5 = data.kill5;
                kill6 = data.kill6;
            }
        }
        catch (System.Exception)
        {

        }
        
    }
    [System.Serializable]
    class SaveData
    {
        public int gold;
        public int indexSkill;
        public bool kill1;
        public bool kill2;
        public bool kill3;
        public bool kill4;
        public bool kill5;
        public bool kill6;
    }
}
