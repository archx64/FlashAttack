using UnityEngine;

public class DeliverRawEnergy : GoapAction
{
    bool completed = false;
    float startTime = 0;
    public float workDuration = 2; // seconds
    public Inventory inv;

    public DeliverRawEnergy()
    {
        AddPrecondition("hasRaw", true);
        AddEffect("doJob", true);
        actionName = "Harvest";
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
            startTime = Time.time;
        }

        if (Time.time - startTime > workDuration)
        {
            //Debug.Log("Finished: " + actionName);
            inv.rawEnergy += 3;
            completed = true;
        }
        return true;
    }

}
