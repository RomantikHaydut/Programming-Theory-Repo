using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class TheManager : MonoBehaviour
{
    public static TheManager theManager;

    public AudioSource audioSource;

    public AudioClip batman;

    public AudioClip time;

    public AudioClip carribean;

    public Button[] musicButtons;

    private int selectedButtonIndex;

    public static string activePlayerName;

    public static string bestScoreOwner;

    public static int bestScore;


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
        LoadMusic();
        audioSource.Play();
        if (selectedButtonIndex<=3)
        {
            musicButtons[selectedButtonIndex].Select();
        }
    }


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayMusic(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
        SaveMusic();
    }

    public void SaveMusicIndex(int index)
    {
        selectedButtonIndex = index;
    }

    public void GetPlayerName(TextMeshProUGUI name)
    {
        activePlayerName = name.text.ToString();
    }

    [System.Serializable]
    public class SaveData
    {
        public string name;

        public int bestScore;

        public AudioClip music;

        public int lastMusicIndex;
    }

    public void SaveNameAndScore(string Name, int BestScore)
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
            bestScoreOwner = data.name;
            bestScore = data.bestScore;
        }
    }

    public void SaveMusic()
    {
        SaveData data = new SaveData();
        data.music = audioSource.clip;
        data.lastMusicIndex = selectedButtonIndex;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "savefile2.json", json);
    }

    public void LoadMusic()
    {
        string path = Application.persistentDataPath + "savefile2.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            audioSource.clip = data.music;
            selectedButtonIndex = data.lastMusicIndex;
        }
    }
}
