using UnityEngine;
using TMPro;
using System.Text;

public class HighscoreDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text highscoreText;

    public void ShowHighscores()
    {
        var runs = HighscoreManager.LoadHighscores();
        StringBuilder sb = new StringBuilder();
        int rank = 1;

        foreach (var run in runs)
        {
            sb.AppendLine($"{rank}. Score: {run.score} | Coins: {run.coins} | Time: {run.time}s");
            rank++;
        }

        highscoreText.text = sb.ToString();
    }
}
