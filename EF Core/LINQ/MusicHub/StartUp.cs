using System.Text;
namespace MusicHub
{
    using Data;
    using Initializer;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albumsInfo = context
                .Producers.Find(producerId)
                .Albums.Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        SongPrice = s.Price,
                        SongWriterName = s.Writer.Name
                    })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.SongWriterName),
                    AlbumPrice = a.Price
                })
                .OrderByDescending(a => a.AlbumPrice)
                .ToList();

            var sb = new StringBuilder();
            foreach (var a in albumsInfo)
            {
                sb.AppendLine($"-AlbumName: {a.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {a.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {a.ProducerName}");
                sb.AppendLine("-Songs:");

                int position = 1;
                if (a.Songs.Any())
                {
                    foreach (var s in a.Songs)
                    {
                        sb.AppendLine($"---#{position++}");
                        sb.AppendLine($"---SongName: {s.SongName}");
                        sb.AppendLine($"---Price: {s.SongPrice:F2}");
                        sb.AppendLine($"---Writer: {s.SongWriterName}");
                    }
                }

                sb.AppendLine($"-AlbumPrice: {a.AlbumPrice:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            //Calling AsEnumerable() so that we materialise the query and apply the where clause
            var songsInfo = context
                .Songs.AsEnumerable()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    SongName = s.Name,
                    SongWriterName = s.Writer.Name,
                    SongPerformersNames = s.SongPerformers
                        .Select(sp =>
                            $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                        .OrderBy(x => x)
                        .ToList(),
                    AlbumProducerName = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.SongWriterName)
                .ToList();

            int position = 1;
            var sb = new StringBuilder();
            foreach (var s in songsInfo)
            {
                sb.AppendLine($"-Song #{position++}");
                sb.AppendLine($"---SongName: {s.SongName}");
                sb.AppendLine($"---Writer: {s.SongWriterName}");

                if (s.SongPerformersNames.Any())
                {
                    foreach (var p in s.SongPerformersNames)
                    {
                        sb.AppendLine($"---Performer: {p}");
                    }
                }

                sb.AppendLine($"---AlbumProducer: {s.AlbumProducerName}");
                sb.AppendLine($"---Duration: {s.Duration}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
