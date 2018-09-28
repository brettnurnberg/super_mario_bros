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
int x_offset = 0;
int y_offset = 0;
SpriteEffects flip_state = SpriteEffects.None;

switch( status )
    {
    case mario_status_enum.STILL:
        sprite = Marios.textures[(int)mario_enum.STILL];
        break;
    case mario_status_enum.WALK:
        sprite = Animations.mario_run.get_sprite();
        break;
    case mario_status_enum.RUN:
        sprite = Animations.mario_run.get_sprite();
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

if( sprite == Marios.textures[(int)mario_enum.WALK2] )
    {
    y_offset++;
    }
else if( sprite == Marios.textures[(int)mario_enum.JUMP] )
    {
    x_offset -= 3;
    }

float x = (float)physics.position.x * ViewDims.scale / (float)( 1 << 12 );
float y = (float)physics.position.y * ViewDims.scale / (float)( 1 << 12 );

if( ( physics.position.x & 0x0FFF ) == 0 )
    {
    x++;
    }
y++;

x += ( x_offset * ViewDims.scale );
y += ( y_offset * ViewDims.scale );

if( KeyBinding.D_LEFT_pressed )
    {
    flip_state = SpriteEffects.FlipHorizontally;
    }

Vector2 p = new Vector2( (int)( x ), (int)( y ) );
s.Draw( sprite, p , null, Color.White, 0, new Vector2( 0, 0 ), ViewDims.scale, flip_state, 0 );
} /* draw() */


}
}
