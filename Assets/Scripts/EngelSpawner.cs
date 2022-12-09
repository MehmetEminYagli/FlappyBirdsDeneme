
using UnityEngine;

public class EngelSpawner : MonoBehaviour
{
    public GameObject prefab;

    public float SpawnOran = 1f;

    public float minHeight = -1f;

    public float maxHeight = 1f;

    private void Spawn()
    {                                          //pozisyonu de�i�sin ama rotasyonu sabit kals�n dedim
        GameObject engel = Instantiate(prefab, transform.position, Quaternion.identity);

        //random engel getirme
        engel.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);

    }
    private void OnEnable()
    {
        //etkin oldu�u s�rece yani oyuncu �lmedi�i s�rece etkin olucak oyuncu �ld���nde duracak ki oyun kasmas�n
        InvokeRepeating(nameof(Spawn), SpawnOran, SpawnOran);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }
}
