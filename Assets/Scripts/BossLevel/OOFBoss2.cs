using System.Collections;
using UnityEngine;

public class OOFBoss2 : MonoBehaviour
{

    [SerializeField] GameObject Player;
    [SerializeField] GameObject playerAnimation;
    [SerializeField] AudioSource collisionFX;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject fadeOut;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(CollisionEnd());
        }
                        
    }

    IEnumerator CollisionEnd()
    {

        Player.GetComponent<PlayerMoveInBoss1>().enabled = false;
        playerAnimation.GetComponent<Animator>().Play("Hit");
        collisionFX.Play();
        mainCamera.GetComponent<Animator>().Play("CollisionCam");
        yield return new WaitForSeconds(2);
        fadeOut.SetActive(true);
    }
}
