using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class ProgressViewer : MonoBehaviour
{
    public static ProgressViewer instance;
    public Level[] playableLevels;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(this != instance)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        LoadData();
    }
    public void LevelPassed(string LevelName)
    {
        foreach(Level level in playableLevels)
        {
            if( level.SceneName.Equals(LevelName))
            {
                level.SceneWon = true;
                break;
            }
        }
    }
    public void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = File.Create(Application.persistentDataPath + "/ProgressViewer.dat");

        bf.Serialize(fileStream, playableLevels);
        fileStream.Close();
    }
    public void LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/ProgressViewer.dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/ProgressViewer.dat", FileMode.Open);
            playableLevels =(Level[])bf.Deserialize(file);
            Debug.Log("Deserialised");
            file.Close();
        }
    }
    public void ResetProgress()
    {
        foreach (Level level in playableLevels)
        {
            level.SceneWon = false;
            Debug.Log("Should reset");
        }
        File.Delete(Application.persistentDataPath + "/ProgressViewer.dat");
        
    }
}

[System.Serializable]
public class Level {
    public string SceneName;
    public bool SceneWon;
}