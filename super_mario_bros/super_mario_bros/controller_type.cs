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
*       update
*
*   Description:
*       Updates the game logic.
*       //update mario's status (for use with animations)
*       Mario seems to stop moving when hitting the ground?
*
***********************************************************/

public void update()
{
KeyBinding.set_key_states();
physics_type physics = model.level.mario.physics;
char_status_enum location;

location = model.level.mario.ground_status;

/*----------------------------------------------------------
Update mario Y location on jump
----------------------------------------------------------*/
if( location == char_status_enum.GROUND && KeyBinding.A_BTN_pressed )
    {
    physics.init_velocity = physics.velocity;

    v_idx = 0;
    if( physics.velocity.x >= MarioPhysics.vy_j_thresh1 )
        {
        v_idx++;
        }
    if( physics.velocity.x >= MarioPhysics.vy_j_thresh2 )
        {
        v_idx++;
        }

    physics.acceleration.y = MarioPhysics.ay_j_a[v_idx];
    physics.velocity.y     = MarioPhysics.vy_j_init[v_idx];
    }
/*----------------------------------------------------------
Update mario Y location on fall
----------------------------------------------------------*/
else if( prev_location == char_status_enum.GROUND &&
         location == char_status_enum.AIR &&
         physics.velocity.y == 0 )
    {
    physics.init_velocity = physics.velocity;

    v_idx = 0;
    if( physics.velocity.x >= MarioPhysics.vy_j_thresh1 )
        {
        v_idx++;
        }
    if( physics.velocity.x >= MarioPhysics.vy_j_thresh2 )
        {
        v_idx++;
        }

    physics.acceleration.y = MarioPhysics.ay_j_f[v_idx];
    physics.velocity.y += physics.acceleration.y;
    }
/*----------------------------------------------------------
Update mario Y location in air
----------------------------------------------------------*/
else if( location == char_status_enum.AIR )
    {
    if( KeyBinding.A_BTN_pressed && physics.velocity.y < 0 )
        {
        physics.acceleration.y = MarioPhysics.ay_j_a[v_idx];
        physics.velocity.y += physics.acceleration.y;
        }
    else
        {
        physics.acceleration.y = MarioPhysics.ay_j_f[v_idx];
        physics.velocity.y += physics.acceleration.y;
        }

    if( KeyBinding.D_RIGHT_pressed )
        {
        if( physics.velocity.x < MarioPhysics.vx_walk_max )
            {
            physics.acceleration.x = MarioPhysics.ax_jf_walk;
            }
        else
            {
            physics.acceleration.x = MarioPhysics.ax_jf_run;
            }

        physics.velocity.x += physics.acceleration.x;
        }
    else if( KeyBinding.D_LEFT_pressed )
        {
        if( physics.velocity.x >= MarioPhysics.vx_walk_max )
            {
            physics.acceleration.x = MarioPhysics.ax_jb_run;
            }
        else if( ( physics.velocity.x < MarioPhysics.vx_walk_max ) &&
                 ( physics.init_velocity.x >= MarioPhysics.vx_j_thresh ) )
            {
            physics.acceleration.x = MarioPhysics.ax_jb_run_walk;
            }
        else
            {
            physics.acceleration.x = MarioPhysics.ax_jb_walk;
            }

        physics.velocity.x += physics.acceleration.x;
        }

    /*----------------------------------------------------------
    Keep speeds in bounds
    ----------------------------------------------------------*/
    if( ( physics.init_velocity.x <= MarioPhysics.vx_walk_max ) &&
        ( physics.velocity.x > MarioPhysics.vx_walk_max ) )
        {
        physics.velocity.x = MarioPhysics.vx_walk_max;
        }
    else if( ( physics.init_velocity.x >= -1 * MarioPhysics.vx_walk_max ) &&
             ( physics.velocity.x < -1 * MarioPhysics.vx_walk_max ) )
        {
        physics.velocity.x = -1 * MarioPhysics.vx_walk_max;
        }

    if( physics.velocity.y > MarioPhysics.vy_j_max )
        {
        physics.velocity.y = MarioPhysics.vy_j_max;
        }
    if( physics.velocity.x > MarioPhysics.vx_run_max )
        {
        physics.velocity.x = MarioPhysics.vx_run_max;
        }
    else if( physics.velocity.x < ( -1 * MarioPhysics.vx_run_max ) )
        {
        physics.velocity.x = -1 * MarioPhysics.vx_run_max;
        }
    }
/*----------------------------------------------------------
Update mario Y location on ground
----------------------------------------------------------*/
else
    {
    physics.acceleration.y = 0;
    physics.velocity.y = 0;
    }

/*----------------------------------------------------------
Skidding left
----------------------------------------------------------*/
if( ( KeyBinding.D_RIGHT_pressed ) &&
    ( physics.velocity.x < -1 * MarioPhysics.vx_skid_thresh ) &&
    ( location == char_status_enum.GROUND ) )
    {
    physics.acceleration.x = MarioPhysics.ax_skid;
    physics.velocity.x += physics.acceleration.x;
    }
/*----------------------------------------------------------
Skidding right
----------------------------------------------------------*/
else if( ( KeyBinding.D_LEFT_pressed ) &&
         ( physics.velocity.x > MarioPhysics.vx_skid_thresh ) &&
         ( location == char_status_enum.GROUND ) )
    {
    physics.acceleration.x = -1 * MarioPhysics.ax_skid;
    physics.velocity.x += physics.acceleration.x;
    }
/*----------------------------------------------------------
Running right
----------------------------------------------------------*/
else if( KeyBinding.D_RIGHT_pressed &&
         KeyBinding.B_BTN_pressed &&
         ( location == char_status_enum.GROUND ) )
    {
    if( physics.velocity.x < 0 )
        {
        physics.velocity.x = 0;
        }

    physics.acceleration.x = MarioPhysics.ax_run;
    physics.velocity.x += physics.acceleration.x;

    if( physics.velocity.x > MarioPhysics.vx_run_max )
        {
        physics.velocity.x = MarioPhysics.vx_run_max;
        }

    if( physics.velocity.x < MarioPhysics.vx_walk_min )
        {
        physics.velocity.x = MarioPhysics.vx_walk_min;
        }
    }
/*----------------------------------------------------------
Running left
----------------------------------------------------------*/
else if( KeyBinding.D_LEFT_pressed &&
         KeyBinding.B_BTN_pressed &&
         ( location == char_status_enum.GROUND ) )
    {
    if( physics.velocity.x > 0 )
        {
        physics.velocity.x = 0;
        }

    physics.acceleration.x = -1 * MarioPhysics.ax_run;
    physics.velocity.x += physics.acceleration.x;

    if( physics.velocity.x < -1 * MarioPhysics.vx_run_max )
        {
        physics.velocity.x = -1 * MarioPhysics.vx_run_max;
        }

    if( physics.velocity.x > -1 * MarioPhysics.vx_walk_min )
        {
        physics.velocity.x = -1 * MarioPhysics.vx_walk_min;
        }
    }
/*----------------------------------------------------------
Walking right
----------------------------------------------------------*/
else if( KeyBinding.D_RIGHT_pressed &&
         !KeyBinding.B_BTN_pressed &&
         ( location == char_status_enum.GROUND ) )
    {
    physics.acceleration.x = MarioPhysics.ax_walk;
    physics.velocity.x += physics.acceleration.x;

    if( physics.velocity.x > MarioPhysics.vx_walk_max )
        {
        physics.velocity.x = MarioPhysics.vx_walk_max;
        }

    if( physics.velocity.x < MarioPhysics.vx_walk_min )
        {
        physics.velocity.x = MarioPhysics.vx_walk_min;
        }
    }
/*----------------------------------------------------------
Walking left
----------------------------------------------------------*/
else if( KeyBinding.D_LEFT_pressed &&
         !KeyBinding.B_BTN_pressed &&
         ( location == char_status_enum.GROUND ) )
    {
    physics.acceleration.x = -1 * MarioPhysics.ax_walk;
    physics.velocity.x += physics.acceleration.x;

    if( physics.velocity.x < -1 * MarioPhysics.vx_walk_max )
        {
        physics.velocity.x = -1 * MarioPhysics.vx_walk_max;
        }

    if( physics.velocity.x > -1 * MarioPhysics.vx_walk_min )
        {
        physics.velocity.x = -1 * MarioPhysics.vx_walk_min;
        }
    }
/*----------------------------------------------------------
Sliding right
----------------------------------------------------------*/
else if( ( physics.velocity.x > MarioPhysics.vx_walk_min ) &&
         ( location == char_status_enum.GROUND ) )
    {
    physics.acceleration.x = -1 * MarioPhysics.ax_release;
    physics.velocity.x += physics.acceleration.x;
    }
/*----------------------------------------------------------
Sliding left
----------------------------------------------------------*/
else if( ( physics.velocity.x < -1 * MarioPhysics.vx_walk_min ) &&
         ( location == char_status_enum.GROUND ) )
    {
    physics.acceleration.x = MarioPhysics.ax_release;
    physics.velocity.x += physics.acceleration.x;
    }
/*----------------------------------------------------------
Standing still
----------------------------------------------------------*/
else if( location == char_status_enum.GROUND )
    {
    physics.acceleration.x = 0;
    physics.velocity.x = 0;
    }

/*----------------------------------------------------------
Temporarily update position for testing
----------------------------------------------------------*/
physics.position += physics.velocity;

/*----------------------------------------------------------
Handle all collisions
----------------------------------------------------------*/
update_hit_box( model.level.mario );

if( physics.position.x < ViewDims.view.X )
    {
    physics.position.x = ViewDims.view.X;
    physics.acceleration.x = 0;
    physics.velocity.x = 0;
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
push_up( c );
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
int suby = (int)( c.physics.position.y - c.physics.hit_box.Height ) % (int)Blocks.size.Height;

c.physics.acceleration.y = 0;
c.physics.velocity.y = 0;
c.physics.position.y += ( Blocks.size.Height - suby );

} /* push_down() */


/***********************************************************
*
*   Method:
*       push_up
*
*   Description:
*       Determines if character is on ground or air.
*
***********************************************************/

public void push_up( character_type c )
{
map_type m = model.level.map;
int x1   = ( c.physics.position.x >> 12 ) / Blocks.size.Width;
int x2   = ( ( c.physics.position.x >> 12 ) + c.physics.hit_box.Width ) / Blocks.size.Width;
int y    = (int)( ( ( c.physics.position.y >> 12 ) + c.physics.hit_box.Height ) / Blocks.size.Height );
int suby = (int)( c.physics.position.y >> 12 ) % (int)Blocks.size.Height;

prev_location = c.ground_status;

//this method will fail when mario falls off map - access out of bounds
//call lose_life function when we try to access out of bounds
if( ( m.blocks[x1, y] != null || m.blocks[x2, y] != null ) && suby > 0 )    //replace with block status == air??
    {
    c.ground_status = char_status_enum.GROUND;
    c.physics.position.y = ( ( ( y * Blocks.size.Height ) - c.physics.hit_box.Height ) + 1 ) << 12;
    }
else
    {
    c.ground_status = char_status_enum.AIR;
    }

} /* push_up() */


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
int subx = (int)c.physics.position.x % (int)Blocks.size.Width;

c.physics.acceleration.x = 0;
c.physics.velocity.x = 0;
c.physics.position.x += ( Blocks.size.Width - subx );

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
int subx = (int)( c.physics.position.x + c.physics.hit_box.Width ) % (int)Blocks.size.Width;

c.physics.acceleration.x = 0;
c.physics.velocity.x = 0;
c.physics.position.x -= subx;
c.physics.position.x--;

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
