using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public Transform[] WayPoints;
    public float Speed = 10;
    public string TrackerName;
    public GameObject Steam;

    private Rigidbody rd;
    private Transform target;
    private int Index = 0;
    private GameObject tracker;
    // Start is called before the first frame update
    void Start()
    {
        Index = 0;
        tracker = new GameObject(TrackerName);
        tracker.transform.position = transform.position;
        rd = GetComponent<Rigidbody>();
        target = WayPoints[Index];
        StartCoroutine("ChangeSpeed");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(PlayerController.GameState == true)
        {
            Steam.SetActive(true);
            MoveTracker();
            Vector3 MoveDir = (tracker.transform.position - transform.position).normalized;
            //rd.velocity = MoveDir * Speed;
            rd.AddForce(MoveDir * Speed);
            transform.forward = Vector3.Lerp(transform.forward, MoveDir, Time.fixedDeltaTime*5);
            
        }
        else
        {
            Steam.SetActive(false);
        }
    }
    void MoveTracker()
    {
        if (Vector3.Distance(transform.position, tracker.transform.position) > 10)
            return;
        Vector3 MoveDir = (target.position - tracker.transform.position).normalized;
        tracker.transform.Translate(MoveDir * Speed*2.0f* Time.fixedDeltaTime);
        if (Vector3.Distance(target.position, tracker.transform.position) < 2.0f)
        {
            Index++;
            Index %= WayPoints.Length;
            target = WayPoints[Index];
        }
    }
    IEnumerator ChangeSpeed()
    {
        yield return new WaitForSeconds(1);
        Speed += 5;
        //Debug.Log(1);
        yield return new WaitForSeconds(1);
        Speed += 5;
        //Debug.Log(2);
        yield return new WaitForSeconds(1f);
        Speed += 5;
        //Debug.Log(3);
    }
}
