using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher2 : MonoBehaviour
{
    [SerializeField] private string sceneToLoad = "YourSceneName";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float delay = Random.Range(10f, 30f);
        Debug.Log("Switching scene in " + delay + " seconds.");
        Invoke(nameof(SwitchScene), delay);
    }

    private void SwitchScene()
    {
        SceneManager.LoadScene("Boss fight");
    }

}
