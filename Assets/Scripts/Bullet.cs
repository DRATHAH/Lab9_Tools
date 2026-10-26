using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = .05f;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb.linearVelocity.magnitude < 0)
        {
            rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
        }
    }

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Ship>() != null)
        {
            other.GetComponent<Ship>().Damage(1);
            ObjectPool.instance.Remove(gameObject);
        }
    }

    private void Update()
    {
        if (transform.position.y >= 10)
        {
            ObjectPool.instance.Remove(gameObject);
        }
    }
}
