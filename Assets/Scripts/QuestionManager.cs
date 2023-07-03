using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class QuestionManager : MonoBehaviour
{
    public GameObject Panel;

    public Vector3[] Pozisyonlar;

    public Text Soru;

    public Button CevapButon1;
    public Button CevapButon2;
    public Button CevapButon3;
    public Button CevapButon4;

    private int rnd;

    public List<QuestionAndAnswers> SvC;

    public void TrueAnswer()
    {
        // win
        Panel.SetActive(false);
        Debug.Log("win");
        FindObjectOfType<GameManager>().StartCoroutine("Firework");
        Invoke(nameof(SonrakiBolum), 2f);
    }/*Eğer bölüm sonunda çıkan sonuç doğru ise GameManager scriptindeki "Firework" fonksiyonunu çalıştırıp
      * animasyon gösteriyoruz ve 2 saniye sonra sonraki bölüme geçen fonksiyonu çalıştırmasını sağlıyoruz.*/

    public void FalseAnswer()
    {
        // lose
        Panel.SetActive(false);
        Debug.Log("lose");
        Invoke(nameof(YenidenBaslat), 0.5f);
    }/*Eğer verdiğimiz sonuç yanlış ise bölümü yeniden başlatma kodu 0.5 saniye sonra çalışıyor. */

    private Vector3 GeciciPozisyon;

    public void SorulariOlustur()
    {

        for (int i = 0; i < Pozisyonlar.Length; i++)
        {
            int rnd = Random.Range(0, Pozisyonlar.Length);
            GeciciPozisyon = Pozisyonlar[rnd];
            Pozisyonlar[rnd] = Pozisyonlar[i];
            Pozisyonlar[i] = GeciciPozisyon;
        }
        /*Soruların cevaplarının üzerinde yazdığı butonların yeri, harita üzerindeki 4 pozisyona rasgele biçimde seçiliyor.
         * Bunu ise dizinin elemanlarını rasgele dağıtarak yapıyoruz.*/

        rnd = Random.Range(0, SvC.Count);

        Soru.text = SvC[rnd].Soru;

        CevapButon1.image.sprite = SvC[rnd].Cevaplar[0];
        CevapButon2.image.sprite = SvC[rnd].Cevaplar[1];
        CevapButon3.image.sprite = SvC[rnd].Cevaplar[2];
        CevapButon4.image.sprite = SvC[rnd].Cevaplar[3];

        CevapButon1.transform.localPosition = Pozisyonlar[0];
        CevapButon2.transform.localPosition = Pozisyonlar[1];
        CevapButon3.transform.localPosition = Pozisyonlar[2];
        CevapButon4.transform.localPosition = Pozisyonlar[3];

        /*Cevap butonlarının resimlerini ve pozisyonlarını belirliyoruz. */
    }

    public void SonrakiBolum()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    /*Sonraki bölüme geçiyoruz. */

    public void YenidenBaslat()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    /*Bölümü yeniden başlatıyoruz. */

    void Start()
    {
        SorulariOlustur();
    }
}
