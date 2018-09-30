/*********************************************************************
*
*   Class:
*       block_pipe_type
*
*   Description:
*       Contains data for pipe block
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

public class block_pipe_type: block_type {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

private pipe_type pipe;
private int texture_id;

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/


/***********************************************************
*
*   Method:
*       block_pipe_type
*
*   Description:
*       Constructor.
*
***********************************************************/

public block_pipe_type( pipe_type p, int t_id )
{
pipe = p;
texture_id = t_id;
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
Texture2D texture = Blocks.textures[texture_id];

Vector2 position = new Vector2( x * Blocks.size.Width * ViewDims.scale, y * Blocks.size.Height * ViewDims.scale );
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
return true;
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
