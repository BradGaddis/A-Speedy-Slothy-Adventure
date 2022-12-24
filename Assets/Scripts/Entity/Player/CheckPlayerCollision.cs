using UnityEngine;


public class CheckPlayerCollision : MonoBehaviour {
    [SerializeField]
    LayerMask groundLayer;
    [SerializeField]
    BoxCollider2D boxCollider;

    // Box dimensions

    void Start() {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Draw a box in the editor to show the size of the boxcast
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(
            boxCollider.bounds.center,
            boxCollider.bounds.size
        );
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