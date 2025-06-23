using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class OOFBoss2 : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject playerAnimation;
    [SerializeField] AudioSource collisionFX;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject fadeOut;
    [SerializeField] GameObject deathMenu;
    [SerializeField] TMP_Text finalScoreText;
    [SerializeField] TMP_Text finalCoinText;
    [SerializeField] TMP_Text finalTimeText;

    private float deathTime;

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

        yield return new WaitForSeconds(1); // Optional delay before showing menu

        deathTime = Time.timeSinceLevelLoad;

        finalScoreText.text = "SCORE: " + Knowledge.scoreTally;
        finalCoinText.text = "COINS: " + Knowledge.coinTally;
        finalTimeText.text = "TIME: " + Mathf.RoundToInt(deathTime) + "s";

        SaveScore(Knowledge.scoreTally, Knowledge.coinTally, deathTime);

        deathMenu.SetActive(true);
    }

    void SaveScore(int score, int coins, float time)
    {
        HighscoreManager.SaveRun(score, coins, Mathf.RoundToInt(time));
    }
}
