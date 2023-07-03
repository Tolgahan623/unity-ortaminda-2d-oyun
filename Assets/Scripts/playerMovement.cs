using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float hiz;
    public float ziplamaHizi;

    private float yerdeBasma;
    private float yerdeBasmaZamani = 0.2f;

    private float ziplamaBasma;
    private float ziplamaBasmaZamani = 0.2f;

    private bool yereDegdi;
    public Transform yerKontrol;
    public float yaricapKontrol;
    public LayerMask yerNedir;

    private float input;
    private float hareket;

    public Animator anim;

    [HideInInspector]
    public bool hareketEdebilir;





    void Start()
    {
        hareketEdebilir = true;
    }

    void Update()
    {
        if (!hareketEdebilir) return;

        input = Input.GetAxisRaw("Horizontal");
        hareket = input * hiz;
        if (Mathf.Abs(input) > 0.01)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        if (zipliyor)
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            ziplamaBasma = ziplamaBasmaZamani;
        }
    }/* Bu kısımda klavyeden W A S D tuşlarını alıp kontrol ederek, karakterin hareket animasyonlarını
      * aktif hale getiriyoruz. Aynı zamanda hareket vektörü ekliyoruz.*/

    void FixedUpdate()
    {
        Hareket();
        Ziplama();
    }

    void Hareket()
    {
        rb.velocity = new Vector2(hareket * Time.fixedDeltaTime, rb.velocity.y);

        if (sagaBakiyor && input == 1)
        {
            TersCevir();
        }
        else if (!sagaBakiyor && input == -1)
        {
            TersCevir();
        }
        /*Bu kısımda, aldığımız hareket vektörü değeri ile karakteri hareket ettiriyoruz. Eğer ters yöne hareket ederse
         * karakteri döndürüyoruz.*/
    }

    private bool zipliyor = false;
    void Ziplama()
    {

        yereDegdi = Physics2D.OverlapCircle(yerKontrol.position, yaricapKontrol, yerNedir);
        //Burada karakterin yere değip değmediğini kontrol ediyoruz, değmiyorsa zıplama tuşu çalışmayacak.

        ziplamaBasma -= Time.deltaTime;
        yerdeBasma -= Time.deltaTime;

        if (yereDegdi)
        {
            yerdeBasma = yerdeBasmaZamani;
        }

        /*if(Input.GetKey(KeyCode.W)){
            jumpPressed = jumpPressedTime;
        }*/

        if (ziplamaBasma > 0 && yerdeBasma > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, ziplamaHizi * Time.fixedDeltaTime);
        }

        if (yereDegdi)
        {
            zipliyor = false;
        }

        else
        {
            zipliyor = true;
        }
    }/*Bu kısımda karakterin zıplamasını sağlıyoruz. */

    private bool sagaBakiyor;
    void TersCevir()
    {
        sagaBakiyor = !sagaBakiyor;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
        /*Bu kısımda karakterin ters yöne dönmesini sağlıyoruz. Eğer karakterimiz sağ tarafa bakıyorken, sola dönmek isterse
        veya sola bakarken sağa dönmek isterse, karakterimizin baktığı yönü tersine çeviriyoruz.*/
    }
}
