using System.Collections.ObjectModel;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private List<ArmyController> UnderlyingArmies = new List<ArmyController>();

    public ArmyController[] Armies
    {
        get
        {
            return UnderlyingArmies.ToArray();
        }
    }

    public bool Reinforcing { get; private set; }
    
    public ArmyController[] UnassignedArmies
    {
        get
        {
            List<ArmyController> tmp = new List<ArmyController>();
            foreach (ArmyController item in Armies)
            {
                if (item.Assignable)
                {
                    tmp.Add(item);
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
            foreach (ArmyController item in Armies)
            {
                if (!item.Assignable)
                {
                    tmp.Add(item);
                }
            }

            return tmp.ToArray();
        }
    }

    public TerritoryController[] OwnedTerritories
    {
        get
        {
            List<TerritoryController> tmp = new List<TerritoryController>();
            foreach (ArmyController army in AssignedArmies)
            {
                if (!tmp.Contains(army.Location))
                {
                    tmp.Add(army.Location);
                }
            }

            return tmp.ToArray();
        }
    }

    public Continent[] OwnedContinents
    {
        get
        {
            List<Continent> ownedContinents = new List<Continent>();

            foreach (Continent continent in RiskGameManager.Shared().AllContinents)
            {
                foreach (TerritoryController tc in continent.ChildTerritories)
                {
                    if (tc.Player != this)
                    {
                        break;
                    }
                }

                ownedContinents.Add(continent);
            }

            return ownedContinents.ToArray();
        }
    }

    public void AddArmies(uint value)
    {
        ArmyController[] unassignedArmies = InstantiateNewArmies(value + (uint)UnassignedArmies.Length);
        UnderlyingArmies.AddRange(unassignedArmies);
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
            Debug.LogWarning("Cannot place army, no units available!\n# of Total Troops: " + Armies.Length + "\n# of Unassigned Troops: " + UnassignedArmies.Length + "\n# of Assigned Troops: " + AssignedArmies.Length);
            return false;
        }
    }

    public void Update()
    {
        // Make sure all unassigned armies are inactive, and all assigned ones are active.
        if (Armies != null && Armies.Length > 0)
        {
            foreach (ArmyController army in Armies)
            {
                army.gameObject.SetActive(army.Location != null);
            }
        }
    }

    /// <summary>
    /// Creates an array of cloned GameObjects of armies.
    /// </summary>
    /// <param name="count">The number of armies to clone.</param>
    /// <returns>An array of armies with the given count.</returns>
    private ArmyController[] InstantiateNewArmies(uint count)
    {
        List<ArmyController> defaultArmies = new List<ArmyController>();

        for (int i = 0; i < count; ++i)
        {
            GameObject basicArmyCopy = Instantiate<GameObject>(RiskGameManager.Shared().PrefabBasicArmy);
            ArmyController army = basicArmyCopy.GetComponent<ArmyController>();
            army.Player = this;
            defaultArmies.Add(army);
        }

        return defaultArmies.ToArray();
    }
}
