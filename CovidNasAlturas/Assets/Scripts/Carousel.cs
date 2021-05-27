using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carousel : MonoBehaviour
{
    [SerializeField]
    private float velocidade;

    private Vector3 posicaoInicial;

    private float tamanhoRealDaImagem;

    private void Awake()
    {
        this.posicaoInicial = this.transform.position; // salvando a posi��o inicial, assim que o jogo inicia
        float tamanhoDaImagem = this.GetComponent<SpriteRenderer>().size.x; //objeto que desenha as coisas na tela, est� presente em componentes // nos interessa apenas o tamanho da imagem em x
        float escala = this.transform.localScale.x; //escalonando a imagem, pois alteramos o seu tamanho para preencher a �rea da c�mera
        this.tamanhoRealDaImagem = tamanhoDaImagem * escala; //tamanho da imagem utilizada no jogo
    }
    // Update is called once per frame
    void Update()
    {   //deslocamento = v*tempo (f�sica 1)
        float deslocamento = Mathf.Repeat(this.velocidade * Time.time, this.tamanhoRealDaImagem); // calculando o deslocamento da imagem, assim que o deslocamento for maior que o tamanho da imagem, a imagem deve retornar ao ponto 0
                                                                        //Limitando essa repeti��o com o tamanho da imagem     
        this.transform.position = this.posicaoInicial + (Vector3.left * deslocamento);
    }
}
