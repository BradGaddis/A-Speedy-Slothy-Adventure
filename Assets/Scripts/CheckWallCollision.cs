using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWallCollision : MonoBehaviour
{
    public bool isColliding = false;
    public GameObject objHit;
    Collider2D collide2D;
    Rigidbody2D rb;
    Vector2 dir;
    float dirx;
    AudioSource audioSource;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        collide2D = GetComponent<Collider2D>();
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        dir = rb.velocity;
        dirx = dir.x;
        isColliding = CheckCollidedGeneric();
    }

    bool CheckCollidedGeneric() {
        if (rb.velocity.x == 0) 
            {
                return false;
            }
        Vector2 dir = new Vector2(transform.position.x * Mathf.Sign(rb.velocity.x),transform.position.y);
        RaycastHit2D hit = Physics2D.BoxCast(collide2D.bounds.center,collide2D.bounds.extents - new Vector3(0, 0.3f), 0, dir, .3f * Mathf.Sign(rb.velocity.x));
        if (!hit.collider) 
            {
                return false;
            }
        objHit = hit.collider.gameObject;
        bool output = hit.collider && hit.collider.gameObject.name != this.gameObject.name;
        return output;
    }

}
