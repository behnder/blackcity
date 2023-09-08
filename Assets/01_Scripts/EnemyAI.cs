using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public string targetStateName = "Enemy_Attack_01"; // Replace with the name of your target state
    public bool hasExitTimeValue = true; // Replace with the desired value for "Has Exit Time"

    [SerializeField] GameObject hero;
    [SerializeField] GameObject weapon;
    [SerializeField] float distanceBetween;
  


    [Header("Pathfinding")]
    public Transform target;
    public float activateDistance = 50f;
    public float pathupdateSeconds = 0.5f;

    [Header("Physiscs")]
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public float jumpNodeHeightRequirement = 0.8f;
    public float JumpModifier = 0.3f;
    public float jumpCheckOffset = 0.1f;

    [Header("CustomBehavior")]
    public bool followEnabled = true;
    public bool jumpEnabled = true;
    public bool directionLookEnabled = true;

    public Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    bool isGrounded = false;

    Seeker seeker;
    Rigidbody2D rb;

    public GameObject Weapon { get => weapon; set => weapon = value; }

    void Start()
    {

 
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, pathupdateSeconds);

    }
    private void Update()
    {
        if (Vector2.Distance(gameObject.transform.position, hero.transform.position) < distanceBetween)
            Weapon.GetComponent<Animator>().Play("Enemy_Attack_01");
        else
            Weapon.GetComponent<Animator>().Play("Enemy_Weapon_Idle");
    }

    private void StopAttack()
    {
        Weapon.SetActive(false);

    }
    private void FixedUpdate()
    {
        if (TargetInDistance() && followEnabled)
        {
            PathFollow();
        }
    }

    private void UpdatePath()
    {
        if (followEnabled && TargetInDistance() && seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    private void PathFollow()
    {
        if(path == null)
        {
            return;
        }

        // reached end of path
        if (currentWaypoint >= path.vectorPath.Count)
        {
            return;
        }

        //see if colliding with anything
        Vector3 startOffset = transform.position - new Vector3(0f, GetComponent<Collider2D>().bounds.extents.y + jumpCheckOffset);
        isGrounded = Physics2D.Raycast(transform.position, -Vector3.up, 0.05f);

        //Direction Calculation
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        
        Vector2 force = direction * speed * Time.deltaTime;

        //Jump

        if(jumpEnabled && isGrounded)
        {
            if(direction.y > jumpNodeHeightRequirement)
            {
                rb.AddForce(Vector2.up * speed * JumpModifier);
            }
        }

        //Movement
       // rb.AddForce(force);
        rb.AddForce(new Vector2(force.x, 0));

        //Next Waypoint

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        //Direction Grapchics Handling

        if(directionLookEnabled)
        {
            if (rb.velocity.x > 0.05f)
            {
                transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

            }
            else if (rb.velocity.x < -0.05f)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
      
    }

    private bool TargetInDistance()
    {
        return Vector2.Distance(transform.position, target.transform.position) < activateDistance;
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    
}
