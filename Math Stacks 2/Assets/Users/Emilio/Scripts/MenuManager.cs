using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;


public class MenuManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject GradeSelect;
    public GameObject Options;
    public GameObject PauseScreen;
    public GameObject InGameOverlay;
    public GameObject Labels;
    public GameObject GameOver;
    public GameObject Credit;

    public GameObject Staging;
    public GameObject OptionsDash;

    public string mainMenu;

    public bool IsMainMenu;
    public bool IsLabelsMenu;
    public bool Paused;

    //[SerializeField]
    //private Animator CameraTransitions;

    BoxController cont;
    //public AudioMixerSnapshot normal;
    //public AudioMixerSnapshot pause;
    //public SoundUpdater su;
    private TutorialK TK;
    public AudioSource mainMu;
    public AudioSource gameMu;
    public AudioSource gameAb;

    private bool musicTriger;

    private Tape tape;

    private Scissors scissors;

    private Exhaust Exh;

    private Score scoreZero;

    private bool goback;

    private GameManager Gm;

    private StampGen stmp;
    // Start is called before the first frame update
    void Start()
    {
        
        musicTriger = true;
        MainMenu.SetActive(false);
        if (IsMainMenu == true)
        {
            MainMenuActive();

            Staging.SetActive(true);
            OptionsDash.SetActive(false);
        }

        IsLabelsMenu = false;
        Paused = false;
        //su = FindObjectOfType<GameManager>().GetComponent<SoundUpdater>();
        tape = FindObjectOfType<Tape>().GetComponent<Tape>();
        scissors = FindObjectOfType<Scissors>().GetComponent<Scissors>();
        //CameraTransitions = FindObjectOfType<Animator>().GetComponent<Animator>();
        //Exh = FindObjectOfType<Exhaust>().GetComponent<Exhaust>();
        Gm = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        mainMenu = currentScene.name;

        //if (mainMenu == "Main Menu")
        //{
        //    CameraTransitions = FindObjectOfType<Animator>().GetComponent<Animator>();
        //}
    }

    //public void Pause()
    //{
    //    Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    //    Lowpass();
    //}

    public void Back()
    {
        if (MainMenu.activeSelf == false && IsMainMenu)
        {
            MainMenuActive();
        }
        else if (MainMenu.activeSelf == false && !IsMainMenu)
        {
            InGameOverlayActive();
            PauseScreenActive();
        }
    }

    public void OptionBack()
    {
        MainMenu.SetActive(false);
        GradeSelect.SetActive(false);
        Options.SetActive(false);
        PauseScreen.SetActive(true);
        InGameOverlay.SetActive(false);
        Labels.SetActive(false);
    }

    public void Cancel()
    {
        ChangePaused();
        if (IsLabelsMenu)
        {
            Labels.SetActive(false);
            InGameOverlayActive();
            IsLabelsMenu = false;
        }
    }

    public void Resume()
    {
        WasGamePaused();
    }

    public void MainMenuActive()
    {
        Credit.SetActive(false);
        goback = true;
        if (MainMenu.activeSelf == false)
        {

            /*GameObject exhaustP = GameObject.Find("Exhaust");
            GameObject exhaustC = exhaustP.transform.Find("ExhaustPrewarm").gameObject;
            exhaustC.SetActive(true);
            //exhaust.SetActive(true);
            */
            GameObject[] temp = SceneManager.GetSceneByName("Main Menu").GetRootGameObjects();
            for (int i = 0; i < temp.Length; i++)
            {

                if (temp[i].name == "Exhaust")
                {
                    Exh = temp[i].GetComponent<Exhaust>();
                    Exh.PlayExhoust();
                }
            }

            Debug.Log("testing!!!");
            if (musicTriger)
            {
                mainMu.Play();
                gameAb.Stop();
                gameMu.Stop();
                musicTriger = false;
                Debug.Log("Play main menu music");
            }//if (CameraTransitions.GetBool("MenuTOGrade") == true)
            //{
            //    CameraTransitions.SetBool("MenuTOGrade", false);
            //    CameraTransitions.SetBool("GradeTOMenu", true);
            //}
            if (mainMenu == "Main Menu")
            {
                if (Staging.activeSelf == false)
                {
                    OptionsDash.SetActive(false);
                    Staging.SetActive(true);
                    MainMenu.SetActive(true);
                }
                else
                {
                    MainMenu.SetActive(true);
                    GradeSelect.SetActive(false);
                    Options.SetActive(false);
                    PauseScreen.SetActive(false);
                    InGameOverlay.SetActive(false);
                    Labels.SetActive(false);
                }
            }
            else
            {
                MainMenu.SetActive(true);
                GradeSelect.SetActive(false);
                Options.SetActive(false);
                PauseScreen.SetActive(false);
                InGameOverlay.SetActive(false);
                Labels.SetActive(false);

                OptionsDash.SetActive(false);
                Staging.SetActive(true);
            }

            //CameraTransitions = FindObjectOfType<Animator>().GetComponent<Animator>();
            //if (CameraTransitions.GetBool("MenuTOGrade") == true)
            //{
            //    CameraTransitions.SetBool("MenuTOGrade", false);
            //    CameraTransitions.SetBool("GradeTOMenu", true);
            //}
        }
    }

    public void GradeSelectActive()
    {
        //CameraTransitions.SetBool("MenuTOGrade", true);
        Gm.GradeSelect();
        if (GradeSelect.activeSelf == false)
        {
            MainMenu.SetActive(false);
            GradeSelect.SetActive(false);//change
            Options.SetActive(false);
            PauseScreen.SetActive(false);
            InGameOverlay.SetActive(false);
            Labels.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void InGameOverlayActive()
    {
        if (InGameOverlay.activeSelf == false)
        {
            IsMainMenu = false;

            MainMenu.SetActive(false);
            GradeSelect.SetActive(false);
            Options.SetActive(false);
            PauseScreen.SetActive(false);
            Labels.SetActive(false);
            InGameOverlay.SetActive(true);
            tape.ResetTape();
            scissors.ResecScissor();
            if (!musicTriger)
            {
                mainMu.Stop();
                gameAb.Play();
                gameMu.Play();
                musicTriger = true;
            }

            if (goback)
            {
                scoreZero = FindObjectOfType<Score>().GetComponent<Score>();
                scoreZero.ScoreZero();
                goback = false;
            }
            stmp = GameObject.Find("UI Screens").GetComponent<StampGen>();
            stmp.canMake = true;
        }
    }

    public void ChangePaused()
    {
        Paused = false;
    }
    public void LabelsActive()
    {
        if (Labels.activeSelf == false)
        {
            IsLabelsMenu = true;
            Paused = true;
            MainMenu.SetActive(false);
            GradeSelect.SetActive(false);
            Options.SetActive(false);
            PauseScreen.SetActive(false);
            InGameOverlay.SetActive(false);
            Labels.SetActive(true);

            GameObject[] temp = SceneManager.GetSceneByName("Test_Scene").GetRootGameObjects();
            for (int i = 0; i < temp.Length; i++)
            {

                if (temp[i].name == "TutorialTwo")
                {
                    TK = temp[i].GetComponent<TutorialK>();
                    TK.UseStamp();
                }
            }
        }
    }

    public void OptionsActive()
    {
        if (IsMainMenu == true)
        {
            if (mainMenu == "Main Menu")
            {
                /*
                //GameObject exhaust = GameObject.Find("ExhaustPrewarm");
                GameObject exhaustP = GameObject.Find("Exhaust");
                GameObject exhaustC = exhaustP.transform.Find("ExhaustPrewarm").gameObject;
                exhaustC.SetActive(false);
                */
                GameObject[] temp = SceneManager.GetSceneByName("Main Menu").GetRootGameObjects();
                for (int i = 0; i < temp.Length; i++)
                {

                    if (temp[i].name == "Exhaust")
                    {
                        Exh = temp[i].GetComponent<Exhaust>();
                        Exh.StopExhaust();
                    }
                }

                //exhaust.SetActive(false);
                MainMenu.SetActive(false);
                GradeSelect.SetActive(false);
                Options.SetActive(false);
                PauseScreen.SetActive(false);
                InGameOverlay.SetActive(false);
                Labels.SetActive(false);

                Staging.SetActive(false);
                OptionsDash.SetActive(true);
            }
            else
            {
                MainMenu.SetActive(false);
                GradeSelect.SetActive(false);
                Options.SetActive(true);
                PauseScreen.SetActive(false);
                InGameOverlay.SetActive(false);
                Labels.SetActive(false);
            }
        }
        else if (IsMainMenu == false)
        {
            PauseScreen.SetActive(false);
            Options.SetActive(true);
        }
    }

    public void PauseScreenActive()
    {
        if (PauseScreen.activeSelf == false)
        {
            PauseScreen.SetActive(true);
            InGameOverlay.SetActive(false);
            Paused = true;
            Debug.Log("Game Is Paused");
            Time.timeScale = 0;
            //su.Pause(true);
            //Lowpass();
        }
        /*
        Paused = true;

        MainMenu.SetActive(false);
        GradeSelect.SetActive(false);
        Options.SetActive(false);
        PauseScreen.SetActive(true);
        InGameOverlay.SetActive(false);
        Labels.SetActive(false);

        Time.timeScale = 0;
        */

    }
    /*
    void Lowpass()
    {
        if (Time.timeScale == 0)
        {
            pause.TransitionTo(0.05f);
            Debug.Log("Change Volume Down");
        }
        else
        {
            normal.TransitionTo(0.05f);
            Debug.Log("Change Volume Up");
        }
    }
    */

    private void WasGamePaused()
    {

        if (PauseScreen.activeSelf == true)
        {
            /*
            if (Paused == true)
            {
                Paused = false;
                Debug.Log("Game Is Paused");
                Time.timeScale = 0;
            }
            */
            Paused = false;
            Debug.Log("Game Is Unpaused");
            Time.timeScale = 1;
            PauseScreen.SetActive(false);
            InGameOverlay.SetActive(true);
            //su.Pause(false);
            //Lowpass();

        }
        else
        {
            Paused = false;
            Debug.Log("Game Is Unpaused");
            Time.timeScale = 1;
            PauseScreen.SetActive(false);
            //su.Pause(false);
            //Lowpass();
            /*
            if (Paused == true)
            {
                Paused = false;
                Debug.Log("Game Is Unpaused");
                Time.timeScale = 1;

            }
            */
        }
        /*
        Paused = false;

        MainMenu.SetActive(false);
        GradeSelect.SetActive(false);
        Options.SetActive(false);
        PauseScreen.SetActive(false);
        InGameOverlay.SetActive(true);
        Labels.SetActive(false);

        Time.timeScale = 1;
        */
    }

    public void GameOverActive()
    {
        Time.timeScale = 0;
        Paused = true;

        MainMenu.SetActive(false);
        GradeSelect.SetActive(false);
        Options.SetActive(false);
        PauseScreen.SetActive(false);
        InGameOverlay.SetActive(false);
        Labels.SetActive(false);
        GameOver.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        Paused = false;
        IsMainMenu = true;
        GameOver.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void PlayCredit()
    {
        MainMenu.SetActive(false);
        GradeSelect.SetActive(false);
        Options.SetActive(false);
        PauseScreen.SetActive(false);
        InGameOverlay.SetActive(false);
        Labels.SetActive(false);
        GameOver.SetActive(false);
        Credit.SetActive(true);
    }
}
