using UnityEngine;

public class PickupRawEnergy : GoapAction
{
    bool completed = false;
    float startTime = 0;
    public float workDuration = 2; // seconds
    public Inventory windmill;

    public PickupRawEnergy()
    {
        AddPrecondition("hasStock", true);
        AddPrecondition("hasRawEnergy", false);
        AddEffect("hasRawEnergy", true);
        actionName = "PickupRawEnergy";
    }

    public override void Reset()
    {
        completed = false;
        startTime = 0;
    }

    public override bool IsDone()
    {
        return completed;
    }

    public override bool RequiresInRange()
    {
        return true;
    }

    public override bool CheckProceduralPrecondition(GameObject agent)
    {
        return true;
    }

    public override bool Perform(GameObject agent)
    {
        if (startTime == 0)
        {
            //Debug.Log("Starting: " + actionName);
            //startTime = Time.time;
        }

        if (Time.time - startTime > workDuration)
        {
            //Debug.Log("Finished: " + actionName);
            GetComponent<Inventory>().rawEnergy += 5;
            windmill.rawEnergy -= 5;
            completed = true;
        }
        return true;
    }

}
