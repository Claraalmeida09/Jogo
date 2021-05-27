using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pontuacao : MonoBehaviour
{
    [SerializeField]
    Text vaccineText;
    //[SerializeField]
    //private int vaccineQuantity = 0;
    //private Pontuacao vaccineController;

    public void TextUpdate(int value) {

        this.vaccineText.text = value.ToString(); //transformando um inteiro para string para que ele consiga ser inserido no texto
    }

    //private void Awake()
    //{
    //    this.vaccineController = GameObject.FindObjectOfType<Pontuacao>();
    //}

    //    public void AdicionarPontos()
    //{
    //    vaccineQuantity++;
    //    vaccineController.TextUpdate(vaccineQuantity);
    //    //Destroy(colisao.gameObject);
    //}

    
}
