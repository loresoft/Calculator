using System.IO;
using Microsoft.Win32;

namespace LoreSoft.Calculator
{
    /// <summary>
    /// Class used to set the debugger for an image file.
    /// </summary>
    internal class ImageFileOptions
    {
        private const string ImageFileOptionsRegistryPath =
            @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options";

        private const string DebuggerValueName = "Debugger";

        /// <summary>Sets the debugger for an image file name.</summary>
        /// <param name="imageFileName">Name of the image file.</param>
        /// <param name="debuggerFullPath">The debugger full path.</param>
        public static void SetDebugger(string imageFileName, string debuggerFullPath)
        {
            using (RegistryKey optionsKey = Registry.LocalMachine.OpenSubKey(
                ImageFileOptionsRegistryPath, true))
            {
                using (RegistryKey imageKey = optionsKey.CreateSubKey(imageFileName))
                {
                    imageKey.SetValue(DebuggerValueName, debuggerFullPath);
                }
            }

        }

        /// <summary>Clears the debugger for an image file name.</summary>
        /// <param name="imageFileName">Name of the image file.</param>
        public static void ClearDebugger(string imageFileName)
        {
            string path = Path.Combine(ImageFileOptionsRegistryPath, imageFileName);
            using (RegistryKey imageKey = Registry.LocalMachine.OpenSubKey(path, true))
            {
                if (imageKey == null)
                    return;

                imageKey.DeleteValue(DebuggerValueName, false);
            }

        }

        /// <summary>Gets the debugger for an image file name.</summary>
        /// <param name="imageFileName">Name of the image file.</param>
        /// <returns>The debugger for the image file name.</returns>
        public static string GetDebugger(string imageFileName)
        {
            string path = Path.Combine(ImageFileOptionsRegistryPath, imageFileName);
            using (RegistryKey imageKey = Registry.LocalMachine.OpenSubKey(path, false))
            {
                if (imageKey == null)
                    return null;

                return imageKey.GetValue(DebuggerValueName, string.Empty) as string;
            }
        }

    }
}
