using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public KeyCode left, right;
    public float buildup;
    public float maxspeed;

    public KeyCode jump;
    public float jumpforce;

    private Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move left and right.
        if (Input.GetKey(left))
        {
            rb2D.AddForce(Vector2.left * buildup);
        }
        if (Input.GetKey(right))
        {
            rb2D.AddForce(Vector2.right * buildup);
        }

        //Jump.
        if (Input.GetKeyDown(jump))
        {
            rb2D.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        }

        //Clamp and velocity.
        rb2D.velocity = new Vector2(Mathf.Clamp(rb2D.velocity.x, -maxspeed, maxspeed), rb2D.velocity.y);
    }
}
