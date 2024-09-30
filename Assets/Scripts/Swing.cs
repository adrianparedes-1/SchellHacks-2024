using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Swing : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Collided");
    }
}
