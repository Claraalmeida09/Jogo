using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diretor : MonoBehaviour
{

    [SerializeField]
    private GameObject imagemGameOver;
    
    private AviaoVacina aviao;
    //private Pontuacao pontuacao;
    
        private void Start() //utilizando o m�todo Start pois esse m�todo � chamado ap�s a cena inteira ter sido criada, dessa forma o objeto nunca ser� nulo
    {
        this.aviao = GameObject.FindObjectOfType<AviaoVacina>(); // busacando um objeto fora do diretor do tipo avi�o
        //this.pontuacao = GameObject.FindObjectOfType<pontuacao>();
        
    }


    public void FinalizarJogo() // � um m�todo p�blico pois ser� acessado pelo avi�o
    {
        Time.timeScale = 0; // alterando a escala de tempo

        //Habiltar imagem Game Over
        this.imagemGameOver.SetActive(true); 
    }


    public void ReiniciarJogo()
    {
        this.imagemGameOver.SetActive(false); //desativando a imagem game over
        Time.timeScale = 1; //modificando a escala de tempo novamente para o jogo voltar 
        this.aviao.Reiniciar(); //reiniciando o avi�o, colocando ele na posi��o inicial do jogo
        this.DestruirObstaculos();
        this.DestruirVacinas();
        //this.pontuacao.ReiniciarPontos();
        this.aviao.ReiniciarPontos();
    }

    //destruindo todos os obst�culos da tela para reiniciar o jogo
    private void DestruirObstaculos()
    {
        ObstaculoVirus[] obstaculos = GameObject.FindObjectsOfType<ObstaculoVirus>(); //trata-se de uma lista de obst�culos (n clones criados)
        foreach (ObstaculoVirus obstaculo in obstaculos)
        {
            obstaculo.Destruir();
        }
    }

    private void DestruirVacinas()
    {
        CollectedVaccine[] vaccines = GameObject.FindObjectsOfType<CollectedVaccine>(); //trata-se de uma lista de obst�culos (n clones criados)
        foreach (CollectedVaccine vaccine in vaccines)
        {
            vaccine.Destruir();
        }
    }



}
