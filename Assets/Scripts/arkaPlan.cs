using UnityEngine;

public class arkaPlan : MonoBehaviour
{
    //meshRenderer ile arka plan hareketini yapýcaz sonsuz bir þekilde

    private MeshRenderer meshRenderer;

    public float animasyonhýzý = 0.0001f;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        //update ile arka plan hareketini saðlýcaz
        //meshrenderrin ofsetini arttýrarak arkaplaný hareket ettiricez

        meshRenderer.material.mainTextureOffset += new Vector2(animasyonhýzý * Time.deltaTime,0);
        //x i artýrmaya baþla her saniye y sýfýrda kalsýn
    }
}
