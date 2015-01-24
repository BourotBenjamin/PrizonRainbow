using UnityEngine;
using System.Collections;

public class Zombihavior : MonoBehaviour {

	private GameObject[] _Joueurs;
	public float _hearRange = 10;
	public float _viewRange = 20;
	public float _viewAngle = 60;
	public float _speed = 3;
	private Vector3 _target;
	private float _baseViewRange;
	public AudioClip[] _ZSounds;

	// Use this for initialization
	void Start () 
	{
		_baseViewRange = _viewRange;
		_Joueurs = GameObject.FindGameObjectsWithTag("player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		_target = SearchPlayer();
		if(_target != Vector3.zero)
		{
			WatchPlayer(_target);
			//transform.position = Vector3.MoveTowards(transform.position, _target, _speed*Time.deltaTime);
			//transform.position -= new Vector3(0,0,transform.position.z+0.5f);
			_target.z = transform.position.z;
			rigidbody.velocity = ((_target-transform.position).normalized*_speed);
		}
		if(Vector3.Distance(transform.position, _target) < 0.1f)
		{
			_target = Vector3.zero;
		}

	}

	Vector3 SearchPlayer()
	{
		_viewRange = _baseViewRange;
		foreach(GameObject go in _Joueurs)
		{
			if(go.activeSelf)
			{
				if(go.GetComponent<Controller>().lightIsOn || go.GetComponent<ManetteController>().lightIsOn)
				{
					_viewRange=20;
				}

				if(Vector3.Distance(transform.position, go.transform.position) < _viewRange)
				{
					if(Vector3.Angle(transform.right, (go.transform.position - transform.position)) < _viewAngle)
					{
						if(Physics.Raycast(transform.position, go.transform.position - transform.position, Vector3.Distance(transform.position, go.transform.position), 1<<9))
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
		}
		return _target;
	}


	void WatchPlayer(Vector3 _playerPosition)
	{ 
		float AngleRad = Mathf.Atan2(_playerPosition.y - transform.position.y, _playerPosition.x - transform.position.x); 
		float AngleDeg = (180 / Mathf.PI) * AngleRad; 
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, AngleDeg), Time.deltaTime*10);
	}

	void OnCollisionEnter(Collision other)
	{
		Debug.Log("collision : " + other.gameObject.name);
		if(other.gameObject.tag == "player")
		{
			other.gameObject.SetActive(false);
			_target = Vector3.zero;
		}
	}

}
