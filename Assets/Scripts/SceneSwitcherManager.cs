using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneSwitcherManager : MonoBehaviour
{
    public static SceneSwitcherManager Instance;

    private bool isBossPhase = false;
    private float gamePageDuration;
    private string[] gamePages = { "GamePage1", "GamePage2" };
    private string[] bossFights = { "BossFight", "BossFight2" };

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(GameLoop());
    }

    private IEnumerator GameLoop()
    {
        string currentScene = "GamePage1";
        yield return StartCoroutine(LoadScene(currentScene));

        while (true)
        {
            if (!isBossPhase)
            {
                gamePageDuration = Random.Range(20f, 30f);
                yield return new WaitForSeconds(gamePageDuration);

                isBossPhase = true;
                currentScene = PickNextBoss();
            }
            else
            {
                yield return new WaitForSeconds(30f); 

                isBossPhase = false;
                currentScene = PickNextGamePage();
            }

            yield return StartCoroutine(LoadScene(currentScene));
        }
    }

    private string PickNextGamePage()
    {
        return gamePages[Random.Range(0, gamePages.Length)];
    }

    private string PickNextBoss()
    {
        return bossFights[Random.Range(0, bossFights.Length)];
    }

    private IEnumerator LoadScene(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
