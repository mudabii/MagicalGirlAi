using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{


    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool isDead =false;
    private Aim aimScript;
    private Rigidbody2D rb;
    


    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Color hurtColor = new Color(204f / 255f, 8f / 255f, 126f / 255f, 0.5f);
    public float dmgColorTime = 0.2f;



    private void Awake()
    {
        currentHealth = startingHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        anim = GetComponent<Animator>();
        aimScript = GetComponent<Aim>();
        rb = GetComponent<Rigidbody2D>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage,0, startingHealth);
        if (0 < currentHealth)
        {
            StartCoroutine(ChangeColorTemporarily());
        }
        else {
            if (isDead) return;
            {
                Die();
            }
            }
        }
    private void Die()
    {
        isDead = true;
        anim.SetTrigger("Death");

        StartCoroutine(Reload());

        GetComponent<Ai>().enabled = false;
        GetComponent<AiAttack>().enabled = false;
        GetComponent<Aim>().enabled = false;

        if (aimScript != null)
        {
            aimScript.enabled = false; 
        }
        rb.rotation = 0;
    }

    private IEnumerator ChangeColorTemporarily()
    {
        spriteRenderer.color = hurtColor; 
        yield return new WaitForSeconds(dmgColorTime); 
        spriteRenderer.color = originalColor; 
    }
   public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
    private IEnumerator Reload()
    {
        transform.localScale *= 15f;
        yield return new WaitForSeconds(0.9f);  
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
        Destroy(gameObject);

    }
}