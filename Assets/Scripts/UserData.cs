using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UserData : MonoBehaviour {

    public InputField nameField;
    public InputField emailField;
    public GameLogic gl;
    public CanvasGroup backdrop;
    public Vector3 awayPos = new Vector3(541f, -350f, 0);

    void Start()
    {

        gl = GameObject.FindObjectOfType<GameLogic>();
        backdrop.alpha = 0f;

    }

	
	 public void validate () {

        bool fieldsOkay = false;

        if (nameField.text.Length > 5 && emailField.text.Contains("@") && emailField.text.Contains(".")) fieldsOkay = true;
        else fieldsOkay = false;

        if (fieldsOkay)
        {
            gl.setUserData(nameField.text, emailField.text);
            gl.changeState("Test");
            Debug.Log("State changed");
            Application.LoadLevel(1);
        }
        else
        {
            backdrop.alpha = 1f;
            backdrop.GetComponent<RectTransform>().localPosition = Vector3.zero;
            StartCoroutine(waitForGUI());
        }
	
	}

     IEnumerator waitForGUI()
     {
         yield return new WaitForSeconds(3);
         backdrop.alpha = 0f;
         backdrop.transform.position = awayPos;

     }
}
