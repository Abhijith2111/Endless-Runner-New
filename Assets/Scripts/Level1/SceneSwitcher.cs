using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private string[] gamePages = { "GamePage", "GamePage2" };
    private string[] bossFights = { "BossFight", "BossFight2" };

    private string currentScene;
    private Coroutine sceneFlowCoroutine;
    private int initialStage = 0;
    private bool isRandomPhase = false;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        sceneFlowCoroutine = StartCoroutine(SceneFlow());
    }

    IEnumerator SceneFlow()
    {
        while (true)
        {
            // Initial linear transition sequence
            if (!isRandomPhase)
            {
                if (initialStage == 0 && currentScene == "GamePage")
                {
                    yield return new WaitForSeconds(Random.Range(15f, 30f));
                    LoadScene("BossFight");
                    initialStage++;
                }
                else if (initialStage == 1 && currentScene == "BossFight")
                {
                    yield return new WaitForSeconds(30f);
                    LoadScene("GamePage2");
                    initialStage++;
                }
                else if (initialStage == 2 && currentScene == "GamePage2")
                {
                    yield return new WaitForSeconds(Random.Range(15f, 30f));
                    LoadScene("BossFight2");
                    initialStage++;
                }
                else if (initialStage == 3 && currentScene == "BossFight2")
                {
                    yield return new WaitForSeconds(30f);
                    isRandomPhase = true; // Start randomizing now
                }

                yield return new WaitUntil(() => SceneManager.GetActiveScene().name != currentScene);
                currentScene = SceneManager.GetActiveScene().name;
            }
            else
            {
                // Infinite random loop begins
                if (IsGamePage(currentScene))
                {
                    yield return new WaitForSeconds(Random.Range(15f, 30f));
                    currentScene = GetRandomBossFight();
                    LoadScene(currentScene);
                }
                else if (IsBossFight(currentScene))
                {
                    yield return new WaitForSeconds(30f);
                    currentScene = GetRandomGamePage();
                    LoadScene(currentScene);
                }

                yield return new WaitUntil(() => SceneManager.GetActiveScene().name == currentScene);
            }
        }
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    bool IsGamePage(string sceneName)
    {
        return sceneName == "GamePage" || sceneName == "GamePage2";
    }

    bool IsBossFight(string sceneName)
    {
        return sceneName == "BossFight" || sceneName == "BossFight2";
    }

    string GetRandomGamePage()
    {
        return gamePages[Random.Range(0, gamePages.Length)];
    }

    string GetRandomBossFight()
    {
        return bossFights[Random.Range(0, bossFights.Length)];
    }
}
