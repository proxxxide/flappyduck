using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RuchKaczki : MonoBehaviour
{

    Vector3 velocity = Vector3.zero;
    public float skokPredkosc = 100f;
    public float ruch = 1f;

    bool skok = false;

    Animator animator;

    public bool dead = false;
    float czasZycia;


    // Use this for initialization
    void Start()
    {
        animator = transform.GetComponentInChildren<Animator>();

        if (animator == null)
        {
            Debug.LogError("Brak obiektu");
        }
    }

    // Do Graphic & Input updates here
    void Update()
    {
        if (dead)
        {
            czasZycia -= Time.deltaTime;

            if (czasZycia <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    SceneManager.LoadScene("projekt");
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                skok = true;
            }
        }
        if(Input.GetKey("escape"))
            {
            Application.Quit();
            }
    }


    // Do physics engine updates here
    void FixedUpdate()
    {

        if (dead)
            return;

        GetComponent<Rigidbody2D>().AddForce(Vector2.right * ruch);

        if (skok)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * skokPredkosc);
            animator.SetTrigger("Skacz");

            skok = false;
        }

        if (GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("Dead");
        dead = true;
        czasZycia = 0.5f;
    }
}