using UnityEngine;

public class Delivery : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package"))
        {
            Debug.Log("Picked up package");
        }

        if (collision.CompareTag("Customer"))
        {
            Debug.Log("Delivered to customer");
        }
    }
}
