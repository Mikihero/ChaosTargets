using System;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;

namespace FullChaosTargets
{
     using Exiled.API.Features;

     public class Plugin : Plugin<Config>
     {
          public override string Name => "ChaosTargets";
          public override string Prefix => Name;
          public override string Author => "Miki_hero";
          public override Version Version { get; } = new(1, 0, 0, 0);
          public override Version RequiredExiledVersion { get; } = new(8, 2, 1, 0);


          public override void OnEnabled()
          {
               Exiled.Events.Handlers.Player.ChangingRole += OnChangingRole;

               base.OnEnabled();
          }

          public override void OnDisabled()
          {
               Exiled.Events.Handlers.Player.ChangingRole += OnChangingRole;
               
               base.OnDisabled();
          }

          private void OnChangingRole(ChangingRoleEventArgs ev)
          {
               if (ev.NewRole.GetTeam() == Team.ChaosInsurgency)
               {
                    RoundSummary.singleton.ChaosTargetCount = 0;
               }
          }
     }
}