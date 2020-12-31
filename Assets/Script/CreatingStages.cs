using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CreatingStages : MonoBehaviour
{
    [SerializeField]
    private ScrollRect scroll;

    [SerializeField]
    private GameObject listRow;

    [SerializeField]
    private GameObject listItem;

    [SerializeField]
    private GameObject Item;

    [SerializeField]
    private GameObject locked;

    [SerializeField]
    private GameObject tutorialImage;

    [SerializeField]
    private int minVariable = 2, maxVariable=999;

    [SerializeField]
    private GameObject star1, star2, star3;

    void Start()
    {
        for (int j = 0; j < 250; j++)
        {
            GameObject ListItem = Instantiate(listItem, listRow.transform) as GameObject;
            ListItem.name = "ListItem_" + j;
            for (int i = 0; i < 4; i++)
            {
                GameObject item = Instantiate(Item, ListItem.transform) as GameObject;
                item.name = "item_" + i + "_ofList" + j;
                item.transform.localScale = new Vector3(1, 1, 1);

                //Creating the lock in stages
                GameObject Locked = Instantiate(locked, item.transform) as GameObject;
                
                //Change text in item
                int itemNumber = j * 4 + i + 1;
                Text textItem = item.GetComponentInChildren<Text>();
                textItem.text = "" + itemNumber;

                Locked.name = "Lock_" + itemNumber;
                if (itemNumber == 1000)
                {
                    Destroy(item);
                }
                if (i == 0 && j == 0)
                {
                    textItem.text = "";
                    Instantiate(tutorialImage, item.transform);
                }
            }   
        }
        scroll.verticalNormalizedPosition = 1;
        _RandomUnlockStage();
    }

    //Tắt button nếu màn bị khóa
    void _TurnOffButtonStage(int randomNumber)
    {
        for (int j = 0; j < 250; j++)
        {
            for (int i = 0; i < 4; i++)
            {
                int itemNumber = j * 4 + i + 1;
                Button itemButton = GameObject.Find("item_" + i + "_ofList" + j).GetComponent<Button>();
                if (itemNumber >= randomNumber)
                {
                    itemButton.enabled = false;
                }
            }
        }
    }

    //màn ngẫu nhiên được unlock
    void _RandomUnlockStage()
    {
        int randomNumber = 0;
        if (!PlayerPrefs.HasKey("numberOfUnlockedStage"))
        {
            randomNumber = Random.Range(minVariable, maxVariable);
            PlayerPrefs.SetInt("numberOfUnlockedStage", randomNumber);
        }
        else
        {
            randomNumber = PlayerPrefs.GetInt("numberOfUnlockedStage");
        }
        for (int i = 0; i < randomNumber; i++)
        {
            GameObject lockedItem = GameObject.Find("Lock_" + i);
            Destroy(lockedItem);
        }
        _RandomStars(randomNumber);
        _TurnOffButtonStage(randomNumber);
    }

    //tạo sao ngẫu nhiên
    void _RandomStars(int randomNumber)
    {
        if (randomNumber < 4)
        {
            for (int i = 0; i < randomNumber; i++)
            {
                int rand = 0;

                if (!PlayerPrefs.HasKey("item_" + i + "_ofList" + 0))
                {
                    rand = Random.Range(1, 4);
                    PlayerPrefs.SetInt("item_" + i + "_ofList" + 0, rand);
                }
                else
                {
                    rand = PlayerPrefs.GetInt("item_" + i + "_ofList" + 0);
                }
                rand= Random.Range(1, 3);
                if (rand == 1)
                {
                    _creating1Star(i);
                }
                else if (rand == 2)
                {
                    _creating2Star(i);
                }
                else if (rand == 3)
                {
                    _creating3Star(i);
                }
            }
        }
        else
        {          
            int coefficientOfList = randomNumber / 4;
            int viceCoefficientOfList = randomNumber % 4;
            for (int j = 0; j <= coefficientOfList; j++)
            {
                if (j != coefficientOfList)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        int rand = 0;
                        if (!PlayerPrefs.HasKey("item_" + i + "_ofList" + j))
                        {
                            rand = Random.Range(1, 4);
                            PlayerPrefs.SetInt("item_" + i + "_ofList" + j, rand);
                        }
                        else
                        {
                            rand = PlayerPrefs.GetInt("item_" + i + "_ofList" + j);
                        }
                        if (rand == 1)
                        {
                            _creating1Star(i, j);
                        }
                        else if (rand == 2)
                        {
                            _creating2Star(i, j);
                        }
                        else if (rand == 3)
                        {
                            _creating3Star(i, j);
                        }       
                    }
                }
                //creating odd items 
                else if (viceCoefficientOfList > 0 && j == coefficientOfList)
                {
                    for (int k = 0; k < viceCoefficientOfList-1; k++)
                    {
                        int rand = Random.Range(1, 4);
                        if (PlayerPrefs.HasKey("item_" + k + "_ofList" + j))
                        {
                            rand = Random.Range(1, 4);
                            PlayerPrefs.SetInt("item_" + k + "_ofList" + j, rand);
                        }
                        else
                        {
                            PlayerPrefs.GetInt("item_" + k + "_ofList" + j);
                        }
                        if (rand == 1)
                        {
                            _creating1Star(k, j);
                        }
                        else if (rand == 2)
                        {
                            _creating2Star(k, j);
                        }
                        else if (rand == 3)
                        {
                            _creating3Star(k, j);
                        }
                    }
                }
            }
        }
    }

    void _creating1Star(int index)
    {
        GameObject stage = GameObject.Find("item_" + index + "_ofList" + 0);
        Instantiate(star1, stage.transform);
    }
    void _creating1Star(int indexI, int indexJ)
    {
        GameObject stage = GameObject.Find("item_" + indexI + "_ofList" + indexJ);
        Instantiate(star1, stage.transform);
    }
    void _creating2Star(int index)
    {
        GameObject stage = GameObject.Find("item_" + index + "_ofList" + 0);
        Instantiate(star1, stage.transform);
        Instantiate(star2, stage.transform);
    }
    void _creating2Star(int indexI, int indexJ)
    {
        GameObject stage = GameObject.Find("item_" + indexI + "_ofList" + indexJ);
        Instantiate(star1, stage.transform);
        Instantiate(star2, stage.transform);
    }
    void _creating3Star(int index)
    {
        GameObject stage = GameObject.Find("item_" + index + "_ofList" + 0);
        Instantiate(star1, stage.transform);
        Instantiate(star2, stage.transform);
        Instantiate(star3, stage.transform);
    }
    void _creating3Star(int indexI, int indexJ)
    {
        GameObject stage = GameObject.Find("item_" + indexI + "_ofList" + indexJ);
        Instantiate(star1, stage.transform);
        Instantiate(star2, stage.transform);
        Instantiate(star3, stage.transform);
    }
}
