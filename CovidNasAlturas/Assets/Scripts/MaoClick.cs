using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaoClick : MonoBehaviour
{
    private SpriteRenderer imagem;
    
    private void Awake()
    {
        this.imagem = this.GetComponent<SpriteRenderer>();
    }

  
    private void Update()
    {
        //verificando se o mouse doi clicado
        if (Input.GetButtonDown("Fire1")) {
            this.Desaparecer();
        }
    }

    private void Desaparecer() {
        this.imagem.enabled = false;
    }
}
