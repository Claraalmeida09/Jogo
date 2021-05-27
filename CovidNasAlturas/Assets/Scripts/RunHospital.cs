using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunHospital : MonoBehaviour
{
    [SerializeField]
    private float velocidade;
    private Animator anim;

    private Vector3 posicaoInicial;
    [SerializeField]
    public float countdown;


    private float tamanhoRealDaImagem;

    void Start()
    {
        this.anim = GameObject.Find("DrWho").GetComponent<Animator>();
    }

    private void Awake()
    {
        
        this.posicaoInicial = this.transform.position; // salvando a posição inicial, assim que o jogo inicia
        float tamanhoDaImagem = this.GetComponent<SpriteRenderer>().size.x; //objeto que desenha as coisas na tela, está presente em componentes // nos interessa apenas o tamanho da imagem em x
        float escala = this.transform.localScale.x; //escalonando a imagem, pois alteramos o seu tamanho para preencher a área da câmera
        this.tamanhoRealDaImagem = tamanhoDaImagem * escala; //tamanho da imagem utilizada no jogo
    }
    // Update is called once per frame
    void Update()
    {   //deslocamento = v*tempo (física 1)
        
        countdown -= Time.deltaTime;
        float deslocamento = Mathf.Repeat(this.velocidade * Time.time, this.tamanhoRealDaImagem/4.8f);

        
        if (countdown <= 0) {
            anim.enabled = false;
            deslocamento = this.tamanhoRealDaImagem/6;
        }
        this.transform.position = this.posicaoInicial + (Vector3.left * deslocamento); 

    }
}
