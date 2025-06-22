using UnityEngine;

public class Knowledge : MonoBehaviour
{
    public static int coinTally = 0;
    public static int scoreTally = 0;

    [SerializeField] GameObject coinDisplay;
    [SerializeField] GameObject scoreDisplay;

    // Update is called once per frame
    void Update()
    {
        coinDisplay.GetComponent<TMPro.TMP_Text>().text = "COINS: " + coinTally;
        scoreDisplay.GetComponent<TMPro.TMP_Text>().text = "SCORE: " + scoreTally;
    }
}
