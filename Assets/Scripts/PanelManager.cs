using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private GameObject panel; // assign this in inspector

    public void ShowPanel()
    {
        panel.SetActive(true);
    }

    public void HidePanel()
    {
        panel.SetActive(false);
    }
}
