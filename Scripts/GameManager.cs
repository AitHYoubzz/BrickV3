using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int vies;
    public int pointage;
    public Text texteVies;
    public Text textePointage;
    // Start is called before the first frame update
    void Start()
    {
        texteVies.text = "Vies:" + vies;
        textePointage.text = "Pointage:" + pointage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void G�rerVies(int viesChang�es)
    {
        vies += viesChang�es;
        texteVies.text = "Vies:" + vies;
        if (vies <= 0)
        {
            SortieJeu();
        }
    }

    public void G�rerPointage(int pointageChang�)
    {
        pointage += pointageChang�;
        textePointage.text = "Pointage:" + pointage;
    }

    void SortieJeu()
    {

    }

    void PauseJeu()
    {
        
    }
}
