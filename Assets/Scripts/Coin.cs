using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotasyonHizi;

    public GameObject coinFxPrefab;


    void Update()
    {
        transform.Rotate(0f, rotasyonHizi * Time.deltaTime, 0f);
    }
    /*Altın sürekli olarak belli hızda dönüyor. */

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("player"))
        {
            Destroy(gameObject);
            GameObject go = Instantiate(coinFxPrefab, transform.position, transform.rotation);
            Destroy(go, 3f);
        }
    }/*Eğer objemiz, karakterimize değerse yok oluyor. */
}
