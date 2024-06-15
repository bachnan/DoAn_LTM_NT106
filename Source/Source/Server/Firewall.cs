using System;
using System.Diagnostics;

public static class Firewall
{
    public static string ProgramName = string.Empty;

    public static bool AllowThisProgram(string protocol, string remotePorts, string localPorts, string direction)
    {
        string programFullName = AppDomain.CurrentDomain.BaseDirectory + AppDomain.CurrentDomain.FriendlyName; // Will work even if debugging AppName.vshost.exe
        int end = programFullName.LastIndexOf("\\");
        string programName = Firewall.ProgramName;

        if (Firewall.ProgramName.Length == 0)
            programName = programFullName.Substring(end + 1);

        return AllowProgram(programName, programFullName, protocol, remotePorts, localPorts, direction);
    }

    public static bool AllowProgram(string programName, string programFileName, string protocol, string remotePorts, string localPorts, string direction)
    {
        programName = "Allow " + programName + " " + protocol.ToUpper() + " " + direction.ToLower() + " " + localPorts + " " + remotePorts;
        programName = programName.Replace("  ", " ").Trim();

        string commandDelete = "netsh advFirewall Firewall delete rule name='" + programName + "' protocol=" + protocol.ToUpper() + " dir=" + direction.ToLower();

        if (localPorts.Length > 0)
            commandDelete += " localport=\"" + localPorts + "\"";

        if (remotePorts.Length > 0)
            commandDelete += " remoteport=\"" + remotePorts + "\"";

        if (programFileName.Length > 0)
            commandDelete += " program=\"" + programFileName + "\"";

        string test = ExecuteCommandAsAdmin(commandDelete);

        string commandAdd = "netsh advFirewall Firewall add rule name='" + programName + "' dir=" + direction.ToLower() + " action=allow protocol=" + protocol.ToUpper();

        if (localPorts.Length > 0)
            commandAdd += " localport=\"" + localPorts + "\"";
        else
            localPorts = "Any";

        if (remotePorts.Length > 0)
            commandAdd += " remoteport=\"" + remotePorts + "\"";
        else
            remotePorts = "Any";

        if (programFileName.Length > 0)
            commandAdd += " program=\"" + programFileName + "\"";
        else
            programFileName = "Any";

        commandAdd += " description='Allow " + programFileName + " on " + protocol + " using local-ports " + localPorts + " and remote-ports " + remotePorts + "'";

        return ExecuteCommandAsAdmin(commandAdd).ToUpper().StartsWith("OK");
    }

    public static string ExecuteCommandAsAdmin(string command)
    {
        ProcessStartInfo psinfo = new ProcessStartInfo();
        psinfo.FileName = "powershell.exe";
        psinfo.Arguments = command;
        psinfo.RedirectStandardError = true;
        psinfo.RedirectStandardOutput = true;
        psinfo.UseShellExecute = false;

        using (Process proc = new Process())
        {
            proc.StartInfo = psinfo;
            proc.Start();

            string output = proc.StandardOutput.ReadToEnd();

            if (string.IsNullOrEmpty(output))
                output = proc.StandardError.ReadToEnd();

            return output;
        }
    }
}
