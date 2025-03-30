namespace SocialNetwork.DataProcessor.ExportDTOs
{
    public class ConversationExportDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string StartedAt { get; set; }

        public MessageExportDTO[] Messages { get; set; }
    }
}
