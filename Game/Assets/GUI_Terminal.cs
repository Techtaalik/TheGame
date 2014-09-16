﻿using UnityEngine;
using System.Collections;

public class GUI_Terminal : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	protected string input = "";
	protected Vector2 scrollPosition;
	protected string consoleLog = "";
	void OnGUI () 
	{

		// get enter to work properly
		// after submit add to log, if clear command is entered, clear the log
		GUILayout.BeginArea(new Rect(10, Screen.height - 123, Screen.width - 20, 123));
		scrollPosition = GUILayout.BeginScrollView (scrollPosition, GUILayout.Width (Screen.width - 20), GUILayout.Height (98));
		GUILayout.Label (consoleLog);

		GUILayout.EndScrollView();
		if(GUI.Button(new Rect(0, 98, 60,20 ),"Submit"))
		{
			SubmitCommand();
		}
		input = GUI.TextField(new Rect(70,  98, Screen.width - 90,20), input);
		GUILayout.EndArea();

	}
	void SubmitCommand()
	{

		string output = Parser.Parse(input);
		if(!input.Equals(""))
		{
			consoleLog = input + "\n" + consoleLog;
		}

		consoleLog = output + "\n" + consoleLog;
		if(output.Equals("<===Clearing===>"))
		{
			consoleLog = "" + "<===Cleared===>";
		}
		input = "";
	}
}