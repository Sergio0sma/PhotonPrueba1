using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerControler : MonoBehaviourPun //Para elementos que queremos sincronizar
{
    // Atributos
    public float velocidad = 10f;
    private Rigidbody2D rd;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>(); // Inicializamos el SpriteRenderer
        if (photonView.IsMine)
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

            rd.velocity = new Vector2(movX, movY) * velocidad;
        }
    }

    private void Cambiarcolor()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value);
        photonView.RPC("SincronizarColor", RpcTarget.AllBuffered, randomColor.r, randomColor.g, randomColor.b);
    }

    [PunRPC]
    private void SincronizarColor(float r, float g, float b)
    {
        sr.color = new Color(r, g, b);
    }
}
