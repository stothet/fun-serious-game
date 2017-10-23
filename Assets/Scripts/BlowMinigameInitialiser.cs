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
			txtBox.notNPC = true;
            txtBox.ShowDialogueBox();
            txtBox.dialogueText.text =  "The note is dusty. Do you want to blow it?";
        }
    }

    private void YesTaskClick()
    {
        txtBox.dialogueText.text = "";
        txtBox.DisableDialogueBox();
        yesBtnObject.SetActive(false);
        noBtnObject.SetActive(false);
		SceneManager.LoadScene(Configuration.microphoneMinigameSceneName);
    }

    private void NoTaskClick()
    {
        txtBox.dialogueText.text = "";
        txtBox.DisableDialogueBox();
        yesBtnObject.SetActive(false);
        noBtnObject.SetActive(false);
    }
}
