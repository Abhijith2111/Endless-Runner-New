using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OOF : MonoBehaviour
{
    [SerializeField] GameObject Player1;
    [SerializeField] GameObject CameraMain;
    [SerializeField] GameObject Death;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(CollisionEnd());
            Debug.Log(gameObject.name);
        }
        
    }

    IEnumerator CollisionEnd()
    {
        Player1.GetComponent<PlayerMovment>().enabled = false;
        CameraMain.GetComponent<Animator>().Play("Hit The wall Cam");
        yield return new WaitForSeconds(2);
        Death.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}
