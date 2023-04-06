using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ball : MonoBehaviour
    
{
    public Rigidbody2D rigidbody2D;
    public float speed;
    public int rightPlayerScore;
    public int leftPlayerScore;
    public Vector2 velocity;
    public TextMeshProUGUI leftPlayerText;
    public TextMeshProUGUI rightPlayerText;
     


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        ResetAndSetRandomVelocity();
        rightPlayerScore = 0;
        leftPlayerScore = 0;
    }
    private void ResetAndSetRandomVelocity()
    {
        ResetBall();
        rigidbody2D.velocity = GenerateRandomVector2Without0(true) * speed;
        velocity = rigidbody2D.velocity;
    }

    private Vector2 GenerateRandomVector2Without0(bool returnNormalized)
    {
        Vector2 newRandomVector = new Vector2();
        bool shouldXBeLessThanZero = Random.Range(0, 100) % 2 == 0;
        newRandomVector.x = shouldXBeLessThanZero ? Random.Range(-.8f, -.1f) : Random.Range(.1f, .8f);

        bool shouldYBeLessThanZero = Random.Range(0, 100) % 2 == 0;
        newRandomVector.y = shouldYBeLessThanZero ? Random.Range(-.8f, -.1f) : Random.Range(.1f, .8f);

        return returnNormalized ? newRandomVector.normalized : newRandomVector;
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ResetAndSetRandomVelocity();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigidbody2D.velocity = Vector2.Reflect(velocity, collision.contacts[0].normal);
        velocity = rigidbody2D.velocity;
    }
        
    private void ResetBall()
    {
        rigidbody2D.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(transform.position.x > 0)
        {
            leftPlayerScore += 1;
            leftPlayerText.text = leftPlayerScore.ToString();
        }
        if(transform.position.x < 0)
        {
            rightPlayerScore += 1;
            rightPlayerText.text = rightPlayerScore.ToString();
        }
        ResetBall(); 
    }
}
