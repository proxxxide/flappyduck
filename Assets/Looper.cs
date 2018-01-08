using UnityEngine;
using System.Collections;

public class Looper : MonoBehaviour
{
    int BGcount = 4; // ilosc tekstur tla

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Triggered: " + collider.name);

        float widthOfBGObject = ((BoxCollider2D)collider).size.x;
        Vector3 pos = collider.transform.position;
        pos.x += widthOfBGObject * BGcount;
        collider.transform.position = pos;
    }
}