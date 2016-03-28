using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityStandardAssets._2D;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class GameState : MonoBehaviour
	{

		public static GameState instance = null;

		private string nextSpawnPoint = "newGameSpawnPoint";
		//public CharacterMovementUserControl playerPrefab;
		public Dictionary<string, int> gameVars = new Dictionary<string, int> ();

		void Awake() {
			if (instance == null) {
				instance = this;
				Setup ();
			} else if (instance != this) {
				Destroy (gameObject);
				instance.Awake ();
				return;
			}
			instance.OnLevelWasLoaded();
		}

		void Setup() {
			DontDestroyOnLoad (this);

			Physics.IgnoreLayerCollision (9, 9);
		}

		void OnLevelWasLoaded() {
			SpawnPlayer(nextSpawnPoint);
		}

		public void EnterDoorway(string nextScene, string spawnPoint) {
			nextSpawnPoint = spawnPoint;
			SceneManager.LoadScene (nextScene);
		}

		public void SetGameVar (string key, string val)
		{
			if (val == null || val == "0" || val == "") {
				if (gameVars.ContainsKey (key))
					gameVars.Remove (key);
			} else {
				gameVars.Add (key, int.Parse (val));
			}
		}

		public void SetGameVar (string key, int val)
		{
			if (val == 0) {
				if (gameVars.ContainsKey (key))
					gameVars.Remove (key);
			} else {
				gameVars.Add (key, val);
			}
		}


		void SpawnPlayer (string nextSpawnPoint)
		{
			//CharacterMovementUserControl player = Instantiate<CharacterMovementUserControl>(playerPrefab);
			//playerPrefab.transform.position = GameObject.Find (nextSpawnPoint).transform.position;
		}

		static System.Random random = new System.Random();
		public static int Random (int max)
		{
			return random.Next (max);
		}
	}
}

