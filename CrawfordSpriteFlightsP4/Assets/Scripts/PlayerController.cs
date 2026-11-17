using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{


    private float elapsedTime = 0f;
    private float score = 0f;

    public float scoreMultiplier = 10f;
    public float thrustForce = 1f;

    Rigidbody2D rb;

    public UIDocument uiDocument;
    public GameObject boosterFlame;
    private Label scoreText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
    }

    void Update()
    {
        UpdateScore();
        MovePlayer();
    }

    void MovePlayer()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            boosterFlame.SetActive(true);
        }
        else if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            boosterFlame.SetActive(false);
        }

        if (Mouse.current.leftButton.isPressed)
        {


            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            Vector2 direction = (mousePos - transform.position).normalized;


            transform.up = direction;
            rb.AddForce(direction * thrustForce);
        }
    }
void UpdateScore()
    {
        elapsedTime += Time.deltaTime;
        score = Mathf.FloorToInt(elapsedTime * scoreMultiplier);
        scoreText.text = "Score: " + score;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
// no more commeents because I am tired of writing them and also i slacked off the entirety of tuesday so i am going to lock in and get caught up so when i go home i can sleep for 30 hours
// also i am going to make a new story and it will not be related to this project at all because its fun to slack off 
// not during this period im joking i swear i will get caught up and not slack off anymore uhhh idk im bored too 