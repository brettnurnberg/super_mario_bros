/*********************************************************************
*
*   Class:
*       physics_type
*
*   Description:
*       Contains the game data
*
*********************************************************************/

/*--------------------------------------------------------------------
                            INCLUDES
--------------------------------------------------------------------*/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

/*--------------------------------------------------------------------
                           NAMESPACE
--------------------------------------------------------------------*/

namespace super_mario_bros {

/*--------------------------------------------------------------------
                           DELEGATES
--------------------------------------------------------------------*/

/*--------------------------------------------------------------------
                             CLASS
--------------------------------------------------------------------*/

public  class physics_type {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

public  int_vector2_type    position;
public  int_vector2_type    init_position;
public  int_vector2_type    velocity;
public  int_vector2_type    init_velocity;
public  int_vector2_type    acceleration;
public  Rectangle           hit_box;

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/


/***********************************************************
*
*   Method:
*       physics_type
*
*   Description:
*       Constructor.
*
***********************************************************/

public physics_type()
{
init_position = new int_vector2_type( 0, 0 );
init_velocity = new int_vector2_type( 0, 0 );
position      = new int_vector2_type( 0, 0 );
velocity      = new int_vector2_type( 0, 0 );
acceleration  = new int_vector2_type( 0, 0 );
} /* physics_type() */

}
}
