using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public float speed;
    private Animator anim;
    private bool playerMoving;
    private Vector2 lastMove;
    private Inventory inventory;
    public bool canMove;
    public NPCController cutsceneNPC;
	public CameraController camera;

    void Start(){
        canMove = true;
		anim = GetComponent<Animator> ();
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>(); // finding the inventory
        cutsceneNPC = GameObject.FindGameObjectWithTag("Principal").GetComponent<NPCController>();
        cutsceneNPC.autoTalk = true;
        transform.position = PersistenceController.instance.playerState.playerPosition;

		camera = GameObject.Find("Main Camera").GetComponent<CameraController>();

    }
    // Update is called once per frame
    void Update () {
		if (camera.tiltActive) {
			canMove = false;
		} else {
			canMove = true;
		}
        if (!canMove) // this is to stop the player from moving during cutscenes
        {
            anim.SetBool("PlayerMoving", false);
            return;
        }

        playerMoving = false;
		if (Input.GetAxis ("Horizontal") > 0.5f || Input.GetAxis ("Horizontal") < -0.5f) { // checking the input every frame, to see the directional input corresponding to L/R
			transform.Translate (new Vector3 (Input.GetAxis ("Horizontal") * speed * Time.deltaTime, 0f, 0f)); // moving the player across the X axis
			playerMoving = true;
			lastMove = new Vector2 (Input.GetAxis ("Horizontal"), 0f); // setting the last move direction for animations
		}

		if (Input.GetAxis ("Vertical") > 0.5f || Input.GetAxis ("Vertical") < -0.5f) { // checking the input every frame, to see the directional input corresponding to UP and DOWN
			transform.Translate (new Vector3 (0f, Input.GetAxis ("Vertical") * speed * Time.deltaTime, 0f)); // moving player across the Y axis
			playerMoving = true;
			lastMove = new Vector2 (0f,Input.GetAxis ("Vertical"));
		}

		if (TouchControls.directionX != 0) {
			transform.Translate (new Vector3 (TouchControls.directionX * speed * Time.deltaTime, 0f, 0f)); // moving the player across the X axis
			playerMoving = true;
			lastMove = new Vector2 (TouchControls.directionX, 0f); // setting the last move direction for animations
		}

		if (TouchControls.directionY != 0) {
			transform.Translate (new Vector3 (0f, TouchControls.directionY * speed * Time.deltaTime, 0f)); // moving the player across the X axis
			playerMoving = true;
			lastMove = new Vector2 (0f, TouchControls.directionY); // setting the last move direction for animations
		}

		anim.SetBool ("PlayerMoving", playerMoving);
		//anim.SetFloat ("MoveX", Input.GetAxis("Horizontal"));
		//anim.SetFloat ("MoveY", Input.GetAxis("Vertical"));
		anim.SetFloat ("MoveX", TouchControls.directionX); // these all relate to the animation logic for the blend tree
		anim.SetFloat ("MoveY", TouchControls.directionY);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);

        PersistenceController.instance.playerState.playerPosition = transform.position;
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
            inventory.addItem(other.gameObject.name);
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
        PersistenceController.instance.playerState.lives--;
        if (PersistenceController.instance.playerState.lives <= 0)
        {
            PersistenceController.instance.playerState.lives = Configuration.maxLives;
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
