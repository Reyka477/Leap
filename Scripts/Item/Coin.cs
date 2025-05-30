using UnityEngine;
using TMPro;
public class Coin : MonoBehaviour
{
    [SerializeField] private string pickupTriggerName = "Pickup";
    [SerializeField] private AudioSource audioSource;
    
    public PlayerInfo PlayerInfo;
    private bool collected = false;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        PlayerInfo = FindObjectOfType<PlayerInfo>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (collected || other == null || !other.CompareTag("Player"))
            return;
        
        // Добавляем монеты, обновляем текст
        collected = true;
        PlayerInfo.UpdateCurrencyText("coin");
        
        // Запускаем звук
        if (audioSource != null)
            audioSource.Play();

        // Запускаем анимацию
        if (anim != null)
        {
            anim.SetTrigger(pickupTriggerName);
        }
    }
    
    // Этот метод вызывается в конце анимации (Animation Event), удаляет объект
    public void DestroyAfterAnimation()
    {
        Destroy(gameObject);
    }
}