using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regione : MonoBehaviour
{
    public Vector3 coordin;
    public Camera camm;
    void Update()
    {
        if (Vector3.Distance(transform.position, camm.transform.position) > 20000)
        {
            Destroy(gameObject); 
        }
    }
}
