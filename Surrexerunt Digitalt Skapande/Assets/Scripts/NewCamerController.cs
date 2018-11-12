using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Quick temporary camera script
/// 
/// Written by: Simon Hansson SU16a
/// </summary>
public class NewCamerController : MonoBehaviour {

    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;

    [SerializeField] private float smoothAmount;

    void Update() {
        Vector3 targetPos = new Vector3 (player.position.x, 0) + offset;
        Vector3 smoothing = Vector3.Lerp(transform.position, targetPos, smoothAmount);

        transform.position = smoothing;
    }
}
