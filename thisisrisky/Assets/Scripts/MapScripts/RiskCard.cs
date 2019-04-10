using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiskCard : MonoBehaviour
{
    public GameObject CardPrefab;
    public List<GameObject> RiskCards = new List<GameObject>();
    public GameObject TempCard;
    public Sprite[] TerritorySprites;
    public Sprite[] UnitTypeSprites;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewCard()
    {
        if (TempCard)
        {
            Destroy(TempCard);
        }
        GameObject Card = Instantiate(CardPrefab, new Vector3(2.56f, -2.93f, -0.81f), Quaternion.identity) as GameObject;
        Card.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = UnitTypeSprites[Random.Range(0, UnitTypeSprites.Length)];
        Card.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = TerritorySprites[Random.Range(0, TerritorySprites.Length)];
        TempCard = Card;
    }
}