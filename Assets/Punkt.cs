using UnityEngine;
using System.Collections;

public class Punkt : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Wynik.AddPoint();
        }
    }
}