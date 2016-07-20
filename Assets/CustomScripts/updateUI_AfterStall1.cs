﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Vuforia
{

	public class updateUI_AfterStall1 : MonoBehaviour,
	ITrackableEventHandler
	{

		private TrackableBehaviour mTrackableBehaviour;

		private bool targetHasBeenFound = false;
		private bool showCornerImage = false;
		private bool timeElapsed = false;
		string currentTargetTracked;


		public Texture testImage;
		public Texture stall1;
		public Texture stall2;
		public Texture stall3;
		public Texture stall4;
		public Texture stall5;
		public Texture stall6;
		GUIContent content;



		void Start () {
					GameObject ImageTarget = GameObject.Find("ImageTarget");
					updateCameraUI_Initial previousScript = ImageTarget.GetComponent<updateCameraUI_Initial>();

			if (previousScript.timeLeft <= 0) {
				timeElapsed = true;
				content = new GUIContent(stall2);
				
							}

			mTrackableBehaviour = GetComponent<TrackableBehaviour>();
			if (mTrackableBehaviour)
			{
				mTrackableBehaviour.RegisterTrackableEventHandler(this);
			}
		}

		public void OnTrackableStateChanged(
			TrackableBehaviour.Status previousStatus,
			TrackableBehaviour.Status newStatus)

		{

			if (newStatus == TrackableBehaviour.Status.DETECTED ||
				newStatus == TrackableBehaviour.Status.TRACKED)
			{


				currentTargetTracked = mTrackableBehaviour.TrackableName;

				switch (currentTargetTracked) {
				case "chips":
					content = new GUIContent (stall1);
					break;
				case "stall1":
					content = new GUIContent (stall2);
					break;
				case "stall2":
					content = new GUIContent (stall3);
					break;
				case "stall3":
					content = new GUIContent (stall4);
					break;
				case "stall4":
					content = new GUIContent (stall5);
					break;
				case "stall5":
					content = new GUIContent (stall6);
					break;
				case "stall6":
					content = new GUIContent (testImage);
					break;
				default:
					content = new GUIContent (testImage);
					break;
				}
				targetHasBeenFound = true;	
				showCornerImage = false;



			}
			else
			{
				showCornerImage = true;
			}
		}

		void OnGUI() {
			if (showCornerImage && !targetHasBeenFound && timeElapsed) {
				GUI.Box (new Rect (0, 0, 100, 100), content);

			}
		}


	

	}

}


