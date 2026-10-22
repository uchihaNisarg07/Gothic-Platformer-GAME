
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Vector3 startPosition;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            startPosition = player.transform.position;
        }
    }

    public void ResetPlayer(GameObject player)
    {
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }

        player.transform.position = startPosition;
    }
}
