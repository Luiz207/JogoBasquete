using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GAMEMANAGER : MonoBehaviour {


	public static GAMEMANAGER instance;

	public bool bolaEmCena;
	public int numJogadas;
    public GameObject bolaPrefab;
  

	[SerializeField]
	private Transform posDireita, posEsquerda, posCima, posBaixo;

	public bool jogoExecutando = true, win = false, lose = false;

	//Mão Bolinhas

	public GameObject mao, bolinhas;
	public int primeiraVez = 0;

    //Identifica_ponto
    public int pontos = 0;
    public bool pontos3 = false;
   



    //***********************************************************
    private Animator maoAnim, bolinhasAnim;


	

	void Awake()
	{


		if(instance == null)
		{
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		}
		else
		{
			Destroy (gameObject);
		}

        if (PlayerPrefs.HasKey("PrimeiraVez") == false)
        {
            PlayerPrefs.SetInt("PrimeiraVez", 0);
            primeiraVez = PlayerPrefs.GetInt("PrimeiraVez");
        }
 

        SceneManager.sceneLoaded += Carrega;


    }

    void Carrega(Scene cena, LoadSceneMode modo)
	{
		StartGame();
		

		posDireita = GameObject.FindWithTag ("DIREITA_POS").GetComponent<Transform> ();
		posEsquerda = GameObject.FindWithTag ("ESQUERDA_POS").GetComponent<Transform> ();
		posCima = GameObject.FindWithTag ("CIMA_POS").GetComponent<Transform> ();
		posBaixo = GameObject.FindWithTag ("BAIXO_POS").GetComponent<Transform> ();

		
        //***************************************************************************************
        maoAnim = GameObject.FindWithTag("mao").GetComponent<Animator>();
        bolinhasAnim = GameObject.FindWithTag("bolinhas").GetComponent<Animator>();

        primeiraVez = PlayerPrefs.GetInt("PrimeiraVez");
        if (primeiraVez == 0 || primeiraVez == 1)
		{
			PegaSpritesTutorial ();

			if(primeiraVez == 1 )
			{
				Matador (mao.gameObject,bolinhas.gameObject);
			}
		}




    }

	// Use this for initialization
	void Start () {

        //PlayerPrefs.DeleteAll();


        StartGame();
        bolaEmCena = true;
        numJogadas = 8;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OndeEstou.instance.fase++;
            SceneManager.LoadScene(OndeEstou.instance.fase);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(OndeEstou.instance.fase);
        }

    }


	public void NascBolas() {
            //Codigo ajustado para achar a bola, forma mais complexa
            Instantiate(bolaPrefab, new Vector2(Random.Range(posEsquerda.position.x, posDireita.position.x), Random.Range(posCima.position.y, posBaixo.position.y)), Quaternion.identity);
            bolaEmCena = true;


    }

	public void DesligaTuto()
	{
		Matador (mao.gameObject,bolinhas.gameObject);
		PlayerPrefs.SetInt ("PrimeiraVez",1);
       
	}

	void Matador(GameObject obj, GameObject obj2)
	{
		Destroy (obj);
		Destroy (obj2);
	}

	void PegaSpritesTutorial()
	{
		mao = GameObject.FindWithTag ("mao");
		bolinhas = GameObject.FindWithTag ("bolinhas");
	}


	void Novamente()
	{
		SceneManager.LoadScene (OndeEstou.instance.fase);
	}

	void Avancar()
	{
		OndeEstou.instance.fase++;
		SceneManager.LoadScene (OndeEstou.instance.fase);
	}

	void Voltar()
	{
		SceneManager.LoadScene ("Menu_Fases");
	}


	void StartGame()
	{



    }

    //***********************************************

    public void PrimeiraJogada()
    {
        //*********************************************************************************************
        if (jogoExecutando == true && primeiraVez == 0)
        {
            if (mao != null && bolinhas != null)
            {
                maoAnim.Play("iconehand");
                bolinhasAnim.Play("bolinhas");
                print("animando");
            }
            print(primeiraVez);

        }
    }

}
