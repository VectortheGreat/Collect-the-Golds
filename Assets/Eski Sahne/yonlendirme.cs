using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yonlendirme : MonoBehaviour
{
    Vector3 pozisyon;   //değişkenleri atıyoruz
    Quaternion yon;
    void Start()
    {
        pozisyon = transform.position;  //pozisyona pozisyon
        yon = transform.rotation;   //yöne yön
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))    //boşluk tuşuna basıldığında
        {
            pozisyon = new Vector3(pozisyon.x + 2f, pozisyon.y, pozisyon.z);    //pozisyona pozisyon değerleri atar
            yon = Quaternion.Euler(0, 120, 0);   //aynı şekilde
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))    //shift tuşuna basıldığında
        {
            pozisyon = new Vector3(pozisyon.x - 2f, pozisyon.y, pozisyon.z);    //shift de tam tersi için kullandım
            yon = Quaternion.Euler(0, 120, 0);
        }
        transform.position = Vector3.Lerp(transform.position, pozisyon, 0.01f);  //en sonunda pozisyonun uygulanması, sonundaki değer hızı
        transform.rotation = Quaternion.Lerp(transform.rotation, yon, 0.01f);   //aynı şekilde
    }
}
