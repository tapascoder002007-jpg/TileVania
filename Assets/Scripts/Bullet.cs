using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 20f;
    Rigidbody2D myRigidbody;
    PlayerMovement player;
    float xSpeed;
    void Start()
    {   
        player = FindAnyObjectByType<PlayerMovement>();
        myRigidbody = GetComponent<Rigidbody2D>();
        xSpeed=player.transform.localScale.x*bulletSpeed;
    }

    void Update()
    {
        myRigidbody.linearVelocity = new Vector2(xSpeed,0f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {   
            AudioSource.PlayClipAtPoint(player.enemySplat,transform.position,1f);
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject,0.1f);
    }
}
