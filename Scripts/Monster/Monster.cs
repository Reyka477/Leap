using UnityEngine.UI;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int maxHealth;
    private int _currentHealth;
    public int currentHealth{get{return _currentHealth;}set{GetHit(10);}}
    public int attack;
    public float moveSpeed;
    
    private Rigidbody2D rb;
    public Image healthBar;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    public PlayerInfo PlayerInfo;
    
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        PlayerInfo = FindObjectOfType<PlayerInfo>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Attack()
    {
        PlayerInfo.currentHealth -= attack;
    }

    public void GetHit(int damage)
    {
        _currentHealth -= damage;
        if (currentHealth <= 0) Die();
        else
        {
            animator.SetTrigger("Hurt");
        }
        
    }

    public void Die()
    {
        if (animator != null)
        {
            animator.SetTrigger("Die");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) Attack();

        if (collision.gameObject.CompareTag("Sword")) GetHit(10);
    }
    
}
