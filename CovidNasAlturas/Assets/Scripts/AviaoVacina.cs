using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AviaoVacina : MonoBehaviour
{
    //Declarando as variáveis
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
    



    //método chamado assim que o jogo é criado
    private void Awake() {
        this.vaccineController = GameObject.FindObjectOfType<Pontuacao>();

        this.audioPontuacao = GetComponent<AudioSource>();

        this.posicaoInicial = this.transform.position; //salvando a posição inicial do avião assim que ele é iniciado

        this.fisica = this.GetComponent<Rigidbody2D>();   //pegando o componente que existe dentro do objeto

        

    }

    private void Start()
    {
        this.diretor = GameObject.FindObjectOfType<Diretor>(); //pegar algo que está fora do objeto avião usamos GameObject.FindObjectOfType -> trata-se de um método pesado
        //procurando o objeto do tipo diretor na cena inteira

        this.ganharJogo = GameObject.FindObjectOfType<GanharJogo>();
    }


    // A unity chama automaticamente este método, enquanto o jogo estiver rodando esse código estará sendo executado sempre (game loop)
    private void Update()
    {
        //verificando que o jogador clicou no botão direito do mouse 
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

    public void Reiniciar() //public pq será acessado de diretor
    {
        this.transform.position = this.posicaoInicial; //pegando a posição inicial do avião
        this.fisica.simulated = true; //voltando a simular a física
    }

    private void Impulsionar() {
        this.fisica.velocity = Vector2.zero; //anulando as forças acumuladas nos frames do jogo para que o avião funcione melhor
        //Adicionando uma força contrária à gravidade no avião
        this.fisica.AddForce(Vector2.up * this.forca, ForceMode2D.Impulse); //aplicando uma força para cima no avião
        this.deveImpulsionar = false; // pois ´já impulsionamos o avião ao clicar na tela, se não ele seria impulsionado constatemente
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
    { //reconhecer a colisão entre os objetos físicos

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
            this.fisica.simulated = false; // quando o avião bater em algo, ele deve parar de simular a física
            this.diretor.FinalizarJogo(); //chamando o finalizar jogo no Diretor
        }

        //if (colisao.gameObject.tag != "collectables") {
        //    this.fisica.simulated = false; // quando o avião bater em algo, ele deve parar de simular a física
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
