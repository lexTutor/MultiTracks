using DataAccess;
using System;
using System.Data;

public partial class artistDetails : System.Web.UI.Page
{
    private const int defaultAlbumSize = 6;
    private const int defaultSongSize = 3;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                DataSet artistDetailsDataSet = GetArtistDataset();

                if (artistDetailsDataSet != null || artistDetailsDataSet.Tables.Count > 0)
                {
                    var artistInformations = artistDetailsDataSet?.Tables[0].ToDynamic();

                    if (artistInformations != null && artistInformations.Count > 0)
                    {
                        var artistInformation = artistInformations[0];

                        artistBannerImage.ImageUrl = artistInformation.ArtistBannerImage;
                        artistBannerImage.Attributes["srcset"] = $"{artistInformation.ArtistBannerImage}, {artistInformation.ArtistBannerImage} 2x";
                        artistBannerImage.AlternateText = artistInformation.ArtistName;

                        artistImage.ImageUrl = artistInformation.ArtistImage;
                        artistImage.Attributes["srcset"] = $"{artistInformation.ArtistImage}, {artistInformation.ArtistImage} 2x";
                        artistImage.AlternateText = artistInformation.ArtistImage;

                        artistLabel.Text = artistInformation.ArtistName;

                        emptyContent.Visible = false;
                        artistContent.Visible = true;
                    }
                    else
                    {
                        emptyContent.Visible = true;
                        artistContent.Visible = false;
                    }

                    BiographyFormView.DataSource = artistDetailsDataSet.Tables[0];
                    BiographyFormView.DataBind();

                    Songs.DataSource = DB.TopNRows(artistDetailsDataSet.Tables[1], defaultSongSize);
                    Songs.DataBind();

                    Albums.DataSource = DB.TopNRows(artistDetailsDataSet.Tables[2], defaultAlbumSize);
                    Albums.DataBind();

                    Session["allAlbums"] = false;
                    Session["allSongs"] = false;
                }
            }
        }
        catch(Exception)
        {

        }
    }

    protected void OnViewAllSongsClicked(object sender, EventArgs e)
    {
        bool allSongs = Session["allSongs"] as bool? ?? true;

        if (allSongs)
        {
            Session["allSongs"] = false;
            viewAllSongs.Text = "View All";

            DataSet artistDetailsDataSet = GetArtistDataset();

            // I could create another stored procedure for this using limit and offset
            // but the instruction says to levarage the MTDataAccess library

            Songs.DataSource = DB.TopNRows(artistDetailsDataSet.Tables[1], defaultSongSize);
            Songs.DataBind();
        }
        else
        {
            Session["allSongs"] = true;
            viewAllSongs.Text = "View Less";

            DataSet artistDetailsDataSet = GetArtistDataset();

            Songs.DataSource = artistDetailsDataSet.Tables[1];
            Songs.DataBind();
        }

    }

    protected void OnViewAllAlbumsClicked(object sender, EventArgs e)
    {
        bool allSongs = Session["allAlbums"] as bool? ?? true;

        if (allSongs)
        {
            Session["allAlbums"] = false;

            viewAllAlbums.Text = "View All";

            DataSet artistDetailsDataSet = GetArtistDataset();

            Albums.DataSource = DB.TopNRows(artistDetailsDataSet.Tables[2], defaultAlbumSize);
            Albums.DataBind();
        }
        else
        {
            Session["allAlbums"] = true;
            viewAllAlbums.Text = "View Less";

            DataSet artistDetailsDataSet = GetArtistDataset();

            Albums.DataSource = artistDetailsDataSet.Tables[2];
            Albums.DataBind();
        }

    }

    private DataSet GetArtistDataset()
    {
        var sql = new SQL();

        if (!int.TryParse(Request.QueryString["id"], out int artistId) || artistId == 0)
        {
            artistId = 5; //A default as Hillsong because I love their songs.
        }

        sql.Parameters.Add("@artistID", artistId);
        var artistDetailsDataSet = sql.ExecuteStoredProcedureDS("GetArtistDetails", true);
        return artistDetailsDataSet;
    }
}