using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoVirus : MonoBehaviour
{
    [SerializeField]
    private float velocidade;
    [SerializeField]
    private float variacaoDaPosicaoY;


    private void Awake()
    {
        this.transform.Translate(Vector3.up * Random.Range(-variacaoDaPosicaoY, variacaoDaPosicaoY)); //intervalo maximo e minimo // modificando a posicao de forma aleatoria 
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.left * this.velocidade * Time.deltaTime); // fazendo o objeto se mover para a esquerda // delta time para que o obstaculo se desloque de acordo com o tempo que passou
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.Destruir(); //assimq que o obstaculo colidir, ele se destrói
    }

    public void Destruir()
    {
        GameObject.Destroy(this.gameObject);
    }
}
