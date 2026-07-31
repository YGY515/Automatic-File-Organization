namespace FileOrganization_Core
{
    public abstract class FileOrganizerBase
    {
        public int FileCount { get; protected set; }    // 총 정리한 파일 
        public int FolderCount { get; protected set; }  // 총 생성한 폴더

        public abstract string Organize(string path, CancellationToken token, IProgress<int> progress = null);

        public abstract void CollectFiles();

        public abstract void CreateFolders();

        public abstract void MoveFiles(CancellationToken token, IProgress<int> progress = null);

        public string PrintLog(int fileNum, int folderNum)
        {
            return ($"위치에서 파일 {fileNum}개를 정리하고 폴더 {folderNum}개를 생성했습니다.");
        }
    }
}
