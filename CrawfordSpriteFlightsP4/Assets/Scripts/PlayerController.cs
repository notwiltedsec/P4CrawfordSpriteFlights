using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public GameObject boosterFlame;
    public float maxSpeed = 5f;
    public float thrustForce = 1f;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.isPressed) 
        {
            // where tf is the mouse? the script that calculates it:
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            Vector2 direction = (mousePos - transform.position).normalized;
            // go go human guy go to the mouse position
            transform.up = direction;
            rb.AddForce(direction * thrustForce);
            // limit the speed of the player because i HATE my players grr i hate it when they go too fast and i cant control them
            if (rb.linearVelocity.magnitude > maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }
        }
        // boosting flame but really its running particles and stuff, but the flame is a particle system so it looks like a flame unfortunately
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            boosterFlame.SetActive(true);
        }
        else if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            boosterFlame.SetActive(false);
        }

    }
    // kill the player when it collides with an obstacle because i hate when my players dont die when they hit obstacles and i want to make sure they die when they hit obstacles
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}

// i want capri desktop assistant on this pc
// capri yams