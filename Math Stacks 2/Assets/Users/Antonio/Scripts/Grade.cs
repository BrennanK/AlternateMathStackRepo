using UnityEngine;
using UnityEngine.UI;

public class Grade : MonoBehaviour
{
    private GameManager GM;

    [SerializeField] private Text gradeText;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    

    private void Update()
    {
        gradeText.text = "" + GM.currLevels;
    }
}
