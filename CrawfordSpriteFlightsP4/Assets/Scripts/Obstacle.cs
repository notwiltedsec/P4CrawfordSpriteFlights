using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float minsize = 0.3f;
    public float maxsize = 2.5f;
    public float minSpeed = 30f;
    public float maxSpeed = 150f;
    public float maxSpinSpeed = 100f;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float randomSize = Random.Range(minsize, maxsize);
        transform.localScale = new Vector3(randomSize, randomSize, 1);
        float randomSpeed = Random.Range(minSpeed, maxSpeed) / randomSize;
        Vector2 randomDirection = Random.insideUnitCircle;
        rb.AddForce(randomDirection * randomSpeed);
        float randomTorque = Random.Range(-maxSpinSpeed, maxSpinSpeed);
        rb.AddTorque(randomTorque);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
