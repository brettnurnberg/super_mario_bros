/*********************************************************************
*
*   Class:
*       level_type
*
*   Description:
*       Contains the data for a single level
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

public class level_type {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

public  mario_type              mario;
public  map_type                map;
public  List<character_type>    enemies;
public  int                     time_initial;
public  int                     time_current;

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/

/***********************************************************
*
*   Method:
*       level_type
*
*   Description:
*       Constructor.
*
***********************************************************/

public level_type()
{
enemies = new List<character_type>();
mario = new mario_type();
map = new map_type();

mario.position_initial = new Vector2( 3 * Blocks.size.Width, ( 10 * Blocks.size.Height ) + 1 );
mario.physics.position = mario.position_initial;

} /* level_type() */

//temp
public void temp_load( ContentManager c )
{
mario.load_content( c ); //temp

} /* level_type() */

/***********************************************************
*
*   Method:
*       draw
*
*   Description:
*       Draw the level.
*
***********************************************************/

public void draw( SpriteBatch s )
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
