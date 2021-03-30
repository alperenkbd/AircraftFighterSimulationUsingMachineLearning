using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class FlyAgent : Agent
{
    private float PlaneSpeed = 90.0f;
    private Vector3 EpisodeBeginVector;


    private void Start()
    {
        EpisodeBeginVector = new Vector3(0, 850, 0);
    }


    public override void OnEpisodeBegin()
    {
        transform.position = EpisodeBeginVector;
    }


    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(transform.rotation);
    }


    public override void OnActionReceived(ActionBuffers actions)
    {
        float RotateX = actions.ContinuousActions[0];
        float RotateZ = actions.ContinuousActions[1];

        transform.position -= transform.forward * Time.deltaTime * PlaneSpeed;

        transform.Rotate(RotateX, 0f, RotateZ);

        SetReward(1f);
    }


    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> ContinuousActions = actionsOut.ContinuousActions;
        ContinuousActions[0] = Input.GetAxis("Vertical");
        ContinuousActions[1] = Input.GetAxis("Horizontal");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Terrain" || other.tag == "wall") {
            SetReward(-1f);
            EndEpisode();
        }
        
    }

}
