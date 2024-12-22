using ICSharpCode.SharpZipLib.Zip;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(" ███▄    █ ▓█████ ▒██   ██▒ █    ██   ██████      ▄████  █    ██  ██▓\r\n ██ ▀█   █ ▓█   ▀ ▒▒ █ █ ▒░ ██  ▓██▒▒██    ▒     ██▒ ▀█▒ ██  ▓██▒▓██▒\r\n▓██  ▀█ ██▒▒███   ░░  █   ░▓██  ▒██░░ ▓██▄      ▒██░▄▄▄░▓██  ▒██░▒██▒\r\n▓██▒  ████▒▒▓█  ▄  ░ █ █ ▒ ▓▓█  ░██░  ▒   ██▒   ░▓█  ██▓▓▓█  ░██░░██░\r\n▒██░   ▓██░░▒████▒▒██▒ ▒██▒▒▒█████▓ ▒██████▒▒   ░▒▓███▀▒▒▒█████▓ ░██░\r\n░ ▒░   ▒ ▒ ░░ ▒░ ░▒▒ ░ ░▓ ░░▒▓▒ ▒ ▒ ▒ ▒▓▒ ▒ ░    ░▒   ▒ ░▒▓▒ ▒ ▒ ░▓  \r\n░ ░░   ░ ▒░ ░ ░  ░░░   ░▒ ░░░▒░ ░ ░ ░ ░▒  ░ ░     ░   ░ ░░▒░ ░ ░  ▒ ░\r\n   ░   ░ ░    ░    ░    ░   ░░░ ░ ░ ░  ░  ░     ░ ░   ░  ░░░ ░ ░  ▒ ░\r\n         ░    ░  ░ ░    ░     ░           ░           ░    ░      ░  \r\n                                                                     ");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Fetching Latest From GitHub");

        string fileUrl = "https://github.com/AmiraIsAmiraOMG/Nexus-Launcher/releases/download/Installer/LatestLauncher.zip\r\n";
        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string destinationFolderPath = Path.Combine(appDataPath, "Nexus Utilities");
        string destinationFilePath = Path.Combine(destinationFolderPath, "Launcher.zip");
        string extractFolderPath = Path.Combine(destinationFolderPath, "Launcher");

        try
        {
            // Ensure the destination folder exists
            if (!Directory.Exists(destinationFolderPath))
            {
                Directory.CreateDirectory(destinationFolderPath);
            }

            await DownloadFileWithProgressAsync(fileUrl, destinationFilePath);
            Console.WriteLine("\nDownload completed successfully.");

            ExtractZipWithSharpZipLib(destinationFilePath, extractFolderPath);
            Console.WriteLine("\nExtraction completed successfully.");

            File.Delete(destinationFilePath);
            Console.WriteLine("\nClean-up: Deleted the ZIP file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nAn error occurred: {ex.Message}");
        }
    }

    static async Task DownloadFileWithProgressAsync(string url, string destinationPath)
    {
        using (HttpClient client = new HttpClient())
        {
            using (HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();

                long? totalSize = response.Content.Headers.ContentLength;
                using (var contentStream = await response.Content.ReadAsStreamAsync())
                {
                    using (var fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        var buffer = new byte[8192];
                        long totalRead = 0;
                        int read;
                        int lastProgress = -1;

                        while ((read = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            await fileStream.WriteAsync(buffer, 0, read);
                            totalRead += read;

                            if (totalSize.HasValue)
                            {
                                int progress = (int)((totalRead * 100) / totalSize.Value);
                                if (progress != lastProgress)
                                {
                                    Console.CursorLeft = 0;
                                    Console.Write($"Downloading: {progress}%");
                                    lastProgress = progress;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    static void ExtractZipWithSharpZipLib(string zipFilePath, string extractFolderPath)
    {
        if (!Directory.Exists(extractFolderPath))
        {
            Directory.CreateDirectory(extractFolderPath);
        }

        FastZip fastZip = new FastZip();
        fastZip.CreateEmptyDirectories = true;

        fastZip.ExtractZip(zipFilePath, extractFolderPath, null);

        Console.WriteLine("Extracted");
    }
}