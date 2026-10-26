I made a ShipBuilder which constructs all the ships stats. GameManager controls which ships are made.

GameManager needs to spawn enemy -> ShipBuilder sets the stats of that enemy and returns it to GameManager -> GameManager spawns the enemy at the correct place