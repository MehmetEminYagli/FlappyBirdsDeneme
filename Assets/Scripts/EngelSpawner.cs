
using UnityEngine;

public class EngelSpawner : MonoBehaviour
{
    public GameObject prefab;

    public float SpawnOran = 1f;

    public float minHeight = -1f;

    public float maxHeight = 1f;

    private void Spawn()
    {                                          //pozisyonu deðiþsin ama rotasyonu sabit kalsýn dedim
        GameObject engel = Instantiate(prefab, transform.position, Quaternion.identity);

        //random engel getirme
        engel.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);

    }
    private void OnEnable()
    {
        //etkin olduðu sürece yani oyuncu ölmediði sürece etkin olucak oyuncu öldüðünde duracak ki oyun kasmasýn
        InvokeRepeating(nameof(Spawn), SpawnOran, SpawnOran);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }
}
