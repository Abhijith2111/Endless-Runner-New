using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class RunData
{
    public int score;
    public int coins;
    public int time;

    public RunData(int s, int c, int t)
    {
        score = s;
        coins = c;
        time = t;
    }
}

public static class HighscoreManager
{
    private const string HighscoreKey = "Highscores";

    public static void SaveRun(int score, int coins, int time)
    {
        List<RunData> highscores = LoadHighscores();
        highscores.Add(new RunData(score, coins, time));

        // Sort and take top 10
        highscores = highscores.OrderByDescending(r => r.score).Take(10).ToList();

        string json = JsonUtility.ToJson(new HighscoreListWrapper { runs = highscores });
        PlayerPrefs.SetString(HighscoreKey, json);
        PlayerPrefs.Save();
    }

    public static List<RunData> LoadHighscores()
    {
        if (!PlayerPrefs.HasKey(HighscoreKey)) return new List<RunData>();

        string json = PlayerPrefs.GetString(HighscoreKey);
        return JsonUtility.FromJson<HighscoreListWrapper>(json).runs;
    }

    [System.Serializable]
    private class HighscoreListWrapper
    {
        public List<RunData> runs;
    }
}
