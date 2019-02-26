using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] GameObject valueBox;
    [SerializeField] GameObject[] boxChoice;
    [SerializeField]GameObject[] boxLocations;
    GameObject currentValueBox;
    BoxController[] oldBoxes = new BoxController[9];
  public  GameObject[] RandomBoxes = new GameObject[9];

    int boxCount = 9;
    int number = 0;
    int index;
    private int amountTick;
    private int spwnIndex;
    private int i;
    private int amountOfBoxes;

    private GameManager GM;

    private void Start()
    {
        int i;
        int spwnIndex = 0;
        int amountTick = 0;
     
        int amountOfBoxes = Random.Range(2, 3);
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnBoxes();
    }

    void ResetSpawner()
    {
        number = 0;
    }

    void SpawnBoxes()
    {
        while(number<boxCount)
        {
            if (GM.currLevels == 0 || GM.currLevels == 1 || GM.currLevels == 2 || GM.currLevels == 3)
            {
                Instantiate(boxChoice[0].gameObject, boxLocations[number].transform.position, boxLocations[number].transform.rotation);
                oldBoxes = FindObjectsOfType<BoxController>();
                number++;
            }

            else if (GM.currLevels == 4)
            {
                Instantiate(boxChoice[1].gameObject, boxLocations[number].transform.position, boxLocations[number].transform.rotation);
                oldBoxes = FindObjectsOfType<BoxController>();
                number++;
            }

            else if (GM.currLevels == 5)
            {
           

                for ( i = 0; i < RandomBoxes.Length; i++)
                {
                    index = Random.Range(1, boxChoice.Length);
                    RandomBoxes[i] = boxChoice[index].gameObject;
                    spwnIndex = i;
                    if (RandomBoxes[i].gameObject.GetComponent<BlankID>())
                    {
                        amountTick++;
                        if (amountTick >= amountOfBoxes)
                        {
                            RandomBoxes[i] = null;
                            RandomBoxes[i] = boxChoice[Random.Range(1, boxChoice.Length)].gameObject;
                        }
                    }
                 
                }

                Instantiate(RandomBoxes[spwnIndex].gameObject, boxLocations[number].transform.position, boxLocations[number].transform.rotation);
                oldBoxes = FindObjectsOfType<BoxController>();
                number++;
            }
        }
    }


    public void DestroyBoxes()
    {
        oldBoxes = FindObjectsOfType<BoxController>();
        for (int i = 0; i < oldBoxes.Length; i++)
        {
            Destroy(oldBoxes[i].gameObject);
            ResetSpawner();
        }
    }
}