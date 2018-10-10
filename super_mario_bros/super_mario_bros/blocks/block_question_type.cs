/*********************************************************************
*
*   Class:
*       block_question_type
*
*   Description:
*       Contains data for question block
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

public class block_question_type: block_type {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

private Boolean hit;
private int     hit_frame_start;

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/


/***********************************************************
*
*   Method:
*       block_question_type
*
*   Description:
*       Constructor.
*
***********************************************************/

public block_question_type()
{
hit = false;
}


/***********************************************************
*
*   Method:
*       draw
*
*   Description:
*       Draws the given block.
*
***********************************************************/

public override void draw( SpriteBatch s, int x, int y )
{
Texture2D texture;
int y_offset = 0;

if( hit )
    {
    y_offset = Animations.get_block_offset( hit_frame_start );

    texture = Blocks.textures[(int)block_enum.BLOCK_HIT];
    }
else
    {
    texture = Blocks.textures[Animations.block_question.get_sprite()];
    }

Vector2 position = new Vector2( x * Blocks.size.Width * ViewDims.scale.X, ( y * Blocks.size.Height - y_offset ) * ViewDims.scale.Y );
s.Draw( texture, position , null, Color.White, 0, new Vector2( 0, 0 ), ViewDims.scale, SpriteEffects.None, 0 );
}


/***********************************************************
*
*   Method:
*       hit_bottom
*
*   Description:
*       Behavior on hitting the bottom of the block.
*       Returns true if the block is immobile.
*
***********************************************************/

public override Boolean hit_bottom()
{
Boolean immobile = true;

if( !hit )
    {
    hit_frame_start = Animations.frame_count;
    immobile = false;
    hit = true;
    }

return immobile;
}


/***********************************************************
*
*   Method:
*       hit_side
*
*   Description:
*       Behavior on hitting the side of the block.
*
***********************************************************/

public override void hit_side()
{

}


}
}
