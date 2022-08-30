using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalBird : MonoBehaviour
{
	//serialize
	[SerializeField] float _launchForce = 500;
	[SerializeField] float _maxDragDistance = 3;
	// gloabls
	Vector2 _startPosition;
	Rigidbody2D _rgdbdy;
	
	
	void Awake()
	{
		_rgdbdy = GetComponent<Rigidbody2D>();
	}
    // Start is called before the first frame update
    
    void Start()
    {
    	
    	_startPosition =_rgdbdy.position;
    	_rgdbdy.isKinematic  = true ;
    }
    void OnMouseDown()
    {
    	GetComponent<SpriteRenderer>().color =Color.red;
    	
    }
    void OnMouseUp()
    {
    	Vector2 currentPosition =_rgdbdy.position;
    	Vector2 direction = _startPosition - currentPosition;
    	direction.Normalize();
    	_rgdbdy.isKinematic  = false ;
    	_rgdbdy.AddForce(direction * _launchForce);
    	GetComponent<SpriteRenderer>().color =Color.white;
    	
    }
    void OnMouseDrag()
    {
    	Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    	
    	Vector2 desiredPosition = mousePosition;

    	
    	
    	float distance = Vector2.Distance(desiredPosition , _startPosition);
    	if(distance > _maxDragDistance)
    	{
    		Vector2 direction = desiredPosition - _startPosition ;
    		direction.Normalize();
    		desiredPosition = _startPosition + (direction * _maxDragDistance);
    	}
    	if (desiredPosition.x > _startPosition.x)
    		desiredPosition.x = _startPosition.x;
    	
    	
    	//transform.position = new Vector3(mousePosition.x,mousePosition.y,transform.position.z);
    	_rgdbdy.position = desiredPosition;
    	
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
    	StartCoroutine(ResetAfterDely());

    	
    }
    IEnumerator ResetAfterDely()
    {
    	yield return new WaitForSeconds(3);
    	_rgdbdy.position = _startPosition ;
    	_rgdbdy.isKinematic  = true ;
    	_rgdbdy.velocity = Vector2.zero;
    }
}
