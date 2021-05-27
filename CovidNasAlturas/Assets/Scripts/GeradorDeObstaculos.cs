using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeObstaculos : MonoBehaviour
{
    [SerializeField]
    private float tempoParaGerar;

    private float cronometro; // é necessário de um marcador de tempo, para saber quanto tempo já passou    

    [SerializeField]
    private GameObject manualDeInstrucoes; //todo objeto da unity é chamado como game object

    private void Awake()
    {
        this.cronometro = this.tempoParaGerar;
    }



    // Update is called once per frame
    void Update()
    {
        //Quando eu quero gerar obstáculos? Os obstáculos serão gerados de acordo com o tempo
        this.cronometro -= Time.deltaTime; //o tempo do cronometro menos o tempo que já passou (deltaTime: diferença entre a última chamada desse método e a chamada atual)
        if (this.cronometro < 0)
        {   //Quando o cronômetro for zero será gerado um novo obstáculo
            //Onde vou gerar?  os obstáculos serão gerados na posição do gerador
            //Como criar novos obstáculos 
                    //É necesário criar um manual de instruções para a geração de obstáculos!
            GameObject.Instantiate(this.manualDeInstrucoes, this.transform.position, Quaternion.identity); // instanciando o objeto (usado para criar um novo projeto)
                                                //onde esse objeto será instanciado; Quaternion.identity: não quereomos o objeto rotacionando
            this.cronometro = this.tempoParaGerar; //quando o obstáculo for criado, o cronômetro volta a ter o mesmo valor de tempo para gerar
        } 
    }
}
