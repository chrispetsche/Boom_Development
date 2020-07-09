﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SimpleJSON;

// The purpose of this script is to be placed onto the main canvas of a scene and manage setting UI elements active and innactive.
// This is also where all the "New" methods are. As in the methods that create new user data types, like Floors, Rooms and the like.

public class UIManager : MonoBehaviour
{
    private void OnEnable()
	{
		AppManager.appManager.currUIManager = this;
	}

	private void OnDisable()
	{
		AppManager.appManager.currUIManager = null;
	}

	public void OpenPanel(GameObject panel)
	{
		if (panel.activeSelf)
		{
			panel.SetActive(false);
		}
		else
		{
			panel.SetActive(true);
		}
	}

    // CP???Why are these needed in the UIManager? Can they be placed in their own script that handles creating anything realated 
    // CP???to new user data types and checked here if needed to fulfill UI related actions happening on the canvas.
    //public void NewProject(NewProject _newProject)
    //{
    //	if (!_newProject)
    //	{
    //		Debug.LogWarning("Argument for NewProject() is null!");
    //		return;
    //	}
    //	else if (_newProject.passwordField.text != _newProject.passwordCheckField.text)
    //	{
    //		Debug.Log("You're passwords do not match!");
    //		return;
    //	}

    //	AppManager temp = AppManager.appManager;

    //	#region determing new projectID
    //	// What's happening here is I'm finding all of the total project IDs.
    //	// Let's say there are 4 projects. Their IDs are 1, 2, 4, 5. What this section does is finds the lowest room ID number that isn't taken.
    //	// This this example, it would find the number 3.

    //	int newProjId = 0;

    //	List<Project> projects = temp.FindAllProjects();

    //	List<int> projectIds = new List<int>();
    //	foreach (Project proj in projects)
    //	{
    //		projectIds.Add(proj.projectId);
    //	} // Grabbing all project IDs

    //	int highestId = 0;
    //	for (int i = 0; i <= projectIds.Count; i++)
    //	{
    //		if (i > highestId)
    //		{
    //			highestId = i;
    //		}
    //	} // Finding highest Id

    //	for (int i = 1; i <= highestId; i++)
    //	{
    //		if (!projectIds.Contains(i))
    //		{
    //			newProjId = i;
    //		}
    //		else if (i == highestId)
    //		{
    //			newProjId = i + 1;
    //		}
    //	} // Finding lowest unused project ID
    //	#endregion

    //	#region grab uploaded img
    //	byte[] plan = new byte[0];

    //	if (_newProject.image != null)
    //	{
    //		if (_newProject.image.sprite != null)
    //		{
    //			Texture2D tex = _newProject.image.sprite.texture;

    //			try
    //			{
    //				plan = tex.EncodeToJPG();
    //			}
    //			catch (Exception e)
    //			{
    //				Debug.LogWarning("Failed to encode img. " + e.Message);
    //				return;
    //			}
    //		}

    //		//reset new proj panel
    //		_newProject.image.sprite = null;
    //		for (int i = 0; i < _newProject.imgButtonsToReset.Length; i++)
    //		{
    //			_newProject.imgButtonsToReset[i].SetActive(true);
    //		}
    //	}
    //	#endregion

    //	Project tempProj = new Project(newProjId, _newProject.projNameField.text, plan);
    //	temp.currUser.projects.Add(tempProj);

    //	//Upload to server here. I intended for there to be funtions to call in the AppManager that would handle uploading. They could just take in an argument of "Project."

    //	//string url = temp.serverAddress + "api/v1/projects?sessionId=" + temp.sessionId + "&" + "name=" + tempProj.name;
    //	//JSONObject json = new JSONObject();
    //	//json["project"]["id"].AsInt = tempProj.projectId;
    //	//json["project"]["name"] = tempProj.name;
    //	//print(json.AsObject);

    //	//RestFarm.restFarm.POST(url, json.AsObject, RestFarm.restFarm.DebugOnComplete);

    //	//AppManager.appManager.currProjId = tempProj.projectId;
    //	//SceneManagement.sceneManagement.LoadScene("FloorSelect");
    //}

    //public void NewFloor(NewFloor _newFloor)
    //{
    //	if (!_newFloor)
    //	{
    //		Debug.LogWarning("Argument for NewProject() is null!");
    //		return;
    //	}

    //	AppManager temp = AppManager.appManager;

    //	#region determing new projectID
    //	// What's happening here is I'm finding all of the total project IDs.
    //	// Let's say there are 4 projects. Their IDs are 1, 2, 4, 5. What this section does is finds the lowest room ID number that isn't taken.
    //	// This this example, it would find the number 3.

    //	int newFloorId = 0;

    //	List<Floor> floors = temp.FindAllFloors();

    //	List<int> floorIds = new List<int>();
    //	foreach (Floor floor in floors)
    //	{
    //		floorIds.Add(floor.floorId);
    //	} // Grabbing all project IDs

    //	int highestId = 0;
    //	for (int i = 0; i <= floorIds.Count; i++)
    //	{
    //		if (i > highestId)
    //		{
    //			highestId = i;
    //		}
    //	} // Finding highest Id

