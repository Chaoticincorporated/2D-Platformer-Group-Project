using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject cage;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(cage);
            Destroy(gameObject);
        }
    }
}
