using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public GameObject enemy;

    public GameObject myTarget;

    public GameObject currentTarget;

    public NavMeshAgent myAgent;

    private Animator animator;

    public float speed;

    public int range = 15;

    public int tetherRange = 30;
    public Vector3 startPos;
    public Vector3 spawnPos = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DistCheck", 0, 0.5f);
        startPos = this.transform.position;

        animator = GetComponent<Animator>(); 

    }

    // Update is called once per frame
    void Update()
    {
        //Speed of enemy
        GetComponent<NavMeshAgent>().speed = 5.0f;

        //If enemy has a target (Player) then it will run towards player
        if (currentTarget != null) {
            myAgent.destination = currentTarget.transform.position;
            //Animation -> Run towards player
            
            animator.SetBool("running", true);
            animator.SetBool("walking", false);
            animator.SetBool("idle", false);
            inRangeCheck(); 
            
        }
        //If the enemy has no target, and is not at the position where it spawned, it will go there by walking anim.
        else if (myAgent.destination != startPos) {
            myAgent.destination = startPos;
            //Animation -> Walk back to position
            
            animator.SetBool("walking", true);
            animator.SetBool("running", false);
            animator.SetBool("idle", false); 
            

        }
        /*
         ATTEMPT TO GET GHOUL TO GO FROM WALKING TO IDLE... 
        if(enemy.transform.position == spawnPos){
            animator.SetBool("idle", true);
            animator.SetBool("running", false);
            animator.SetBool("walking", false);
        }
        */
        

    }
    //Checks how far between the enemy and the player
    public void DistCheck() {
        float dist = Vector3.Distance(this.transform.position, myTarget.transform.position);

        if (dist < range) {
            currentTarget = myTarget; //If in range, it sets the target of the enemy to player
        }
        else if (dist > tetherRange) { //If not in range, no target is set
            currentTarget = null;
        }
    }
    
    public void inRangeCheck() {
        float attackRange = Vector3.Distance(this.transform.position, myTarget.transform.position);
        if (attackRange <=10) { //Checks if player is within range for enemy to perform attack animation
            animator.SetTrigger("attack");
        }

    } 
    
}
