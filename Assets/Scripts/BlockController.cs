using UnityEngine;

public class BlockController : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<GameManager>().SetBlocks(1);
        transform.position = new Vector3(Random.Range(-2f, 2f), Random.Range(-7f, 7f), Random.Range(-2f, 2f));
        transform.rotation = Quaternion.Euler(new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Ball")
        {
            transform.gameObject.SetActive(false);
            FindObjectOfType<GameManager>().SetBlocks(-1);
            if (collision.transform.GetComponent<MoveBall>().speed < 5)
            {
                collision.transform.GetComponent<MoveBall>().speed += 1;
            }
        }
    }
}
