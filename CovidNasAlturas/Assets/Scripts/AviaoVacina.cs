using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AviaoVacina : MonoBehaviour
{
    //Declarando as vari�veis
    private Rigidbody2D fisica;
    [SerializeField]
    private float forca;
    private Diretor diretor;
    private Vector3 posicaoInicial;
    public int vaccineQuantity = 0;
    public Pontuacao vaccineController;
    //private Pontuacao pontuacao;
    private AudioSource audioPontuacao;
    private bool deveImpulsionar;
    private GanharJogo ganharJogo;
    



    //m�todo chamado assim que o jogo � criado
    private void Awake() {
        this.vaccineController = GameObject.FindObjectOfType<Pontuacao>();

        this.audioPontuacao = GetComponent<AudioSource>();

        this.posicaoInicial = this.transform.position; //salvando a posi��o inicial do avi�o assim que ele � iniciado

        this.fisica = this.GetComponent<Rigidbody2D>();   //pegando o componente que existe dentro do objeto

        

    }

    private void Start()
    {
        this.diretor = GameObject.FindObjectOfType<Diretor>(); //pegar algo que est� fora do objeto avi�o usamos GameObject.FindObjectOfType -> trata-se de um m�todo pesado
        //procurando o objeto do tipo diretor na cena inteira

        this.ganharJogo = GameObject.FindObjectOfType<GanharJogo>();
    }


    // A unity chama automaticamente este m�todo, enquanto o jogo estiver rodando esse c�digo estar� sendo executado sempre (game loop)
    private void Update()
    {
        //verificando que o jogador clicou no bot�o direito do mouse 
        if (Input.GetButtonDown("Fire1")) {
            this.deveImpulsionar = true;
        }
    }

    private void FixedUpdate()
    {
        if (this.deveImpulsionar) {
            this.Impulsionar();
        }
    }

    public void Reiniciar() //public pq ser� acessado de diretor
    {
        this.transform.position = this.posicaoInicial; //pegando a posi��o inicial do avi�o
        this.fisica.simulated = true; //voltando a simular a f�sica
    }

    private void Impulsionar() {
        this.fisica.velocity = Vector2.zero; //anulando as for�as acumuladas nos frames do jogo para que o avi�o funcione melhor
        //Adicionando uma for�a contr�ria � gravidade no avi�o
        this.fisica.AddForce(Vector2.up * this.forca, ForceMode2D.Impulse); //aplicando uma for�a para cima no avi�o
        this.deveImpulsionar = false; // pois �j� impulsionamos o avi�o ao clicar na tela, se n�o ele seria impulsionado constatemente
    }

    //private void OnTriggerEnter2D(Collider2D colisao)
    //{
    //    if (colisao.gameObject.tag == "collectables")
    //    {
    //        //print(colisao.gameobject.name);
    //        vaccineQuantity++;
    //        vaccineController.TextUpdate(vaccineQuantity);
    //        Destroy(colisao.gameObject);
    //        this.audioPontuacao.Play();
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D colisao)
    { //reconhecer a colis�o entre os objetos f�sicos

        if (colisao.gameObject.tag == "collectables")
        {
            //this.pontuacao.AdicionarPontos();
            vaccineQuantity++;
            vaccineController.TextUpdate(vaccineQuantity);
            Destroy(colisao.gameObject);
            this.audioPontuacao.Play();

            if (vaccineQuantity == 2)
            {
                
                this.ganharJogo.Ganhar();
            }
        }
        else
        {
            this.fisica.simulated = false; // quando o avi�o bater em algo, ele deve parar de simular a f�sica
            this.diretor.FinalizarJogo(); //chamando o finalizar jogo no Diretor
        }

        //if (colisao.gameObject.tag != "collectables") {
        //    this.fisica.simulated = false; // quando o avi�o bater em algo, ele deve parar de simular a f�sica
        //    this.diretor.FinalizarJogo(); //chamando o finalizar jogo no Diretor
        //}


    }


    public void ReiniciarPontos()
    {
        this.vaccineQuantity = 0;
        vaccineController.TextUpdate(vaccineQuantity);
    }

    public void GanharJogo()
    {
        if (vaccineQuantity == 8) {
            
        }
    }


    
}
