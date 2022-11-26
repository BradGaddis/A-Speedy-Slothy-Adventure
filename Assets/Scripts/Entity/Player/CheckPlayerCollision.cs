using UnityEngine;


public class CheckPlayerCollision : MonoBehaviour {
    LayerMask groundLayer;
    BoxCollider2D boxCollider;

    void Start() {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public bool IsGrounded() {
        Vector2 direction = Vector2.down;
        float distance = 1f;

        RaycastHit2D hit = Physics2D.BoxCast(
            boxCollider.bounds.center,
            boxCollider.bounds.size,
            0f,
            direction,
            distance,
            groundLayer
        );
        Debug.Log("IsGrounded. Hitting:  " + hit.collider);
        return hit.collider != null;
    }

}