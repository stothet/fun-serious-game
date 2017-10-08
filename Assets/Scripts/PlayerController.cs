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

    // Global fields
    private static int numLives;
    private static bool hasCompletedMinigame;

    void Start(){
        canMove = true;
		anim = GetComponent<Animator> ();
        inventory = inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        cutsceneNPC = GameObject.FindGameObjectWithTag("Principal").GetComponent<NPCController>();
        cutsceneNPC.autoTalk = true;

        numLives = 3;
        hasCompletedMinigame = false;

    }

    // Update is called once per frame
    void Update () {

        if (!canMove)
        {
            anim.SetBool("PlayerMoving", false);
            return;
        }

        playerMoving = false;
		if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) {
			transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * speed * Time.deltaTime, 0f, 0f));
			playerMoving = true;
			lastMove = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0f);
		}

		if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) {
			transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * speed * Time.deltaTime, 0f));
			playerMoving = true;
			lastMove = new Vector2 (0f,Input.GetAxisRaw ("Vertical"));
		}
		anim.SetBool ("PlayerMoving", playerMoving);
		anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);
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
            inventory.addItem(0);
            other.gameObject.SetActive(false);
        }

    }

    /// <summary>
    /// Adds an evidence object into the inventory
    /// </summary>
    /// <param name="itemName"></param>
    public void addToInventory(string itemName)
    {
        int databaseID = ItemDatabase.NameToID(itemName);
        inventory.addItem(databaseID);
    }

    public void subtractLife()
    {
        numLives--;
        if (numLives <= 0)
        {
            // Transition to game over scene;
            Debug.Log("Game over");
            SceneManager.LoadScene(0);

        }
        else
        {
            // Update lives UI
        }

    }

    public static int getNumberOfLives()
    {
        return numLives;
    }

    public static bool getHasCompletedMinigame()
      {
          return hasCompletedMinigame;
      }
  
      public static void setHasCompletedMinigame(bool boolean)
      {
          hasCompletedMinigame = boolean;
      }

}
