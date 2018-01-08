using UnityEngine;
using System.Collections;

public class RuchKamery : MonoBehaviour
{

    Transform player;
    float kamera_ruch_x;

    // Use this for initialization
    void Start()
    {
        GameObject gracz_ruch = GameObject.FindGameObjectWithTag("Player");

        if (gracz_ruch == null)
        {
            Debug.LogError("Nie ma obiektu ktory nazywa sie 'Player'");
            return;
        }
        player = gracz_ruch.transform;
        kamera_ruch_x = transform.position.x - player.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 pos = transform.position;
            pos.x = player.position.x + kamera_ruch_x;
            transform.position = pos;
        }
    }
}