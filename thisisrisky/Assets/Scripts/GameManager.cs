using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string Message = "Minimum players should be > 1.";
    public PlayerController[] players;
    public TerritoryController[] rootTerritories;
    
    // Start is called before the first frame update
    void Start()
    {
        if (players.Length <= 1)
        {
            Debug.LogError(Message);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
