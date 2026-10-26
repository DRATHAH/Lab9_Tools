using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ShipBuilder
{
    GameObject enemyPrefab;
    float speed;
    float size = 1;
    int points;
    float health;

    public ShipBuilder SetPrefab(GameObject newPrefab)
    {
        enemyPrefab = newPrefab;
        return this;
    }

    public ShipBuilder AssignSpeed(float newSpeed)
    {
        speed = newSpeed;
        return this;
    }

    public ShipBuilder AssignSize(float newSize)
    {
        size = newSize;
        return this;
    }

    public ShipBuilder AssignPoints(int newPoints)
    {
        points = newPoints;
        return this;
    }

    public ShipBuilder AssignHealth(float newHealth)
    {
        health = newHealth;
        return this;
    }

    public Ship Build(Vector3 position, Quaternion rotation)
    {
        if (enemyPrefab == null)
        {
            Debug.LogWarning("EnemyBuilder requires a prefab");
            return null;
        }

        GameObject instance = ObjectPool.instance.Create(enemyPrefab, position, rotation);
        Ship ship = instance.GetComponent<Ship>();
        if (ship == null)
        {
            Object.Destroy(instance);
            Debug.LogWarning("Enemy prefab is missing the Ship component");
            return null;
        }

        ship.AssignStats(speed, size, points, health);

        return ship;
    }
}
