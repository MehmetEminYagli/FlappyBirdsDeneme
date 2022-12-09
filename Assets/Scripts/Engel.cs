using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engel : MonoBehaviour
{
    public float speed = 5f;

    private float ArkadaKalanlar;

    void Start()
    {
        //kameradan ��kt�klar� anda kaybolmalar�n� istiyorum 
        //k���k bir dipnot oyunun sol taraf� vector3.zero olarak ge�er
        ArkadaKalanlar = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        //kameran�n s�f�r noktas�ndan 1f sonra sil 
    }

    
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        //olu�turulan engelleri yok etmek laz�m dimi

        if (transform.position.x < ArkadaKalanlar)
        {
            Destroy(gameObject);
        }
    }

}
