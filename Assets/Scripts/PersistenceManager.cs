using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PersistenceManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static PersistenceManager Instance;

    public string playerName;
    public string bestPlayerName;
    public int m_Points;
    public int highestPoints;
    [SerializeField] Text inputText;
    [SerializeField] Text bestScore;


    private void Start()
    {
        LoadBestScoreName();
        bestScore.text = "Best score: " + bestPlayerName +": "+ highestPoints;
    }

    private void Awake()
    { 
    if (Instance != null)//check if PersistanceManager exists and if yes destroy the clone
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public string SavePlayerName()//test script
    {
        return playerName = inputText.text;
    }

    private void Update()
    {
        m_Points = MainManager.m_Points;
    }



    [System.Serializable]
    class SaveData
    {
        public string bestPlayerName;
        public int highestPoints;
    }

    public void SaveBestScoreName()
    {
        if(m_Points > highestPoints)
        {
            SaveData data = new SaveData();
            data.bestPlayerName = playerName;
            data.highestPoints = m_Points;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
        
    }

    public void LoadBestScoreName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.bestPlayerName;
            highestPoints = data.highestPoints;
        }
    }
}
