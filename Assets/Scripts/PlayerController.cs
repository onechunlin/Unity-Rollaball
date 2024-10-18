using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public Joystick joystick;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 13)
        {
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        movementX = joystick.Horizontal;
        movementY = joystick.Vertical;
        Vector3 movementVector = new Vector3(movementX, 0, movementY);
        rb.AddForce(movementVector * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }
}
