/*********************************************************************
*
*   Class:
*       controller_type
*
*   Description:
*       Contains the game logic
*
*********************************************************************/

/*--------------------------------------------------------------------
                            INCLUDES
--------------------------------------------------------------------*/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

public class controller_type {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

private model_type model;
private int v_idx;
private char_status_enum prev_location;

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/

/***********************************************************
*
*   Method:
*       controller_type
*
*   Description:
*       Constructor.
*
***********************************************************/

public controller_type( model_type m )
{
model = m;
v_idx = 0;
} /* controller_type() */


/***********************************************************
*
*   Method:
*       set_ground_status
*
*   Description:
*       Determines if character is on ground or air.
*
***********************************************************/

public void set_ground_status( character_type c, map_type m )
{
int x1   = (int)( c.physics.position.X / Blocks.size.Width );
int x2   = (int)( ( c.physics.position.X + c.physics.hit_box.Width ) / Blocks.size.Width );
int y    = (int)( c.physics.position.Y / Blocks.size.Height ) + 1;
int suby = (int)c.physics.position.Y % (int)Blocks.size.Height;

//this method will fail when mario falls off map - access out of bounds
//call lose_life function when we try to access out of bounds
if( ( m.blocks[x1, y] != null || m.blocks[x2, y] != null ) && suby > 0 )    //replace with block status == air??
    {
    c.ground_status = char_status_enum.GROUND;
    c.physics.position.Y = ( y - 1 ) * Blocks.size.Height + 1;
    }
else
    {
    c.ground_status = char_status_enum.AIR;
    }

} /* set_ground_status */


/***********************************************************
*
*   Method:
*       update
*
*   Description:
*       Updates the game logic.
*
***********************************************************/

public void update()
{
KeyBinding.set_key_states();
physics_type physics = model.level.mario.physics;
char_status_enum location;

location      = model.level.mario.ground_status;

/*----------------------------------------------------------
Update mario Y location on jump
----------------------------------------------------------*/
if( location == char_status_enum.GROUND && KeyBinding.A_BTN_pressed )
    {
    physics.init_velocity = physics.velocity;

    v_idx = 0;
    if( physics.velocity.X >= MarioPhysics.vy_j_thresh1 )
        {
        v_idx++;
        }
    if( physics.velocity.X >= MarioPhysics.vy_j_thresh2 )
        {
        v_idx++;
        }

    physics.acceleration.Y = MarioPhysics.ay_j_a[v_idx];
    physics.velocity.Y = -1 * MarioPhysics.vy_j_init[v_idx];
    physics.position.Y += physics.velocity.Y;
    }
/*----------------------------------------------------------
Update mario Y location on fall
----------------------------------------------------------*/
else if( prev_location == char_status_enum.GROUND && location == char_status_enum.AIR )
    {
    physics.init_velocity = physics.velocity;

    v_idx = 0;
    if( physics.velocity.X >= MarioPhysics.vy_j_thresh1 )
        {
        v_idx++;
        }
    if( physics.velocity.X >= MarioPhysics.vy_j_thresh2 )
        {
        v_idx++;
        }

    physics.acceleration.Y = MarioPhysics.ay_j_f[v_idx];
    physics.velocity.Y += physics.acceleration.Y;
    physics.position.Y += physics.velocity.Y;
    }
/*----------------------------------------------------------
Update mario Y location in air
----------------------------------------------------------*/
else if( location == char_status_enum.AIR )
    {
    if( KeyBinding.A_BTN_pressed && physics.velocity.Y < 0 )
        {
        physics.acceleration.Y = MarioPhysics.ay_j_a[v_idx];
        physics.velocity.Y += physics.acceleration.Y;
        }
    else
        {
        physics.acceleration.Y = MarioPhysics.ay_j_f[v_idx];
        physics.velocity.Y += physics.acceleration.Y;
        }

    if( KeyBinding.D_RIGHT_pressed )
        {
        if( physics.velocity.X < MarioPhysics.v_walk_max )
            {
            physics.acceleration.X = MarioPhysics.ax_jf_walk;
            }
        else
            {
            physics.acceleration.X = MarioPhysics.ax_jf_run;
            }

        physics.velocity.X += physics.acceleration.X;
        }
    else if( KeyBinding.D_LEFT_pressed )
        {
        if( physics.velocity.X >= MarioPhysics.v_walk_max )
            {
            physics.acceleration.X = MarioPhysics.ax_jb_run;
            }
        else if( ( physics.velocity.X < MarioPhysics.v_walk_max ) &&
                 ( physics.init_velocity.X >= MarioPhysics.vx_j_thresh ) )
            {
            physics.acceleration.X = MarioPhysics.ax_jb_run_walk;
            }
        else
            {
            physics.acceleration.X = MarioPhysics.ax_jb_walk;
            }

        physics.velocity.X += physics.acceleration.X;
        }

    /*----------------------------------------------------------
    Keep speeds in bounds
    ----------------------------------------------------------*/
    if( physics.velocity.Y > MarioPhysics.vy_j_max )
        {
        physics.velocity.Y = MarioPhysics.vy_j_max;
        }
    if( physics.velocity.X > MarioPhysics.v_run_max )
        {
        physics.velocity.X = MarioPhysics.v_run_max;
        }
    else if( physics.velocity.X < ( -1 * MarioPhysics.v_run_max ) )
        {
        physics.velocity.X = -1 * MarioPhysics.v_run_max;
        }

    physics.position += physics.velocity;
    }
/*----------------------------------------------------------
Update mario Y location on ground
----------------------------------------------------------*/
else
    {
    physics.acceleration.Y = 0;
    physics.velocity.Y = 0;
    }

/*----------------------------------------------------------
Skidding left
----------------------------------------------------------*/
if( ( KeyBinding.D_RIGHT_pressed ) &&
    ( physics.velocity.X < -1 * MarioPhysics.v_skid_thresh ) &&
    ( location == char_status_enum.GROUND ) )
    {
    physics.acceleration.X = MarioPhysics.a_skid;
    physics.velocity.X += physics.acceleration.X;

    physics.position.X += physics.velocity.X;
    }
/*----------------------------------------------------------
Skidding right
----------------------------------------------------------*/
else if( ( KeyBinding.D_LEFT_pressed ) &&
         ( physics.velocity.X > MarioPhysics.v_skid_thresh ) &&
         ( location == char_status_enum.GROUND ) )
    {
    physics.acceleration.X = -1 * MarioPhysics.a_skid;
    physics.velocity.X += physics.acceleration.X;

    physics.position.X += physics.velocity.X;
    }
/*----------------------------------------------------------
Running right
----------------------------------------------------------*/
else if( KeyBinding.D_RIGHT_pressed && KeyBinding.B_BTN_pressed && location == char_status_enum.GROUND )
    {
    if( physics.velocity.X < 0 )
        {
        physics.velocity.X = 0;
        }

    physics.acceleration.X = MarioPhysics.a_run;
    physics.velocity.X += physics.acceleration.X;

    if( physics.velocity.X > MarioPhysics.v_run_max )
        {
        physics.velocity.X = MarioPhysics.v_run_max;
        }

    if( physics.velocity.X < MarioPhysics.v_walk_min )
        {
        physics.velocity.X = MarioPhysics.v_walk_min;
        }

    physics.position.X += physics.velocity.X;
    }
/*----------------------------------------------------------
Running left
----------------------------------------------------------*/
else if( KeyBinding.D_LEFT_pressed && KeyBinding.B_BTN_pressed && location == char_status_enum.GROUND )
    {
    if( physics.velocity.X > 0 )
        {
        physics.velocity.X = 0;
        }

    physics.acceleration.X = -1 * MarioPhysics.a_run;
    physics.velocity.X += physics.acceleration.X;

    if( physics.velocity.X < -1 * MarioPhysics.v_run_max )
        {
        physics.velocity.X = -1 * MarioPhysics.v_run_max;
        }

    if( physics.velocity.X > -1 * MarioPhysics.v_walk_min )
        {
        physics.velocity.X = -1 * MarioPhysics.v_walk_min;
        }

    physics.position.X += physics.velocity.X;
    }
/*----------------------------------------------------------
Walking right
----------------------------------------------------------*/
else if( KeyBinding.D_RIGHT_pressed && !KeyBinding.B_BTN_pressed && location == char_status_enum.GROUND )
    {
    physics.acceleration.X = MarioPhysics.a_walk;
    physics.velocity.X += physics.acceleration.X;

    if( physics.velocity.X > MarioPhysics.v_walk_max )
        {
        physics.velocity.X = MarioPhysics.v_walk_max;
        }

    if( physics.velocity.X < MarioPhysics.v_walk_min )
        {
        physics.velocity.X = MarioPhysics.v_walk_min;
        }

    physics.position.X += physics.velocity.X;
    }
/*----------------------------------------------------------
Walking left
----------------------------------------------------------*/
else if( KeyBinding.D_LEFT_pressed && !KeyBinding.B_BTN_pressed && location == char_status_enum.GROUND )
    {
    physics.acceleration.X = -1 * MarioPhysics.a_walk;
    physics.velocity.X += physics.acceleration.X;

    if( physics.velocity.X < -1 * MarioPhysics.v_walk_max )
        {
        physics.velocity.X = -1 * MarioPhysics.v_walk_max;
        }

    if( physics.velocity.X > -1 * MarioPhysics.v_walk_min )
        {
        physics.velocity.X = -1 * MarioPhysics.v_walk_min;
        }

    physics.position.X += physics.velocity.X;
    }
/*----------------------------------------------------------
Sliding right
----------------------------------------------------------*/
else if( ( physics.velocity.X > MarioPhysics.v_walk_min ) && ( location == char_status_enum.GROUND ) )
    {
    physics.acceleration.X = -1 * MarioPhysics.a_release;
    physics.velocity.X += physics.acceleration.X;
    physics.position.X += physics.velocity.X;
    }
/*----------------------------------------------------------
Sliding left
----------------------------------------------------------*/
else if( ( physics.velocity.X < -1 * MarioPhysics.v_walk_min ) && ( location == char_status_enum.GROUND ) )
    {
    physics.acceleration.X = MarioPhysics.a_release;
    physics.velocity.X += physics.acceleration.X;
    physics.position.X += physics.velocity.X;
    }
/*----------------------------------------------------------
Standing still
----------------------------------------------------------*/
else if( location == char_status_enum.GROUND )
    {
    physics.acceleration.X = 0;
    physics.velocity.X = 0;
    }

//update mario's status (for use with animations)
update_hit_box( model.level.mario );

//also check hit box for sides and tops
if( physics.position.X < ViewDims.view.X )
    {
    physics.position.X = ViewDims.view.X;
    physics.acceleration.X = 0;
    physics.velocity.X = 0;
    }

} /* update() */


/***********************************************************
*
*   Method:
*       update_hit_box
*
*   Description:
*       Determines if character is on ground or air.
*
***********************************************************/

private void update_hit_box( character_type c )
{
int[] x = new int[2];
int[] y = new int[2];
Boolean[] is_block = new Boolean[4];

x[0] = (int)( c.physics.position.X / Blocks.size.Width );
x[1] = (int)( ( c.physics.position.X + c.physics.hit_box.Width ) / Blocks.size.Width );
y[0] = (int)( c.physics.position.Y / Blocks.size.Height ) + 1;
y[1] = (int)( ( c.physics.position.Y - c.physics.hit_box.Height ) / Blocks.size.Height ) + 1;
int subx = (int)c.physics.position.X % (int)Blocks.size.Width;
int suby = (int)c.physics.position.Y % (int)Blocks.size.Height;

if( c.ground_status == char_status_enum.GROUND )
    {
    y[0]--;
    }

is_block[0] = contains_block( x[0], y[0] );
is_block[1] = contains_block( x[1], y[0] );
is_block[2] = contains_block( x[1], y[1] );
is_block[3] = contains_block( x[0], y[1] );

//call lose_life function when we try to access out of bounds
//add first check for no collisions to avoid all these extra checks
//add implementation to update velocities/accels as well
/*----------------------------------------------------------
Check ceiling collision
----------------------------------------------------------*/
if( ( !is_block[0] && !is_block[1] ) &&
    ( ( ( c.physics.velocity.X == 0 ) && ( is_block[2] || is_block[3] ) ) ||
      ( ( c.physics.velocity.X < 0  ) &&   is_block[3] && contains_block( x[0] + 1, y[1] ) ) ||
      ( ( c.physics.velocity.X > 0  ) &&   is_block[2] && contains_block( x[1] - 1, y[1] ) ) ) )
    {
    push_down( c );
    }
/*----------------------------------------------------------
Check left wall collision
----------------------------------------------------------*/
else if( ( ( c.physics.velocity.Y == 0 ) && ( is_block[0] || is_block[3] ) ) ||
         ( ( c.physics.velocity.Y < 0  ) &&   is_block[3] && contains_block( x[0], y[1] + 1 ) ) ||
         ( ( c.physics.velocity.Y > 0  ) &&   is_block[0] && contains_block( x[0], y[0] - 1 ) ) )
    {
    push_right( c );
    }
/*----------------------------------------------------------
Check right wall collision
----------------------------------------------------------*/
else if( ( ( c.physics.velocity.Y == 0 ) && ( is_block[1] || is_block[2] ) ) ||
         ( ( c.physics.velocity.Y < 0  ) &&   is_block[2] && contains_block( x[1], y[1] + 1 ) ) ||
         ( ( c.physics.velocity.Y > 0  ) &&   is_block[1] && contains_block( x[1], y[0] - 1 ) ) )
    {
    push_left( c );
    }
/*----------------------------------------------------------
Check dual collisions TODO - see line question
----------------------------------------------------------*/

/*----------------------------------------------------------
Check feet on ground
----------------------------------------------------------*/
prev_location = model.level.mario.ground_status;
set_ground_status( model.level.mario, model.level.map );

} /* update_hit_box() */


/***********************************************************
*
*   Method:
*       push_down
*
*   Description:
*       Push the character down one block.
*
***********************************************************/

private void push_down( character_type c )
{
int suby = (int)( c.physics.position.Y - c.physics.hit_box.Height ) % (int)Blocks.size.Height;

c.physics.acceleration.Y = 0;
c.physics.velocity.Y = 0;
c.physics.position.Y += ( Blocks.size.Height - suby );

} /* push_down() */


/***********************************************************
*
*   Method:
*       push_right
*
*   Description:
*       Push the character left one block.
*
***********************************************************/

private void push_right( character_type c )
{
int subx = (int)c.physics.position.X % (int)Blocks.size.Width;

c.physics.acceleration.X = 0;
c.physics.velocity.X = 0;
c.physics.position.X += ( Blocks.size.Width - subx );

} /* push_right() */


/***********************************************************
*
*   Method:
*       push_left
*
*   Description:
*       Push the character down one block.
*
***********************************************************/

private void push_left( character_type c )
{
int subx = (int)( c.physics.position.X + c.physics.hit_box.Width ) % (int)Blocks.size.Width;

c.physics.acceleration.X = 0;
c.physics.velocity.X = 0;
c.physics.position.X -= subx;
c.physics.position.X--;
//set equal to the view_dims most right point in the left block
//may need to change physics to pixel, subpixel, subsubpixel, and subsubsubpixel mode

} /* push_left() */


/***********************************************************
*
*   Method:
*       contains_block
*
*   Description:
*       Returns true if the given map block is solid.
*
***********************************************************/

private Boolean contains_block( int x, int y )
{
if( ( x >= model.level.map.width )  ||
    ( x < 0 )                       ||
    ( y >= model.level.map.height ) ||
    ( y < 0 ) )
    {
    /* Infinite loop to avoid out of bounds access */
    while( true );
    }

return ( model.level.map.blocks[x, y] != null );
} /* contains_block() */

}
}
