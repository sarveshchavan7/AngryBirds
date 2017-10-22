using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour {

    public float health = 3f;
    public GameObject deathEffect;
   public static int enemyAlive = 0;

    private void Start()
    {
        enemyAlive++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude>health) {
            Die();
        }
    }

    private void Die() {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        enemyAlive--;
        if (enemyAlive <= 0) {
          
            Debug.Log("WON");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    
        Destroy(gameObject);
    }
}
