using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour   //Bunu main cameraya bağlıyoruz
{
    public OyunKontrol oyk; //Oyunkontrol scriptine erişebilmek için
    Vector2 gecispozisyon;
    Vector2 kamerapozisyon;
    float hassasiyet = 5f;
    float yumusaklik = 1f;
    GameObject oyuncu;

    void Start()
    {
        oyuncu = transform.parent.gameObject;   //sağa sola dönmesi için
        kamerapozisyon.y = 12f; //Oyun başladığında fare yi ortaya odaklar
    }

    void Update()
    {
        if (oyk.oyunaktif == true)
        {
            Vector2 farepoz = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));  //farepoz diye değilken oluşturuyoruz ve bunu mouse x ve mouse y değerlerine atıyoruz
            farepoz = Vector2.Scale(farepoz, new Vector2(hassasiyet * yumusaklik, hassasiyet * yumusaklik));    //farepoz a yumuşaklık ve hassasiyeti ekliyoruz
            gecispozisyon.x = Mathf.Lerp(gecispozisyon.x, farepoz.x, 1f / yumusaklik);  //geçiş poz
            gecispozisyon.y = Mathf.Lerp(gecispozisyon.y, farepoz.y, 1f / yumusaklik);
            kamerapozisyon += gecispozisyon;

            transform.localRotation = Quaternion.AngleAxis(-kamerapozisyon.y, Vector3.right);   //yukarı aşağı
            oyuncu.transform.localRotation = Quaternion.AngleAxis(kamerapozisyon.x, oyuncu.transform.up);   //sağa sola dönmesi için
        }
    }
}
