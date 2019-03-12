using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class TruckScore : MonoBehaviour
{
    public GameObject truck;

    private bool change = true;

    public List<Text> scoreBoards;
    // Start is called before the first frame update
    void Start()
    {
        truck = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (change)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TruckChangePosition();
                change = false;
            }
        }
        */
        for (int i = 0; i < scoreBoards.Count; i++)
        {
            scoreBoards[i].text = 10.ToString();

        }

    }
    public void TruckChangePosition()
    {
        truck.transform.localPosition = new Vector3(5f, 1.48f, 4f);
        //Quaternion target = Quaternion.Euler(0, 180, 0);
        //truck.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime*1f);
        truck.transform.Rotate(0,180,0);
    }

    public void TruckChangeBack()
    {
        truck.transform.Rotate(0, 180, 0);
        truck.transform.localPosition = new Vector3(- 3.08f, 1.48f, 4f);
    }
}
