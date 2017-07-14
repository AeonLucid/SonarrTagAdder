using System;
using System.Collections.Generic;

namespace SonarrTagAdder.Sonarr.Data
{
    internal class SerieResponse
    {
        public string Title { get; set; }
        public SerieAlternatetitle[] AlternateTitles { get; set; }
        public string SortTitle { get; set; }
        public int SeasonCount { get; set; }
        public int TotalEpisodeCount { get; set; }
        public int EpisodeCount { get; set; }
        public int EpisodeFileCount { get; set; }
        public long SizeOnDisk { get; set; }
        public string Status { get; set; }
        public string Overview { get; set; }
        public DateTime PreviousAiring { get; set; }
        public string Network { get; set; }
        public string AirTime { get; set; }
        public SerieImage[] Images { get; set; }
        public SerieSeason[] Seasons { get; set; }
        public int Year { get; set; }
        public string Path { get; set; }
        public int ProfileId { get; set; }
        public bool SeasonFolder { get; set; }
        public bool Monitored { get; set; }
        public bool UseSceneNumbering { get; set; }
        public int Runtime { get; set; }
        public int TvdbId { get; set; }
        public int TvRageId { get; set; }
        public int TvMazeId { get; set; }
        public DateTime FirstAired { get; set; }
        public DateTime LastInfoSync { get; set; }
        public string SeriesType { get; set; }
        public string CleanTitle { get; set; }
        public string ImdbId { get; set; }
        public string TitleSlug { get; set; }
        public string Certification { get; set; }
        public string[] Genres { get; set; }
        public List<int> Tags { get; set; }
        public DateTime Added { get; set; }
        public SerieRatings Ratings { get; set; }
        public int QualityProfileId { get; set; }
        public int Id { get; set; }

        public class SerieRatings
        {
            public int Votes { get; set; }
            public float Value { get; set; }
        }

        public class SerieAlternatetitle
        {
            public string Title { get; set; }
            public int SeasonNumber { get; set; }
        }

        public class SerieImage
        {
            public string CoverType { get; set; }
            public string Url { get; set; }
        }

        public class SerieSeason
        {
            public int SeasonNumber { get; set; }
            public bool Monitored { get; set; }
            public SerieStatistics Statistics { get; set; }
        }

        public class SerieStatistics
        {
            public DateTime PreviousAiring { get; set; }
            public int EpisodeFileCount { get; set; }
            public int EpisodeCount { get; set; }
            public int TotalEpisodeCount { get; set; }
            public long SizeOnDisk { get; set; }
            public double PercentOfEpisodes { get; set; }
        }
    }
}
