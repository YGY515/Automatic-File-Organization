namespace FileOrganization_Api.Models
{
    public class OrganizeLogDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Path { get; set; }
        public int FileCount { get; set; }
        public int FolderCount { get; set; }
        public bool WasCancelled { get; set; }
    }
}
