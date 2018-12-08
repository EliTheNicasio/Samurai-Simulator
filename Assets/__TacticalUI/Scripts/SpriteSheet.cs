using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSheet : MonoBehaviour 
{

	public int uvY = 5;
	public int uvX = 5;

	public int fps = 4;
	private int index;

	void Update () 
	{

		index = (int)(Time.time*fps);
		index = index % (uvY * uvX);
		Vector2 size = new Vector2(1.0f/uvY, 1.0f/uvX);

		var uIndex = index % uvX;
		var vIndex = index / uvX;

		Vector2 offset = new Vector2(uIndex * size.x, 1.0f - size.y - vIndex * size.y);

		GetComponent<Renderer>().material.SetTextureOffset ("_MainTex", offset);
		GetComponent<Renderer>().material.SetTextureScale("_MainTex", size);
		
	}
}
