namespace MusicStoreCore.Data.DomainClasses
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public int GenreId { get; set; }

    }
}
