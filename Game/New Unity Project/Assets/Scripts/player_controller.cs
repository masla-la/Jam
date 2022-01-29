using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    public float speed = 1000.0f;
    public float jumpforce = 25.0f;
    int canjump = 0;
    Vector3 originalPos;
    Vector2 movement;
    private Rigidbody2D _body;

    void Start() 
    {
            originalPos = transform.position; // get a copy
             
             originalPos.x = Mathf.RoundToInt(gameObject.transform.position.x);
             originalPos.y = Mathf.RoundToInt(gameObject.transform.position.y);
             originalPos.z = Mathf.RoundToInt(gameObject.transform.position.z);
             
             transform.position = originalPos;
        _body = GetComponent<Rigidbody2D>();
    }

    void Update() 
    {
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        if (deltaX > 50)
            movement = new Vector2(50, _body.velocity.y);
        else if (deltaX < -50)
            movement = new Vector2(-50, _body.velocity.y);
        else
            movement = new Vector2(deltaX, _body.velocity.y);
        _body.velocity = movement;

        if (Input.GetKeyDown(KeyCode.W) && canjump == 1)
        {
            canjump = 0;
            _body.AddForce (Vector2.up * jumpforce, ForceMode2D.Impulse);
        }
        
        if (gameObject.transform.position.y < -24)
        {
            gameObject.transform.position = originalPos;
            movement = new Vector2(0, 0);
            _body.velocity = movement;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Floor")
            canjump = 1;
    }
}
