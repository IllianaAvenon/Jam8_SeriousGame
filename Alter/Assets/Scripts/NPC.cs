using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
	public float rotSpeed = 2.0f;
	public string dialJsonPath;
	
	public GameObject dialogueUI;
	
	private Button btn1;
	private Button btn2;
	private Button closeBtn;
	private Text dialText;
	private Text btn1Text;
	private Text btn2Text;
	
	private Dialogue dial;
	private int curDialogNum;
	
	private Quaternion startDir;
	private Quaternion lookAtRot;
	private GameObject player;
	private bool doRotate = false;
	private bool updateDialogue = false;
	
	public int friendship = 50;
	public int romance = 50;

	// Start is called before the first frame update
	void Start()
	{
        curDialogNum = 0;
		startDir = transform.rotation;
		dialogueUI.SetActive(false);
		btn1 = dialogueUI.transform.Find("Choice1").GetComponent<Button>();
		btn2 = dialogueUI.transform.Find("Choice2").GetComponent<Button>();
		closeBtn = dialogueUI.transform.Find("Close").GetComponent<Button>();
		dialText = dialogueUI.transform.Find("NPCText").GetComponent<Text>();
		btn1Text = dialogueUI.transform.Find("Choice1/Text").GetComponent<Text>();
		btn2Text = dialogueUI.transform.Find("Choice2/Text").GetComponent<Text>();
		
		Object asset = Resources.Load(dialJsonPath, typeof(TextAsset));
		dial = Dialogue.GetFromJson(asset.ToString());
	}

	// Update is called once per frame
	void Update()
	{
		if(doRotate)
		{
			lookAtRot = Quaternion.LookRotation(player.transform.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, lookAtRot, Time.deltaTime * rotSpeed);
			
			if(Vector3.Distance(player.transform.position, transform.position) > 3)
			{
				doRotate = false;
				dialogueUI.SetActive(false);
			}
		}
		
		else if(Quaternion.Angle(transform.rotation, startDir) > 0.5f)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, startDir, Time.deltaTime * rotSpeed);
		}
		
		if(updateDialogue)
			UpdateDialogue();
	}
	
	public void Interact(GameObject player)
	{
		this.player = player;
		doRotate = true;
		UpdateDialogue();
	}
	
	private void UpdateDialogue()
	{
		dialogueUI.SetActive(true);
		closeBtn.gameObject.SetActive(false);
		dialText.text = dial.choice[curDialogNum].dialogue;
		btn1Text.text = dial.choice[curDialogNum].opt1;
		btn2Text.text = dial.choice[curDialogNum].opt2;
		
		updateDialogue = false;
		
		btn1.onClick.AddListener( delegate {
			DoDialogue(dial.choice[curDialogNum].path1, dial.choice[curDialogNum].friendMod1, dial.choice[curDialogNum].relMod1);
		});
		
		btn2.onClick.AddListener( delegate {
			DoDialogue(dial.choice[curDialogNum].path2, dial.choice[curDialogNum].friendMod2, dial.choice[curDialogNum].relMod2);
		});
		
		closeBtn.onClick.AddListener( delegate {
			ResetDialogue();
		});
	}
	
	private void DoDialogue(int path, int frnd, int rel)
	{
		friendship += frnd;
		romance += rel;
		int lastDial = curDialogNum;
		curDialogNum = path;
		
		if(curDialogNum == -1) {
			dialText.text = dial.choice[lastDial].dialogue;
			btn1.gameObject.SetActive(false);
			btn2.gameObject.SetActive(false);
			closeBtn.gameObject.SetActive(true);
			updateDialogue = false;
		}
		else
			updateDialogue = true;
	}
	
	private void ResetDialogue()
	{
		btn1.onClick.RemoveAllListeners();
		btn2.onClick.RemoveAllListeners();
		btn1.gameObject.SetActive(true);
		btn2.gameObject.SetActive(true);
		dialogueUI.SetActive(false);
		curDialogNum = 0;
		
	}
}
