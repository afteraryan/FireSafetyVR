using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AiState
{
    //Tell player about different gears
    tellHelment,
    tellGloves,
    tellBoots,
    tellSuit,
    tellCylinder,
    tellMask,

    tellMotionControls,//Explain Controllers
    tellCompleteGear,//If player tries to move out of the room without completing gear
    
    idle,//AI waiting for player to enter room
    approachplayer,//AI walks upto player like welcoming
    
    tellCompleteGearupModule//Inform player that they have completed Gearing up module
}
