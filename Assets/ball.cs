using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
    
{
    public Rigidbody2D rigidbody2D;
    public float speed;
    public Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
     
        rigidbody2D.velocity = new Vector2(Random.Range(-1f, 1f) * speed, Random.Range(-1f, 1f) * speed);
        velocity = rigidbody2D.velocity;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigidbody2D.velocity = Vector2.Reflect(velocity, collision.contacts[0].normal);
        velocity = rigidbody2D.velocity;
    }
}
