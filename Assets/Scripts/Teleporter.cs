using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public string targetScene;
    public GameObject player;
    public float teleportDelay = 0.5f; 

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            StartCoroutine(TeleportPlayer());
        }
    }

    IEnumerator TeleportPlayer()
    {
        if (TryGetComponent<AudioSource>(out var audioSource))
        {
            audioSource.Play();
        }

        yield return new WaitForSeconds(teleportDelay);

        if (!string.IsNullOrEmpty(targetScene))
        {
            SceneManager.LoadScene(targetScene);
        }
        else
        {
            Debug.LogError("Target scene not specified!");
        }
    }
}
