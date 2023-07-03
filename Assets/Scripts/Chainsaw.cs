using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chainsaw : MonoBehaviour
{
    public float rotasyonHizi;
    public float zamanlayici;
    private float geciciZamanlayici;

    void Start()
    {
        geciciZamanlayici = zamanlayici;
    }

    void Update()
    {
        geciciZamanlayici -= Time.deltaTime;
        if (geciciZamanlayici <= 0)
        {
            TersCevir();
        }
        transform.Rotate(0f, 0f, rotasyonHizi * Time.deltaTime);
    }/*Testerenin belli bir süre bir yöne dönüp daha sonra yönünü değiştirmesini sağlıyoruz. */

    void TersCevir()
    {
        rotasyonHizi *= -1f;
        geciciZamanlayici = zamanlayici;
    }
    /*Rotasyon hızını - haline çeviriyoruz. */
}
