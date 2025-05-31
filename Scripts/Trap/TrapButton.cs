using UnityEngine;

using UnityEngine;

public class TrapButton : MonoBehaviour
{
    [SerializeField] private Sprite pressedSprite;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject trapToActivate;

    private SpriteRenderer spriteRenderer;
    private bool pressed = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (pressed || !other.CompareTag("Player")) return;

        pressed = true;

        // включаем звук
        if (audioSource != null) audioSource.Play();

        // меняем спрайт
        if (pressedSprite != null && spriteRenderer != null)
            spriteRenderer.sprite = pressedSprite;

        // включаем анимацию ловушки
        Animator trapAnim = trapToActivate.GetComponent<Animator>();
        if (trapAnim != null)
            trapAnim.enabled = true;

        // активируем коллайдер ловушки
        Collider2D trapCollider = trapToActivate.GetComponent<Collider2D>();
        if (trapCollider != null)
            trapCollider.enabled = true;
    }
}
