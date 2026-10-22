
using UnityEngine;

public class ResetOnTouch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.ResetPlayer(other.gameObject);
        }
    }
}
