using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OyunKontrol : MonoBehaviour
{
    public bool oyunaktif = false;
    public int altinsayisi = 0;   //Altınların sayı değeri
    public Text altinsayma; //Altın sayısının metni
    public Button butonugizle;  //Butonu gizlemek için bir değişken
    public Button restartbut;  //Restart butonu için

    public bool restarticin = false ;

    void Start()
    {
        GetComponent<AudioSource>().Play();   //Başlatma Komutu
        //Pause, Stop da var.
    }

    void Update()
    {
        if (oyunaktif == false && restarticin==true)
        {
            restartbut.gameObject.SetActive(true);
        }
    }
    public void altinsayaci()
    {
        altinsayisi += 1;
        altinsayma.text = "Coins: " + altinsayisi;
    }
    public void OyunBasla()
    {
        oyunaktif = true;
        butonugizle.gameObject.SetActive(false);
    }

}
