using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerInfo playerInfo;
    public static GameManager Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }
    private void Start()
    {
        if (playerInfo == null)
            Debug.LogError("⚠️ PlayerInfo не назначен в GameManager!");

        else if (playerInfo.coinText == null)
            Debug.LogError("⚠️ coinText не назначен в PlayerInfo!");
    }
    
    // Обновляет текущую полоску здоровья игрока и текст в UI
    public void UpdateHealthUI()
    {
        if (playerInfo == null) return;

        float fill = (float)playerInfo.currentHealth / playerInfo.maxHealth;
        fill = Mathf.Clamp01(fill);

        playerInfo.healthBar.fillAmount = fill;
        playerInfo.healthText.text = playerInfo.currentHealth + " / " + playerInfo.maxHealth;
    }
    
    public void PlayerTakeDamage(int damage)
    {
        playerInfo.currentHealth -= damage;
        if (playerInfo.currentHealth < 0) playerInfo.currentHealth = 0;

        UpdateHealthUI();

        if (playerInfo.currentHealth == 0)
        {
            Debug.Log("Игрок умер");
            playerInfo.Die();
        }
    }
    
    public void UseHealPotion(int amount)
    {
        playerInfo.currentHealth += amount;
        if (playerInfo.currentHealth > playerInfo.maxHealth)
            playerInfo.currentHealth = playerInfo.maxHealth;

        UpdateHealthUI();
    }
    
}
