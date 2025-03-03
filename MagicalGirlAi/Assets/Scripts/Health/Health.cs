using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{


    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;


    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Color hurtColor = new Color(204f / 255f, 8f / 255f, 126f / 255f, 0.5f);
    public float dmgColorTime = 0.2f;



    private void Awake()
    {
        currentHealth = startingHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }
     private void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage,0, startingHealth);
        if (0 < currentHealth)
        {
            StartCoroutine(ChangeColorTemporarily());
        }
        else {
            if (!dead)
            {

                anim.SetTrigger("Death");
                GetComponent<Ai>().enabled = false;
                GetComponent<AiAttack>().enabled = false;
                dead = true;
            }
            }
        }

    private IEnumerator ChangeColorTemporarily()
    {
        spriteRenderer.color = hurtColor; 
        yield return new WaitForSeconds(dmgColorTime); 
        spriteRenderer.color = originalColor; 
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }

}