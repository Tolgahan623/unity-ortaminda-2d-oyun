using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public int paraMiktari;

    public bool olebilir;
    public bool hareketEdebilir;

    public GameObject SoruPaneli;

    private bool SoruSor;


    void Start()
    {
        SoruSor = FindObjectOfType<GameManager>().SoruSor;
    }

    void Update()
    {
        Debug.Log(SoruSor);
        // LEVEL GEÇME
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            olebilir = !olebilir;
        }
    }


    public GameObject deathFxPrefab;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("saw") || col.gameObject.CompareTag("fireTrap") ||
        col.gameObject.CompareTag("spikes"))
        {
            if (!olebilir) return;
            this.gameObject.SetActive(false);
            GameObject go = Instantiate(deathFxPrefab, transform.position, transform.rotation);
            Destroy(go, 5f);
            Invoke(nameof(YenidenBaslat), 3f);
        }/*Bu kısımda karakterimizin değdiği objelerin etiketini kontrol ediyoruz. Eğer objenin etiketi
          "saw" , "firetrap" , "spikes" lardan biri ise karakterimizin objesini etkisizleştiriyoruz.
           Ölüm animasyonu oynatıyoruz ve ölüm animasyonunu 5 saniye sonra yok ediyoruz. 3 saniye sonra "restart" fonksiyonu
        çalışıyor ve bölüm yeniden başlıyor*/

        if (col.gameObject.CompareTag("levelEnd"))
        {
            if(!FindObjectOfType<GameManager>().SoruSor)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

            else
            {
                SoruPaneli.SetActive(true);
                FindObjectOfType<QuestionManager>().SorulariOlustur();
                GetComponent<playerMovement>().hareketEdebilir = false;
            }
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }/*Eğer karakterimizin değdiği objenin etiketi "levelEnd" ise karakterimiz bir sonraki bölüme geçiyor. */

        if (col.gameObject.CompareTag("coin"))
        {
            paraMiktari++;
            FindObjectOfType<GameManager>().AltinMiktari--;
            int x = FindObjectOfType<GameManager>().AltinMiktari;
            if(x == 0)
            {
                FindObjectOfType<GameManager>().SoruSor = false;
            }
        }
        /*Karakterimiz altın topladığında, toplam altın sayımız değişiyor. */
    }

    void YenidenBaslat()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    /*Restart fonksiyonu ile bir sonraki bölüme geçiyoruz. */
}
