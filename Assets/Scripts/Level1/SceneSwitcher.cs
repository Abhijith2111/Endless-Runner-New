using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private string sceneToLoad = "BossFight";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float delay = Random.Range(10f, 30f);
        Debug.Log("Switching scene in " + delay + " seconds.");
        Invoke(nameof(SwitchScene), delay);
    }

    private void SwitchScene()
    {
        SceneManager.LoadScene("BossFight");
    }

}
