using UnityEngine;

public class GoalController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.GetComponent<MoveBall>().speed = 2;
        FindObjectOfType<GameManager>().ChangeHealth(1);
    }
}
