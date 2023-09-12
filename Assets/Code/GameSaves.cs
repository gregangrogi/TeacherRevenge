using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameInfo
{
    public int coins;
    public int level;
    public Dictionary<int, string> unlockedWeapons = new Dictionary<int, string>();
}

public class GameSaves : MonoBehaviour
{
    public GameInfo gameInfo;
    public Slider slider;

    [DllImport("__Internal")]
    private static extern void SaveExtern(string Date);
    [DllImport("__Internal")]
    private static extern void LoadExtern();

    [SerializeField] TextMeshProUGUI _gameInfoText;

    public static GameSaves Instance;
    // Start is called before the first frame update
    public void ChangeInfo()
    {
        gameInfo.level = (int)slider.value;
        Save();
    }
    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
            LoadExtern();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        _gameInfoText.text = gameInfo.level.ToString();
    }

    // Update is called once per frame
    public void Save()
    {
        string jsonString = JsonUtility.ToJson(gameInfo);
        SaveExtern(jsonString);
    }

    public void SetGameInfo(string Value)
    {
        gameInfo = JsonUtility.FromJson<GameInfo>(Value);
        slider.value = gameInfo.level;
    }
}
