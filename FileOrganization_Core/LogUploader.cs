using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FileOrganization_Core
{
    public class LogUploader
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task SendLogAsync (string path, int organizeMethod, int fileCount, int folderCount, bool cancelled)
        {
            var log = new { Date = DateTime.Now, Path = path, OrganizeMethod = organizeMethod,
                FileCount = fileCount, FolderCount = folderCount, WasCancelled = cancelled };

            await client.PostAsJsonAsync("https://localhost:7179/api/logs", log);
        }
    }
}
