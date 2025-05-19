using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// This should be in a separate file named Teleporter.cs
public class Teleporter : MonoBehaviour
{
    public string targetScene;
    public GameObject player;
    public float teleportDelay = 0.5f; // Short delay for effects

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            StartCoroutine(TeleportPlayer());
        }
    }

    IEnumerator TeleportPlayer()
    {
        // Optional: Play teleport sound/effect
        if (TryGetComponent<AudioSource>(out var audioSource))
        {
            audioSource.Play();
        }

        // Brief delay before teleporting
        yield return new WaitForSeconds(teleportDelay);

        // Load the boss scene
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
