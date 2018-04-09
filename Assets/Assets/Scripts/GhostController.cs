using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//add this import statement for Random number generation
using Random = UnityEngine.Random;

public class GhostController : MonoBehaviour
{
    private Vector3 velocity;

    private SpriteRenderer rend;
    private Animator anim;
    public float speed = 2.0f;

    //public GameController gameController;


    // Use this for initialization
    void Start()
    {
        velocity = new Vector3(0f, 0f, 0f);
        rend = GetComponent<SpriteRenderer> ();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

       // calculate location of screen borders
        // this will make more sense after we discuss vectors and 3D
        var dist = (transform.position - Camera.main.transform.position).z;
        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;

        //get the width of the object
        float width = rend.bounds.size.x;
        float height = rend.bounds.size.y;

				//1% of the time, switch the direction:
				int change = Random.Range(0,100);
				if (change == 0)
				{
						velocity = new Vector3(-1f, -1f, 0);
            anim.Play("Ghost_move_left");
				}
				//1% of the time, switch from horizontal to vertical, or vice-versa:
				else if (change == 1)
				{
						if (velocity.x != 0f){
								velocity = new Vector3(0f, 1f, 0f);
                anim.Play("Ghost_move_up");}
						else
								velocity = new Vector3(1f, 0f, 0f);
                anim.Play("Ghost_move_right");
				}

        //make sure the obect is inside the borders... if edge is hit destroy object
        if((transform.position.y <= bottomBorder + height/2.0) && velocity.y < 0f){
            Destroy(gameObject);
        }
        if((transform.position.y >= topBorder - height/2.0) && velocity.y > 0f){
            Destroy(gameObject);
        }
        transform.position = transform.position + velocity * Time.deltaTime * speed;

    }
}
