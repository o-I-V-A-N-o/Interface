using UnityEngine;

public class MovePlayer1 : MonoBehaviour
{
    [SerializeField]
    private GameObject _manager;

    private InputPlayerController control;
    private Rigidbody rBody;

    private void Awake()
    {
        rBody = GetComponent<Rigidbody>();
        control = new InputPlayerController();
        control.Player1.Shoot.performed += _ => Shoot();
        control.Player1.Pause.performed += _ => Pause();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        var vector = control.Player1.Move.ReadValue<Vector2>();
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

    private void Shoot()
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

    private void Pause()
    {
        _manager.GetComponent<GameManager>().Pause();
    }
}
