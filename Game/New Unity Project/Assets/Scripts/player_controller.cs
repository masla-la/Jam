using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    public float speed = 1000.0f;
    public float jumpforce = 25.0f;
    int canjump = 0;

    private Rigidbody2D _body;

    void Start() 
    {
        _body = GetComponent<Rigidbody2D>();
    }

    void Update() 
    {
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector2 movement = new Vector2(deltaX, _body.velocity.y);
        _body.velocity = movement;

        if (Input.GetKeyDown(KeyCode.W) && canjump == 1)
        {
            canjump = 0;
            _body.AddForce (Vector2.up * jumpforce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Floor")
            canjump = 1;
    }
}
