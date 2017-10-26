using UnityEngine;
using System.Collections;

public class NPCRandomWalk : MonoBehaviour {

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private Animator anim;
    private Vector2 lastMove;
    private bool playerMoving;

    public int currentWayPoint = 0;
    Transform targetWayPoint;

    public float speed = 4f;

    void Start()
    {
        playerMoving = false;
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        //GotoNextPoint();
    }


    /*void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
        /*(float moveX = 0f;
        float moveY = 0f;
        playerMoving = false;
        if (Random.Range(0f, 1f) > 0.95)
        {
            if (Random.Range(0f, 1f) > 0.5)
            {
                if (Random.Range(0f, 1f) > 0.5)
                {
                    moveX = -1;
                }
                else
                {
                    moveX = 1;
                }
                // playerMoving = true;
                transform.Translate(new Vector3(0f, moveX * 5 * Time.deltaTime, 0f));
                lastMove = new Vector2(0f, moveX);
                playerMoving = true;
            }
            else
            {
                if (Random.Range(0f, 1f) > 0.5)
                {
                    moveY = -1;
                }
                else
                {
                    moveY = 1;
                }
                //playerMoving = true;
                transform.Translate(new Vector3(moveY * 5 * Time.deltaTime, 0f, 0f));
                lastMove = new Vector2(moveY, 0f);
                playerMoving = true;
            }

            anim.SetFloat("MoveX", moveX);
            anim.SetFloat("MoveY", moveY);
            //		anim.SetFloat ("MoveX", TouchControls.directionX); // these all relate to the animation logic for the blend tree
            //		anim.SetFloat ("MoveY", TouchControls.directionY);
            anim.SetFloat("LastMoveX", lastMove.x);
            anim.SetFloat("LastMoveY", lastMove.y);
            anim.SetBool("PlayerMoving", playerMoving);
        } else
        {
            anim.SetBool("PlayerMoving", playerMoving);
        }*/
    //}

    // Update is called once per frame
    void Update()
    {
            Debug.Log("Does this move once only?");
            walk();
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
        anim.SetBool("PlayerMoving", playerMoving);
        //transform.position = Vector3.MoveTowards(transform.position,points[0].position,0.03f);

    }

    void walk()
    {
        playerMoving = true;
        float MoveX = -1*(transform.position.x - points[0].position.x);
        float MoveY = transform.position.y - points[0].position.y;
        lastMove = new Vector2(MoveX, MoveY);
        anim.SetFloat("MoveX", MoveX);
        anim.SetFloat("MoveY", MoveY);
        transform.position = Vector3.MoveTowards(transform.position, points[0].position, 0.03f);
        if(points[0].position.x == transform.position.x && points[0].position.y == transform.position.y)
        {
            playerMoving = false;
            lastMove.y = -1;
            lastMove.x = 0;
        }
        //playerMoving = false;
        //transform.Translate(new Vector3(moveX * 5 * Time.deltaTime, 0f, 0f));
    }
}
