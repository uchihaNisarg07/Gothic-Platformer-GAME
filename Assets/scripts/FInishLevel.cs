
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private GameObject victoryPanel;
    private bool levelFinished = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !levelFinished)
        {
            levelFinished = true;
            victoryPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
