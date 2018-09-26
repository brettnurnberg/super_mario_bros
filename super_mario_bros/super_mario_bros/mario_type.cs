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


private const int run_frame_rate  = 5;
private const int walk_frame_rate = 10;

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

public  mario_status_enum status;
private int run_frame_cnt;
private int walk_frame_cnt;

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
physics.hit_box.Width = 12;
physics.hit_box.Height = 16;
run_frame_cnt = 0;
walk_frame_cnt = 0;
status = mario_status_enum.STILL;
ground_status = char_status_enum.GROUND;
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
Texture2D sprite;
int idx;

switch( status )
    {
    case mario_status_enum.STILL:
        sprite = Marios.textures[(int)mario_enum.STILL];
        break;
    case mario_status_enum.WALK:
        idx = walk_frame_cnt / walk_frame_rate;
        idx = idx % 3;
        walk_frame_cnt++;
        sprite = Marios.textures[(int)mario_enum.WALK0 + idx];
        break;
    case mario_status_enum.RUN:
        idx = run_frame_cnt / run_frame_rate;
        idx = idx % 3;
        run_frame_cnt++;
        sprite = Marios.textures[(int)mario_enum.WALK0 + idx];
        break;
    case mario_status_enum.JUMP:
        sprite = Marios.textures[(int)mario_enum.JUMP];
        break;
    case mario_status_enum.SKID:
        sprite = Marios.textures[(int)mario_enum.SKID];
        break;
    default:
        sprite = Marios.textures[(int)mario_enum.STILL];
        break;
    }

float x = (float)physics.position.x * ViewDims.scale / (float)( 1 << 12 );
float y = (float)physics.position.y * ViewDims.scale / (float)( 1 << 12 );

if( ( physics.position.x & 0x0FFF ) == 0 )
    {
    x++;
    }
y++;

Vector2 p = new Vector2( (int)( x ), (int)( y ) );
s.Draw( sprite, p , null, Color.White, 0, new Vector2( 0, 0 ), ViewDims.scale, SpriteEffects.None, 0 );
} /* draw() */


}
}
