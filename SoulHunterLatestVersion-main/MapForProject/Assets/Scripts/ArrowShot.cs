using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShot : MonoBehaviour
{
    private bool isOut = false;
    public GameObject theArrow = null;
    public AudioClip arrowShotSound; // placeholder for arrow shot sound
    private Vector3 thePos = Vector3.zero;
    private float shootInterval = 0.5f; // interval between arrow shots, in seconds
    private float elapsedTime = 0f; // elapsed time since last arrow shot

    void Start()
    {

    }


    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            elapsedTime += Time.deltaTime; // update elapsed time

            thePos = this.transform.position;
            if (Input.GetKeyDown(KeyCode.Mouse0) && elapsedTime >= shootInterval)
            {
                isOut = true;
            }

            if (isOut)
            {
                GameObject cloneArrow = (GameObject)Instantiate(theArrow, thePos, Quaternion.identity);
                cloneArrow.transform.position = thePos;
                cloneArrow.transform.rotation = this.transform.rotation;
                isOut = false;
                elapsedTime = 0f; // reset elapsed time

                // play arrow shot sound
                if (arrowShotSound != null)
                {
                    AudioSource.PlayClipAtPoint(arrowShotSound, transform.position);
                }
            }
        }
    }
}
