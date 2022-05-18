using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinCondition : MonoBehaviour
{
	public float ActiveDistance = 5.0f;
	public string playerTag = "Player";
	public string Wincondition = "WinCon"; 
	public GameObject Player;
	private Camera Cam;
	private Collider WinCollider;
	private GameObject WinTerminal;

	// Start is called before the first frame update
	void Start()
    {
		WinCollider = GetComponent<CapsuleCollider>();
		Cam = Camera.main;
		WinTerminal = GameObject.FindGameObjectWithTag(Wincondition);
		Player = GameObject.Find("Terminal");
	}

    // Update is called once per frame
    void Update()
    {
		
		if (Input.GetKeyDown(KeyCode.E))
        {
			TryTerminal();
		}
		void TryTerminal()
        {
			if (Mathf.Abs(Vector3.Distance(transform.position, WinTerminal.transform.position)) <= ActiveDistance)
			{
				
				Ray ray = Cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
				RaycastHit hit;

				if (WinCollider.Raycast(ray, out hit, ActiveDistance))
				{

					EventManager.Instance.Notify(EventTypes.Events.GAME_VICTORY);
					//Debug.LogWarning(transform.position - Player.transform.position);

				}
				Debug.LogWarning((transform.position - Player.transform.position).magnitude);
			}

		}

	}
}
