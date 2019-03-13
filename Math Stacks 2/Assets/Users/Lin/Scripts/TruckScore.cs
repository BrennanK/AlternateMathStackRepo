using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class TruckScore : MonoBehaviour
{
    public GameObject truck;

    private bool change = true;
    public Camera viewCamera;

    public List<Text> scoreBoards;
    // Start is called before the first frame update
    void Start()
    {
        truck = this.gameObject;
        viewCamera = Camera.current;
    }

    // Update is called once per frame
    void Update()
    {
        viewCamera = Camera.current;
        /*if (change)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TruckChangePosition();
                change = false;
            }
        }
        */
        
        scoreBoards[0].text = PlayerPrefs.GetInt("highScore_level0").ToString();
        scoreBoards[1].text = PlayerPrefs.GetInt("highScore_level1").ToString();
        scoreBoards[2].text = PlayerPrefs.GetInt("highScore_level2").ToString();
        scoreBoards[3].text = PlayerPrefs.GetInt("highScore_level3").ToString();
        scoreBoards[4].text = PlayerPrefs.GetInt("highScore_level4").ToString();
        scoreBoards[5].text = PlayerPrefs.GetInt("highScore_level5").ToString();
    }
    public void TruckChangePosition()
    {
        truck.transform.localPosition = new Vector3(4.5f, 1.8f, -10.5f);
        //Quaternion target = Quaternion.Euler(0, 180, 0);
        //truck.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime*1f);
        truck.transform.Rotate(0,180,0);
        viewCamera.GetComponent<Camera>().orthographicSize = 2.75f;
    }

    public void TruckChangeBack()
    {
        truck.transform.Rotate(0, 180, 0);
        truck.transform.localPosition = new Vector3(- 3.08f, 1.48f, 4f);
        viewCamera.GetComponent<Camera>().orthographicSize = 4f;
    }
}
