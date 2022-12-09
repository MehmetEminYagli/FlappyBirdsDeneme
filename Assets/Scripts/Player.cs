using UnityEngine;

public class Player : MonoBehaviour
{

    //animasyon i�in player karakteri i�ersindeki spriteRenderer  'i kullan�caz
    private SpriteRenderer spriteRenderer;

    public Sprite[] sprites; //animasyon dizisisi
   
    //hangi animasyon kullan�cak onun indexini alarak yap�caz

    private int spriteIndex;

    private Vector3 direction;

    public float gravity = -10f;
    public float ziplamag�c� = 5f;


    private void Awake()
    {
       spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        //animasyon oyun ba�lad��� ba�l�cak o y�zden starta yaz�yoruz
        InvokeRepeating(nameof(AnimasyonSprite), 0.15f, 0.15f);
        //animasyonsprite methodu  15 saniyede bir tekrar edice
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }


    private void AnimasyonSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        if (spriteIndex < sprites.Length && spriteIndex >= 0)
        {
            spriteRenderer.sprite = sprites[spriteIndex];
        }
        //animasyon olmas� i�in resimleri 15 saniyede bir de�i�tiriyorum ve resim say�m d�ng� i�ideki say�y� ge�ince s�f�ra al diyorum ki resim d�ng�m devam etsin
        // ve animasyon gibi g�z�ks�n
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            direction = Vector3.up * ziplamag�c�;
        }

        //telefonlar i�in dokunarak hareket etme kontrolleri

        if (Input.touchCount > 0)
        {
            Touch dokunma = Input.GetTouch(0);

            if (dokunma.phase == TouchPhase.Began) //dokunma ba�lad���nda
            {
                direction = Vector3.up * ziplamag�c�;
            }
        }

        //yer�ekimi kodlar�
        direction.y += gravity * Time.deltaTime;
        //karakteri a�a��ya do�ru haraketini sa�lama
        transform.position += direction * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Engel")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        else if (collision.gameObject.tag == "Skor")
        {
            FindObjectOfType<GameManager>().skor();
        }
    }

}
