using UnityEngine;

public class LootBox : MonoBehaviour
{
    [Header("Настройка сундука")]
    [SerializeField] private Sprite openSprite;
    [SerializeField] private Animator animator;
    [SerializeField] private bool oneTimeOnly = true;
    [SerializeField] private AudioSource audioSource;

    private bool opened = false;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (animator == null)
            animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (opened || !other.CompareTag("Player")) return;

        opened = true;
        
        // добавляем звук
        audioSource?.Play();
        
        // Анимация
        if (animator != null)
            animator.SetBool("Open", true);

        // Смена спрайта
        if (openSprite != null && spriteRenderer != null)
            spriteRenderer.sprite = openSprite;

        // Генерация ресурсов
        GenerateLoot();
    }
    
    public void DisableAnimator()
    {
        if (animator != null)
            animator.enabled = false;
    }

    private void GenerateLoot()
    {
        PlayerInfo playerInfo = FindObjectOfType<PlayerInfo>();
        if (playerInfo == null) return;

        int coins = Random.Range(0, 6);  // 0-5
        int orbs = Random.Range(0, 6);   // 0-5
        float chance = Random.value;    // 0.0 – 1.0

        playerInfo.coin += coins;
        playerInfo.orb += orbs;

        if (chance <= 0.01f)  // 1%
        {
            playerInfo.life++;
            Debug.Log("🎉 Игрок получил дополнительную жизнь!");
        }
    }
}