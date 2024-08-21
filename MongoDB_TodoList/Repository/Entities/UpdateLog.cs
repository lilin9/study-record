namespace Repository.Entities {
    public class UpdateLog: BaseEntity {
        private UpdateLog() { }

        public UpdateLog(string? updateContent) {
            UpdateContent = updateContent;
        }

        public string? UpdateContent { get; private set; }
    }
}
