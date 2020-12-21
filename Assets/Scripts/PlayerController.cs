
using UnityEngine;

// Include the namespace required to use Unity UI and Input System
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    // Create public variables for player speed, and for the Text UI game objects
    public float speed;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI secText;
    public GameObject winTextObject;
    

    private float movementX;
    private float movementY;

    private Rigidbody rb;
    private int count;

    private bool isEndGame = false;
    private float secundomer = 0F;
    private int minute = 0;


    // At the start of the game..
    void Start()
    {
        // Assign the Rigidbody component to our private rb variable
        rb = GetComponent<Rigidbody>();

        // Set the count to zero 
        count = 0;

        SetCountText();

        // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
        winTextObject.SetActive(false);

    }

    void Update()
    {
        if (!isEndGame)
        {
            secundomer += Time.deltaTime;
            if (secundomer.CompareTo(60F) >= 0)
            {
                secundomer = 0F;
                minute++;
            }
            secText.text = string.Format("{0,2:00}:{1,2:00}", minute, (int)System.Math.Floor(secundomer));
        }

    }

    void FixedUpdate()
    { 
        // Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        // ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            // Add one to the score variable 'count'
            count = count + 1;

            // Run the 'SetCountText()' function (see below)
            SetCountText();
        }
    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();

        movementX = v.x;
        movementY = v.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 13)
        {
            // Set the text value of your 'winText'
            winTextObject.SetActive(true);
            isEndGame = true;
        }
    }
}

