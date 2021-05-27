using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diretor : MonoBehaviour
{

    [SerializeField]
    private GameObject imagemGameOver;
    
    private AviaoVacina aviao;
    //private Pontuacao pontuacao;
    
        private void Start() //utilizando o método Start pois esse método é chamado após a cena inteira ter sido criada, dessa forma o objeto nunca será nulo
    {
        this.aviao = GameObject.FindObjectOfType<AviaoVacina>(); // busacando um objeto fora do diretor do tipo avião
        //this.pontuacao = GameObject.FindObjectOfType<pontuacao>();
        
    }


    public void FinalizarJogo() // é um método público pois será acessado pelo avião
    {
        Time.timeScale = 0; // alterando a escala de tempo

        //Habiltar imagem Game Over
        this.imagemGameOver.SetActive(true); 
    }


    public void ReiniciarJogo()
    {
        this.imagemGameOver.SetActive(false); //desativando a imagem game over
        Time.timeScale = 1; //modificando a escala de tempo novamente para o jogo voltar 
        this.aviao.Reiniciar(); //reiniciando o avião, colocando ele na posição inicial do jogo
        this.DestruirObstaculos();
        this.DestruirVacinas();
        //this.pontuacao.ReiniciarPontos();
        this.aviao.ReiniciarPontos();
    }

    //destruindo todos os obstáculos da tela para reiniciar o jogo
    private void DestruirObstaculos()
    {
        ObstaculoVirus[] obstaculos = GameObject.FindObjectsOfType<ObstaculoVirus>(); //trata-se de uma lista de obstáculos (n clones criados)
        foreach (ObstaculoVirus obstaculo in obstaculos)
        {
            obstaculo.Destruir();
        }
    }

    private void DestruirVacinas()
    {
        CollectedVaccine[] vaccines = GameObject.FindObjectsOfType<CollectedVaccine>(); //trata-se de uma lista de obstáculos (n clones criados)
        foreach (CollectedVaccine vaccine in vaccines)
        {
            vaccine.Destruir();
        }
    }



}
