using UnityEngine;

public class MoveBall : MonoBehaviour
{
    public float speed = 2f;
    public bool hover = false;
    public bool ICanMove = false;
    public Vector3 _direction;

    public Transform originalObject;
    public Transform reflectedObject;

    void Update()
    {
        if (ICanMove)
        {
            Move();
        }
        else
        {
            Begin();
        }
    }

    public void Begin()
    {
        transform.rotation = FindObjectOfType<MovePlayer1>().transform.rotation;
        transform.position = FindObjectOfType<MovePlayer1>().transform.position + transform.forward * 1f;
    }

    public void Move()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void Go()
    {
        _direction = transform.forward;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Goal")
        {
            ICanMove = false;
        }
        else
        {
            _direction = Vector3.Reflect(transform.forward, collision.GetContact(0).normal);
            transform.forward = _direction;
        }
    }
}
