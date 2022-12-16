using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damageAmount = 25.0f; // amount of damage to deal to the player

    private void OnTriggerEnter(Collider other)
    {
        // check if the collider that entered the trigger is the player
        if (other.CompareTag("Player"))
        {
            // get a reference to the Player script attached to the player game object
            Player playerScript = other.gameObject.GetComponent<Player>();
            // call the TakeDamage() function of the Player script, passing in the damageAmount
            playerScript.TakeDamage(damageAmount);
        }
    }
}
