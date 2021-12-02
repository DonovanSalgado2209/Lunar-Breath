using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    bool isImnune;
    public float inmunityTime;
    SpriteRenderer sprite;
    public float knockbacForceX;
    public float knockbacForceY;
    Rigidbody2D rb;
    Blinks material;
    public Slider barraVida;

    public GameObject GameOverImg;
    public GameObject GameFinishImg;


    // Start is called before the first frame update
    void Start()
    {
        GameOverImg.SetActive(false);
        GameFinishImg.SetActive(false);
        material = GetComponent<Blinks>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        health = maxHealth;
        Score.scoreValue = 0;
        Time.timeScale = 1;
    }
    void Update()
    {
        barraVida.value = health;
        if(Score.scoreValue == 80)
        {
            Time.timeScale = 0;
            GameFinishImg.SetActive(true);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo") && !isImnune)
        {
            health -= collision.GetComponent<EnemigoController>().damageToGiven;
            StartCoroutine(Inmunity());

            if(collision.transform.position.x > transform.position.x)
            {
                rb.AddForce(new Vector2(-knockbacForceX, knockbacForceY), ForceMode2D.Force);
            }
            else
            {
                rb.AddForce(new Vector2(knockbacForceX, knockbacForceY), ForceMode2D.Force);
            
            }

            if (health <= 0)
            {
                Time.timeScale = 0;
                GameOverImg.SetActive(true);

            }
        }
    }
    
    IEnumerator Inmunity()
    {
        isImnune = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds(inmunityTime);
        sprite.material = material.original;
        isImnune = false;
    }
   
}
