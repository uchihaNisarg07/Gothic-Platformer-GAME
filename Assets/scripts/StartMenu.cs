
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;

    private void Start()
    {
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("START GAME BUTTON WORKED!");
    }
}
