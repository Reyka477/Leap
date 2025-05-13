using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
   public Image healthBar;
   public TextMeshProUGUI healthText;
   public TextMeshProUGUI coinText;
   public TextMeshProUGUI orbText;
   public int life = 0;
   public GameObject heartPrefab;
   public Transform container;
   private List<GameObject> hearts = new List<GameObject>();
   
   public void AddHeart()
   {
      GameObject newHeart = Instantiate(heartPrefab, container);

      // Вставляем сердце слева
      newHeart.transform.SetSiblingIndex(0);
      hearts.Insert(0, newHeart);

      // Запускаем анимацию появления 
      Animator anim = newHeart.GetComponent<Animator>();
      if (anim != null)
         anim.SetTrigger("Appear");

      life++;
   }
   public void RemoveHeart()
   {
      if (life <= 0 || hearts.Count == 0)
      {
         Die();
         return;
      }

      // Берём последнее сердце
      GameObject heartToRemove = hearts[hearts.Count - 1];

      // Запускаем анимацию исчезновения
      Animator anim = heartToRemove.GetComponent<Animator>();
      
      if (anim != null)
         anim.SetTrigger("Disappear");

      // Удаляем с задержкой
      Destroy(heartToRemove, 0.3f);

      hearts.RemoveAt(hearts.Count - 1);
      life--;

      if (life <= 0)
         Die();
   }

   private void Die()
   {
      Debug.Log("Игрок умер 😵");
   }

}
