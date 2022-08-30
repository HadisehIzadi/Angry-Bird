using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{
	[SerializeField] string _nextLevelName;
	mnstr[] _monsters;

    // Start is called before the first frame update
    void OnEnable()
    {
    	_monsters = FindObjectsOfType<mnstr>();
    }

    // Update is called once per frame
    void Update()
    {
    	if(MonstersAreAllDead())
    		GoToNextLevel();   
    }
    
    void GoToNextLevel()
    {
    	Debug.Log("Go To Level"+_nextLevelName);
    	SceneManager.LoadScene(_nextLevelName);
    }
    
    bool MonstersAreAllDead()
    {
    	foreach(var monster in _monsters)
    	{
    		if(monster.gameObject.activeSelf)
    			return false;
    	}
    	return true;
    }
    
}
