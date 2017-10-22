using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlowMinigameInitialiser : MonoBehaviour {

    public static bool completed = false;
    public TextBoxManager txtBox;
    public GameObject yesBtnObject;
    public GameObject noBtnObject;
    private Button yesBtn;
    private Button noBtn;
	// Use this for initialization
	void Start () {
        yesBtn = yesBtnObject.GetComponent<Button>();
        noBtn = noBtnObject.GetComponent<Button>();
        yesBtn.onClick.AddListener(YesTaskClick);
        noBtn.onClick.AddListener(NoTaskClick);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !completed)
        {
            yesBtnObject.SetActive(true);
            noBtnObject.SetActive(true);
            Debug.Log("HELLO?");
            txtBox.ShowDialogueBox();
            txtBox.dialogueText.text =  "The note is dusty. Do you want to blow it?";
        }
    }

    private void YesTaskClick()
    {
        Debug.Log("is this task being called?");
        txtBox.dialogueText.text = "";
        txtBox.DisableDialogueBox();
        yesBtnObject.SetActive(false);
        noBtnObject.SetActive(false);
        Debug.Log("THINKING?");
        SceneManager.LoadScene(5);
    }

    private void NoTaskClick()
    {
        Debug.Log("is this task2 being called?");
        txtBox.dialogueText.text = "";
        txtBox.DisableDialogueBox();
        yesBtnObject.SetActive(false);
        noBtnObject.SetActive(false);
       // Debug.Log("THINKING?4");
    }
}
