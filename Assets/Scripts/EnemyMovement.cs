using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigidbody;
    BoxCollider2D myBoxCollider;

    void Start()
    {
      myRigidbody = GetComponent<Rigidbody2D>();  
      myBoxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        myRigidbody.linearVelocity = new UnityEngine.Vector2 (moveSpeed,0f);
        
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Ground"))
        return;
        moveSpeed = -moveSpeed;
        bool hasHorizontalSpeed = Mathf.Abs(myRigidbody.linearVelocity.x)>Mathf.Epsilon;
        if (hasHorizontalSpeed)
        {
            transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.linearVelocity.x)),1f);
        }
    }
}
