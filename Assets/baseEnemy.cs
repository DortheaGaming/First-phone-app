using UnityEngine;

public abstract class baseEnemy : MonoBehaviour
{
    public float gravityScale = 1f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
    }
     void Update()
    {
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);

        if (viewportPos.y <0)
        {
            Destroy(gameObject);
        }
    }
}
