using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GanharJogo : MonoBehaviour
{
    [SerializeField]
    private GameObject imagemVencer;
    
    private AudioSource audioVencer;
    private AudioSource audioPause;




    private void Awake()
    {

        this.audioPause = GameObject.Find("TrilhaSonora").GetComponent<AudioSource>();
        this.audioVencer = GetComponent<AudioSource>();
    }

    public void Ganhar()
    {

        Time.timeScale = 0; // alterando a escala de tempo
        this.audioPause.Stop();
        //Habiltar imagem Game Over
        this.imagemVencer.SetActive(true);
        
        this.audioVencer.Play();

    }
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Vitoria");
            Time.timeScale = 1;
        }
    }
}
