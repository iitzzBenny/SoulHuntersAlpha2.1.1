using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthAndDamage : MonoBehaviour
{
    public float ghoulHealth = 100f;
    public float arrowDamage = 25f;
    public AudioClip deathSound; // placeholder for death sound


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "arrow")
        {
            ghoulHealth = ghoulHealth - arrowDamage;
        }
        if (ghoulHealth <= 0)
        {
            // play death sound
            if (deathSound != null)
            {
                AudioSource.PlayClipAtPoint(deathSound, transform.position);
            }

            Destroy(gameObject);
        }
    }
}
