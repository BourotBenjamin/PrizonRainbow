using UnityEngine;
using System.Collections;

public class Zombihavior : MonoBehaviour {

	private GameObject[] _Joueurs;
	public float _hearRange = 10;
	public float _viewRange = 20;
	public float _viewAngle = 60;
	public float _speed = 3;
	private Vector3 _target;

	// Use this for initialization
	void Start () 
	{
		_Joueurs = GameObject.FindGameObjectsWithTag("Joueur");
	}
	
	// Update is called once per frame
	void Update () 
	{
		_target = SearchPlayer();
		if(_target != Vector3.zero)
		{
			WatchPlayer(_target);
			transform.position = Vector3.MoveTowards(transform.position, _target, _speed*Time.deltaTime);
		}
		if(Vector3.Distance(transform.position, _target) < 0.1f)
		{
			_target = Vector3.zero;
		}

	}

	Vector3 SearchPlayer()
	{
		foreach(GameObject go in _Joueurs)
		{
			if(Vector3.Distance(transform.position, go.transform.position) < _viewRange)
			{
				if(Vector3.Angle(transform.forward, (transform.position-go.transform.position)) < _viewAngle)
				{
					if(Physics.Raycast(transform.position, transform.position-go.transform.position, Vector3.Distance(transform.position, go.transform.position)))
					{
						//Obstacle dans le champs de vision
					}
					else
					{
						return go.transform.position;
					}
				}
			}
			
			
			if(Vector3.Distance(transform.position, go.transform.position) < _hearRange)
			{
				return go.transform.position;

			}
		}
		return Vector3.zero;
	}


	void WatchPlayer(Vector3 _playerPosition)
	{ 
		float AngleRad = Mathf.Atan2(_playerPosition.y - transform.position.y, _playerPosition.x - transform.position.x); 
		float AngleDeg = (180 / Mathf.PI) * AngleRad; 
		transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
	}

}
