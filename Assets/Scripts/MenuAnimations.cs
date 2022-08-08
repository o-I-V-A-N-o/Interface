using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimations : MonoBehaviour
{
    private void OnEnable()
    {
        Debug.Log("enable");
        StartCoroutine(Scale(true));
        transform.localScale = new Vector3(2f, 2f, 1f);
    }

    private void OnDisable()
    {
        Debug.Log("disable");
        StartCoroutine(Scale(false));
    }

    private IEnumerator Scale(bool isOpen)
    {
        float scale = 1f;
        Vector3 endPosition = new Vector3(1f, 1f, 1f);
        if (!isOpen)
        {
            scale = -2f;
            endPosition = new Vector3(0f, 0f, 1f);
        }
        while(transform.localScale.x <= 1 || transform.localScale.x >= 0)
        {
            transform.localScale += new Vector3(0.1f, 0.1f, 0) * scale * Time.deltaTime;
            Debug.Log("ss");
        }
        transform.localScale = endPosition;
        yield return null;
    }
}
