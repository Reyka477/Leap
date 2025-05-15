using System;
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
   public GameObject heartPrefab;
   public Transform container;
   private List<GameObject> hearts = new List<GameObject>();
   
   public int maxHealth = 100;
   public int currentHealth;
   public int life;
   public int orb;
   public int key;
   public int coin;
   private void Start()
   {
    currentHealth = maxHealth;
    coin = 0;
    life = 0;
    orb = 0;
    key = 0;
   }
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

   public void UpdateCurrencyText(string type)
   {
      if (type == "coin")
      {
         coin++;
         coinText.text = coin.ToString();
      }
      else if (type == "orb")
      {
         orb++;
         orbText.text = orb.ToString();
      }
   }

   public void Die()
   {
      Debug.Log("Игрок умер 😵");
   }

}
