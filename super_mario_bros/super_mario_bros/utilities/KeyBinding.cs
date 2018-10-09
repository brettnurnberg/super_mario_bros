/*********************************************************************
*
*   Class:
*       KeyBinding
*
*   Description:
*       Contains the key binding
*
*********************************************************************/

/*--------------------------------------------------------------------
                            INCLUDES
--------------------------------------------------------------------*/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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

public static class KeyBinding {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

public  const Keys D_LEFT  = Keys.A;
public  const Keys D_RIGHT = Keys.D;
public  const Keys D_UP    = Keys.W;
public  const Keys D_DOWN  = Keys.S;

public  const Keys A_BTN   = Keys.K;
public  const Keys B_BTN   = Keys.M;

public  static Boolean D_LEFT_pressed;
public  static Boolean D_RIGHT_pressed;
public  static Boolean D_UP_pressed;
public  static Boolean D_DOWN_pressed;

public  static Boolean A_BTN_pressed;
public  static Boolean B_BTN_pressed;

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/

public static void set_key_states()
{
D_LEFT_pressed  = Keyboard.GetState().IsKeyDown( D_LEFT  );
D_RIGHT_pressed = Keyboard.GetState().IsKeyDown( D_RIGHT );
D_UP_pressed    = Keyboard.GetState().IsKeyDown( D_UP    );
D_DOWN_pressed  = Keyboard.GetState().IsKeyDown( D_DOWN  );
A_BTN_pressed   = Keyboard.GetState().IsKeyDown( A_BTN   );
B_BTN_pressed   = Keyboard.GetState().IsKeyDown( B_BTN   );
}

}
}
