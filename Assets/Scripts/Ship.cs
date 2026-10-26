using UnityEngine;

public class Ship : MonoBehaviour
{
    public float speed;
    public float size;
    public int points;
    public float health = 1;
    Rigidbody2D rb;

    private void Update()
    {
        if (health <= 0)
        {
            GameManager.instance.GivePoints(points);
            ObjectPool.instance.Remove(gameObject);
        }

        if (transform.position.y <= -8)
        {
            ObjectPool.instance.Remove(gameObject);
        }
    }

    public void AssignStats(float newSpeed, float newSize, int newPoints, float newHealth)
    {
        speed = newSpeed;
        size = newSize;
        transform.localScale = new Vector2(size, size);
        points = newPoints;
        health = newHealth;
    }

    public void Move()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(Vector2.down * speed, ForceMode2D.Impulse);
    }

    public void Damage(int damage)
    {
        Debug.Log("damaged");
        health -= damage;
    }
}
