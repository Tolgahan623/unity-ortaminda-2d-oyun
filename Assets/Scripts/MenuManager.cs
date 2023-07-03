using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Play(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    /*Play butonuna basarsak Play fonksiyonunu çalıştırıyoruz ve bir sonraki bölüme geçiyoruz. */

    public void Quit(){
        Application.Quit();
    }
    /*Quit butonuna tıklayınca oyun kapanıyor. */
}
