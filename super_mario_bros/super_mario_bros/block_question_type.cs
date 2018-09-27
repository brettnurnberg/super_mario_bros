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

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/


/***********************************************************
*
*   Method:
*       draw
*
*   Description:
*       Draws the given block.
*
***********************************************************/

public override void draw( SpriteBatch s, int x, int y, int count )
{
Texture2D texture;
int idx = ( count % 42 ) / 7;

switch( idx )
    {
    case 0:
    case 1:
    case 2:
        texture = Blocks.textures[(int)block_enum.QUESTION_LIT];
        break;
    case 3:
    case 5:
        texture = Blocks.textures[(int)block_enum.QUESTION_MID];
        break;
    case 4:
        texture = Blocks.textures[(int)block_enum.QUESTION_DARK];
        break;
    default:
        texture = Blocks.textures[(int)block_enum.QUESTION_LIT];
        break;
    }

Vector2 position = new Vector2( x * Blocks.size.Width * ViewDims.scale, y * Blocks.size.Height * ViewDims.scale );
s.Draw( texture, position , null, Color.White, 0, new Vector2( 0, 0 ), ViewDims.scale, SpriteEffects.None, 0 );
}


}
}
