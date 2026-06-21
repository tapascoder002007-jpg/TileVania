using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public AudioClip enemySplat;
    [SerializeField] AudioClip jumpingSound;
    [SerializeField] AudioClip bulletshoot;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip boing;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    [SerializeField] float moveSpeed  = 10f;
    [SerializeField] float jumpSpeed = 10f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(10f,20f);
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    float gravityScaleAtStart;

    bool isAlive = true;

    SpriteRenderer spriteRenderer;
    Animator myAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        gravityScaleAtStart = myRigidbody.gravityScale;
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(!isAlive){return;}
        Run();
        FlipSprite();
        ClimbLadder();
        Die();
        if (myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Bouncing")))
        {
            AudioSource.PlayClipAtPoint(boing,transform.position,0.1f);
        }
        
    }

    void OnMove(InputValue value)
    {   
        if(!isAlive){return;}
        moveInput = value.Get<Vector2>();
        
    }

    void OnJump(InputValue value)
    {
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if (value.isPressed)
        {
            //do stuff
            myRigidbody.linearVelocity+=new Vector2(0f,jumpSpeed);
            AudioSource.PlayClipAtPoint(jumpingSound,transform.position,0.3f);
        }
    }
    void Run()
    {
        Vector2 playerVeclocity = new Vector2 (moveInput.x*moveSpeed,myRigidbody.linearVelocity.y);
        myRigidbody.linearVelocity = playerVeclocity;
        bool hasHorizontalSpeed = Mathf.Abs(myRigidbody.linearVelocity.x)>Mathf.Epsilon;
        if (hasHorizontalSpeed)
        {
            myAnimator.SetBool("isRunning", true);
        }
        else
        {
            myAnimator.SetBool("isRunning", false);
        }

    }
    void FlipSprite()
    {
        bool hasHorizontalSpeed = Mathf.Abs(myRigidbody.linearVelocity.x)>Mathf.Epsilon;
        if (hasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.linearVelocity.x),1f);
        }
    }

    void ClimbLadder()
    {
        if (!myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
            {   
                myAnimator.SetBool("isClimbing", false);
                myRigidbody.gravityScale = gravityScaleAtStart;
                return;
            
            }
            bool hasVerticalSpeed = Mathf.Abs(myRigidbody.linearVelocity.y)>Mathf.Epsilon;
            if (hasVerticalSpeed)
            {
                myAnimator.SetBool("isClimbing", true);
            }
            else
            {
                myAnimator.SetBool("isClimbing", false);
            }
            myRigidbody.gravityScale = 0f;
            Vector2 climbVeclocity = new Vector2 (myRigidbody.linearVelocity.x,moveInput.y*climbSpeed);
            myRigidbody.linearVelocity = climbVeclocity;
        
    }
    void OnAttack(InputValue value)
    {
        if(!isAlive){return;}
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            return;
        }
        myAnimator.SetTrigger("Attack");
        Instantiate(bullet,gun.position,transform.rotation);
        AudioSource.PlayClipAtPoint(bulletshoot,transform.position,1f); 
    }
    void Die()
    {
        if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards"))){
            isAlive = false;
            myAnimator.SetTrigger("Dying");
            spriteRenderer.color = new Color(1f, 0.4f, 0.4f, 1f);
            AudioSource.PlayClipAtPoint(deathSound,transform.position,2f);
            myRigidbody.linearVelocity = deathKick;
            myRigidbody.linearDamping = 5f;
            StartCoroutine(HandleDeath());
            
        }
    }
    IEnumerator HandleDeath()
{
    yield return new WaitForSeconds(0.83f); // Match animation length
    FindAnyObjectByType<GameSession>().ProcessPlayerDeath();
}
    
}
