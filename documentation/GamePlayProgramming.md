# Class Structure

- GameManager -- Holds turn, player, and game config information.
- UnitArmy -- Handles the visual representation of the army for a given player.
- UnitArmyController -- Handles movement and game manager interface logic for a player's army.
- PlayerController -- Handles game logic, army controllers, and legal army movement for a player.
- Player -- In game representation of player. For this game it will likely just be an empty object.
- Region -- Handles visual aspects of displaying a region in the map.
- RegionController -- Handles game logic for holding armies, things determining wether the player holding the region should receive the round bonus for holding the region.
- BattleController -- Created when two or more players enter a battle. Handles all game logic for resolving it.
