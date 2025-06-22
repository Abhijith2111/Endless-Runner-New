using UnityEngine;

public class OOFBoss2 : MonoBehaviour
{

    [SerializeField] GameObject Player;
    [SerializeField] GameObject playerAnimation;
    [SerializeField] AudioSource collisionFX;
    private void OnTriggerEnter(Collider other)
    {
        collisionFX.Play();
        if(other.gameObject == Player)
        {
            Player.GetComponent<PlayerMoveInBoss1>().enabled = false;
            playerAnimation.GetComponent<Animator>().Play("Hit");
        }
        
    }
}
