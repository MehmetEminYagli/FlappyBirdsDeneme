using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject PlayButton;
    public GameObject gameover;
    public GameObject GetReady;

    private int score;



    private void Awake()
    {
        Pause();
        gameover.SetActive(false);
        GetReady.SetActive(true);

    }
    public void Play()
    {
        //oyuna baþlandýðýnda önce skoru sýfýrlýcam
        score = 0;
        scoreText.text = score.ToString();

        //sonrasýnda play button ve game over gizlicem
        PlayButton.SetActive(false);
        gameover.SetActive(false);
        GetReady.SetActive(false);

        //oyun hareket etsin diye de timescale'i bir yapýcaðým ki devam etsin

        Time.timeScale = 1f;

        //ve player ýn hareketini etkinleþtiriceðim
        player.enabled = true;

        //oyuncu öldüðünde de kalan engelleri silmem gerekiyor


        Engel[] engeller = FindObjectsOfType<Engel>();

          for (int i = 0; i < engeller.Length; i++)
          {
             Destroy(engeller[i].gameObject);
          }
        
        

    }
    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void skor()
    {//oyun içindeki skorun artýþýný oraya yansýtmamýz gerekiyor
        score++;
        //skor deðiþtiðinde skoretext'e yansýtmak istiyorum
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        //gameover ve play button resmini göstermek istiyorum
        gameover.SetActive(true);
        PlayButton.SetActive(true);
        GetReady.SetActive(false);
        //sonrasýnda oyun durucak
        Pause();
    }
}
