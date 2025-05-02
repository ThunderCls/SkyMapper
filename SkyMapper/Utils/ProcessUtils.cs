using System.Diagnostics;
using System.Management;

namespace SkyMapper.Utils;

public static class ProcessUtils
{
    public static Task<int> ExecuteProcessAsync(
        string fileName, 
        string arguments,
        Form synchronizingObject,
        Action<string>? progressAction = null,
        Func<string, Task>? errorAction = null)
    {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false
            }
        };
        process.EnableRaisingEvents = true;
        process.SynchronizingObject = synchronizingObject;
        var tcs = new TaskCompletionSource<int>();
        process.Exited += (_, _) => tcs.SetResult(process.ExitCode);
        process.OutputDataReceived += (_, dataReceivedArgs) =>
        {
            if (!string.IsNullOrWhiteSpace(dataReceivedArgs.Data))
                progressAction?.Invoke(dataReceivedArgs.Data);
        };
        process.ErrorDataReceived += (_, dataReceivedArgs) =>
        {
            if (process.ExitCode != 0)
                errorAction?.Invoke($"Process error exit code: 0x{process.ExitCode:x8}. Details: " +
                                    $"{dataReceivedArgs.Data ?? "No additional error information"}");
        };
        
        if (!process.Start())
            tcs.SetResult(-1);
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        return tcs.Task;
    }
    
    public static async Task ExecuteProcessAsync(
        string fileName, 
        string arguments, 
        bool hidden = false, 
        bool fireAndForget = false)
    {
        try
        {
            using var process = new Process();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = hidden ? "cmd.exe" : fileName,
                Arguments = hidden ? $"/c \"{fileName} {arguments}\"" : arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                WindowStyle = hidden ? ProcessWindowStyle.Hidden : ProcessWindowStyle.Normal
            };
            process.Start();
            if (fireAndForget) return;
            
            var error = await process.StandardError.ReadToEndAsync();
            await process.WaitForExitAsync();
            if (process.ExitCode != 0)
            {
                throw new ApplicationException($"Failed to create process with exit code 0x{process.ExitCode:x8}");
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine($"ExecuteProcess failed {e}");
            throw;
        }
    }
    
    public static string? GetParentProcessNameWmi(int processId)
    {
        try
        {
            var query = $"SELECT ParentProcessId FROM Win32_Process WHERE ProcessId = {processId}";
            using var searcher = new ManagementObjectSearcher("root\\CIMV2", query);
            using var results = searcher.Get();
            
            foreach (var obj in results)
            {
                var parentId = Convert.ToInt32(obj["ParentProcessId"]);
                try
                {
                    var parentProcess = Process.GetProcessById(parentId);
                    return parentProcess.ProcessName;
                }
                catch (ArgumentException)
                {
                    Debug.WriteLine("Unknown (process has exited)");
                    return null;
                }
            }
            
            return null;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error getting parent process: {ex.Message}");
            return null;
        }
    }

    // public static string? GetParentProcessNameNt(int processId)
    // {
    //     string? parentProcessName = null;
    //     
    //     try
    //     {
    //         using var process = NtProcess.Open(processId, ProcessAccessRights.QueryLimitedInformation);
    //         var parentId = process.ParentProcessId;
    //         var parentProcess = Process.GetProcessById(parentId);
    //         parentProcessName = parentProcess.ProcessName;
    //     }
    //     catch (Exception ex)
    //     {
    //         Debug.WriteLine($"Error getting parent process: {ex.Message}");
    //     }
    //     
    //     return parentProcessName;
    // }
}