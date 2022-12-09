using UnityEngine;

public class Player : MonoBehaviour
{

    //animasyon için player karakteri içersindeki spriteRenderer  'i kullanýcaz
    private SpriteRenderer spriteRenderer;

    public Sprite[] sprites; //animasyon dizisisi
   
    //hangi animasyon kullanýcak onun indexini alarak yapýcaz

    private int spriteIndex;

    private Vector3 direction;

    public float gravity = -10f;
    public float ziplamagücü = 5f;


    private void Awake()
    {
       spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        //animasyon oyun baþladýðý baþlýcak o yüzden starta yazýyoruz
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
        //animasyon olmasý için resimleri 15 saniyede bir deðiþtiriyorum ve resim sayým döngü içideki sayýyý geçince sýfýra al diyorum ki resim döngüm devam etsin
        // ve animasyon gibi gözüksün
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            direction = Vector3.up * ziplamagücü;
        }

        //telefonlar için dokunarak hareket etme kontrolleri

        if (Input.touchCount > 0)
        {
            Touch dokunma = Input.GetTouch(0);

            if (dokunma.phase == TouchPhase.Began) //dokunma baþladýðýnda
            {
                direction = Vector3.up * ziplamagücü;
            }
        }

        //yerçekimi kodlarý
        direction.y += gravity * Time.deltaTime;
        //karakteri aþaðýya doðru haraketini saðlama
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
