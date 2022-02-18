using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public bool IsAlive;
     public AudioSource soundBall;
      public AudioSource soundLevelComplete;
       public AudioSource soundLightning;
      public AudioSource soundAxe;
    public AudioSource soundSnake;
    public AudioSource soundRobot;
   public static GameManager Instance;
   enum Direction {Ruby,Emerald,Saphire,Coin,Ametist} ;
   public float fireBallSpeed=7.0f,FireBallDestoryTime=2.0f,FireBallDieTime=0.44f,RobotDieTime=4.0f;
   public IDictionary<string,int> GemD = new Dictionary<string,int>();
   public Animator animator;
   public Rigidbody2D rigidbody;
    public GameObject Fireball;
  static public int Lives=3;
   public Text text;
    void Start()
    {
        Instance=this;
        IsAlive=true;
      //  DontDestroyOnLoad(this.gameObject);
       // animator=GetComponent<Animator>();
       // rigidbody=GetComponent<Rigidbody2D>();
        GemD.Add("Ametist", 0);
          GemD.Add("Coin", 0); 
           GemD.Add("Saphire", 0);
            GemD.Add("Ruby", 0);
             GemD.Add("Emerald", 0);
if(text!=null)             text.text="Lives :"+Lives;
    }
    public void DecreaseLife(int l=1)
    {
        
        Lives-=l;
        if(Lives==0)
        {
            Die();
            return;
        }animator.SetBool("DecreaseLife",true);
        Invoke("DecreaseLifeTrigger",0.5f);
        UpdateLife();
    }
    
    void UpdateLife()
    {
        text.text="Lives :"+Lives;
    }
    void DecreaseLifeTrigger()
    {
         animator.SetBool("DecreaseLife",false);
         animator.SetBool("Idle",true);
    }
    public void Die()
    {
        animator.SetTrigger("Death");
        IsAlive=false;
        rigidbody.bodyType=RigidbodyType2D.Static;
    }
    public void IncreaseLife()
    {
        Lives+=1;
         UpdateLife();
    }
    public int GetCurrentLives()
    {
        return Lives;
    }
    public void ShowLife()
    {
        print("Lives :"+Lives);
    }
    public void ShowGems()
    {
        print("Ruby : "+GemD["Ruby"]+" Emerald : "+GemD["Emerald"]+" Saphire : "+GemD["Saphire"]+" Coin : "+GemD["Coin"]+" Ametist : "+GemD["Ametist"]);
    }
    public void LoadNextScene()
    {
        soundLevelComplete.Play();
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
     public void LoadInstructionsScene()
    {
         SceneManager.LoadScene(3);
    }
      public void LoadThanksScene()
    {
         SceneManager.LoadScene(4);
    }
      public void LoadGameOverScene()
    {
         SceneManager.LoadScene(5);
    }
     public void ApplicationQuit()
    {
         Application.Quit();
    }
     public void LoadMainMenuScene()
    {
         SceneManager.LoadScene(0);
    }
    public void LoadCurrentScene()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
