using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoHealth : MonoBehaviour
{
    EnemigoController enemigo;
    bool isImnune;
    public float inmunityTime;
    // Start is called before the first frame update
    void Start()
    {
        enemigo = GetComponent<EnemigoController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Golpe") && !isImnune)
        {
            enemigo.healthPoints -= 5f;
            StartCoroutine(Inmunity());

            if (enemigo.healthPoints <= 0)
            {
                Destroy(gameObject);
                Score.scoreValue += 10;
            } 
        }
    }

    IEnumerator Inmunity()
    {
        isImnune = true;
        yield return new WaitForSeconds(inmunityTime);
        isImnune = false;
    }
}
