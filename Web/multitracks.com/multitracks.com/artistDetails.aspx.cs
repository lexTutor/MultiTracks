using DataAccess;
using System;
using static System.Net.WebRequestMethods;

public partial class artistDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            var sql = new SQL();

            if (!int.TryParse(Request.QueryString["id"], out int artistId) || artistId == 0)
            {
                artistId = 5; //A default as Hillsong because I love their songs.
            }

            sql.Parameters.Add("@artistID", artistId);
            var artistDetailsDataSet = sql.ExecuteStoredProcedureDS("GetArtistDetails", true);

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

                Songs.DataSource = artistDetailsDataSet.Tables[1];
                Songs.DataBind();

                Albums.DataSource = artistDetailsDataSet.Tables[2];
                Albums.DataBind();
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
}