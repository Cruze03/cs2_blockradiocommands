namespace BlockRadioCommands;

using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Commands;

public class PluginInfo : BasePlugin
{
    public override string ModuleName => "Block Radio Commands";
    public override string ModuleVersion => "0.1";
    public override string ModuleAuthor => "Cruze";
    public override string ModuleDescription => "Blocks radio commands, player ping and chatwheel";

    private string[] Commands = new string[] { "coverme", "takepoint", "holdpos", "regroup", "followme", "takingfire", "go", "fallback", "sticktog","getinpos", "stormfront", "report", "roger", "enemyspot", "needbackup", "sectorclear", "inposition", "reportingin","getout", "negative", "enemydown", "compliment", "thanks", "cheer", "go_a", "go_b", "sorry", "needrop", "playerradio", "playerchatwheel", "player_ping", "chatwheel_ping"};


    public override void Load(bool hotReload)
    {
        for (int i = 0; i < Commands.Length; i++)
        {
            AddCommandListener(Commands[i], CommandListener_RadioCommands);
            // Console.WriteLine($"Adding listener to {Commands[i]}");
        }
        
        
        Console.WriteLine("BlockRadioCommands is loaded");
    }

    private HookResult CommandListener_RadioCommands(CCSPlayerController? player, CommandInfo info)
    {
        Console.WriteLine($"Debug - {player.PlayerName} just tried {info.GetCommandString}");

        // If the the CCSPlayerController entity is invalid then execute this section
        if (!player.IsValid)
        {
            return HookResult.Continue;
        }

        // If the pawn associated with the CCSPlayerController is invalid then execute this section
        if (!player.PlayerPawn.IsValid)
        {
            return HookResult.Continue;
        }

        return HookResult.Stop;
    }
}