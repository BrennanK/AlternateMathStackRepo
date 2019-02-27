using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> boxChoice = new List<GameObject>();
    [SerializeField] List<GameObject> boxLocations = new List<GameObject>();
    [SerializeField] List<GameObject> RandomBoxes = new List<GameObject>();
    //[SerializeField] GameObject[] boxChoice;
    //[SerializeField] GameObject[] boxLocations;
    //[SerializeField] GameObject[] RandomBoxes = new GameObject[9];
    BoxController[] oldBoxes = new BoxController[9];

    private int boxCount = 9;
    private int number = 0;
    private int index;
    private int amountTick;
    private int spwnIndex;
    private int i;
    private int amountOfBoxes;

    private GameManager GM;

    private void Start()
    {
         spwnIndex = 0;
         amountTick = 0;
     
        amountOfBoxes = Random.Range(2, 4);
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
        if (GM.currLevels == 0 || GM.currLevels == 1 || GM.currLevels == 2 || GM.currLevels == 3)
        {
            while (number < boxCount)
            {
                Instantiate(boxChoice[0].gameObject, boxLocations[number].transform.position, boxLocations[number].transform.rotation);
                oldBoxes = FindObjectsOfType<BoxController>();
                number++;
            }
        }

        else if (GM.currLevels == 4)
        {
            while (number < boxCount)
            {
                Instantiate(boxChoice[1].gameObject, boxLocations[number].transform.position, boxLocations[number].transform.rotation);
                oldBoxes = FindObjectsOfType<BoxController>();
                number++;
            }
        }

        else if (GM.currLevels == 5)
        {
            while (number < boxCount)
            {
                for (i = 0; i < RandomBoxes.Count; i++)
                {
                    index = Random.Range(1, boxChoice.Count);
                    RandomBoxes[i] = boxChoice[index].gameObject;
                    spwnIndex = i;

                    if (RandomBoxes[i].gameObject.GetComponent<BlankID>())
                    {
                        amountTick++;

                        if (amountTick > amountOfBoxes)
                        {
                            RandomBoxes[i] = boxChoice[1].gameObject;
                        }
                    }

                    else if (RandomBoxes[i].gameObject.GetComponent<VerticalGroupID>())
                    {
                        amountTick += 2;

                        if (amountTick > amountOfBoxes)
                        {
                            RandomBoxes[i] = boxChoice[1].gameObject;
                        }
                    }

                    else if (RandomBoxes[i].gameObject.GetComponent<HorizontalGroupID>())
                    {
                        amountTick += 2;

                        if (amountTick > amountOfBoxes)
                        {
                            RandomBoxes[i] = boxChoice[1].gameObject;
                        }
                    }

                    //if (boxLocations[0].gameObject.GetComponent<VerticalGroupID>())
                    //{
                    //    boxLocations[]
                    //}

                    Instantiate(RandomBoxes[i].gameObject, boxLocations[number].transform.position, boxLocations[number].transform.rotation);
                    oldBoxes = FindObjectsOfType<BoxController>();
                    number++;
                }
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