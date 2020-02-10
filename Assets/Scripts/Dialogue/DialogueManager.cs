using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
	private Queue<string> sentences;

	public Text nameText;
	public Text dialogueText;

	public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
		sentences = new Queue<string>();
    }

	public void startDialogue(Dialogue dialogue)
    {
		animator.SetBool("isOpen", true);

		Debug.Log("Starting dialogue. . .");

		nameText.text = dialogue.name;
		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
        {
			sentences.Enqueue(sentence);
        }

		DisplayNextSentence();
    }


	public void DisplayNextSentence()
    {

		if (sentences.Count == 0)
        {
			EndDialogue();
			return;
        }

		string sentence = sentences.Dequeue();

		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
    }


	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
        }
    }


	public void EndDialogue()
	{
		Debug.Log("Ending dialogue. . .");
		animator.SetBool("isOpen", false);
	}
}
