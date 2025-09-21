using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Driver : MonoBehaviour
{
    [SerializeField] float currentSpeed = 5f;
    [SerializeField] float steerSpeed = 75f;
    [SerializeField] float regularSpeed = 5f;
    [SerializeField] float boostSpeed = 15f;

    [SerializeField] TMP_Text boostText;

    private void Start()
    {
        boostText.gameObject.SetActive(false);
    }

    void Update()
    {
        float move = 0f;
        float steer = 0f;

        if (Keyboard.current.sKey.isPressed)
        {
            move = 1f;
        }

        else if (Keyboard.current.wKey.isPressed)
        {
            move = -1f;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            steer = 1f;
        }

        else if (Keyboard.current.dKey.isPressed)
        {
            steer = -1f;
        }

        float moveAmount = move * currentSpeed * Time.deltaTime;
        float steerAmount = steer * steerSpeed * Time.deltaTime;

        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0, 0, steerAmount);
    }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Speed"))
            {
                Debug.Log("Go Faster");
                currentSpeed = boostSpeed;
                boostText.gameObject.SetActive(true);
                Destroy(collision.gameObject);

            }
        }
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.CompareTag("EnvorimentalCollision"))
        {
            Debug.Log("Go Slower");
            currentSpeed = regularSpeed;
            boostText.gameObject.SetActive(false);
        }
    }
}

