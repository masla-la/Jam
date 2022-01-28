using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death_check : MonoBehaviour
{
    private Rigidbody2D _body;
    private Collision2D collision;

   
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(collision.transform.tag == "Finish")
        {
            Destroy(this.gameObject);
        }
    }
}
