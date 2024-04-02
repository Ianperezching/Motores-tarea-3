using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class Movimientojugador : MonoBehaviour
{
    private Rigidbody2D _compRigidbody2D;
    
    public LayerMask layerdecolision;
    private float horizontal;
    public int speex = 10;
    public int ditanciadelsalto = 5;
    public bool saltos;
    public bool suelo;
    public float raycast=2f;
    public int idcolor;
    public int colorenemigo;
    public int vida= 10;
    public Slider gaaa;

    public static event Action Perder;
    public static event Action Ganar;
    public static event Action cambiarpuntos;
    

    private void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
      
    }
    void Update()
    {
        if (vida <= 0)
        {
            Perder();
        }

        Vector2 raycastOrigin = transform.position;
        Vector2 raycastDirection = Vector2.right;
        Color raycastColor = Color.red;

        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, raycastDirection, raycast, layerdecolision);
        Debug.DrawRay(raycastOrigin, Vector2.down, raycastColor);

        horizontal = Input.GetAxisRaw("Horizontal");
        _compRigidbody2D.velocity = new Vector2(horizontal * speex,_compRigidbody2D.velocity.y);
        if (Physics2D.Raycast(transform.position,Vector2.down, 2f, layerdecolision))
        {
            suelo= true;

        }
        else
        {
            suelo = false;
        }

        
        if (Input.GetKeyDown(KeyCode.W) && (suelo||saltos))
        {
            if (!suelo)
            {
                saltos = true;
            }
            _compRigidbody2D.velocity = new Vector2(_compRigidbody2D.velocity.x, ditanciadelsalto);
        }

    }
    public void cambiardecolorbotonrojo()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        idcolor = 1;
        
    }
    public void cambiardecolorbotonAzul()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        idcolor = 2;
    }
    public void cambiardecolorbotonNegro()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        idcolor = 3;
    }
    public void cambiardecolorbotonnaranja()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 129, 0, 255);
        idcolor = 4;
    }
    public void cambiardecolorbotonVerde()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        idcolor = 5;
    }
    public void Destruirpersonaje()
    {
        GameObject.Destroy(this.gameObject, 0);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Rojo" )
        {
            if (idcolor==1)
            {

            }
            else
            {
                vida--;
                Debug.Log("vida restada: " + vida);
                gaaa.value = vida;
            }
        }
        if (collision.tag == "Azul")
        {
            if (idcolor == 2)
            {

            }
            else
            {
                vida--;
                Debug.Log("vida restada: " + vida);
                gaaa.value = vida;
            }
        }
        if (collision.tag == "Negro")
        {
            if (idcolor == 3)
            {

            }
            else
            {
                vida--;
                Debug.Log("vida restada: " + vida);
                gaaa.value = vida;
            }
        }
        if (collision.tag == "Naranja")
        {
            if (idcolor == 4)
            {

            }
            else
            {
                vida--;
                Debug.Log("vida restada: " + vida);
                gaaa.value = vida;
            }
        }
        if (collision.tag == "Verde")
        {
            if (idcolor == 5)
            {

            }
            else
            {
                vida--;
                Debug.Log("vida restada: " + vida);
                gaaa.value = vida;
            }
        }
        if (collision.tag == "Vida")
        {
            vida++;
            Debug.Log("vida sumada: " + vida);
            gaaa.value = vida;
            Destroy(collision);
        }

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "salida")
        {
           
                SceneManager.LoadScene("Nivel 2");
            
        }
        if (collision.gameObject.tag == "final")
        {


            Ganar();

        }

    }
}
