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


/***********************************************************
*
*   Method:
*       load_content
*
*   Description:
*       Loads content for the given character.
*
***********************************************************/

public override void load_content( ContentManager c )
{
sprite = c.Load<Texture2D>( "mario_0" );
} /* load_content() */


}
}
