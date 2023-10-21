CREATE PROCEDURE [dbo].[GetArtistDetails]
    @artistID INT
AS
BEGIN
    -- Subquery for Artist Details
    SELECT 
        artist.title AS ArtistName,
        artist.imageURL AS ArtistImage,
        artist.biography AS ArtistBiography,
        artist.heroURL AS ArtistBannerImage
    FROM 
        dbo.[Artist] artist
    WHERE 
        artist.artistID = @artistID;

    -- Subquery for Song Details
    SELECT 
        song.title AS SongTitle,
        song.bpm AS BeatsPerMinute,
        (CONVERT(INT, song.multitracks) + CONVERT(INT, song.customMix) +
        CONVERT(INT, song.chart) + CONVERT(INT, song.rehearsalMix) +
        CONVERT(INT, song.patches) + CONVERT(INT, song.proPresenter)) AS FeatureCount,
        album.title AS AlbumName,
        album.imageURL AS AlbumImage
    FROM 
        dbo.[Song] song
    LEFT JOIN 
        dbo.[Album] album ON song.albumID = album.albumID
    WHERE 
        song.artistID = @artistID;

    -- Subquery for Album Details
    SELECT 
        album.title AS AlbumTitle,
        album.imageURL AS AlbumImage,
        album.year AS AlbumYear,
        artist.title AS AlbumArtist
    FROM 
        dbo.[Album] album 
    JOIN 
        dbo.[Artist] artist ON album.artistID = artist.artistID
    WHERE 
        album.artistID = @artistID;
END
