using UnityEngine;
 


public class changeColor : MonoBehaviour
{
    private MeshRenderer meshRenderer1,meshRenderer2;
    public GameObject gameObject1, gameObject2;
    public Material kirmizi, mavi, mor, turkuaz, yesil,defaultMet;
    public AudioSource colorAudio;

    int getPressKeyNumber = 0;
    //oyunu kazandınız ifadesinin ekrana bir kere basılmasi için konulmuş bir değişken.
    bool endGame = false;

    void Start()
    {
        //meshrendererlar getirildi.
        meshRenderer1 = getMeshRenderer(gameObject1);
        meshRenderer2 = getMeshRenderer(gameObject2);
        
    }

    void Update()
    {
        //iki obje içinde colorChange fonksiyonu çağırıldı.
        colorChange(meshRenderer1);
        colorChange(meshRenderer2);
        if (!endGame)
        {
           gameOver(gameObject1, gameObject2);
        }
        
    }

    

    MeshRenderer getMeshRenderer(GameObject gameObject)
    {
        
        MeshRenderer meshRenderer;
        //parametre olarak alınan gameObject nesnesinin meshrenderer componenti çekildi.
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        return meshRenderer;

    }

    void colorChange(MeshRenderer meshRenderer)
    {   
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            getPressKeyNumber++;
            //her tuşa basildiginda müzik oynatiliyor.
            colorAudio.Play();
            int randomNumber = Random.Range(0, 5);

            switch (randomNumber)
            {
                case 0:
                    meshRenderer.material = kirmizi;
                    break;
                case 1:
                    meshRenderer.material = mavi;
                    break;
                case 2:
                    meshRenderer.material = mor;
                    break;
                case 3:
                    meshRenderer.material = turkuaz;
                    break;
                case 4:
                    meshRenderer.material = yesil;
                    break;
            }

        }
    }
        
    void gameOver(GameObject gameObjectOne,GameObject gameObjectTwo)
    {
        MeshRenderer mesh1 = gameObjectOne.GetComponent<MeshRenderer>();
        MeshRenderer mesh2 = gameObjectTwo.GetComponent<MeshRenderer>();

        //oyun baslangicinda iki objenin de metarialleri aynı olduğu için oyun kazanma ekranı çıkmaması için bu eklenmiştir.
        //hiçe tuşa basılmadığı takdirde ekrana oyunu kazandınız bastırmaz.
        if (getPressKeyNumber!=0)
        {
            if (mesh1.material.name == mesh2.material.name)
            {
                //oyunu kazandınız ibaresinin bir kere ekrana basilmasi için konulmuş bir değişken.
                endGame = true;
                Debug.Log("Oyunu Kazandiniz...");
      
            }
        }
        

    }
}
