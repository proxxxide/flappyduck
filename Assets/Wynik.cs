using UnityEngine;
using System.Collections;

public class Wynik : MonoBehaviour
{
    
    static int wynik = 0;
    static int najWynik = 0;

    static Wynik instance;

    static public void AddPoint()
    {
        if (instance.kaczka.dead)
            return;

        wynik++;

        if (wynik > najWynik)
        {
            najWynik = wynik;
        }
    }

    RuchKaczki kaczka;

    void Start()
    {
        instance = this;
        GameObject gracz_idz = GameObject.FindGameObjectWithTag("Player");
        if (gracz_idz == null)
        {
            Debug.LogError("Nie ma obiektu ktory nazywa sie 'Player'.");
        }

        kaczka = gracz_idz.GetComponent<RuchKaczki>();
        wynik = 0;
        najWynik = PlayerPrefs.GetInt("Rekord", 0);
    }

    void OnDestroy()
    {
        instance = null;
        PlayerPrefs.SetInt("Rekord", najWynik);
    }

    void Update()
    {
        GetComponent<GUIText>().text = "Wynik: " + wynik + "\nRekord: " + najWynik;
    }
}