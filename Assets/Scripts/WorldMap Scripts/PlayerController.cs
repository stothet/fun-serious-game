using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {

    public float speed;
    private Animator anim;
    private bool playerMoving;
    private Vector2 lastMove;
    private Inventory inventory;
    //private Rigidbody2D rb2d;
    public bool canMove;
    public NPCController cutsceneNPC;
    void Start(){
        canMove = true;
		anim = GetComponent<Animator> ();
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>(); // finding the inventory
        cutsceneNPC = GameObject.FindGameObjectWithTag("Principal").GetComponent<NPCController>();
        cutsceneNPC.autoTalk = true;
        transform.position = PersistenceController.PlayerState.playerPosition;
    }

    // Update is called once per frame
    void Update () {

        if (!canMove) // this is to stop the player from moving during cutscenes
        {
            anim.SetBool("PlayerMoving", false);
            return;
        }

        playerMoving = false;
		if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) { // checking the input every frame, to see the directional input corresponding to L/R
			transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * speed * Time.deltaTime, 0f, 0f)); // moving the player across the X axis
			playerMoving = true;
			lastMove = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0f); // setting the last move direction for animations
		}

		if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) { // checking the input every frame, to see the directional input corresponding to UP and DOWN
			transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * speed * Time.deltaTime, 0f)); // moving player across the Y axis
			playerMoving = true;
			lastMove = new Vector2 (0f,Input.GetAxisRaw ("Vertical"));
		}
		anim.SetBool ("PlayerMoving", playerMoving);
		anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal")); // these all relate to the animation logic for the blend tree
		anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);

        PersistenceController.PlayerState.playerPosition = transform.position;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision occured");
        if (Configuration.isTestMode)
        {
            subtractLife(); // For testing life subtraction
        }
        if (other.gameObject.CompareTag("Pickup"))
        {
            //inventory.addItem(0);
            other.gameObject.SetActive(false);
        }

    }

    /// <summary>
    /// Adds an evidence object into the inventory
    /// </summary>
    /// <param name="itemName"></param>
    public void addToInventory(string itemName)
    {
 
        inventory.addItem(itemName);
    }

    public void subtractLife()
    {
        PersistenceController.PlayerState.lives--;
        if (PersistenceController.PlayerState.lives <= 0)
        {
            PersistenceController.PlayerState.lives = Configuration.maxLives;
            // Transition to game over scene;
            Debug.Log("Game over");
            SceneManager.LoadScene(0);

        }
        else
        {
            // Update lives UI
        }

    }
}
