/*********************************************************************
*
*   Class:
*       decor_pole_type
*
*   Description:
*       Contains data for a pole
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

public class decor_pole_type: decor_type {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/


/***********************************************************
*
*   Method:
*       decor_pole_type
*
*   Description:
*       Constructor.
*
***********************************************************/

public decor_pole_type( int _x, int _y )
{
x = _x;
y = _y;
}


/***********************************************************
*
*   Method:
*       draw
*
*   Description:
*       Draws the given decoration.
*
***********************************************************/

public override void draw( SpriteBatch s )
{
Texture2D texture = Decor.textures[(int)decor_enum.FLAG_POLE];
Vector2 position = new Vector2( x * ViewDims.scale, y * ViewDims.scale );

s.Draw( texture, position, null, Color.White, 0, new Vector2( 0, 0 ), ViewDims.scale, SpriteEffects.None, 0 );
}


}
}
