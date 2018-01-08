using UnityEngine;
using System.Collections;

public class RuchBarow : MonoBehaviour
{

    Rigidbody2D gracz;

    void Start()
    {
        GameObject gracz_idz = GameObject.FindGameObjectWithTag("Gracz");

        if (gracz_idz == null)
        {
            Debug.LogError("Nie mozna znalezc obiektu o nazwie 'Gracz'!");
            return;
        }

        gracz = gracz_idz.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float vel = gracz.velocity.x * 0.1f;

        transform.position = transform.position + Vector3.right * vel * Time.deltaTime;
    }
}