using System.Collections;
using UnityEngine;

public class OOFLevel2 : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject playerAnimation;
    [SerializeField] AudioSource collisionFX;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject FadeOut;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(CollisionEnd());
        }

    }

    IEnumerator CollisionEnd()
    {

        Player.GetComponent<PlayerMovement2>().enabled = false;
        playerAnimation.GetComponent<Animator>().Play("Hit");
        collisionFX.Play();
        mainCamera.GetComponent<Animator>().Play("collisionCam");
        yield return new WaitForSeconds(2);
        FadeOut.SetActive(true);
    }
}
