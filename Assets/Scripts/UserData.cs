using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UserData : MonoBehaviour {

    public InputField nameField;
    public InputField emailField;
    public GameLogic gl;

    void Start()
    {

        gl = GameObject.FindObjectOfType<GameLogic>();

    }

	
	// Update is called once per frame
	public void validate () {

        bool fieldsOkay = false;

        if (nameField.text.Length > 5 && emailField.text.Contains("@") && emailField.text.Contains(".")) fieldsOkay = true;
        else fieldsOkay = false;

        if (fieldsOkay)
        {
            gl.setUserData(nameField.text, emailField.text);
            gl.changeState("Test");
            Debug.Log("State changed");

        }
	
	}
}
