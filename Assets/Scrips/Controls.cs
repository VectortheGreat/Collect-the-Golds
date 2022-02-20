using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controls : MonoBehaviour
{
    private float speed = 20;   //Hız için değer atıyoruz

    public OyunKontrol OYK; //Oyunkontrol scriptine erişebilmek için

    public AudioClip altinsesi, dusmesesi;  //Seslere değişken atayıp ardından sesleri klasörden scripte atıyoruz.

    //Ders Dışı- Zıplama ekleme
    public float jump = 2;
    public SphereCollider col;
    private Rigidbody rb;

    public LayerMask GL;
    //Ders Dışı 
    void Start()
    {
        //Ders Dışı
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
        //
    }

    void Update()
    {
        if (OYK.oyunaktif == true)
        {
            float x = Input.GetAxis("Horizontal");  //Hor. Ver. i x ve ye değerine atıyoruz
            float y = Input.GetAxis("Vertical");
            x *= Time.deltaTime * speed;    //Hızı ayarlıyoruz
            y *= Time.deltaTime * speed;

            transform.Translate(x, 0f, y);  //En son alınan sayıları uygulatıyoruz
        }
        // Ders Dışı- Zıplama ekleme
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }
        //

    }
    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * 9f, GL);
    }
    void OnCollisionEnter(Collision c)  //Çarpma metodu 3D için
    {
        if (c.gameObject.tag.Equals("altin"))   //Altın tag'ine çarparsa
        {
            OYK.altinsayaci();
            Destroy(c.gameObject);
            GetComponent<AudioSource>().PlayOneShot(altinsesi, 1f);  //Bu ise dışarıdaki sesi buraya aktarmak için, 1f ise ses yüksekliği(max)
            //AudioSource.PlayClipAtPoint(altinsesi,transform.position); Bu ise eğer scripte veya karaktere ses bağlanmadıysa ikinci bir yöntemdir
        }
        else if (c.gameObject.tag.Equals("dusman")) //Düşman tag'ine çarparsa
        {
            OYK.oyunaktif = false;
            OYK.restarticin = true;
            GetComponent<AudioSource>().PlayOneShot(dusmesesi, 1f);
            //AudioSource.PlayClipAtPoint(dusmesesi,transform.position);
        }
    }
}
