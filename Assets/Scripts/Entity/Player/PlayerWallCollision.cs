using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallCollision : MonoBehaviour
{
    public bool isColliding = false;
    public GameObject objHit;
    Collider2D collide2D;
    Rigidbody2D rb;
    Vector2 dir;
    float dirx;
    LayerMask groundMask;

    bool HitWall() {
        RaycastHit2D raycastHit2DRight = Physics2D.BoxCast(collide2D.bounds.center, collide2D.bounds.size, 90f, dir, .1f, groundMask);
        RaycastHit2D raycastHit2DLeft = Physics2D.BoxCast(collide2D.bounds.center, collide2D.bounds.size, 90f, -dir, .1f, groundMask);
        return raycastHit2DRight.collider != null || raycastHit2DLeft.collider != null;
    }
}
