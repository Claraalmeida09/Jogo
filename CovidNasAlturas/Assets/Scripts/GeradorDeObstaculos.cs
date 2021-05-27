using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeObstaculos : MonoBehaviour
{
    [SerializeField]
    private float tempoParaGerar;

    private float cronometro; // � necess�rio de um marcador de tempo, para saber quanto tempo j� passou    

    [SerializeField]
    private GameObject manualDeInstrucoes; //todo objeto da unity � chamado como game object

    private void Awake()
    {
        this.cronometro = this.tempoParaGerar;
    }



    // Update is called once per frame
    void Update()
    {
        //Quando eu quero gerar obst�culos? Os obst�culos ser�o gerados de acordo com o tempo
        this.cronometro -= Time.deltaTime; //o tempo do cronometro menos o tempo que j� passou (deltaTime: diferen�a entre a �ltima chamada desse m�todo e a chamada atual)
        if (this.cronometro < 0)
        {   //Quando o cron�metro for zero ser� gerado um novo obst�culo
            //Onde vou gerar?  os obst�culos ser�o gerados na posi��o do gerador
            //Como criar novos obst�culos 
                    //� neces�rio criar um manual de instru��es para a gera��o de obst�culos!
            GameObject.Instantiate(this.manualDeInstrucoes, this.transform.position, Quaternion.identity); // instanciando o objeto (usado para criar um novo projeto)
                                                //onde esse objeto ser� instanciado; Quaternion.identity: n�o quereomos o objeto rotacionando
            this.cronometro = this.tempoParaGerar; //quando o obst�culo for criado, o cron�metro volta a ter o mesmo valor de tempo para gerar
        } 
    }
}
