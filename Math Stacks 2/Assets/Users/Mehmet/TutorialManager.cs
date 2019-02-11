// Author: Mehmet Holbert
// Description: Manages Tutorials being played for the first time.
// Date: 2/7/2019
// Last Edited By: 
// Last Edited Date: 2/7/2019

using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager TMInstance;
    public bool HasSeenK, HasSeen1, HasSeen2, HasSeen3, HasSeen4, HasSeen5;
    [SerializeField] private GameObject TutorialFifth;
    [SerializeField] private GameObject TutorialFirst;
    [SerializeField] private GameObject TutorialFourth;
    [SerializeField] private GameObject TutorialK;
    [SerializeField] private GameObject TutorialSecond;
    [SerializeField] private GameObject TutorialThird;

    private void Awake()
    {
        if (TMInstance == null)
            TMInstance = this;
        if (TMInstance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        var curScene = SceneManager.GetActiveScene();
        var SceneName = curScene.name;
        if (SceneName == "Test_Scene")
        {
            switch (GameManager.Instance.currLevels)
            {
                case 0:
                    KTutorial();
                    break;
                case 1:
                    FirstTutorial();
                    break;
                case 2:
                    SecondTutorial();
                    break;
                case 3:
                    ThirdTutorial();
                    break;
                case 4:
                    FourthTutorial();
                    break;
                case 5:
                    FifthTutorial();
                    break;
                default:
                    KTutorial();
                    break;
            }
        }
        else
        {
            TutorialK.SetActive(false);
            TutorialFirst.SetActive(false);
            TutorialSecond.SetActive(false);
            TutorialThird.SetActive(false);
            TutorialFourth.SetActive(false);
            TutorialFifth.SetActive(false);
        }
    }

    private void KTutorial()
    {
        if (!HasSeenK)
            TutorialK.SetActive(true);
        else
            TutorialK.SetActive(false);
    }

    private void FirstTutorial()
    {
        if (!HasSeenK)
        {
            TutorialK.SetActive(true);
        }
        else if (!HasSeen1 && HasSeenK)
        {
            TutorialK.SetActive(false);
            TutorialFirst.SetActive(true);
        }
        else
        {
            TutorialK.SetActive(false);
            TutorialFirst.SetActive(false);
        }
    }

    private void SecondTutorial()
    {
        if (!HasSeenK)
        {
            TutorialK.SetActive(true);
        }
        else if (!HasSeen1 && HasSeenK)
        {
            TutorialK.SetActive(false);
            TutorialFirst.SetActive(true);
        }
        else if (!HasSeen2 && HasSeen1 && HasSeenK)
        {
            TutorialK.SetActive(false);
            TutorialFirst.SetActive(false);
            TutorialSecond.SetActive(true);
        }
        else
        {
            TutorialK.SetActive(false);
            TutorialFirst.SetActive(false);
            TutorialSecond.SetActive(false);
        }
    }

    private void ThirdTutorial()
    {
        if (!HasSeenK)
        {
            TutorialK.SetActive(true);
        }
        else if (!HasSeen1 && HasSeenK)
        {
            TutorialK.SetActive(false);
            TutorialFirst.SetActive(true);
        }
        else if (!HasSeen2 && HasSeen1 && HasSeenK)
        {
            TutorialK.SetActive(false);
            TutorialFirst.SetActive(false);
            TutorialSecond.SetActive(true);
        }
        else if (!HasSeen3 && HasSeen2 && HasSeen1 && HasSeenK)
        {
            TutorialK.SetActive(false);
            TutorialFirst.SetActive(false);
            TutorialSecond.SetActive(false);
            TutorialThird.SetActive(true);
        }
        else
        {
            TutorialK.SetActive(false);
            TutorialFirst.SetActive(false);
            TutorialSecond.SetActive(false);
            TutorialThird.SetActive(false);
        }
    }

    private void FourthTutorial()
    {
        if (!HasSeenK)
        {
            TutorialK.SetActive(true);
        }
        else if (!HasSeen1 && HasSeenK)
        {
            TutorialK.SetActive(false);
            TutorialFirst.SetActive(true);
        }
        else if (!HasSeen2 && HasSeen1 && HasSeenK)
        {
            TutorialK.SetActive(false);
            TutorialFirst.SetActive(false);
            TutorialSecond.SetActive(true);
        }
        else if (!HasSeen3 && HasSeen2 && HasSeen1 && HasSeenK)
        {
            TutorialK.SetActive(false);
            TutorialFirst.SetActive(false);
            TutorialSecond.SetActive(false);
            TutorialThird.SetActive(true);
        }
        else if (!HasSeen4 && HasSeen3 && HasSeen2 && HasSeen1 && HasSeenK)
        {
            TutorialK.SetActive(false);
            TutorialFirst.SetActive(false);
            TutorialSecond.SetActive(false);
            TutorialThird.SetActive(false);
            TutorialFourth.SetActive(true);
        }
        else
        {
            TutorialK.SetActive(false);
            TutorialFirst.SetActive(false);
            TutorialSecond.SetActive(false);
            TutorialThird.SetActive(false);
            TutorialFourth.SetActive(false);
        }
    }

    private void FifthTutorial()
    {
        if (!HasSeenK)
        {
            TutorialK.SetActive(true);
        }
        else if (!HasSeen1 && HasSeenK)
        {
            TutorialK.SetActive(false);
            TutorialFirst.SetActive(true);
        }
        else if (!HasSeen2 && HasSeen1 && HasSeenK)
        {
            TutorialK.SetActive(false);
            TutorialFirst.SetActive(false);
            TutorialSecond.SetActive(true);
        }
        else if (!HasSeen3 && HasSeen2 && HasSeen1 && HasSeenK)
        {
            TutorialK.SetActive(false);
            TutorialFirst.SetActive(false);
            TutorialSecond.SetActive(false);
            TutorialThird.SetActive(true);
        }
        else if (!HasSeen5 && HasSeen4 && HasSeen3 && HasSeen2 && HasSeen1 && HasSeenK)
        {
            TutorialK.SetActive(false);
            TutorialFirst.SetActive(false);
            TutorialSecond.SetActive(false);
            TutorialThird.SetActive(false);
            TutorialFourth.SetActive(false);
            TutorialFifth.SetActive(true);
        }
        else
        {
            TutorialK.SetActive(false);
            TutorialFirst.SetActive(false);
            TutorialSecond.SetActive(false);
            TutorialThird.SetActive(false);
            TutorialFourth.SetActive(false);
            TutorialFifth.SetActive(false);
        }
    }
}