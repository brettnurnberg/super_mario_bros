/*********************************************************************
*
*   Class:
*       Game1
*
*   Description:
*       The main class for the game. Contains methods to initialize
*       game, read input, update game logic, and update the view.
*
*********************************************************************/

/*--------------------------------------------------------------------
                            INCLUDES
--------------------------------------------------------------------*/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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

public class Game1 : Game {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

private model_type      model;
private controller_type ctlr;
private view_type       view;

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/


/***********************************************************
*
*   Method:
*       Draw
*
*   Description:
*       Draws the game.
*
***********************************************************/

protected override void Draw( GameTime gameTime )
{
/*----------------------------------------------------------
Draw the view
----------------------------------------------------------*/
view.draw();

base.Draw( gameTime );
} /* Draw */

/***********************************************************
*
*   Method:
*       Game1
*
*   Description:
*       Constructor.
*
***********************************************************/

public Game1( model_type m, controller_type c, view_type v )
{
model = m;
ctlr = c;
view = v;

view.construct( this );

} /* Game1 */


/***********************************************************
*
*   Method:
*       Initialize
*
*   Description:
*       Initializes items before game starts to run.
*
***********************************************************/

protected override void Initialize()
{
base.Initialize();
} /* Initialize */


/***********************************************************
*
*   Method:
*       LoadContent
*
*   Description:
*       Draws the game.
*
***********************************************************/

protected override void LoadContent()
{
view.load_content();
} /* LoadContent */


/***********************************************************
*
*   Method:
*       UnloadContent
*
*   Description:
*       Unloads game content.
*
***********************************************************/

protected override void UnloadContent()
{
view.unload_content();
} /* UnloadContent */


/***********************************************************
*
*   Method:
*       Update
*
*   Description:
*       Updates the game logic.
*
***********************************************************/

protected override void Update( GameTime gameTime )
{
if( ( GamePad.GetState( PlayerIndex.One ).Buttons.Back == ButtonState.Pressed ) ||
    ( Keyboard.GetState().IsKeyDown( Keys.Escape ) ) )
    {
    Exit();
    }

ctlr.update();

base.Update( gameTime );
} /* Update */

}
}
