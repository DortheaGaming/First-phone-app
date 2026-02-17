using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Rigidbody2D rb;
    [SerializeField] inputSys inputsys; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        int moveDir = 0;
        Vector2 screenPos;

        if (inputsys.IsPressing(out screenPos))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint
                                (new Vector3(screenPos.x, screenPos.y, 0f));

            if (touchPos.x < 0)
            {
                moveDir = -1;
            }
            else
            {
                moveDir = 1;
            }

        }

         Vector3 viewportPos = Camera.main.WorldToViewportPoint(rb.position);

            if ((viewportPos.x <=0f && moveDir<0) || (viewportPos.x >=1f && moveDir>0))
            {
                moveDir = 0;
            }

            rb.linearVelocityX = moveDir * moveSpeed; 
    }


        void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
