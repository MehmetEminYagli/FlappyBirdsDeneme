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
        //oyuna ba�land���nda �nce skoru s�f�rl�cam
        score = 0;
        scoreText.text = score.ToString();

        //sonras�nda play button ve game over gizlicem
        PlayButton.SetActive(false);
        gameover.SetActive(false);
        GetReady.SetActive(false);

        //oyun hareket etsin diye de timescale'i bir yap�ca��m ki devam etsin

        Time.timeScale = 1f;

        //ve player �n hareketini etkinle�tirice�im
        player.enabled = true;

        //oyuncu �ld���nde de kalan engelleri silmem gerekiyor


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
    {//oyun i�indeki skorun art���n� oraya yans�tmam�z gerekiyor
        score++;
        //skor de�i�ti�inde skoretext'e yans�tmak istiyorum
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        //gameover ve play button resmini g�stermek istiyorum
        gameover.SetActive(true);
        PlayButton.SetActive(true);
        GetReady.SetActive(false);
        //sonras�nda oyun durucak
        Pause();
    }
}
