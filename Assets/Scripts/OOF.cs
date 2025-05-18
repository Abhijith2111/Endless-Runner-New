using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OOF : MonoBehaviour
{
    public GameObject Player1 { get; set; }
    public GameObject CameraMain { get; set; }
    public GameObject Death { get; set; }
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
