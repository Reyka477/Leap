using UnityEngine;
using TMPro;
public class Coin : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private string pickupTriggerName = "Pickup";
    public PlayerInfo PlayerInfo;
    private bool collected = false;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (collected || other == null || !other.CompareTag("Player"))
            return;
        
        // Добавляем монеты, обновляем текст
        collected = true;
        PlayerInfo.UpdateCurrencyText("coin");

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