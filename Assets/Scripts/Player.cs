using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public InputActionReference moveAction;
    public InputActionReference shootAction;
    public float[] worldBounds = new float[4];

    public GameObject bulletPrefab;
    public float speed = 2f;
    public float fireRate = 1f;

    float timeSinceShot = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = moveAction.action.ReadValue<Vector2>();
        Vector2 position = new Vector3((movement.x * speed) + transform.position.x, (movement.y * speed) + transform.position.y, 0);
        position.x = Mathf.Clamp(position.x, worldBounds[0], worldBounds[1]);
        position.y = Mathf.Clamp(position.y, worldBounds[2], worldBounds[3]);
        transform.position = position;

        if (shootAction.action.IsPressed() && timeSinceShot <= 0)
        {
            ObjectPool.instance.Create(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
            Debug.Log("shoot");
            timeSinceShot = fireRate;
        }

        if (timeSinceShot >= 0)
        {
            timeSinceShot -= Time.deltaTime;
        }
    }
}
