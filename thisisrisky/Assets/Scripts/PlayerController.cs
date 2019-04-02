using System.Collections.ObjectModel;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ArmyController[] Armies;

    public ArmyController[] UnassignedArmies
    {
        get
        {
            List<ArmyController> tmp = new List<ArmyController>();
            foreach (ArmyController item in tmp)
            {
                if (item.Location)
                {
                    tmp.Remove(item);
                }
            }

            return tmp.ToArray();
        }
    }

    public ArmyController[] AssignedArmies
    {
        get
        {
            List<ArmyController> tmp = new List<ArmyController>();
            foreach (ArmyController item in tmp)
            {
                if (!item.Location)
                {
                    tmp.Remove(item);
                }
            }

            return tmp.ToArray();
        }
    }

    public bool OwnsCurrentTurn()
    {
        return RiskGameManager.Shared().CurrentTurn.Player == this;
    }

    public string displayName;
    public TerritoryController SelectedTerritory;

    /// <summary>
    /// Places the unassigned army at territory.
    /// </summary>
    /// <returns><c>true</c>, if unassigned army at territory was placed, <c>false</c> in all other cases.</returns>
    /// <param name="territory">Territory.</param>
    public bool PlaceUnassignedArmyAtTerritory(TerritoryController territory)
    {
        if (UnassignedArmies.Length > 0)
        {
            UnassignedArmies[0].Location = SelectedTerritory;
            return true;
        }
        else
        {
            Debug.LogError("Cannot place army!");
            return false;
        }
    }

    public void Update()
    {
        // Make sure all unassigned armies are inactive, and all assigned ones are active.
        foreach (ArmyController army in Armies)
        {
            army.gameObject.SetActive(army.Location != null);
        }
    }
}
