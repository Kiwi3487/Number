using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using TMPro;

public class HighScoreBoard : MonoBehaviour
{
    // Script to display the high score by reading off a text file and also sorts and updates the data
    private TMP_Text text;
    private string filePath;

    [Serializable]
    public class HighScoreEntry
    {
        public string name;
        public int score;
    }

    [Serializable]
    public class HighScoreData
    {
        public List<HighScoreEntry> entries;

        public void Sort()
        {
            entries = entries.OrderByDescending(entry => entry.score).ToList();
        }
    }

    private HighScoreData data;
    void Start()
    {
        Debug.Log("persistance data path: " + Application.persistentDataPath);
        filePath = Application.persistentDataPath + "/highscores.json";

        text = GetComponent<TMP_Text>();
        Load();
        DisplayText();
    }

    void Save()
    {
        data.Sort();
        var json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json);
    }

    void Load()
    {
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<HighScoreData>(json);
        }
        else
        {
            Save();
        }

    }

    void DisplayText()
    {
        if (text == null)
        {
            return;
        }
        data.Sort();
        text.text = "";
        var i = 1;
        foreach (var entry in data.entries)
        {
            text.text += i + ".\t" + entry.name + "\t\t" + entry.score + "\n";
            i++;
        }
    }

    public void AddHighScore(string name, int score)
    {
        var entry = new HighScoreEntry { name = name, score = score };
        data.entries.Add(entry);
        Save();
        DisplayText();
    }
}
