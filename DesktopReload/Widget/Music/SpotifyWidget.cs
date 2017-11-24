using System.Linq;
using Enums;
using SpotifyAPI.Web; //Base Namespace
using SpotifyAPI.Web.Auth; //All Authentication-related classes
using SpotifyAPI.Web.Enums; //Enums
using SpotifyAPI.Web.Models; //Models for the JSON-responses
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System;

namespace DesktopReload.Widget
{
    public class SpotifyWidget : BasicWidget
    {
        private static SpotifyWebAPI _spotify;
        private string _albumImage;
        private string _trackTitle = "Loading...";
        private PlaybackContext currentTrack;
        private string _trackArtist;

        public string AlbumImage
        {
            get { return _albumImage; }
            set
            {
                SetField(ref _albumImage, value, "AlbumImage");
            }
        }

        public string TrackTitle
        {
            get { return _trackTitle; }

            set { SetField(ref _trackTitle, value, "TrackTitle"); }
        }

        public string TrackArtist
        {
            get { return _trackArtist; }
            set { SetField(ref _trackArtist, value, "TrackArtist"); }
        }

        public SpotifyWidget()
        {
            LabelText = "Spotify";
            TrackTitle = "Loading...";
            TrackArtist = "Artist";
            Type = WidgetType.SpotifyPlayer;
            ViewType = WidgetViewType.MusicPlayer;
            RefreshRate = WidgetRefreshRate.Default;
            InitSpotifyConnectAsync();
        }

        async System.Threading.Tasks.Task InitSpotifyConnectAsync()
        {
            try
            {
                WebAPIFactory webApiFactory = new WebAPIFactory(
                    "http://localhost",
                    8000,
                    "78919fe5fc9e4bf6ad3fbda92f8f2d16",
                    Scope.Streaming | Scope.UserReadPrivate | Scope.UserReadPlaybackState,
                    TimeSpan.FromSeconds(20)
                );

                //This will open the user's browser and returns once
                //the user is authorized.
                _spotify = await webApiFactory.GetWebApi();
            }
            catch (Exception ex)
            {
               
            }

            if (_spotify == null)
                return;

            currentTrack = _spotify.GetPlayingTrack();
        }

        public override void Refresh()
        {
            base.Refresh();

            if (_spotify == null)
                return;

            currentTrack = _spotify.GetPlayingTrack();
            if (currentTrack != null && !currentTrack.HasError())
            {
                TrackTitle = currentTrack.Item.Name ;
                if (currentTrack.Item.Artists.Any())
                    TrackArtist = currentTrack.Item.Artists.First().Name;

                if (currentTrack.Item.Album.Images.Any())
                    AlbumImage = currentTrack.Item.Album.Images.OrderByDescending(image => image.Width).First().Url;
            }

        }
    }
}
