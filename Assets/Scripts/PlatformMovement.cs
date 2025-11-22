using UnityEngine;
using System.Collections;

public class PlatformMovement : MonoBehaviour
{
    public float speed = 1f, distance = 1f;
    public int directionalTracker = 1/* 1 = right/up and -1 = left/down*/, pauseTime = 2/*how long will the platform wait before reversing direction*/;
    public bool axis = true/* true = horizontal and false = vertical*/, isMoble = false/*used to toggle if the platform moves*/;
    public Vector3 startPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //there is an odd glitch where when the platform reaches the limits of its area
        //instead of reversing direction like it is supposed to, it will occasionally get stuck 
        //shifting back and forth by 0.001 for a few loops before continuing like normal.
        //chouldn't figure out the cause for this
        if (isMoble)  
        {
            if (axis)
            {
                transform.Translate(Vector3.right * directionalTracker * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.up * directionalTracker * speed * Time.deltaTime);
            }
            if (CheckIfReachedLimit())
            {
                isMoble = false;
                directionalTracker *= -1;
                StartCoroutine(PlatformPause(pauseTime));
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
    private IEnumerator PlatformPause(int pauseDuration)
    {
        while (pauseDuration > 0)
        {
            yield return new WaitForSeconds(1);
            pauseDuration--;
        }
        isMoble = true;
        StopAllCoroutines();
    } 
    bool CheckIfReachedLimit()
    {
        bool movementLimitReached = false;
        //for testing purposes
        //Debug.Log(transform.position.x - startPos.x);
        //Debug.Log(Mathf.Abs(transform.position.x - startPos.x));
        if (Mathf.Abs(transform.position.x - startPos.x) >= distance || Mathf.Abs(transform.position.y - startPos.y) >= distance)
        {
                movementLimitReached = true;
        }
            return movementLimitReached;
    }
}