    //	for (int i = 1; i <= highestId; i++)
    //	{
    //		if (!floorIds.Contains(i))
    //		{
    //			newFloorId = i;
    //		}
    //		else if (i == highestId)
    //		{
    //			newFloorId = i + 1;
    //		}
    //	} // Finding lowest unused project ID
    //	#endregion

    //	#region grab uploaded img
    //	byte[] plan = new byte[0];

    //	if (_newFloor.image != null)
    //	{
    //		if (_newFloor.image.sprite != null)
    //		{
    //			Texture2D tex = _newFloor.image.sprite.texture;

    //			try
    //			{
    //				plan = tex.EncodeToJPG();
    //			}
    //			catch (Exception e)
    //			{
    //				Debug.LogWarning("Failed to encode img. " + e.Message);
    //				return;
    //			}
    //		}

    //		//reset new floor panel
    //		_newFloor.image.sprite = null;
    //		for (int i = 0; i < _newFloor.imgButtonsToReset.Length; i++)
    //		{
    //			_newFloor.imgButtonsToReset[i].SetActive(true);
    //		}
    //	}
    //	#endregion

    //	Floor tempFloor = new Floor(newFloorId, _newFloor.floorNameField.text, plan);
    //	temp.FindProjectByID(temp.currProjId).floors.Add(tempFloor);

    //	//Upload to server here

    //	AppManager.appManager.currFloorId = tempFloor.floorId;
    //	SceneManagement.sceneManagement.LoadScene("RoomSelect");
    //}

    //public void NewRoom(NewRoom _newRoom)
    //{
    //	if (!_newRoom)
    //	{
    //		Debug.LogWarning("Argument for NewRoom() is null!");
    //		return;
    //	}
    //	else if (_newRoom.name.Length == 0)
    //	{
    //		Debug.Log("You're room name is blank!");
    //		return;
    //	}

    //	AppManager temp = AppManager.appManager;

    //	#region determing new roomID
    //	// What's happening here is I'm finding all of the total rooms IDs.
    //	// Let's say there are 4 rooms across ALL projects. Their IDs are 1, 2, 4, 5. What this section does is finds the lowest room ID number that isn't taken.
    //	// This this example, it would find the number 3.

    //	int newRoomId = 0;

    //	List<Room> rooms = temp.FindAllRooms();

    //	List<int> roomIds = new List<int>();
    //	foreach(Room room in rooms)
    //	{
    //		roomIds.Add(room.roomId);
    //	} // Grabbing all roomIDs

    //	int highestId = 0;
    //	for (int i = 0; i <= roomIds.Count; i++)
    //	{
    //		if (i > highestId)
    //		{
    //			highestId = i;
    //		}
    //	} // Finding highest Id

    //	for (int i = 1; i <= highestId; i++)
    //	{
    //		if (!roomIds.Contains(i))
    //		{
    //			newRoomId = i;
    //		}
    //		else if (i == highestId)
    //		{
    //			newRoomId = i + 1;
    //		}
    //	} // Finding lowestin unused project ID
    //	#endregion

    //	Room tempRoom = new Room(newRoomId, temp.currProjId, _newRoom.roomNameField.text);

    //	temp.FindFloorByID(temp.currProjId, temp.currFloorId).rooms.Add(tempRoom);

    //	//upload to server here

    //	AppManager.appManager.currRoomId = tempRoom.roomId;
    //	SceneManagement.sceneManagement.LoadScene("BubbleEditor");
    //}

    //public int NewBubble()
    //{
    //	AppManager temp = AppManager.appManager;

    //	#region determing new bubbleID
    //	// What's happening here is I'm finding all of the total bubble IDs.
    //	// Let's say there are 4 rooms across ALL projects. Their IDs are 1, 2, 4, 5. What this section does is finds the lowest room ID number that isn't taken.
    //	// For this example, it would find the number 3.

    //	int newBubbleId = 0;

    //	Room currRoom = temp.FindRoomByID(temp.currProjId, temp.currFloorId, temp.currRoomId);
    //	List<Bubble> currBubbles = currRoom.bubbles;

    //	List<int> bubbleIds = new List<int>();
    //	foreach (Bubble bubble in currBubbles)
    //	{
    //		bubbleIds.Add(bubble.bubbleId);
    //	} // Grabbing all bubbleIDs

    //	int highestId = 0;
    //	for (int i = 0; i <= bubbleIds.Count; i++)
    //	{
    //		if (i > highestId)
    //		{
    //			highestId = i;
    //		}
    //	} // Finding highest Id

    //	for (int i = 1; i <= highestId; i++)
    //	{
    //		if (!bubbleIds.Contains(i))
    //		{
    //			newBubbleId = i;
    //		}
    //		else if (i == highestId)
    //		{
    //			newBubbleId = i + 1;
    //		}
    //	} // Finding lowestin unused project ID
    //	#endregion

    //	Bubble newBub = new Bubble(newBubbleId, temp.currRoomId);
    //	currRoom.bubbles.Add(newBub);

    //	//Upload to server here

    //	return newBub.bubbleId;
    //}
}
