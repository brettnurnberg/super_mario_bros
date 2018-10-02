/*********************************************************************
*
*   Class:
*       view_type
*
*   Description:
*       Contains the view data and logic
*       All positions are in pixels. The scale is only applied when
*       drawing.
*
*********************************************************************/

/*--------------------------------------------------------------------
                            INCLUDES
--------------------------------------------------------------------*/

using Microsoft.Xna.Framework;
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

public class view_type {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

private model_type              model;
private Game                    game;

private GraphicsDeviceManager   graphics;
private SpriteBatch             spriteBatch;

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/

/***********************************************************
*
*   Method:
*       view_type
*
*   Description:
*       Constructor.
*
***********************************************************/

public view_type( model_type m )
{
model = m;

} /* view_type() */


/***********************************************************
*
*   Method:
*       draw
*
*   Description:
*       Draws the game.
*
***********************************************************/

public void draw()
{
game.GraphicsDevice.Clear( model.level.map.get_back_color( model.level.mario.physics.position.x >> 16 ) );

ViewDims.set_view_location( model );

spriteBatch.Begin( SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, Matrix.CreateTranslation( ViewDims.view_scaled.X, ViewDims.view_scaled.Y, 0 ) );
model.level.draw( spriteBatch );
spriteBatch.End();

DrawShape.Rectangle( ViewDims.left_edge,  Color.Black );
DrawShape.Rectangle( ViewDims.right_edge, Color.Black );

} /* draw() */


/***********************************************************
*
*   Method:
*       construct
*
*   Description:
*       Initialize the game.
*
***********************************************************/

public void construct( Game g )
{
game = g;

graphics = new GraphicsDeviceManager( game );
game.Content.RootDirectory = "Content";

game.Window.AllowUserResizing = true;
game.Window.ClientSizeChanged += resize_window;

ViewDims.set_window_size( new Rectangle( 0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height ) );

} /* construct() */


/***********************************************************
*
*   Method:
*       load_content
*
*   Description:
*       Loads content for the game.
*
***********************************************************/

public void load_content()
{
spriteBatch = new SpriteBatch( game.GraphicsDevice );
DrawShape.Initialize( spriteBatch );
DrawShape.LoadTextures( game.Content );

Blocks.load_content( game.Content );
Decor.load_content( game.Content );
Marios.load_content( game.Content );

} /* load_content() */


/***********************************************************
*
*   Method:
*       unload_content
*
*   Description:
*       Unloads content for the game.
*
***********************************************************/

public void unload_content()
{
game.Content.Unload();
} /* unload_content() */


/***********************************************************
*
*   Method:
*       resize_window
*
*   Description:
*       Resets the scale for the game.
*
***********************************************************/

public void resize_window( object sender, EventArgs e )
{
graphics.PreferredBackBufferWidth  = game.Window.ClientBounds.Width;
graphics.PreferredBackBufferHeight = game.Window.ClientBounds.Height;

ViewDims.set_window_size( new Rectangle( 0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height ) );

} /* resize_window() */


}
}
