using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNote : MonoBehaviour
{
    [SerializeField] float tempo;
    // Start is called before the first frame update
    void Start()
    {
        tempo = tempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -1 * new Vector3(tempo * Time.deltaTime, 0, 0);
    }
}
