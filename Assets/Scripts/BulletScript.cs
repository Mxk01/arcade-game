using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public  float velX = 5f;
    float velY = 0f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // we need to turn this to a prefab if we 
        // want the player to shoot
        // moving the bullet to right 
        rb.velocity = new Vector2(velX,velY);
    }
}
