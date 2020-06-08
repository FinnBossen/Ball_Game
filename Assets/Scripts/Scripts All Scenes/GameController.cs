using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    private FieldController coinsCtrl;
    private FieldController CLiveCtrl;
    private FieldController BestScoreCtrl;
    private FieldController ScoreThisTimeCtrl;
    private FieldController CompleteScoreCtrl;
    private FieldController EndTimeCtrl;
    private FieldController BestTimeCtrl;
    private int CastleLives = 10;
    private GameObject HUD;
    GameObject youWin = null;
    GameObject youLost = null;
    public bool WinScore = false ;
    private int CoinsCurrently;
    private static int BestScoreScene1;
    private static int BestScoreScene2;
    private static int BestScoreScene3;
    private static int CompleteScore ;
    public string time;
    private static float BestTimeScene1;
    private static float BestTimeScene2;
    private static float CompleteTime;
    private static float BestTimeScene3;
    public GameObject Nightmission;
    public GameObject DirectionalLight;
    private Light light;
    public GameObject EndScoreLevel1;
    private FieldController EndScoreCtrll;
    public GameObject EndScoreLevel2;
    private FieldController EndScoreCtrl2;
    public GameObject EndTimeLevel1;
    private FieldController EndTimeCtrl1;
    public GameObject EndTimeLevel2;
    private FieldController EndTimeCtrl2;
    public GameObject FullScore;
    private FieldController FullScoreCtrl;
    public GameObject FullTime;
    private FieldController FullTimeCtrl;
    public GameObject CastleMess;
    public GameObject EndScoreLevel3;
    private FieldController EndScoreCtrl3;
    public GameObject EndTimeLevel3;
    private FieldController EndTimeCtrl3;

    void Start()
    {
        //Guckt ob schon genug Coins in Leveln um Spiel zu Gewinnen
        if (CompleteScore >= 50)
        {
            WinScore = true;
        }
        else
        {
            WinScore = false;
        }

        if (DirectionalLight != null) {
            light = DirectionalLight.GetComponent<Light>();
        }
        Time.timeScale = 1;

        //Findet objekte des HUDs You Lose and You win ohne das sie direct als public GameObject eingefügt werden
        HUD = GameObject.Find("HUD");
        if (HUD != null)
        {
            Transform[] Childrens = HUD.GetComponentsInChildren<Transform>(true);

            foreach (Transform t in Childrens)
            {
                if (t.gameObject.name == "Win")
                {
                    youWin = t.gameObject;
                }

                if (t.gameObject.name == "YouLose")
                {
                    youLost = t.gameObject;
                }
                if (t.gameObject.name == "Best Score")
                {
                    BestScoreCtrl = t.gameObject.transform.GetComponentInChildren<FieldController>();

                }
                if (t.gameObject.name == "ScoreThisTime")
                {
                    ScoreThisTimeCtrl = t.gameObject.transform.GetComponentInChildren<FieldController>();

                }
                if (t.gameObject.name == "CompleteScore")
                {
                    CompleteScoreCtrl = t.gameObject.transform.GetComponentInChildren<FieldController>();

                }
                if (t.gameObject.name == "Time Needed")
                {
                    EndTimeCtrl = t.gameObject.transform.GetComponentInChildren<FieldController>();

                }
                if (t.gameObject.name == "Best Time")
                {
                    BestTimeCtrl = t.gameObject.transform.GetComponentInChildren<FieldController>();

                }
            }
        }

        // schaltet you win und yoi lose automatisch auf nicht aktiv
        if (youWin != null)
        {
            youWin.SetActive(false);
        }
        if (youLost != null)
        {
            youLost.SetActive(false);
        }
        GameObject Coins = GameObject.Find("Coins");
        if (Coins != null) {
            coinsCtrl = Coins.GetComponent<FieldController>();
        }
        GameObject Castle = GameObject.Find("CLive");
        if (Castle != null)
        {
            CLiveCtrl = Castle.GetComponent<FieldController>();
            CLiveCtrl.SetValue(CastleLives);
        }

        // Score werte der Endzene
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            EndScoreCtrll = EndScoreLevel1.GetComponent<FieldController>();
            EndScoreCtrll.SetValue(BestScoreScene1);
            EndScoreCtrl2 = EndScoreLevel2.GetComponent<FieldController>();
            EndScoreCtrl2.SetValue(BestScoreScene2);
            EndScoreCtrl3 = EndScoreLevel3.GetComponent<FieldController>();
            EndScoreCtrl3.SetValue(BestScoreScene3);
            EndTimeCtrl1 = EndTimeLevel1.GetComponent<FieldController>();
            EndTimeCtrl1.SetTime(BestTimeScene1);
            EndTimeCtrl2 = EndTimeLevel2.GetComponent<FieldController>();
            EndTimeCtrl2.SetTime(BestTimeScene2);
            EndTimeCtrl3 = EndTimeLevel3.GetComponent<FieldController>();
            EndTimeCtrl3.SetTime(BestTimeScene3);
            FullScoreCtrl = FullScore.GetComponent<FieldController>();
            FullScoreCtrl.SetValue(CompleteScore);
            FullTimeCtrl = FullTime.GetComponent<FieldController>();
            FullTimeCtrl.SetTime(CompleteTime);
        }

    }

    public void UpdateCoin(int Coins)
    {
        CoinsCurrently = Coins;
        if (coinsCtrl != null)
        {
            coinsCtrl.SetValue(CoinsCurrently);
        }
    }


    public void UpdateCastle()
    {
        CastleLives--;
        if (CastleLives <= 0)
        {
            youLose();
        }

        if (CLiveCtrl != null)
        {
            CLiveCtrl.SetValue(CastleLives);
        }
    }
    public void youLose()
    {
        Debug.Log("Leider verloren");
        youLost.SetActive(true);
        Time.timeScale = 0;
    }

    public void nightmission()
    {
        Nightmission.SetActive(true);
        Time.timeScale = 0;

    }

    public void reloadScene()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void nextScene()
    {
        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void backToMenü()
    {
        SceneManager.LoadScene(0);
    }

    public void youWon()
    {
        Debug.Log("Gewonnen");

       
        youWin.SetActive(true);
      
        // Statische Werte werden eingetragen

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (BestTimeScene1 < Time.timeSinceLevelLoad) {
                BestTimeScene1 = Time.timeSinceLevelLoad;
            }
            if (CoinsCurrently > BestScoreScene1)
            {
                BestScoreScene1 = CoinsCurrently;
            }
            BestScoreCtrl.SetValue(BestScoreScene1);
            BestTimeCtrl.SetTime(BestTimeScene1);
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (BestTimeScene2 < Time.timeSinceLevelLoad)
            {
                BestTimeScene2 = Time.timeSinceLevelLoad;
            }
            if (CoinsCurrently > BestScoreScene2)
            {
                BestScoreScene2 = CoinsCurrently;
            }
            BestScoreCtrl.SetValue(BestScoreScene2);
            BestTimeCtrl.SetTime(BestTimeScene2);
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (BestTimeScene3 < Time.timeSinceLevelLoad)
            {
                BestTimeScene3 = Time.timeSinceLevelLoad;
            }
            if (CoinsCurrently > BestScoreScene3)
            {
                BestScoreScene3 = CoinsCurrently;
            }
            BestScoreCtrl.SetValue(BestScoreScene2);
            BestTimeCtrl.SetTime(BestTimeScene2);
        }
        CompleteScore = BestScoreScene1 + BestScoreScene2 + BestScoreScene3;
        ScoreThisTimeCtrl.SetValue(CoinsCurrently);
        CompleteScoreCtrl.SetValue(CompleteScore);
        EndTimeCtrl.SetTime(Time.timeSinceLevelLoad);

        CompleteTime = BestTimeScene1 + BestTimeScene2 + BestTimeScene3;
     

        Time.timeScale = 0;
    }

    // veröndert die RenderSettings sodass eine NachtSzene entsteht
    public void ChangetoNight(){

        RenderSettings.skybox = null;

        light.intensity = 0.08f;
        light.color = Color.black;
        RenderSettings.fog = true;
        Time.timeScale = 1;
        Nightmission.SetActive(false);
        
    }
    public void CastleMessage()
    {
        
        CastleMess.active = !CastleMess.active;

    }

}
