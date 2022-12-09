using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engel : MonoBehaviour
{
    public float speed = 5f;

    private float ArkadaKalanlar;

    void Start()
    {
        //kameradan çýktýklarý anda kaybolmalarýný istiyorum 
        //küçük bir dipnot oyunun sol tarafý vector3.zero olarak geçer
        ArkadaKalanlar = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        //kameranýn sýfýr noktasýndan 1f sonra sil 
    }

    
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        //oluþturulan engelleri yok etmek lazým dimi

        if (transform.position.x < ArkadaKalanlar)
        {
            Destroy(gameObject);
        }
    }

}
