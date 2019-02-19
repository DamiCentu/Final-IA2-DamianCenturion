﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButtonCannon : PerformSomethingButtonAbstract
{
    bool _oneItemAtLeastCreated;

    void Start()
    {
        EventsManager.SubscribeToEvent(EventsConstants.ITEM_CREATED, OnItemCreated);
    }

    private void OnItemCreated(object[] parameterContainer)
    {
        if ((ItemType)parameterContainer[0] == ItemType.Cannon)
            _oneItemAtLeastCreated = true;
    }

    public void PerformUpgrade()
    {
        if (_oneItemAtLeastCreated)
            TriggerCreate(EventsConstants.PLAYER_REQUEST_UPGRADE, ItemType.Cannon);
    }
}
