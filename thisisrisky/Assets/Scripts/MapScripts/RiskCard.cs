using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiskCard : MonoBehaviour
{
    public GameObject CardPrefab;
    public List<GameObject> RiskCards = new List<GameObject>();
    public GameObject TempCard;
    public Sprite[] CardSprites;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewCard()
    {
        // Discard the previous card created (just for testing)
        if (TempCard)
        {
            Destroy(TempCard);
        }
        Debug.Log(Camera.main);
        Vector2 cardVec = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
        GameObject Card = Instantiate(CardPrefab, cardVec, Quaternion.identity) as GameObject;
        Card.GetComponent<SpriteRenderer>().sprite = CardSprites[Random.Range(0,CardSprites.Length)];
        TempCard = Card;
        Debug.Log("NewCard: " + TempCard.transform.position + "\n" + TempCard.name);
    }
}