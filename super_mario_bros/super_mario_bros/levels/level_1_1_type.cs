/*********************************************************************
*
*   Class:
*       level_1_1_type
*
*   Description:
*       Contains the data for world 1-1
*
*********************************************************************/

/*--------------------------------------------------------------------
                            INCLUDES
--------------------------------------------------------------------*/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

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

public class level_1_1_type : level_type {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/

/***********************************************************
*
*   Method:
*       level_1_1_type
*
*   Description:
*       Constructor.
*
***********************************************************/

public level_1_1_type()
{
int x_init = ( 3 * Blocks.size.Width ) << 12;
int y_init = ( ( 11 * Blocks.size.Height - mario.physics.hit_box.Height ) + 1 ) << 12;

map = new map_1_1_type();

mario.physics.init_position = new int_vector2_type( x_init, y_init );
mario.physics.position.x = mario.physics.init_position.x;
mario.physics.position.y = mario.physics.init_position.y;

} /* level_1_1_type() */


/***********************************************************
*
*   Method:
*       draw
*
*   Description:
*       Draw the level.
*
***********************************************************/

public override void draw( SpriteBatch s )
{
map.draw( s );
mario.draw( s );
foreach( character_type enemy in enemies )
    {
    enemy.draw( s );
    }


} /* draw() */


}
}
