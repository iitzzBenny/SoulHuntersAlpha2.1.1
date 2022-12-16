using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public int theSpeed = 15;

    void Start()
    {
    }

    
    void Update()
    {

            this.transform.Translate(Vector3.left * theSpeed * Time.deltaTime);
        
    }
}
