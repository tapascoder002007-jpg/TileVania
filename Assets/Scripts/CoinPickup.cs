using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    GameSession gameSession;
    bool wasCollected = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player")&&!wasCollected)
        {   
            wasCollected = true;
            FindAnyObjectByType<GameSession>().AddToScore(100);
            AudioSource.PlayClipAtPoint(coinPickupSFX,transform.position,1f); 
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
