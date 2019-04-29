using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatDown : MonoBehaviour {

	void Update () {
        transform.Translate(Vector2.down * 5f * Time.deltaTime);
	}
}
