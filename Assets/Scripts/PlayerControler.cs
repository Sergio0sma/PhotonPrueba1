using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerControler : MonoBehaviourPun //Para elementos que queremos sincronizar
{

    //atributos
    public float velocidad = 10f;
    private Rigidbody2D rd ;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        rd= GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        if ( photonView.IsMine)
        {
            Cambiarcolor();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {

            float movX = Input.GetAxis("Horizontal");
            float movY = Input.GetAxis("Vertical");

            rd.velocity = new Vector2(movX, movY)*velocidad;
        }    
    }

    private void Cambiarcolor()
    {
        Color randomColor=new Color(Random.value, Random.value, Random.value);
        sr.color = randomColor;

    }

}
