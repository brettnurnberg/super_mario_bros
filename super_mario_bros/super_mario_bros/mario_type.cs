/*********************************************************************
*
*   Class:
*       mario_type
*
*   Description:
*       Contains data for Mario
*
*       Need a way to load all the sprites for the characters
*
*********************************************************************/

/*--------------------------------------------------------------------
                            INCLUDES
--------------------------------------------------------------------*/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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

public class mario_type : character_type {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

public  mario_status_enum status;
public  int sprite_id;
public  float layer;

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/

/***********************************************************
*
*   Method:
*       mario_type
*
*   Description:
*       Constructor.
*
***********************************************************/

public mario_type()
{
physics = new physics_type();
physics.hit_box.Width = 10;
physics.hit_box.Height = 12;
sprite_id = 0;
status = mario_status_enum.STILL_R;
ground_status = char_status_enum.GROUND;
layer = (float)layer_enum.MARIO / (float)layer_enum.COUNT;
} /* mario_type() */


/***********************************************************
*
*   Method:
*       draw
*
*   Description:
*       Draws the given character.
*
***********************************************************/

public override void draw( SpriteBatch s )
{
Texture2D sprite = null;

/*----------------------------------------------------------
Get Mario's sprite
----------------------------------------------------------*/
if( ( status == mario_status_enum.WALK_L ) ||
    ( status == mario_status_enum.WALK_R ) ||
    ( status == mario_status_enum.WALK_CTRL_R ) ||
    ( status == mario_status_enum.WALK_CTRL_L ) )
    {
    sprite_id = Animations.mario_walk.get_sprite();
    }
else if( ( status == mario_status_enum.RUN_L ) ||
         ( status == mario_status_enum.RUN_R ) )
    {
    sprite_id = Animations.mario_run.get_sprite();
    }
else if( status == mario_status_enum.POLE_R )
    {
    sprite_id = Animations.get_mario_pole_sprite();
    }
else if( status == mario_status_enum.POLE_BOTTOM_R )
    {
    sprite_id = (int)mario_enum.POLE_0_R;
    }
else if( status == mario_status_enum.POLE_L )
    {
    sprite_id = (int)mario_enum.POLE_0_L;
    }
else if( ( status != mario_status_enum.FALL_R ) &&
         ( status != mario_status_enum.FALL_L ) )
    {
    sprite_id = (int)status;
    }

/*----------------------------------------------------------
Animated sprites are all to the right. If we are facing
left, flip the sprite.
----------------------------------------------------------*/
if( ( status == mario_status_enum.WALK_L ) ||
    ( status == mario_status_enum.WALK_CTRL_L ) ||
    ( status == mario_status_enum.RUN_L  ) )
    {
    sprite_id += ( (int)mario_enum.WALK0_L - (int)mario_enum.WALK0_R );
    }

sprite = Marios.textures[sprite_id];

/*----------------------------------------------------------
Get Mario's position
----------------------------------------------------------*/
float x = (float)physics.position.x * ViewDims.scale.X / (float)( 1 << 12 );
float y = (float)physics.position.y * ViewDims.scale.Y / (float)( 1 << 12 );

/*----------------------------------------------------------
Take care of single pixel rounding
----------------------------------------------------------*/
if( ( physics.position.x & 0x0FFF ) == 0 )
    {
    x++;
    }
y++;

/*----------------------------------------------------------
Move the sprite to center Mario's head in the hitbox
----------------------------------------------------------*/
if( facing_right() )
    {
    x -= ( 4 * ViewDims.scale.X );
    }
else
    {
    x -= ( 2 * ViewDims.scale.X );
    }
y -= ( 4 * ViewDims.scale.Y );

/*----------------------------------------------------------
Draw mario
----------------------------------------------------------*/
Vector2 p = new Vector2( (int)( x ), (int)( y ) );
s.Draw( sprite, p , null, Color.White, 0, new Vector2( 0, 0 ), ViewDims.scale, SpriteEffects.None, layer );
} /* draw() */

/***********************************************************
*
*   Method:
*       facing_right
*
*   Description:
*       Returns true if mario is facing right.
*
***********************************************************/

public Boolean facing_right()
{
Boolean result = false;

if( status <= mario_status_enum.SKID_R || status == mario_status_enum.FALL_R || status == mario_status_enum.POLE_R || status == mario_status_enum.WALK_CTRL_R || status == mario_status_enum.POLE_BOTTOM_R )
    {
    result = true;
    }

return result;
} /* facing_right() */


}
}
