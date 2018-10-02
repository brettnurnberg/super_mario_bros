/*********************************************************************
*
*   Class:
*       block_brick_blue_type
*
*   Description:
*       Contains data for brick block
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

public class block_brick_blue_type: block_type {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

private int hit_frame_start;

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/


/***********************************************************
*
*   Method:
*       block_brick_blue_type
*
*   Description:
*       Constructor.
*
***********************************************************/

public block_brick_blue_type()
{
hit_frame_start= 0;
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
int y_offset;
Texture2D texture = Blocks.textures[(int)block_enum.BRICK_BLUE];

y_offset = Animations.get_block_offset( hit_frame_start );

Vector2 position = new Vector2( x * Blocks.size.Width * ViewDims.scale, ( y * Blocks.size.Height - y_offset ) * ViewDims.scale );
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
hit_frame_start = Animations.frame_count;

return false;
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
