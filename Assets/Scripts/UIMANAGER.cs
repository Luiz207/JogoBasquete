using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class UIMANAGER : MonoBehaviour {

    public static UIMANAGER instance;

   
    public Text numBolas;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        SceneManager.sceneLoaded += Carrega;
    }
    void Carrega(Scene cena, LoadSceneMode moda) {

        numBolas = GameObject.FindWithTag("numBolas").GetComponent<Text>();
        numBolas.text = GAMEMANAGER.instance.numJogadas.ToString();
    }

    // Use this for initialization
    void Start () {

        numBolas.text = GAMEMANAGER.instance.numJogadas.ToString();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
