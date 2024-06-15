using System;
using System.Diagnostics;

public static class Firewall
{
    public static string DefaultProgramName = string.Empty;

    public static bool AllowProgram(string protocol, string remotePorts, string localPorts, string direction)
    {
        string programFullName = AppDomain.CurrentDomain.BaseDirectory + AppDomain.CurrentDomain.FriendlyName;
        int end = programFullName.LastIndexOf("\\");
        string programName = string.IsNullOrEmpty(DefaultProgramName) ? programFullName.Substring(end + 1) : DefaultProgramName;

        return AllowProgramAccess(programName, programFullName, protocol, remotePorts, localPorts, direction);
    }

    public static bool AllowProgramAccess(string programName, string programFileName, string protocol, string remotePorts, string localPorts, string direction)
    {
        programName = "Allow " + programName + " " + protocol.ToUpper() + " " + direction.ToLower() + " " + localPorts + " " + remotePorts;
        programName = programName.Replace("  ", " ").Trim();

        string cmdDelete = $"netsh advfirewall firewall delete rule name='{programName}' protocol={protocol.ToUpper()} dir={direction.ToLower()}";
        if (!string.IsNullOrEmpty(localPorts))
            cmdDelete += $" localport=\"{localPorts}\"";
        if (!string.IsNullOrEmpty(remotePorts))
            cmdDelete += $" remoteport=\"{remotePorts}\"";
        if (!string.IsNullOrEmpty(programFileName))
            cmdDelete += $" program=\"{programFileName}\"";

        string test = ExecuteCommandAsAdmin(cmdDelete);

        string cmdAdd = $"netsh advfirewall firewall add rule name='{programName}' dir={direction.ToLower()} action=allow protocol={protocol.ToUpper()}";
        if (!string.IsNullOrEmpty(localPorts))
            cmdAdd += $" localport=\"{localPorts}\"";
        else
            localPorts = "Any";
        if (!string.IsNullOrEmpty(remotePorts))
            cmdAdd += $" remoteport=\"{remotePorts}\"";
        else
            remotePorts = "Any";
        if (!string.IsNullOrEmpty(programFileName))
            cmdAdd += $" program=\"{programFileName}\"";
        else
            programFileName = "Any";
        cmdAdd += $" description='Allow {programFileName} on {protocol} using local-ports {localPorts} and remote-ports {remotePorts}'";

        return ExecuteCommandAsAdmin(cmdAdd).ToUpper().StartsWith("OK");
    }

    public static string ExecuteCommandAsAdmin(string command)
    {
        ProcessStartInfo processInfo = new ProcessStartInfo();
        processInfo.FileName = "powershell.exe";
        processInfo.Arguments = command;
        processInfo.RedirectStandardError = true;
        processInfo.RedirectStandardOutput = true;
        processInfo.UseShellExecute = false;

        using (Process process = new Process())
        {
            process.StartInfo = processInfo;
            process.Start();

            string output = process.StandardOutput.ReadToEnd();

            if (string.IsNullOrEmpty(output))
                output = process.StandardError.ReadToEnd();

            return output;
        }
    }
}
