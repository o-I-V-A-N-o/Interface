using UnityEngine;

public class MovePlayer2 : MonoBehaviour
{
    private InputPlayerController control;
    private Rigidbody rBody;

    private void Awake()
    {
        rBody = GetComponent<Rigidbody>();
        control = new InputPlayerController();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        var vector = control.Player2.Move.ReadValue<Vector2>();
        var movement = new Vector3(vector.x, 0, vector.y);
        rBody.AddForce(movement * 3);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Ball")
        {
            if (collision.transform.GetComponent<MoveBall>().speed < 5)
            {
                collision.transform.GetComponent<MoveBall>().speed += 1;
            }
        }
    }

    public void Shoot()
    {
        FindObjectOfType<MoveBall>().ICanMove = true;
    }

    private void OnEnable()
    {
        control.Enable();
    }

    private void OnDisable()
    {
        control.Disable();
    }
}
