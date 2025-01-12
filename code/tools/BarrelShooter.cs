namespace Sandbox.Tools
{
	[Library( "tool_barrelgun", Title = "Barrel Shooter", Description = "die", Group = "fun" )]
	public class BarrelShooter : BaseTool
	{
		TimeSince timeSinceShoot;

		public override void Simulate()
		{
			if ( Host.IsServer )
			{
				if ( Input.Pressed( InputButton.Attack1 ) )
				{
					ShootBox();
				}

				if ( Input.Down( InputButton.Attack2 ) && timeSinceShoot > 0.05f )
				{
					timeSinceShoot = 0;
					ShootBox();
				}
			}
		}

		void ShootBox()
		{
			var ent = new Prop
			{
				Position = Owner.EyePos + Owner.EyeRot.Forward * 50,
				Rotation = Owner.EyeRot
			};

			ent.SetModel( "models/rust_props/barrels/fuel_barrel.vmdl" );
			ent.Velocity = Owner.EyeRot.Forward * 1000;
		}
	}

}
