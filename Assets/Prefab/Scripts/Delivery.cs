using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;

    void Start()
    {
        Debug.Log(hasPackage);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package"))
        {
            Debug.Log("Picked up package");
            hasPackage = true;
        }

        if (collision.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Delivered to customer");
            hasPackage = false;
        }
    }
}
