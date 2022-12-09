using UnityEngine;

public class arkaPlan : MonoBehaviour
{
    //meshRenderer ile arka plan hareketini yap�caz sonsuz bir �ekilde

    private MeshRenderer meshRenderer;

    public float animasyonh�z� = 0.0001f;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        //update ile arka plan hareketini sa�l�caz
        //meshrenderrin ofsetini artt�rarak arkaplan� hareket ettiricez

        meshRenderer.material.mainTextureOffset += new Vector2(animasyonh�z� * Time.deltaTime,0);
        //x i art�rmaya ba�la her saniye y s�f�rda kals�n
    }
}
