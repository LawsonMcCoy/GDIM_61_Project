using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : GenericHealth
{
    // Start is called before the first frame update
    protected override void Start()
    {
        slider = HUD.Instance.getSlider();
        base.Start();
        
    }

    override protected void onDeath()
    {
        EventManager.Instance.Notify(EventTypes.Events.PLAYER_DEATH);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
