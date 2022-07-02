using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;

public class TheManager : MonoBehaviour
{
    public static TheManager theManager;

    private AudioSource audioSource;

    public AudioClip batman;

    public AudioClip time;

    public AudioClip carribean;

    public string activePlayerName;

    public string bestScoreOwner;

    public int bestScore;


    private void Awake()
    {
        // Here we make TheManager singleton.
        if (theManager != null)
        {
            Destroy(gameObject);
        }
        else
        {
            theManager = this;
        }
        DontDestroyOnLoad(theManager);
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayMusic(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
    }

    public void GetPlayerName(TextMeshProUGUI name)
    {
        activePlayerName = name.text;
    }

    [System.Serializable]
    public class SaveData
    {
        public string name;

        public int bestScore;
    }

    public void SaveNameAndScore(string Name,int BestScore)
    {
        SaveData data = new SaveData();
        data.name = Name;
        data.bestScore = BestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "savefile.json", json);
    }

    public void LoadNameAndScore()
    {
        string path = Application.persistentDataPath + "savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            data.name = bestScoreOwner;
            data.bestScore = bestScore;
        }
    }
}
