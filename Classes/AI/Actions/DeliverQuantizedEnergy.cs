using UnityEngine;

public class DeliverQuantizedEnergy : GoapAction
{
    bool completed = false;
    float startTime = 0;
    public float workDuration = 2; // seconds

    [SerializeField] Inventory spawnerInventory = null;

    public DeliverQuantizedEnergy()
    {
        AddPrecondition("hasDelivery", true);
        AddEffect("doJob", true);
        actionName = "DeliverQuantizedEnergy";
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
            spawnerInventory.quantizedEnergy += 5;
            GetComponent<Inventory>().quantizedEnergy -= 5;
            completed = true;
        }
        return true;
    }

}
